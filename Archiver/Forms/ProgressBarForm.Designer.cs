namespace Archiver
{
    partial class ProgressBarForm
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
            this.totalProgress_label = new System.Windows.Forms.Label();
            this.currentProgress_label = new System.Windows.Forms.Label();
            this.total_progressBar = new System.Windows.Forms.ProgressBar();
            this.current_progressBar = new System.Windows.Forms.ProgressBar();
            this.pause_button = new System.Windows.Forms.Button();
            this.cancle_buton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // totalProgress_label
            // 
            this.totalProgress_label.AutoSize = true;
            this.totalProgress_label.Location = new System.Drawing.Point(13, 13);
            this.totalProgress_label.Name = "totalProgress_label";
            this.totalProgress_label.Size = new System.Drawing.Size(165, 13);
            this.totalProgress_label.TabIndex = 0;
            this.totalProgress_label.Text = "Прогресс записи всего архива";
            // 
            // currentProgress_label
            // 
            this.currentProgress_label.AutoSize = true;
            this.currentProgress_label.Location = new System.Drawing.Point(13, 77);
            this.currentProgress_label.Name = "currentProgress_label";
            this.currentProgress_label.Size = new System.Drawing.Size(168, 13);
            this.currentProgress_label.TabIndex = 1;
            this.currentProgress_label.Text = "Прогресс записи одного файла";
            // 
            // total_progressBar
            // 
            this.total_progressBar.Location = new System.Drawing.Point(16, 29);
            this.total_progressBar.Name = "total_progressBar";
            this.total_progressBar.Size = new System.Drawing.Size(598, 23);
            this.total_progressBar.TabIndex = 2;
            // 
            // current_progressBar
            // 
            this.current_progressBar.Location = new System.Drawing.Point(12, 93);
            this.current_progressBar.Name = "current_progressBar";
            this.current_progressBar.Size = new System.Drawing.Size(598, 23);
            this.current_progressBar.TabIndex = 3;
            // 
            // pause_button
            // 
            this.pause_button.Location = new System.Drawing.Point(12, 122);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(109, 36);
            this.pause_button.TabIndex = 4;
            this.pause_button.Text = "Pause";
            this.pause_button.UseVisualStyleBackColor = true;
            // 
            // cancle_buton
            // 
            this.cancle_buton.Location = new System.Drawing.Point(501, 122);
            this.cancle_buton.Name = "cancle_buton";
            this.cancle_buton.Size = new System.Drawing.Size(109, 36);
            this.cancle_buton.TabIndex = 5;
            this.cancle_buton.Text = "Cancel";
            this.cancle_buton.UseVisualStyleBackColor = true;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 170);
            this.Controls.Add(this.cancle_buton);
            this.Controls.Add(this.pause_button);
            this.Controls.Add(this.current_progressBar);
            this.Controls.Add(this.total_progressBar);
            this.Controls.Add(this.currentProgress_label);
            this.Controls.Add(this.totalProgress_label);
            this.Name = "ProgressForm";
            this.Text = "ProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label totalProgress_label;
        private System.Windows.Forms.Label currentProgress_label;
        private System.Windows.Forms.ProgressBar total_progressBar;
        private System.Windows.Forms.ProgressBar current_progressBar;
        private System.Windows.Forms.Button pause_button;
        private System.Windows.Forms.Button cancle_buton;
    }
}