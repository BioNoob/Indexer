
namespace Indexer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folder_tree = new System.Windows.Forms.TreeView();
            this.img_lst = new System.Windows.Forms.ImageList(this.components);
            this.search_txb = new System.Windows.Forms.TextBox();
            this.sel_ext_cmb = new System.Windows.Forms.ComboBox();
            this.search_result_lbx = new System.Windows.Forms.ListBox();
            this.scan_btn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.csm_file = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.csmi_openfolder = new System.Windows.Forms.ToolStripMenuItem();
            this.csmi_openffile = new System.Windows.Forms.ToolStripMenuItem();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.file_cnt_lbl = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.save_indx_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.open_indx_btn = new System.Windows.Forms.ToolStripMenuItem();
            this.select_current_cmb = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.csm_file.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folder_tree
            // 
            this.folder_tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folder_tree.ImageIndex = 2;
            this.folder_tree.ImageList = this.img_lst;
            this.folder_tree.Location = new System.Drawing.Point(12, 28);
            this.folder_tree.Name = "folder_tree";
            this.folder_tree.SelectedImageIndex = 0;
            this.folder_tree.Size = new System.Drawing.Size(204, 286);
            this.folder_tree.TabIndex = 0;
            this.folder_tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.folder_tree_MouseDown);
            // 
            // img_lst
            // 
            this.img_lst.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.img_lst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_lst.ImageStream")));
            this.img_lst.TransparentColor = System.Drawing.Color.Transparent;
            this.img_lst.Images.SetKeyName(0, "док.png");
            this.img_lst.Images.SetKeyName(1, "меню.png");
            this.img_lst.Images.SetKeyName(2, "папка.png");
            this.img_lst.Images.SetKeyName(3, "опен.png");
            this.img_lst.Images.SetKeyName(4, "сейв.png");
            // 
            // search_txb
            // 
            this.search_txb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_txb.Location = new System.Drawing.Point(222, 28);
            this.search_txb.Name = "search_txb";
            this.search_txb.Size = new System.Drawing.Size(204, 23);
            this.search_txb.TabIndex = 1;
            this.search_txb.TextChanged += new System.EventHandler(this.search_txb_TextChanged);
            // 
            // sel_ext_cmb
            // 
            this.sel_ext_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sel_ext_cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sel_ext_cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sel_ext_cmb.FormattingEnabled = true;
            this.sel_ext_cmb.Location = new System.Drawing.Point(432, 28);
            this.sel_ext_cmb.Name = "sel_ext_cmb";
            this.sel_ext_cmb.Size = new System.Drawing.Size(80, 23);
            this.sel_ext_cmb.TabIndex = 2;
            this.sel_ext_cmb.SelectedIndexChanged += new System.EventHandler(this.sel_ext_cmb_SelectedIndexChanged);
            // 
            // search_result_lbx
            // 
            this.search_result_lbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_result_lbx.FormattingEnabled = true;
            this.search_result_lbx.ItemHeight = 15;
            this.search_result_lbx.Location = new System.Drawing.Point(222, 57);
            this.search_result_lbx.Name = "search_result_lbx";
            this.search_result_lbx.Size = new System.Drawing.Size(290, 184);
            this.search_result_lbx.TabIndex = 3;
            this.search_result_lbx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.search_result_lbx_MouseDown);
            // 
            // scan_btn
            // 
            this.scan_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scan_btn.Location = new System.Drawing.Point(437, 291);
            this.scan_btn.Name = "scan_btn";
            this.scan_btn.Size = new System.Drawing.Size(75, 23);
            this.scan_btn.TabIndex = 4;
            this.scan_btn.Text = "Scan";
            this.scan_btn.UseVisualStyleBackColor = true;
            this.scan_btn.Click += new System.EventHandler(this.scan_btn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(222, 291);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // csm_file
            // 
            this.csm_file.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.csmi_openfolder,
            this.csmi_openffile});
            this.csm_file.Name = "csm_file";
            this.csm_file.Size = new System.Drawing.Size(157, 48);
            // 
            // csmi_openfolder
            // 
            this.csmi_openfolder.Name = "csmi_openfolder";
            this.csmi_openfolder.Size = new System.Drawing.Size(156, 22);
            this.csmi_openfolder.Text = "Открыть папку";
            this.csmi_openfolder.Click += new System.EventHandler(this.csmi_openfolder_Click);
            // 
            // csmi_openffile
            // 
            this.csmi_openffile.Name = "csmi_openffile";
            this.csmi_openffile.Size = new System.Drawing.Size(156, 22);
            this.csmi_openffile.Text = "Открыть файл";
            this.csmi_openffile.Click += new System.EventHandler(this.csmi_openffile_Click);
            // 
            // fbd
            // 
            this.fbd.RootFolder = System.Environment.SpecialFolder.Recent;
            this.fbd.ShowNewFolderButton = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Files count";
            // 
            // file_cnt_lbl
            // 
            this.file_cnt_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.file_cnt_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_cnt_lbl.Location = new System.Drawing.Point(437, 254);
            this.file_cnt_lbl.Name = "file_cnt_lbl";
            this.file_cnt_lbl.Size = new System.Drawing.Size(75, 26);
            this.file_cnt_lbl.TabIndex = 7;
            this.file_cnt_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.select_current_cmb,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(529, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save_indx_btn,
            this.open_indx_btn});
            this.toolStripDropDownButton1.Image = global::Indexer.Properties.Resources.меню;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // save_indx_btn
            // 
            this.save_indx_btn.Image = global::Indexer.Properties.Resources.сейв;
            this.save_indx_btn.Name = "save_indx_btn";
            this.save_indx_btn.Size = new System.Drawing.Size(174, 22);
            this.save_indx_btn.Text = "Сохранить индекс";
            this.save_indx_btn.Click += new System.EventHandler(this.save_indx_btn_Click);
            // 
            // open_indx_btn
            // 
            this.open_indx_btn.Image = global::Indexer.Properties.Resources.опен;
            this.open_indx_btn.Name = "open_indx_btn";
            this.open_indx_btn.Size = new System.Drawing.Size(174, 22);
            this.open_indx_btn.Text = "Открыть индекс";
            this.open_indx_btn.Click += new System.EventHandler(this.open_indx_btn_Click);
            // 
            // select_current_cmb
            // 
            this.select_current_cmb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.select_current_cmb.AutoSize = false;
            this.select_current_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_current_cmb.Name = "select_current_cmb";
            this.select_current_cmb.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.select_current_cmb.Padding = new System.Windows.Forms.Padding(0, 0, 35, 0);
            this.select_current_cmb.Size = new System.Drawing.Size(175, 23);
            this.select_current_cmb.SelectedIndexChanged += new System.EventHandler(this.select_current_cmb_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel1.Size = new System.Drawing.Size(118, 22);
            this.toolStripLabel1.Text = "Доступные индексы";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 322);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.file_cnt_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.scan_btn);
            this.Controls.Add(this.search_result_lbx);
            this.Controls.Add(this.sel_ext_cmb);
            this.Controls.Add(this.search_txb);
            this.Controls.Add(this.folder_tree);
            this.MinimumSize = new System.Drawing.Size(545, 361);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.csm_file.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView folder_tree;
        private System.Windows.Forms.TextBox search_txb;
        private System.Windows.Forms.ComboBox sel_ext_cmb;
        private System.Windows.Forms.ListBox search_result_lbx;
        private System.Windows.Forms.Button scan_btn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip csm_file;
        private System.Windows.Forms.ToolStripMenuItem csmi_openfolder;
        private System.Windows.Forms.ToolStripMenuItem csmi_openffile;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label file_cnt_lbl;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox select_current_cmb;
        private System.Windows.Forms.ImageList img_lst;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem save_indx_btn;
        private System.Windows.Forms.ToolStripMenuItem open_indx_btn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

