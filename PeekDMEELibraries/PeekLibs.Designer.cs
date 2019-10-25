namespace PeekDMEELibs
{
    partial class DMEEPeekLibs
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectedLibraryTextBox = new System.Windows.Forms.TextBox();
            this.LoadLibraryButton = new System.Windows.Forms.Button();
            this.ModuleDataTextBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.FindModuleTextBox = new System.Windows.Forms.TextBox();
            this.FindPartButton = new System.Windows.Forms.Button();
            this.FindPartLabel = new System.Windows.Forms.Label();
            this.SelectedModuleTextBox = new System.Windows.Forms.TextBox();
            this.ModulesListBox = new System.Windows.Forms.ListBox();
            this.ExtractToFileButton = new System.Windows.Forms.Button();
            this.SetLibraryTextBox = new System.Windows.Forms.TextBox();
            this.SetLibraryButton = new System.Windows.Forms.Button();
            this.FindInFileRadioButton = new System.Windows.Forms.RadioButton();
            this.FindInFolderRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LibraryFilesListBox = new System.Windows.Forms.ListBox();
            this.SelectedLibraryLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // SelectedLibraryTextBox
            // 
            this.SelectedLibraryTextBox.Location = new System.Drawing.Point(294, 4);
            this.SelectedLibraryTextBox.Name = "SelectedLibraryTextBox";
            this.SelectedLibraryTextBox.Size = new System.Drawing.Size(382, 20);
            this.SelectedLibraryTextBox.TabIndex = 1;
            // 
            // LoadLibraryButton
            // 
            this.LoadLibraryButton.Location = new System.Drawing.Point(681, 3);
            this.LoadLibraryButton.Name = "LoadLibraryButton";
            this.LoadLibraryButton.Size = new System.Drawing.Size(129, 21);
            this.LoadLibraryButton.TabIndex = 2;
            this.LoadLibraryButton.Text = "choose library";
            this.LoadLibraryButton.UseVisualStyleBackColor = true;
            this.LoadLibraryButton.Click += new System.EventHandler(this.LoadLibraryButton_Click);
            // 
            // ModuleDataTextBox
            // 
            this.ModuleDataTextBox.BackColor = System.Drawing.Color.White;
            this.ModuleDataTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleDataTextBox.Location = new System.Drawing.Point(375, 101);
            this.ModuleDataTextBox.Multiline = true;
            this.ModuleDataTextBox.Name = "ModuleDataTextBox";
            this.ModuleDataTextBox.ReadOnly = true;
            this.ModuleDataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ModuleDataTextBox.Size = new System.Drawing.Size(389, 319);
            this.ModuleDataTextBox.TabIndex = 3;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.Filter = "All Files (*.*)|*.*";
            // 
            // FindModuleTextBox
            // 
            this.FindModuleTextBox.BackColor = System.Drawing.Color.White;
            this.FindModuleTextBox.Location = new System.Drawing.Point(294, 59);
            this.FindModuleTextBox.Name = "FindModuleTextBox";
            this.FindModuleTextBox.Size = new System.Drawing.Size(382, 20);
            this.FindModuleTextBox.TabIndex = 1;
            // 
            // FindPartButton
            // 
            this.FindPartButton.Location = new System.Drawing.Point(681, 59);
            this.FindPartButton.Name = "FindPartButton";
            this.FindPartButton.Size = new System.Drawing.Size(129, 21);
            this.FindPartButton.TabIndex = 2;
            this.FindPartButton.Text = "find module / part";
            this.FindPartButton.UseVisualStyleBackColor = true;
            this.FindPartButton.Click += new System.EventHandler(this.FindModuleButton_Click);
            // 
            // FindPartLabel
            // 
            this.FindPartLabel.AutoSize = true;
            this.FindPartLabel.Location = new System.Drawing.Point(246, 62);
            this.FindPartLabel.Name = "FindPartLabel";
            this.FindPartLabel.Size = new System.Drawing.Size(42, 13);
            this.FindPartLabel.TabIndex = 6;
            this.FindPartLabel.Text = "search:";
            this.FindPartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SelectedModuleTextBox
            // 
            this.SelectedModuleTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedModuleTextBox.Location = new System.Drawing.Point(241, 427);
            this.SelectedModuleTextBox.Name = "SelectedModuleTextBox";
            this.SelectedModuleTextBox.Size = new System.Drawing.Size(128, 23);
            this.SelectedModuleTextBox.TabIndex = 1;
            // 
            // ModulesListBox
            // 
            this.ModulesListBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModulesListBox.FormattingEnabled = true;
            this.ModulesListBox.ItemHeight = 15;
            this.ModulesListBox.Location = new System.Drawing.Point(241, 101);
            this.ModulesListBox.Name = "ModulesListBox";
            this.ModulesListBox.ScrollAlwaysVisible = true;
            this.ModulesListBox.Size = new System.Drawing.Size(128, 319);
            this.ModulesListBox.TabIndex = 4;
            this.ModulesListBox.SelectedIndexChanged += new System.EventHandler(this.ModulesListBox_SelectedIndexChanged);
            // 
            // ExtractToFileButton
            // 
            this.ExtractToFileButton.Location = new System.Drawing.Point(375, 428);
            this.ExtractToFileButton.Name = "ExtractToFileButton";
            this.ExtractToFileButton.Size = new System.Drawing.Size(129, 23);
            this.ExtractToFileButton.TabIndex = 5;
            this.ExtractToFileButton.Text = "extract module to file";
            this.ExtractToFileButton.UseVisualStyleBackColor = true;
            this.ExtractToFileButton.Click += new System.EventHandler(this.ExtractToFileButton_Click);
            // 
            // SetLibraryTextBox
            // 
            this.SetLibraryTextBox.BackColor = System.Drawing.Color.White;
            this.SetLibraryTextBox.Location = new System.Drawing.Point(294, 32);
            this.SetLibraryTextBox.Name = "SetLibraryTextBox";
            this.SetLibraryTextBox.ReadOnly = true;
            this.SetLibraryTextBox.Size = new System.Drawing.Size(382, 20);
            this.SetLibraryTextBox.TabIndex = 7;
            // 
            // SetLibraryButton
            // 
            this.SetLibraryButton.Location = new System.Drawing.Point(681, 32);
            this.SetLibraryButton.Name = "SetLibraryButton";
            this.SetLibraryButton.Size = new System.Drawing.Size(129, 21);
            this.SetLibraryButton.TabIndex = 8;
            this.SetLibraryButton.Text = "change  library folder";
            this.SetLibraryButton.UseVisualStyleBackColor = true;
            this.SetLibraryButton.Click += new System.EventHandler(this.SetLibraryFolderButton_Click);
            // 
            // FindInFileRadioButton
            // 
            this.FindInFileRadioButton.AutoSize = true;
            this.FindInFileRadioButton.Checked = true;
            this.FindInFileRadioButton.Location = new System.Drawing.Point(10, 3);
            this.FindInFileRadioButton.Name = "FindInFileRadioButton";
            this.FindInFileRadioButton.Size = new System.Drawing.Size(69, 17);
            this.FindInFileRadioButton.TabIndex = 9;
            this.FindInFileRadioButton.TabStop = true;
            this.FindInFileRadioButton.Text = "find in file";
            this.FindInFileRadioButton.UseVisualStyleBackColor = true;
            // 
            // FindInFolderRadioButton
            // 
            this.FindInFolderRadioButton.AutoSize = true;
            this.FindInFolderRadioButton.Location = new System.Drawing.Point(10, 26);
            this.FindInFolderRadioButton.Name = "FindInFolderRadioButton";
            this.FindInFolderRadioButton.Size = new System.Drawing.Size(82, 17);
            this.FindInFolderRadioButton.TabIndex = 10;
            this.FindInFolderRadioButton.TabStop = true;
            this.FindInFolderRadioButton.Text = "find in folder";
            this.FindInFolderRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FindInFolderRadioButton);
            this.panel1.Controls.Add(this.FindInFileRadioButton);
            this.panel1.Location = new System.Drawing.Point(770, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(96, 49);
            this.panel1.TabIndex = 12;
            // 
            // LibraryFilesListBox
            // 
            this.LibraryFilesListBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LibraryFilesListBox.FormattingEnabled = true;
            this.LibraryFilesListBox.ItemHeight = 15;
            this.LibraryFilesListBox.Location = new System.Drawing.Point(17, 101);
            this.LibraryFilesListBox.Name = "LibraryFilesListBox";
            this.LibraryFilesListBox.ScrollAlwaysVisible = true;
            this.LibraryFilesListBox.Size = new System.Drawing.Size(218, 319);
            this.LibraryFilesListBox.TabIndex = 14;
            this.LibraryFilesListBox.SelectedIndexChanged += new System.EventHandler(this.LibraryListBoxItemSelected);
            // 
            // SelectedLibraryLabel
            // 
            this.SelectedLibraryLabel.AutoSize = true;
            this.SelectedLibraryLabel.Location = new System.Drawing.Point(219, 9);
            this.SelectedLibraryLabel.Name = "SelectedLibraryLabel";
            this.SelectedLibraryLabel.Size = new System.Drawing.Size(69, 13);
            this.SelectedLibraryLabel.TabIndex = 15;
            this.SelectedLibraryLabel.Text = "active library:";
            this.SelectedLibraryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "library folder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "libraries in folder:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "modules in active library:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "module data:";
            // 
            // DMEEPeekLibs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(880, 459);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedLibraryLabel);
            this.Controls.Add(this.LibraryFilesListBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SetLibraryButton);
            this.Controls.Add(this.SetLibraryTextBox);
            this.Controls.Add(this.FindPartLabel);
            this.Controls.Add(this.ExtractToFileButton);
            this.Controls.Add(this.ModulesListBox);
            this.Controls.Add(this.ModuleDataTextBox);
            this.Controls.Add(this.FindPartButton);
            this.Controls.Add(this.LoadLibraryButton);
            this.Controls.Add(this.SelectedModuleTextBox);
            this.Controls.Add(this.FindModuleTextBox);
            this.Controls.Add(this.SelectedLibraryTextBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DMEEPeekLibs";
            this.Text = "DMEE Library Peek";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox SelectedLibraryTextBox;
        private System.Windows.Forms.Button LoadLibraryButton;
        private System.Windows.Forms.TextBox ModuleDataTextBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox FindModuleTextBox;
        private System.Windows.Forms.Button FindPartButton;
        private System.Windows.Forms.Label FindPartLabel;
        private System.Windows.Forms.TextBox SelectedModuleTextBox;
        private System.Windows.Forms.ListBox ModulesListBox;
        private System.Windows.Forms.Button ExtractToFileButton;
        private System.Windows.Forms.TextBox SetLibraryTextBox;
        private System.Windows.Forms.Button SetLibraryButton;
        private System.Windows.Forms.RadioButton FindInFileRadioButton;
        private System.Windows.Forms.RadioButton FindInFolderRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox LibraryFilesListBox;
        private System.Windows.Forms.Label SelectedLibraryLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

