namespace ArGsFolderOrganizer
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
            BtnSelectFolder = new Button();
            TxtFolderPath = new TextBox();
            BtnOrganize = new Button();
            ChkOrganizeByType = new CheckBox();
            ChkCleanMusicNames = new CheckBox();
            ChkTrimSpaces = new CheckBox();
            ChkReplaceUnderscores = new CheckBox();
            ChkRemoveBrackets = new CheckBox();
            GrpOptions = new GroupBox();
            ChkRenameByTags = new CheckBox();
            GrpOptions.SuspendLayout();
            SuspendLayout();
            // 
            // BtnSelectFolder
            // 
            BtnSelectFolder.Anchor = AnchorStyles.Top;
            BtnSelectFolder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnSelectFolder.Location = new Point(190, 20);
            BtnSelectFolder.Name = "BtnSelectFolder";
            BtnSelectFolder.Size = new Size(180, 35);
            BtnSelectFolder.TabIndex = 0;
            BtnSelectFolder.Text = "Select Folder";
            BtnSelectFolder.UseVisualStyleBackColor = true;
            BtnSelectFolder.Click += BtnSelectFolder_Click;
            // 
            // TxtFolderPath
            // 
            TxtFolderPath.BackColor = Color.White;
            TxtFolderPath.BorderStyle = BorderStyle.FixedSingle;
            TxtFolderPath.Location = new Point(30, 65);
            TxtFolderPath.Name = "TxtFolderPath";
            TxtFolderPath.ReadOnly = true;
            TxtFolderPath.Size = new Size(500, 30);
            TxtFolderPath.TabIndex = 1;
            // 
            // BtnOrganize
            // 
            BtnOrganize.Anchor = AnchorStyles.Bottom;
            BtnOrganize.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnOrganize.Location = new Point(178, 372);
            BtnOrganize.Name = "BtnOrganize";
            BtnOrganize.Size = new Size(200, 40);
            BtnOrganize.TabIndex = 2;
            BtnOrganize.Text = "Organize";
            BtnOrganize.UseVisualStyleBackColor = true;
            BtnOrganize.Click += BtnOrganize_Click;
            // 
            // ChkOrganizeByType
            // 
            ChkOrganizeByType.AutoSize = true;
            ChkOrganizeByType.Location = new Point(20, 30);
            ChkOrganizeByType.Name = "ChkOrganizeByType";
            ChkOrganizeByType.Size = new Size(196, 27);
            ChkOrganizeByType.TabIndex = 3;
            ChkOrganizeByType.Text = "Organize files by type";
            ChkOrganizeByType.UseVisualStyleBackColor = true;
            // 
            // ChkTrimSpaces
            // 
            ChkTrimSpaces.AutoSize = true;
            ChkTrimSpaces.Location = new Point(20, 63);
            ChkTrimSpaces.Name = "ChkTrimSpaces";
            ChkTrimSpaces.Size = new Size(255, 27);
            ChkTrimSpaces.TabIndex = 4;
            ChkTrimSpaces.Text = "Trim whitespace in file names";
            ChkTrimSpaces.UseVisualStyleBackColor = true;
            // 
            // ChkReplaceUnderscores
            // 
            ChkReplaceUnderscores.AutoSize = true;
            ChkReplaceUnderscores.Location = new Point(20, 96);
            ChkReplaceUnderscores.Name = "ChkReplaceUnderscores";
            ChkReplaceUnderscores.Size = new Size(280, 27);
            ChkReplaceUnderscores.TabIndex = 5;
            ChkReplaceUnderscores.Text = "Replace underscores with spaces";
            ChkReplaceUnderscores.UseVisualStyleBackColor = true;
            // 
            // ChkRemoveBrackets
            // 
            ChkRemoveBrackets.AutoSize = true;
            ChkRemoveBrackets.Location = new Point(20, 129);
            ChkRemoveBrackets.Name = "ChkRemoveBrackets";
            ChkRemoveBrackets.Size = new Size(308, 27);
            ChkRemoveBrackets.TabIndex = 6;
            ChkRemoveBrackets.Text = "Remove brackets and content inside";
            ChkRemoveBrackets.UseVisualStyleBackColor = true;
            // 
            // ChkCleanMusicNames
            // 
            ChkCleanMusicNames.AutoSize = true;
            ChkCleanMusicNames.Location = new Point(20, 162);
            ChkCleanMusicNames.Name = "ChkCleanMusicNames";
            ChkCleanMusicNames.Size = new Size(206, 27);
            ChkCleanMusicNames.TabIndex = 7;
            ChkCleanMusicNames.Text = "Clean music file names";
            ChkCleanMusicNames.UseVisualStyleBackColor = true;
            // 
            // ChkRenameByTags
            // 
            ChkRenameByTags.AutoSize = true;
            ChkRenameByTags.Location = new Point(20, 195);
            ChkRenameByTags.Name = "ChkRenameByTags";
            ChkRenameByTags.Size = new Size(424, 27);
            ChkRenameByTags.TabIndex = 8;
            ChkRenameByTags.Text = "Rename music files based on ID3 tags (Artist - Title)";
            ChkRenameByTags.UseVisualStyleBackColor = true;
            // 
            // GrpOptions
            // 
            GrpOptions.Controls.Add(ChkRenameByTags);
            GrpOptions.Controls.Add(ChkOrganizeByType);
            GrpOptions.Controls.Add(ChkCleanMusicNames);
            GrpOptions.Controls.Add(ChkTrimSpaces);
            GrpOptions.Controls.Add(ChkReplaceUnderscores);
            GrpOptions.Controls.Add(ChkRemoveBrackets);
            GrpOptions.Font = new Font("Segoe UI", 10F);
            GrpOptions.Location = new Point(30, 110);
            GrpOptions.Name = "GrpOptions";
            GrpOptions.Size = new Size(500, 236);
            GrpOptions.TabIndex = 0;
            GrpOptions.TabStop = false;
            GrpOptions.Text = "Options";

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(560, 437);
            Controls.Add(GrpOptions);
            Controls.Add(BtnOrganize);
            Controls.Add(TxtFolderPath);
            Controls.Add(BtnSelectFolder);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ArG's Folder Organizer";
            GrpOptions.ResumeLayout(false);
            GrpOptions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnSelectFolder;
        private TextBox TxtFolderPath;
        private Button BtnOrganize;
        private CheckBox ChkOrganizeByType;
        private CheckBox ChkTrimSpaces;
        private CheckBox ChkReplaceUnderscores;
        private CheckBox ChkRemoveBrackets;
        private CheckBox ChkCleanMusicNames;
        private CheckBox ChkRenameByTags;
        private GroupBox GrpOptions;

    }
}
