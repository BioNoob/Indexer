using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            search_result_lbx_.Items.Add(new ListViewItem("stas", "док.png"));
        }

        private void buildparent(TreeNode parent_node, IEnumerable<IndxElement> child, IndxElement parent)
        {
            var k = child.Where(t => t.Prnt == parent);
            foreach (var item in k)
            {
                if (folder_tree.Nodes.Find(item.FullPath, true).Length == 0)
                    switch (item.Tp)
                    {
                        case IndxElement.Type.folder:
                            TreeNode tn = parent_node.Nodes.Add(item.FullPath, item.Name, "папка.png");
                            buildparent(tn, child, item);
                            break;
                        case IndxElement.Type.file:
                            parent_node.Nodes.Add(item.FullPath, item.Name, "док.png");
                            break;
                    }
                UpdateProgress();
            }
        }

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
            var nd = folder_tree.Nodes.Add(Indexes.RootFolderPath, new FileInfo(Indexes.RootFolderPath).Name);
            nd.ImageKey = "папка.png";
            progressBar1.Maximum = Indexes.AllFiles.Count;
            file_cnt_lbl.Text = progressBar1.Maximum.ToString();
            sel_ext_cmb.Items.Clear();
            sel_ext_cmb.Items.Add("*");
            //фильтр расширений
            sel_ext_cmb.Items.AddRange(Indexes.AllFiles.Select(t => t.Extension).Distinct().ToArray());
            sel_ext_cmb.SelectedIndex = 0;
            //задаем первую ноду корневой

            var a = Indexes.AllFiles.Where(t => t.Prnt != null).ToList();
            var b = Indexes.AllFiles.Where(t => t.Prnt == null).ToList();
            buildparent(nd, Indexes.AllFiles.Where(t => t.Prnt != null), Indexes.AllFiles.Where(t => t.Prnt == null).First());



            //TreeNode lastNode = nd;
            //string subPathAgg;

            //foreach (var item in Indexes.AllFiles)
            //{
            //    //берем путь без рут каталога
            //    string path = item.FullPath.Replace(Indexes.RootFolderPath + "\\", "");
            //    subPathAgg = Indexes.RootFolderPath + '\\';
            //    foreach (string subPath in path.Split('\\'))
            //    {
            //        //гуляем по всем элементам путя к файлу
            //        subPathAgg += subPath;// + '\\';
            //        TreeNode[] nodes = folder_tree.Nodes.Find(subPathAgg, true);
            //        //если не нашли в дереве
            //        if (nodes.Length == 0)
            //            //добавляем в уровень
            //            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
            //        else
            //            //если нашли в дереве, то двигаем уровень дерева
            //            lastNode = nodes[0];
            //        //докидываем слэши для корреляции с алгоритмом скана
            //        if (subPathAgg != item.FullPath)
            //            subPathAgg += '\\';
            //        else
            //            lastNode.ImageKey = "док.png";
            //    }
            //    lastNode = nd; //дефолтная нода для следующей итерации все равно корневая
            //    UpdateProgress();
            //}
            GC.Collect();
            progressBar1.CreateGraphics().DrawString("Done", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
            nd.Expand();

        }
        private IndxElements DoScan(string path)
        {
            IndxElements ie = new IndxElements(path);
            DirectoryInfo di = new DirectoryInfo(path);
            //получаем количество файлов
            progressBar1.Maximum = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
            file_cnt_lbl.Text = progressBar1.Maximum.ToString();
            //создаем корневую ноду по корневому каталогу
            TreeNode tds = folder_tree.Nodes.Add(di.FullName, di.Name);

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
                td.Nodes.Add(fi.FullName, fi.Name).ImageKey = "док.png";
                lie.Add(new IndxElement(fi.FullName) { Tp = IndxElement.Type.file, Prnt = parfolder });
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
                TreeNode tds = td.Nodes.Add(di.FullName, di.Name);
                IndxElement newparent = new IndxElement() { FullPath = di.FullName, Tp = IndxElement.Type.folder, Prnt = parfolder };
                ie.Add(newparent);

                tds.ImageKey = "папка.png";
                ie.AddRange(LoadFiles(subdirectory, tds, newparent));
                ie.AddRange(LoadSubDirectories(subdirectory, tds, newparent));
                UpdateProgress();
            }
            return ie;
        }
        private void scan_btn_Click(object sender, EventArgs e)
        {
            if (Indexes.AllFiles.Count > 0)
                if (MessageBox.Show("Remove saved elements?", "New Indexer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show($"Do index of\n\t{fbd.SelectedPath}", "New Indexer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    folder_tree.Nodes.Clear();
                    Indexes = DoScan(fbd.SelectedPath);
                    was_scanned = true;
                    folder_tree.Nodes[0].Expand();
                }
                else
                    return;
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
                search_result_lbx.Items.Clear();
                if (sel_ext_cmb.SelectedItem.ToString() != "*")
                    search_result_lbx.Items.AddRange(Indexes.AllFiles.Where(t => t.Name.Contains(txb, StringComparison.OrdinalIgnoreCase) && t.Extension == sel_ext_cmb.SelectedItem.ToString()).ToArray());
                else
                    search_result_lbx.Items.AddRange(Indexes.AllFiles.Where(t => t.Name.Contains(txb, StringComparison.OrdinalIgnoreCase)).ToArray());
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

        private void search_result_lbx_MouseDown(object sender, MouseEventArgs e)
        {
            var index = search_result_lbx.IndexFromPoint(e.Location);

            var info = search_result_lbx_.HitTest(e.X, e.Y);
            //var col = info.Item.SubItems.IndexOf(info.SubItem);
            selectedfile = (IndxElement)info.Item.Tag;

            if (index == -1)
                return;
            selectedfile = (IndxElement)search_result_lbx.Items[index];
            if (e.Button == MouseButtons.Left)
            {
                folder_tree.CollapseAll();
                var b = folder_tree.Nodes.Find(selectedfile.FullPath, true);
                folder_tree.SelectedNode = b.First();
                folder_tree.Select();
            }
            else if (e.Button == MouseButtons.Right)
            {

                if (index != ListBox.NoMatches)
                {
                    csm_file.Show(Cursor.Position);
                    csm_file.Visible = true;
                }
                else
                {
                    csm_file.Visible = false;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saves())
                e.Cancel = true;
        }

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

        private void folder_tree_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                TreeNode theNode = folder_tree.GetNodeAt(e.X, e.Y);
                var b = Indexes.AllFiles.Where(t => t.FullPath == theNode.Name);
                if (b.Count() > 0)
                {
                    selectedfile = b.First();
                    csm_file.Show(Cursor.Position);
                    csm_file.Visible = true;
                }
                else
                {
                    csm_file.Visible = false;
                }
            }
        }
        int indx_back = -1;
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

            }
            else
            {
                select_current_cmb.Items.Remove(select_current_cmb.SelectedItem);
                select_current_cmb.SelectedIndex = 0;
            }
        }

        //private void save_indx_btn_Click(object sender, EventArgs e)
        //{

        //}

        //private void open_indx_btn_Click(object sender, EventArgs e)
        //{

        //}

        //private void change_folder_def_btn_Click(object sender, EventArgs e)
        //{

        //}

        private void open_def_folder_btn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"{def_path}");
        }
    }
}
