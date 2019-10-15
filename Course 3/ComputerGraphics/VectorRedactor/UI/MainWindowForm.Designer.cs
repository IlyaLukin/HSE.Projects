namespace VectorRedactor.UI
{
    partial class MainWindowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.CanvasPanel = new System.Windows.Forms.Panel();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.JobPanel = new System.Windows.Forms.Panel();
            this.VectorsButtons = new System.Windows.Forms.GroupBox();
            this.RemoveVectorBtn = new System.Windows.Forms.Button();
            this.AddVectorBtn = new System.Windows.Forms.Button();
            this.GeneralInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.CountOfVectorsLbl = new System.Windows.Forms.Label();
            this.CountOfVectorsTitle = new System.Windows.Forms.Label();
            this.CanvasPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.JobPanel.SuspendLayout();
            this.VectorsButtons.SuspendLayout();
            this.GeneralInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CanvasPanel
            // 
            this.CanvasPanel.Controls.Add(this.Canvas);
            this.CanvasPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CanvasPanel.Location = new System.Drawing.Point(0, 0);
            this.CanvasPanel.Name = "CanvasPanel";
            this.CanvasPanel.Size = new System.Drawing.Size(1093, 627);
            this.CanvasPanel.TabIndex = 0;
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.Snow;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1093, 627);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandleMouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandleMouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HandleMouseUp);
            // 
            // JobPanel
            // 
            this.JobPanel.Controls.Add(this.VectorsButtons);
            this.JobPanel.Controls.Add(this.GeneralInfoGroupBox);
            this.JobPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.JobPanel.Location = new System.Drawing.Point(1096, 0);
            this.JobPanel.Name = "JobPanel";
            this.JobPanel.Size = new System.Drawing.Size(328, 627);
            this.JobPanel.TabIndex = 1;
            // 
            // VectorsButtons
            // 
            this.VectorsButtons.Controls.Add(this.RemoveVectorBtn);
            this.VectorsButtons.Controls.Add(this.AddVectorBtn);
            this.VectorsButtons.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VectorsButtons.Location = new System.Drawing.Point(3, 72);
            this.VectorsButtons.Name = "VectorsButtons";
            this.VectorsButtons.Size = new System.Drawing.Size(322, 64);
            this.VectorsButtons.TabIndex = 1;
            this.VectorsButtons.TabStop = false;
            this.VectorsButtons.Text = "Vectors";
            // 
            // RemoveVectorBtn
            // 
            this.RemoveVectorBtn.BackColor = System.Drawing.Color.Transparent;
            this.RemoveVectorBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RemoveVectorBtn.Enabled = false;
            this.RemoveVectorBtn.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveVectorBtn.Location = new System.Drawing.Point(87, 28);
            this.RemoveVectorBtn.Name = "RemoveVectorBtn";
            this.RemoveVectorBtn.Size = new System.Drawing.Size(75, 29);
            this.RemoveVectorBtn.TabIndex = 1;
            this.RemoveVectorBtn.Text = "Remove";
            this.RemoveVectorBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RemoveVectorBtn.UseVisualStyleBackColor = true;
            this.RemoveVectorBtn.Click += new System.EventHandler(this.HandleClickRemoveVector);
            // 
            // AddVectorBtn
            // 
            this.AddVectorBtn.BackColor = System.Drawing.Color.Transparent;
            this.AddVectorBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddVectorBtn.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddVectorBtn.Location = new System.Drawing.Point(6, 28);
            this.AddVectorBtn.Name = "AddVectorBtn";
            this.AddVectorBtn.Size = new System.Drawing.Size(75, 29);
            this.AddVectorBtn.TabIndex = 0;
            this.AddVectorBtn.Text = "Add";
            this.AddVectorBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddVectorBtn.UseVisualStyleBackColor = true;
            this.AddVectorBtn.Click += new System.EventHandler(this.HandleClickInsertVector);
            // 
            // GeneralInfoGroupBox
            // 
            this.GeneralInfoGroupBox.Controls.Add(this.CountOfVectorsLbl);
            this.GeneralInfoGroupBox.Controls.Add(this.CountOfVectorsTitle);
            this.GeneralInfoGroupBox.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeneralInfoGroupBox.Location = new System.Drawing.Point(3, 3);
            this.GeneralInfoGroupBox.Name = "GeneralInfoGroupBox";
            this.GeneralInfoGroupBox.Size = new System.Drawing.Size(322, 63);
            this.GeneralInfoGroupBox.TabIndex = 0;
            this.GeneralInfoGroupBox.TabStop = false;
            this.GeneralInfoGroupBox.Text = "General info";
            // 
            // CountOfVectorsLbl
            // 
            this.CountOfVectorsLbl.AutoSize = true;
            this.CountOfVectorsLbl.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountOfVectorsLbl.Location = new System.Drawing.Point(116, 28);
            this.CountOfVectorsLbl.Name = "CountOfVectorsLbl";
            this.CountOfVectorsLbl.Size = new System.Drawing.Size(0, 20);
            this.CountOfVectorsLbl.TabIndex = 1;
            // 
            // CountOfVectorsTitle
            // 
            this.CountOfVectorsTitle.AutoSize = true;
            this.CountOfVectorsTitle.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountOfVectorsTitle.Location = new System.Drawing.Point(6, 28);
            this.CountOfVectorsTitle.Name = "CountOfVectorsTitle";
            this.CountOfVectorsTitle.Size = new System.Drawing.Size(104, 20);
            this.CountOfVectorsTitle.TabIndex = 0;
            this.CountOfVectorsTitle.Text = "Vectors count:";
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 627);
            this.Controls.Add(this.JobPanel);
            this.Controls.Add(this.CanvasPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindowForm";
            this.Text = "Рабочее пространство";
            this.Load += new System.EventHandler(this.HandleLoadMainWindow);
            this.CanvasPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.JobPanel.ResumeLayout(false);
            this.VectorsButtons.ResumeLayout(false);
            this.GeneralInfoGroupBox.ResumeLayout(false);
            this.GeneralInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CanvasPanel;
        private System.Windows.Forms.Panel JobPanel;
        private System.Windows.Forms.GroupBox GeneralInfoGroupBox;
        private System.Windows.Forms.Label CountOfVectorsLbl;
        private System.Windows.Forms.Label CountOfVectorsTitle;
        private System.Windows.Forms.GroupBox VectorsButtons;
        private System.Windows.Forms.Button AddVectorBtn;
        private System.Windows.Forms.Button RemoveVectorBtn;
        private System.Windows.Forms.PictureBox Canvas;
    }
}