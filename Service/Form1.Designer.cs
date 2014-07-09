namespace Service
{
    partial class Testform
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.btn_go = new System.Windows.Forms.Button();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.wb1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(24, 31);
            this.tb1.Multiline = true;
            this.tb1.Name = "tb1";
            this.tb1.ReadOnly = true;
            this.tb1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb1.Size = new System.Drawing.Size(365, 192);
            this.tb1.TabIndex = 0;
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(135, 289);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(125, 24);
            this.btn_go.TabIndex = 1;
            this.btn_go.Text = "Go";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(24, 241);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(365, 20);
            this.tb2.TabIndex = 2;
            // 
            // wb1
            // 
            this.wb1.Location = new System.Drawing.Point(409, 31);
            this.wb1.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb1.Name = "wb1";
            this.wb1.Size = new System.Drawing.Size(431, 282);
            this.wb1.TabIndex = 3;
            // 
            // Testform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 359);
            this.Controls.Add(this.wb1);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.tb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Testform";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.WebBrowser wb1;
    }
}

