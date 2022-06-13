using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Indexer
{
    public partial class MainForm : Form
    {
        IndxElements Indexes = new IndxElements();
        IndxElement selectedfile = new IndxElement();
        string Def_path { get => def_path; set { def_path = value; /*curr_catalog_txt.Text = value;*/ } }
        bool was_scanned = false;
        private string def_path;
        int indx_back = -1;

        public MainForm()
        {
            InitializeComponent();
            sel_ext_cmb.Items.Add("*");
            sel_ext_cmb.SelectedIndex = 0;
            Def_path = Application.StartupPath + "indexes";
            //listView1 listView1.
            search_result_lbx_.FullRowSelect = true;
            search_result_lbx_.View = View.SmallIcon;
            search_result_lbx_.GridLines = true;
        }

        #region workers
        #region scan
        private IndxElements DoScan(string path)
        {
            IndxElements ie = new IndxElements(path);
            DirectoryInfo di = new DirectoryInfo(path);
            //получаем количество файлов
            progressBar1.Maximum = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
            file_cnt_lbl.Text = progressBar1.Maximum.ToString();
            //создаем корневую ноду по корневому каталогу
            TreeNode tds = folder_tree.Nodes.Add(di.FullName, di.Name, "папка.png");
            tds.SelectedImageKey = tds.ImageKey;
            IndxElement root = new IndxElement(di.FullName) { Tp = IndxElement.Type.file, Prnt = null };
            ie.AllFiles.Add(root);
            //грузим файлы начального каталога
            ie.AllFiles.AddRange(LoadFiles(path, tds, root));
            //запускаем рекурсивный поиск
            ie.AllFiles.AddRange(LoadSubDirectories(path, tds, root));
            sel_ext_cmb.Items.Clear();
            sel_ext_cmb.Items.Add("*");
            //суем все найденные расширения
            sel_ext_cmb.Items.AddRange(ie.AllFiles.Select(t => t.Extension).Distinct().ToArray());
            sel_ext_cmb.SelectedIndex = 0;
            GC.Collect();
            progressBar1.CreateGraphics().DrawString("Done", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
            return ie;
        }
        /// <summary>
        /// Ищем файлы в указанном каталоге
        /// </summary>
        /// <param name="dir">каталог</param>
        /// <param name="td">предыдущая нода</param>
        /// <returns>Лист найденных элементов</returns>
        private List<IndxElement> LoadFiles(string dir, TreeNode td, IndxElement parfolder)
        {
            List<IndxElement> lie = new List<IndxElement>();
            string[] Files = Directory.GetFiles(dir, "*.*");
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                lie.Add(new IndxElement(fi.FullName) { Tp = IndxElement.Type.file, Prnt = parfolder.Id });
                var a = td.Nodes.Add(fi.FullName, fi.Name, "док.png");
                a.ToolTipText = parfolder.Name;
                a.SelectedImageKey = a.ImageKey;
                UpdateProgress();

            }
            return lie;
        }
        /// <summary>
        /// Парсим поддериктории (Рекурсивная штука)
        /// </summary>
        /// <param name="dir">каталог</param>
        /// <param name="td">предыдущая нода</param>
        /// <returns>Лист найденных элементов</returns>
        private List<IndxElement> LoadSubDirectories(string dir, TreeNode td, IndxElement parfolder)
        {
            List<IndxElement> ie = new List<IndxElement>();
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.FullName, di.Name, "папка.png");
                IndxElement newparent = new IndxElement() { FullPath = di.FullName, Tp = IndxElement.Type.folder, Prnt = parfolder.Id };
                ie.Add(newparent);

                tds.ToolTipText = newparent.Name;
                tds.SelectedImageKey = tds.ImageKey;
                ie.AddRange(LoadFiles(subdirectory, tds, newparent));
                ie.AddRange(LoadSubDirectories(subdirectory, tds, newparent));
                UpdateProgress();
            }
            return ie;
        }
        #endregion
        #region load
        /// <summary>
        /// Загрузка сохраненнки
        /// </summary>
        private void DoLoad(string path_to_load)
        {
            Indexes = IndxElements.LoadInexes(path_to_load);
            if (Indexes == null)
            {
                Indexes = new IndxElements();
                return;
            }
            //создаем корневую ноду
            folder_tree.Nodes.Clear();
            var nd = folder_tree.Nodes.Add(Indexes.RootFolderPath, new FileInfo(Indexes.RootFolderPath).Name, "папка.png");
            nd.SelectedImageKey = nd.ImageKey;
            progressBar1.Maximum = Indexes.AllFiles.Count;
            file_cnt_lbl.Text = progressBar1.Maximum.ToString();
            sel_ext_cmb.Items.Clear();
            sel_ext_cmb.Items.Add("*");
            //фильтр расширений
            sel_ext_cmb.Items.AddRange(Indexes.AllFiles.Select(t => t.Extension).Distinct().ToArray());
            sel_ext_cmb.SelectedIndex = 0;
            //задаем первую ноду корневой

            //var a = Indexes.AllFiles.Where(t => t.Prnt != null).ToList();
            //var b = Indexes.AllFiles.Where(t => t.Prnt == null).ToList();
            buildparent(nd, Indexes.AllFiles.Where(t => t.Prnt != null), Indexes.AllFiles.Where(t => t.Prnt == null).First());
            GC.Collect();
            progressBar1.CreateGraphics().DrawString("Done", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
            nd.Expand();

        }
        private void buildparent(TreeNode parent_node, IEnumerable<IndxElement> child, IndxElement parent)
        {
            var k = child.Where(t => t.Prnt == parent.Id);
            
            foreach (var item in k)
            {
                
                if (folder_tree.Nodes.Find(item.FullPath, true).Length == 0)
                    switch (item.Tp)
                    {
                        case IndxElement.Type.folder:
                            TreeNode tn = parent_node.Nodes.Add(item.FullPath, item.Name, "папка.png");
                            tn.ToolTipText = parent_node.Text;
                            tn.SelectedImageKey = tn.ImageKey;
                            buildparent(tn, child, item);
                            break;
                        case IndxElement.Type.file:
                            parent_node.Nodes.Add(item.FullPath, item.Name, "док.png").ToolTipText = parent_node.Text;
                            break;
                    }
                UpdateProgress();
            }
        }
        #endregion
        private void UpdateProgress()
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                //рисуем процентик
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                Application.DoEvents();
            }
        }
        #endregion

        #region events
        private void scan_btn_Click(object sender, EventArgs e)
        {
            if (Indexes.AllFiles.Count > 0)
            {
                if (!Saves())
                    return;
                //if(was_scanned)
                //{
                //    if (MessageBox.Show("Remove saved elements?\nCurrent indexes will be saved", "New Indexer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                //        return;

                //}
                //else
                //{
                //    if (MessageBox.Show("Close current elements?", "New Indexer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                //        return;
                //}
            }



            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show($"Do index of\n\n{fbd.SelectedPath}", "New Indexer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    folder_tree.Nodes.Clear();
                    Indexes = DoScan(fbd.SelectedPath);
                    was_scanned = true;
                    folder_tree.Nodes[0].Expand();
                    select_current_cmb.Items.Add(new FileInfo(fbd.SelectedPath).Name);
                    select_current_cmb.SelectedIndexChanged -= select_current_cmb_SelectedIndexChanged;
                    select_current_cmb.SelectedIndex = select_current_cmb.Items.Count - 1;
                    select_current_cmb.SelectedIndexChanged += select_current_cmb_SelectedIndexChanged;
                }
                else
                    return;
            }
        }
        private void select_current_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Saves())
            {
                select_current_cmb.SelectedIndexChanged -= select_current_cmb_SelectedIndexChanged;
                select_current_cmb.SelectedIndex = indx_back;
                select_current_cmb.SelectedIndexChanged += select_current_cmb_SelectedIndexChanged;
                return;
            }
            indx_back = select_current_cmb.SelectedIndex;
            if (File.Exists(def_path + "\\" + select_current_cmb.SelectedItem.ToString()))
            {
                DoLoad(def_path + "\\" + select_current_cmb.SelectedItem.ToString());
                Properties.Settings.Default.Last_load = def_path + "\\" + select_current_cmb.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
            else
            {
                select_current_cmb.Items.Remove(select_current_cmb.SelectedItem);
                select_current_cmb.SelectedIndex = 0;
            }
        }

        private void sel_ext_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            search_txb_TextChanged(search_txb, null);
        }
        private void search_txb_TextChanged(object sender, EventArgs e)
        {
            var txb = (sender as TextBox).Text;
            if (txb.Length > 2)
            {
                search_result_lbx_.Items.Clear();
                if (sel_ext_cmb.SelectedItem.ToString() != "*")
                {
                    var b = Indexes.AllFiles.Where(t => t.Name.Contains(txb, StringComparison.OrdinalIgnoreCase) && t.Extension == sel_ext_cmb.SelectedItem.ToString());
                    foreach (var item in b)
                    {
                        search_result_lbx_.Items.Add(item.FullPath, item.Name, item.Tp == IndxElement.Type.file ? "док.png" : "папка.png").Tag = item;
                    }
                }

                else
                {
                    var b = Indexes.AllFiles.Where(t => t.Name.Contains(txb, StringComparison.OrdinalIgnoreCase));
                    foreach (var item in b)
                    {
                        search_result_lbx_.Items.Add(item.FullPath, item.Name, item.Tp == IndxElement.Type.file ? "док.png" : "папка.png").Tag = item;
                    }
                }
            }
        }
        /// <summary>
        /// Подменю открыть папку
        /// </summary>
        private void csmi_openfolder_Click(object sender, EventArgs e)
        {
            selectedfile.OpenFolder();
        }
        /// <summary>
        /// Подменю открыть файл
        /// </summary>
        private void csmi_openffile_Click(object sender, EventArgs e)
        {
            selectedfile.OpenFile();
        }
        private void open_def_folder_btn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"{def_path}");
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saves())
                e.Cancel = true;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!Directory.Exists(Def_path))
            {
                Directory.CreateDirectory(Def_path);
                return;
            }
            var fls = Directory.GetFiles(Def_path);
            if (fls.Length > 0)
            {
                foreach (var item in fls)
                {
                    //FileInfo di = new FileInfo(item);
                    if (new FileInfo(item).Extension == ".json")
                        select_current_cmb.Items.Add(new FileInfo(item).Name);
                }
                //Properties.Settings.Default.Last_load = select_current_cmb.SelectedItem.ToString();
                //Properties.Settings.Default.Save();
            }
            var a = Properties.Settings.Default.Last_load;
            if (!string.IsNullOrEmpty(a))
            {
                if (File.Exists(a))
                {
                    select_current_cmb.SelectedItem = a;
                    DoLoad(def_path + "\\" + a);
                }
                else
                {
                    if (select_current_cmb.Items.Count > 0)
                        select_current_cmb.SelectedIndex = 0;
                    else
                        return;
                    DoLoad(def_path + "\\" + select_current_cmb.SelectedItem.ToString());
                }

            }
            else
            {
                if (select_current_cmb.Items.Count > 0)
                    select_current_cmb.SelectedIndex = 0;
                else
                    return;
                DoLoad(def_path + "\\" + select_current_cmb.SelectedItem.ToString());
            }

        }




        private void search_result_lbx_MouseDown(object sender, MouseEventArgs e)
        {
            var info = search_result_lbx_.HitTest(e.X, e.Y);
            selectedfile = (IndxElement)info.Item.Tag;
            if (e.Button == MouseButtons.Left)
            {
                folder_tree.CollapseAll();
                var b = folder_tree.Nodes.Find(selectedfile.FullPath, true);
                folder_tree.SelectedNode = b.First();
                folder_tree.Select();
                folder_tree.Focus();
            }
            else if (e.Button == MouseButtons.Right)
            {

                if (selectedfile.Tp == IndxElement.Type.folder)
                    csmi_openffile.Enabled = false;
                else
                    csmi_openffile.Enabled = true;
                csm_file.Show(Cursor.Position);
                csm_file.Visible = true;
            }
        }

        private void folder_tree_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                TreeNode theNode = folder_tree.GetNodeAt(e.X, e.Y);
                var b = Indexes.AllFiles.Where(t => t.FullPath == theNode.Name);
                if (b.Count() > 0)
                {
                    selectedfile = b.First();
                    if (selectedfile.Tp == IndxElement.Type.folder)
                        csmi_openffile.Enabled = false;
                    else
                        csmi_openffile.Enabled = true;
                    csm_file.Show(Cursor.Position);
                    csm_file.Visible = true;
                }
                else
                {
                    csm_file.Visible = false;
                }
            }
        }
        private void folder_tree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            var b = Indexes.AllFiles.Where(t => t.FullPath == e.Node.Name).FirstOrDefault();
            if (b == null)
                return;
            if (b.Tp == IndxElement.Type.folder)
            {
                e.Node.ImageKey = "опен.png";
                e.Node.SelectedImageKey = e.Node.ImageKey;
            }
            else
                e.Node.ImageKey = e.Node.ImageKey;

        }
        private void folder_tree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            var b = Indexes.AllFiles.Where(t => t.FullPath == e.Node.Name).FirstOrDefault();
            if (b == null)
                if (b.Tp == IndxElement.Type.folder)
                {
                    e.Node.ImageKey = "папка.png";
                    e.Node.SelectedImageKey = e.Node.ImageKey;
                }
                else
                    e.Node.ImageKey = e.Node.ImageKey;

        }
        #endregion

        private bool Saves()
        {
            if (was_scanned)
            {
                var res = MessageBox.Show("File not saved! Save file?", "Not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string to_save = new DirectoryInfo(Indexes.RootFolderPath).Name + DateTime.Now.ToString("ddMMy_HHmm") + ".json";
                    IndxElements.SaveIndexes(Indexes, def_path + "\\" + to_save);
                    return true;
                }
                else if (res == DialogResult.Cancel)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }

        //public static void SaveTree(TreeView tree, string filename)
        //{
        //    using (Stream file = File.Open(filename, FileMode.Create))
        //    {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        bf.Serialize(file, tree.Nodes.Cast<TreeNode>().ToList());
        //    }
        //}

        //public static void LoadTree(TreeView tree, string filename)
        //{
        //    using (Stream file = File.Open(filename, FileMode.Open))
        //    {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        object obj = bf.Deserialize(file);

        //        TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
        //        tree.Nodes.AddRange(nodeList);
        //    }
        //}
    }
}
