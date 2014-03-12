namespace HandbrakeBatchConvert
{
    partial class Preview
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
            this.txtPreview = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtPreview
            // 
            this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreview.Location = new System.Drawing.Point(0, 0);
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.Size = new System.Drawing.Size(423, 470);
            this.txtPreview.TabIndex = 0;
            this.txtPreview.Text = "";
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 470);
            this.Controls.Add(this.txtPreview);
            this.KeyPreview = true;
            this.Name = "Preview";
            this.Text = "Preview";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtPreview;
    }
}