using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indexer
{
    public partial class MainForm : Form
    {
        IndxElements Indexes = new IndxElements();
        IndxElement selectedfile = new IndxElement();
        public MainForm()
        {
            InitializeComponent();
            sel_ext_cmb.Items.Add("*");
            sel_ext_cmb.SelectedIndex = 0;
        }
        /// <summary>
        /// Загрузка сохраненнки
        /// </summary>
        private void DoLoad()
        {
            Indexes = IndxElements.LoadInexes();
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
            TreeNode lastNode = nd;
            string subPathAgg;
            foreach (var item in Indexes.AllFiles)
            {
                //берем путь без рут каталога
                string path = item.FullPath.Replace(Indexes.RootFolderPath + "\\", "");
                subPathAgg = Indexes.RootFolderPath + '\\';
                foreach (string subPath in path.Split('\\'))
                {
                    //гуляем по всем элементам путя к файлу
                    subPathAgg += subPath;// + '\\';
                    TreeNode[] nodes = folder_tree.Nodes.Find(subPathAgg, true);
                    //если не нашли в дереве
                    if (nodes.Length == 0)
                        //добавляем в уровень
                        lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        //если нашли в дереве, то двигаем уровень дерева
                        lastNode = nodes[0];
                    //докидываем слэши для корреляции с алгоритмом скана
                    if (subPathAgg != item.FullPath)
                        subPathAgg += '\\';
                    else
                        lastNode.ImageKey = "док.png";
                }
                lastNode = nd; //дефолтная нода для следующей итерации все равно корневая
                UpdateProgress();
            }
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
            //грузим файлы начального каталога
            ie.AllFiles.AddRange(LoadFiles(path, tds));
            //запускаем рекурсивный поиск
            ie.AllFiles.AddRange(LoadSubDirectories(path, tds));
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
        private List<IndxElement> LoadFiles(string dir, TreeNode td)
        {
            List<IndxElement> lie = new List<IndxElement>();
            string[] Files = Directory.GetFiles(dir, "*.*");
            foreach (string file in Files)
            {
                FileInfo fi = new FileInfo(file);
                td.Nodes.Add(fi.FullName, fi.Name).ImageKey = "док.png";

                UpdateProgress();
                lie.Add(new IndxElement(fi.FullName));
            }
            return lie;
        }
        /// <summary>
        /// Парсим поддериктории (Рекурсивная штука)
        /// </summary>
        /// <param name="dir">каталог</param>
        /// <param name="td">предыдущая нода</param>
        /// <returns>Лист найденных элементов</returns>
        private List<IndxElement> LoadSubDirectories(string dir, TreeNode td)
        {
            List<IndxElement> ie = new List<IndxElement>();
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode tds = td.Nodes.Add(di.FullName, di.Name);
                tds.ImageKey = "папка.png";
                ie.AddRange(LoadFiles(subdirectory, tds));
                ie.AddRange(LoadSubDirectories(subdirectory, tds));
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IndxElements.SaveIndexes(Indexes);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DoLoad();

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

        private void select_current_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void save_indx_btn_Click(object sender, EventArgs e)
        {

        }

        private void open_indx_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
