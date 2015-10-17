namespace Archiver
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataList = new System.Windows.Forms.DataGridView();
            this.FileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullPathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unzipSimpleFile = new System.Windows.Forms.DataGridViewLinkColumn();
            this.button_Add_Dir = new System.Windows.Forms.Button();
            this.makeZip_button = new System.Windows.Forms.Button();
            this.openZip_button = new System.Windows.Forms.Button();
            this.extractFullZIP_button = new System.Windows.Forms.Button();
            this.zipName_label = new System.Windows.Forms.Label();
            this.addToExistArchive_button = new System.Windows.Forms.Button();
            this.addFiles_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataList
            // 
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileNameColumn,
            this.FullPathColumn,
            this.deleteFile,
            this.Status,
            this.unzipSimpleFile});
            this.dataList.Location = new System.Drawing.Point(12, 34);
            this.dataList.Name = "dataList";
            this.dataList.Size = new System.Drawing.Size(661, 253);
            this.dataList.TabIndex = 0;
            this.dataList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.deleteRow_CellContentClick);
            // 
            // FileNameColumn
            // 
            this.FileNameColumn.HeaderText = "File Name";
            this.FileNameColumn.Name = "FileNameColumn";
            // 
            // FullPathColumn
            // 
            this.FullPathColumn.HeaderText = "Full Path";
            this.FullPathColumn.Name = "FullPathColumn";
            // 
            // deleteFile
            // 
            this.deleteFile.HeaderText = "";
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Text = "delete File";
            this.deleteFile.UseColumnTextForButtonValue = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // unzipSimpleFile
            // 
            this.unzipSimpleFile.HeaderText = "";
            this.unzipSimpleFile.Name = "unzipSimpleFile";
            this.unzipSimpleFile.Text = "unzip fie";
            this.unzipSimpleFile.UseColumnTextForLinkValue = true;
            // 
            // button_Add_Dir
            // 
            this.button_Add_Dir.Location = new System.Drawing.Point(12, 293);
            this.button_Add_Dir.Name = "button_Add_Dir";
            this.button_Add_Dir.Size = new System.Drawing.Size(160, 44);
            this.button_Add_Dir.TabIndex = 1;
            this.button_Add_Dir.Text = "Add Folder";
            this.button_Add_Dir.UseVisualStyleBackColor = true;
            this.button_Add_Dir.Click += new System.EventHandler(this.button_Add_Dir_Click);
            // 
            // makeZip_button
            // 
            this.makeZip_button.Location = new System.Drawing.Point(212, 328);
            this.makeZip_button.Name = "makeZip_button";
            this.makeZip_button.Size = new System.Drawing.Size(238, 57);
            this.makeZip_button.TabIndex = 2;
            this.makeZip_button.Text = "Make a package";
            this.makeZip_button.UseVisualStyleBackColor = true;
            this.makeZip_button.Click += new System.EventHandler(this.makeZip_button_Click);
            // 
            // openZip_button
            // 
            this.openZip_button.Location = new System.Drawing.Point(483, 293);
            this.openZip_button.Name = "openZip_button";
            this.openZip_button.Size = new System.Drawing.Size(165, 43);
            this.openZip_button.TabIndex = 3;
            this.openZip_button.Text = "Open package";
            this.openZip_button.UseVisualStyleBackColor = true;
            this.openZip_button.Click += new System.EventHandler(this.openZip_button_Click);
            // 
            // extractFullZIP_button
            // 
            this.extractFullZIP_button.Location = new System.Drawing.Point(212, 392);
            this.extractFullZIP_button.Name = "extractFullZIP_button";
            this.extractFullZIP_button.Size = new System.Drawing.Size(238, 66);
            this.extractFullZIP_button.TabIndex = 5;
            this.extractFullZIP_button.Text = "Extract ALL Files";
            this.extractFullZIP_button.UseVisualStyleBackColor = true;
            this.extractFullZIP_button.Click += new System.EventHandler(this.extractFullZIP_button_Click);
            // 
            // zipName_label
            // 
            this.zipName_label.AutoSize = true;
            this.zipName_label.Location = new System.Drawing.Point(13, 13);
            this.zipName_label.Name = "zipName_label";
            this.zipName_label.Size = new System.Drawing.Size(0, 13);
            this.zipName_label.TabIndex = 6;
            // 
            // addToExistArchive_button
            // 
            this.addToExistArchive_button.Location = new System.Drawing.Point(483, 343);
            this.addToExistArchive_button.Name = "addToExistArchive_button";
            this.addToExistArchive_button.Size = new System.Drawing.Size(165, 42);
            this.addToExistArchive_button.TabIndex = 7;
            this.addToExistArchive_button.Text = "Add file to container ";
            this.addToExistArchive_button.UseVisualStyleBackColor = true;
            this.addToExistArchive_button.Click += new System.EventHandler(this.addToExistArchive_button_Click);
            // 
            // addFiles_button
            // 
            this.addFiles_button.Location = new System.Drawing.Point(12, 356);
            this.addFiles_button.Name = "addFiles_button";
            this.addFiles_button.Size = new System.Drawing.Size(160, 43);
            this.addFiles_button.TabIndex = 8;
            this.addFiles_button.Text = "Add Files";
            this.addFiles_button.UseVisualStyleBackColor = true;
            this.addFiles_button.Click += new System.EventHandler(this.addFiles_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 470);
            this.Controls.Add(this.addFiles_button);
            this.Controls.Add(this.addToExistArchive_button);
            this.Controls.Add(this.zipName_label);
            this.Controls.Add(this.extractFullZIP_button);
            this.Controls.Add(this.openZip_button);
            this.Controls.Add(this.makeZip_button);
            this.Controls.Add(this.button_Add_Dir);
            this.Controls.Add(this.dataList);
            this.Name = "MainForm";
            this.Text = "FileArchiver";
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataList;
        private System.Windows.Forms.Button button_Add_Dir;
        private System.Windows.Forms.Button makeZip_button;
        private System.Windows.Forms.Button openZip_button;
        private System.Windows.Forms.Button extractFullZIP_button;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullPathColumn;
        private System.Windows.Forms.DataGridViewButtonColumn deleteFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewLinkColumn unzipSimpleFile;
        public System.Windows.Forms.Label zipName_label;
        private System.Windows.Forms.Button addToExistArchive_button;
        private System.Windows.Forms.Button addFiles_button;
    }
}

