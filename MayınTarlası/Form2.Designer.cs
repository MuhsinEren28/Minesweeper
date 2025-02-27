namespace MayınTarlası
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.labelGridSize = new System.Windows.Forms.Label();
            this.labelMineCount = new System.Windows.Forms.Label();
            this.textBoxGridSize = new System.Windows.Forms.TextBox();
            this.textBoxMineCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Location = new System.Drawing.Point(71, 194);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(100, 20);
            this.textBoxPlayerName.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(499, 193);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "başlat";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(110, 154);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(62, 13);
            this.labelPlayerName.TabIndex = 4;
            this.labelPlayerName.Text = "kullanıcı adı";
            // 
            // labelGridSize
            // 
            this.labelGridSize.AutoSize = true;
            this.labelGridSize.Location = new System.Drawing.Point(254, 154);
            this.labelGridSize.Name = "labelGridSize";
            this.labelGridSize.Size = new System.Drawing.Size(55, 13);
            this.labelGridSize.TabIndex = 6;
            this.labelGridSize.Text = "oyun alanı";
            // 
            // labelMineCount
            // 
            this.labelMineCount.AutoSize = true;
            this.labelMineCount.Location = new System.Drawing.Point(389, 154);
            this.labelMineCount.Name = "labelMineCount";
            this.labelMineCount.Size = new System.Drawing.Size(62, 13);
            this.labelMineCount.TabIndex = 7;
            this.labelMineCount.Text = "mayın sayısı";
            // 
            // textBoxGridSize
            // 
            this.textBoxGridSize.Location = new System.Drawing.Point(227, 196);
            this.textBoxGridSize.Name = "textBoxGridSize";
            this.textBoxGridSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxGridSize.TabIndex = 10;
            // 
            // textBoxMineCount
            // 
            this.textBoxMineCount.Location = new System.Drawing.Point(369, 194);
            this.textBoxMineCount.Name = "textBoxMineCount";
            this.textBoxMineCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxMineCount.TabIndex = 11;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(673, 227);
            this.Controls.Add(this.textBoxMineCount);
            this.Controls.Add(this.textBoxGridSize);
            this.Controls.Add(this.labelMineCount);
            this.Controls.Add(this.labelGridSize);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPlayerName);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.Label labelGridSize;
        private System.Windows.Forms.Label labelMineCount;
        private System.Windows.Forms.TextBox textBoxGridSize;
        private System.Windows.Forms.TextBox textBoxMineCount;
    }
}