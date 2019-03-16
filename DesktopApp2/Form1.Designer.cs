namespace DesktopApp2
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Browse = new System.Windows.Forms.Button();
            this.FileDir = new System.Windows.Forms.TextBox();
            this.FerdiantStart = new System.Windows.Forms.ComboBox();
            this.JoseAddress = new System.Windows.Forms.ComboBox();
            this.Direction = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 40);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ask!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Title = "Browse Text FIle";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(446, 12);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 4;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.button2_Click);
            // 
            // FileDir
            // 
            this.FileDir.Location = new System.Drawing.Point(194, 12);
            this.FileDir.Name = "FileDir";
            this.FileDir.Size = new System.Drawing.Size(231, 20);
            this.FileDir.TabIndex = 5;
            // 
            // FerdiantStart
            // 
            this.FerdiantStart.FormattingEnabled = true;
            this.FerdiantStart.Location = new System.Drawing.Point(358, 42);
            this.FerdiantStart.Name = "FerdiantStart";
            this.FerdiantStart.Size = new System.Drawing.Size(67, 21);
            this.FerdiantStart.TabIndex = 6;
            // 
            // JoseAddress
            // 
            this.JoseAddress.FormattingEnabled = true;
            this.JoseAddress.Location = new System.Drawing.Point(276, 42);
            this.JoseAddress.Name = "JoseAddress";
            this.JoseAddress.Size = new System.Drawing.Size(67, 21);
            this.JoseAddress.TabIndex = 7;
            // 
            // Direction
            // 
            this.Direction.AllowDrop = true;
            this.Direction.FormattingEnabled = true;
            this.Direction.Items.AddRange(new object[] {
            "1",
            "0"});
            this.Direction.Location = new System.Drawing.Point(194, 42);
            this.Direction.Name = "Direction";
            this.Direction.Size = new System.Drawing.Size(67, 21);
            this.Direction.TabIndex = 8;
            this.Direction.SelectedIndexChanged += new System.EventHandler(this.Direction_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.Direction);
            this.Controls.Add(this.JoseAddress);
            this.Controls.Add(this.FerdiantStart);
            this.Controls.Add(this.FileDir);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox FileDir;
        private System.Windows.Forms.ComboBox FerdiantStart;
        private System.Windows.Forms.ComboBox JoseAddress;
        private System.Windows.Forms.ComboBox Direction;
    }
}

