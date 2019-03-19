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
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation2 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            this.askbutton = new System.Windows.Forms.Button();
            this.Browse = new System.Windows.Forms.Button();
            this.FileDir = new System.Windows.Forms.TextBox();
            this.FerdiantStart = new System.Windows.Forms.ComboBox();
            this.JoseAddress = new System.Windows.Forms.ComboBox();
            this.Direction = new System.Windows.Forms.ComboBox();
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.InputDir = new System.Windows.Forms.TextBox();
            this.Input = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // askbutton
            // 
            this.askbutton.Location = new System.Drawing.Point(561, 111);
            this.askbutton.Margin = new System.Windows.Forms.Padding(2);
            this.askbutton.Name = "askbutton";
            this.askbutton.Size = new System.Drawing.Size(76, 23);
            this.askbutton.TabIndex = 2;
            this.askbutton.Text = "Ask!";
            this.askbutton.UseVisualStyleBackColor = true;
            this.askbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(562, 41);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 4;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.button2_Click);
            // 
            // FileDir
            // 
            this.FileDir.Location = new System.Drawing.Point(343, 41);
            this.FileDir.Name = "FileDir";
            this.FileDir.Size = new System.Drawing.Size(200, 20);
            this.FileDir.TabIndex = 5;
            // 
            // FerdiantStart
            // 
            this.FerdiantStart.FormattingEnabled = true;
            this.FerdiantStart.Location = new System.Drawing.Point(483, 113);
            this.FerdiantStart.Name = "FerdiantStart";
            this.FerdiantStart.Size = new System.Drawing.Size(60, 21);
            this.FerdiantStart.TabIndex = 6;
            this.FerdiantStart.SelectedIndexChanged += new System.EventHandler(this.FerdiantStart_SelectedIndexChanged);
            // 
            // JoseAddress
            // 
            this.JoseAddress.FormattingEnabled = true;
            this.JoseAddress.Location = new System.Drawing.Point(413, 113);
            this.JoseAddress.Name = "JoseAddress";
            this.JoseAddress.Size = new System.Drawing.Size(60, 21);
            this.JoseAddress.TabIndex = 7;
            // 
            // Direction
            // 
            this.Direction.AllowDrop = true;
            this.Direction.FormattingEnabled = true;
            this.Direction.Items.AddRange(new object[] {
            "1",
            "0"});
            this.Direction.Location = new System.Drawing.Point(343, 113);
            this.Direction.Name = "Direction";
            this.Direction.Size = new System.Drawing.Size(60, 21);
            this.Direction.TabIndex = 8;
            this.Direction.SelectedIndexChanged += new System.EventHandler(this.Direction_SelectedIndexChanged);
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(12, 12);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(291, 334);
            this.gViewer1.TabIndex = 9;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = true;
            this.gViewer1.Transform = planeTransformation2;
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // InputDir
            // 
            this.InputDir.Location = new System.Drawing.Point(344, 141);
            this.InputDir.Name = "InputDir";
            this.InputDir.Size = new System.Drawing.Size(200, 20);
            this.InputDir.TabIndex = 10;
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(562, 139);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(75, 23);
            this.Input.TabIndex = 11;
            this.Input.Text = "Browse";
            this.Input.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Question";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(344, 173);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(293, 173);
            this.listBox1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 358);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.InputDir);
            this.Controls.Add(this.gViewer1);
            this.Controls.Add(this.Direction);
            this.Controls.Add(this.JoseAddress);
            this.Controls.Add(this.FerdiantStart);
            this.Controls.Add(this.FileDir);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.askbutton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Negeri Antah-Berantah";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button askbutton;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox FileDir;
        private System.Windows.Forms.ComboBox FerdiantStart;
        private System.Windows.Forms.ComboBox JoseAddress;
        private System.Windows.Forms.ComboBox Direction;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.TextBox InputDir;
        private System.Windows.Forms.Button Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

