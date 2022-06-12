
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
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.file_cnt_lbl = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.open_def_folder_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.select_current_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.search_result_lbx_ = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // folder_tree
            // 
            this.folder_tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folder_tree.ImageIndex = 2;
            this.folder_tree.ImageList = this.img_lst;
            this.folder_tree.Location = new System.Drawing.Point(12, 47);
            this.folder_tree.Name = "folder_tree";
            this.folder_tree.SelectedImageIndex = 0;
            this.folder_tree.Size = new System.Drawing.Size(204, 455);
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
            this.search_txb.Location = new System.Drawing.Point(222, 47);
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
            this.sel_ext_cmb.Location = new System.Drawing.Point(432, 47);
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
            this.search_result_lbx.Location = new System.Drawing.Point(22, 91);
            this.search_result_lbx.Name = "search_result_lbx";
            this.search_result_lbx.Size = new System.Drawing.Size(290, 349);
            this.search_result_lbx.TabIndex = 3;
            this.search_result_lbx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.search_result_lbx_MouseDown);
            // 
            // scan_btn
            // 
            this.scan_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.scan_btn.Location = new System.Drawing.Point(437, 479);
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
            this.progressBar1.Location = new System.Drawing.Point(222, 479);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // csm_file
            // 
            this.csm_file.Name = "csm_file";
            this.csm_file.Size = new System.Drawing.Size(61, 4);
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
            this.label1.Location = new System.Drawing.Point(362, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Files count";
            // 
            // file_cnt_lbl
            // 
            this.file_cnt_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.file_cnt_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_cnt_lbl.Location = new System.Drawing.Point(437, 442);
            this.file_cnt_lbl.Name = "file_cnt_lbl";
            this.file_cnt_lbl.Size = new System.Drawing.Size(75, 26);
            this.file_cnt_lbl.TabIndex = 7;
            this.file_cnt_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "json";
            this.sfd.Filter = "Json|*.json";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // open_def_folder_btn
            // 
            this.open_def_folder_btn.Location = new System.Drawing.Point(12, 12);
            this.open_def_folder_btn.Name = "open_def_folder_btn";
            this.open_def_folder_btn.Size = new System.Drawing.Size(75, 23);
            this.open_def_folder_btn.TabIndex = 9;
            this.open_def_folder_btn.Text = "button1";
            this.open_def_folder_btn.UseVisualStyleBackColor = true;
            this.open_def_folder_btn.Click += new System.EventHandler(this.open_def_folder_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Доступные индексы";
            // 
            // select_current_cmb
            // 
            this.select_current_cmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.select_current_cmb.FormattingEnabled = true;
            this.select_current_cmb.Location = new System.Drawing.Point(217, 11);
            this.select_current_cmb.Name = "select_current_cmb";
            this.select_current_cmb.Size = new System.Drawing.Size(295, 23);
            this.select_current_cmb.TabIndex = 11;
            this.select_current_cmb.SelectedIndexChanged += new System.EventHandler(this.select_current_cmb_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(500, 1);
            this.label3.TabIndex = 12;
            // 
            // search_result_lbx_
            // 
            this.search_result_lbx_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_result_lbx_.HideSelection = false;
            this.search_result_lbx_.Location = new System.Drawing.Point(222, 76);
            this.search_result_lbx_.Name = "search_result_lbx_";
            this.search_result_lbx_.Size = new System.Drawing.Size(290, 363);
            this.search_result_lbx_.SmallImageList = this.img_lst;
            this.search_result_lbx_.TabIndex = 13;
            this.search_result_lbx_.UseCompatibleStateImageBehavior = false;
            this.search_result_lbx_.MouseDown += new System.Windows.Forms.MouseEventHandler(this.search_result_lbx_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 510);
            this.Controls.Add(this.search_result_lbx_);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.select_current_cmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.open_def_folder_btn);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
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
        //private System.Windows.Forms.ToolStripMenuItem csmi_openfolder;
        //private System.Windows.Forms.ToolStripMenuItem csmi_openffile;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label file_cnt_lbl;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        //private System.Windows.Forms.ToolStrip toolStrip1;
        //private System.Windows.Forms.ToolStripComboBox select_current_cmb_;
        private System.Windows.Forms.ImageList img_lst;
        //private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        //private System.Windows.Forms.ToolStripMenuItem save_indx_btn;
        //private System.Windows.Forms.ToolStripMenuItem open_indx_btn;
        //private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        //private System.Windows.Forms.ToolStripMenuItem change_folder_def_btn;
        //private System.Windows.Forms.ToolStripTextBox curr_catalog_txt;
        //private System.Windows.Forms.ToolStripButton open_def_folder_btn_;
        private System.Windows.Forms.Button open_def_folder_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox select_current_cmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView search_result_lbx_;
    }
}

