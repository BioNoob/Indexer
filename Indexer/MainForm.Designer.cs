
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
            this.folder_tree = new System.Windows.Forms.TreeView();
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
            this.csm_file.SuspendLayout();
            this.SuspendLayout();
            // 
            // folder_tree
            // 
            this.folder_tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folder_tree.Location = new System.Drawing.Point(12, 12);
            this.folder_tree.Name = "folder_tree";
            this.folder_tree.Size = new System.Drawing.Size(204, 302);
            this.folder_tree.TabIndex = 0;
            this.folder_tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.folder_tree_MouseDown);
            // 
            // search_txb
            // 
            this.search_txb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_txb.Location = new System.Drawing.Point(222, 12);
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
            this.sel_ext_cmb.Location = new System.Drawing.Point(432, 12);
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
            this.search_result_lbx.Location = new System.Drawing.Point(222, 41);
            this.search_result_lbx.Name = "search_result_lbx";
            this.search_result_lbx.Size = new System.Drawing.Size(290, 199);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 322);
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
    }
}

