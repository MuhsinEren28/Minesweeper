namespace MayınTarlası
{
    partial class SkorboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button closeButton;

        /// <summary>
        /// Temizleyici metodunu oluşturduğunuzda tüm bileşenlerin temizlendiğinden emin olun.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(360, 300);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(150, 320);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 30);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Kapat";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SkorboardForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 360);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "SkorboardForm";
            this.Text = "Skorboard";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
