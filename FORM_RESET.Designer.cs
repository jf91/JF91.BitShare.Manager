namespace BitShare_Manager
{
    partial class FORM_RESET
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_RESET));
            this.label1 = new System.Windows.Forms.Label();
            this.PROGRESSBAR_RESET = new System.Windows.Forms.ProgressBar();
            this.TIMER_RESET = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aguarde enquanto o BitShare Manager restaura as definições";
            // 
            // PROGRESSBAR_RESET
            // 
            this.PROGRESSBAR_RESET.Location = new System.Drawing.Point(18, 53);
            this.PROGRESSBAR_RESET.Name = "PROGRESSBAR_RESET";
            this.PROGRESSBAR_RESET.Size = new System.Drawing.Size(295, 23);
            this.PROGRESSBAR_RESET.TabIndex = 1;
            // 
            // TIMER_RESET
            // 
            this.TIMER_RESET.Interval = 1500;
            this.TIMER_RESET.Tick += new System.EventHandler(this.TIMER_RESET_Tick);
            // 
            // FORM_RESET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 103);
            this.Controls.Add(this.PROGRESSBAR_RESET);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORM_RESET";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurar definições de origem";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar PROGRESSBAR_RESET;
        private System.Windows.Forms.Timer TIMER_RESET;
    }
}