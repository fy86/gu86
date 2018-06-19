namespace formTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getdirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadtxtgbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveconfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gettdxrootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadtxtgbToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadbinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datatableshowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadidxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.new100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.loadqlwqtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.testToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getdirToolStripMenuItem,
            this.selectfileToolStripMenuItem,
            this.loadtxtgbToolStripMenuItem,
            this.saveconfigToolStripMenuItem,
            this.gettdxrootToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.configToolStripMenuItem.Text = "config";
            // 
            // getdirToolStripMenuItem
            // 
            this.getdirToolStripMenuItem.Name = "getdirToolStripMenuItem";
            this.getdirToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.getdirToolStripMenuItem.Text = "select.dir";
            // 
            // selectfileToolStripMenuItem
            // 
            this.selectfileToolStripMenuItem.Name = "selectfileToolStripMenuItem";
            this.selectfileToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.selectfileToolStripMenuItem.Text = "select.file";
            // 
            // loadtxtgbToolStripMenuItem
            // 
            this.loadtxtgbToolStripMenuItem.Name = "loadtxtgbToolStripMenuItem";
            this.loadtxtgbToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.loadtxtgbToolStripMenuItem.Text = "load.txt.gb";
            // 
            // saveconfigToolStripMenuItem
            // 
            this.saveconfigToolStripMenuItem.Name = "saveconfigToolStripMenuItem";
            this.saveconfigToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveconfigToolStripMenuItem.Text = "save.config";
            this.saveconfigToolStripMenuItem.Click += new System.EventHandler(this.saveconfigToolStripMenuItem_Click);
            // 
            // gettdxrootToolStripMenuItem
            // 
            this.gettdxrootToolStripMenuItem.Name = "gettdxrootToolStripMenuItem";
            this.gettdxrootToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.gettdxrootToolStripMenuItem.Text = "get.tdx_root";
            this.gettdxrootToolStripMenuItem.Click += new System.EventHandler(this.gettdxrootToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadtxtgbToolStripMenuItem1,
            this.loadbinToolStripMenuItem,
            this.datatableshowToolStripMenuItem,
            this.loadidxToolStripMenuItem,
            this.new100ToolStripMenuItem,
            this.loadqlwqtToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.testToolStripMenuItem.Text = "test";
            // 
            // loadtxtgbToolStripMenuItem1
            // 
            this.loadtxtgbToolStripMenuItem1.Name = "loadtxtgbToolStripMenuItem1";
            this.loadtxtgbToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.loadtxtgbToolStripMenuItem1.Text = "load.txt.gb";
            this.loadtxtgbToolStripMenuItem1.Click += new System.EventHandler(this.loadtxtgbToolStripMenuItem1_Click);
            // 
            // loadbinToolStripMenuItem
            // 
            this.loadbinToolStripMenuItem.Name = "loadbinToolStripMenuItem";
            this.loadbinToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.loadbinToolStripMenuItem.Text = "load.bin";
            this.loadbinToolStripMenuItem.Click += new System.EventHandler(this.loadbinToolStripMenuItem_Click);
            // 
            // datatableshowToolStripMenuItem
            // 
            this.datatableshowToolStripMenuItem.Name = "datatableshowToolStripMenuItem";
            this.datatableshowToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.datatableshowToolStripMenuItem.Text = "datatable.show";
            this.datatableshowToolStripMenuItem.Click += new System.EventHandler(this.datatableshowToolStripMenuItem_Click);
            // 
            // loadidxToolStripMenuItem
            // 
            this.loadidxToolStripMenuItem.Name = "loadidxToolStripMenuItem";
            this.loadidxToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.loadidxToolStripMenuItem.Text = "load.idx";
            this.loadidxToolStripMenuItem.Click += new System.EventHandler(this.loadidxToolStripMenuItem_Click);
            // 
            // new100ToolStripMenuItem
            // 
            this.new100ToolStripMenuItem.Name = "new100ToolStripMenuItem";
            this.new100ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.new100ToolStripMenuItem.Text = "new100";
            this.new100ToolStripMenuItem.Click += new System.EventHandler(this.new100ToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 537);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "richText1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(770, 505);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "richText2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(770, 505);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(776, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "datagridview";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(770, 505);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(776, 511);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(776, 511);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loadqlwqtToolStripMenuItem
            // 
            this.loadqlwqtToolStripMenuItem.Name = "loadqlwqtToolStripMenuItem";
            this.loadqlwqtToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.loadqlwqtToolStripMenuItem.Text = "load.ql.wgt";
            this.loadqlwqtToolStripMenuItem.Click += new System.EventHandler(this.loadqlwqtToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "func.test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getdirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadtxtgbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadtxtgbToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ToolStripMenuItem loadbinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datatableshowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadidxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveconfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gettdxrootToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem new100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadqlwqtToolStripMenuItem;
    }
}

