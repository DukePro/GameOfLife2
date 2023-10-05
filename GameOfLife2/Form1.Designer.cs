namespace GameOfLife2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            tBarGeneration = new TrackBar();
            label4 = new Label();
            tBarSpeed = new TrackBar();
            nudSpeed = new NumericUpDown();
            label3 = new Label();
            bPause = new Button();
            nudDencity = new NumericUpDown();
            label2 = new Label();
            nudResolution = new NumericUpDown();
            bStart = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tBarGeneration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tBarSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDencity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudResolution).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(tBarSpeed);
            splitContainer1.Panel1.Controls.Add(nudSpeed);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(bPause);
            splitContainer1.Panel1.Controls.Add(nudDencity);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(nudResolution);
            splitContainer1.Panel1.Controls.Add(bStart);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(tBarGeneration);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Size = new Size(1254, 568);
            splitContainer1.SplitterDistance = 171;
            splitContainer1.TabIndex = 0;
            // 
            // tBarGeneration
            // 
            tBarGeneration.Location = new Point(-2, 315);
            tBarGeneration.Name = "tBarGeneration";
            tBarGeneration.RightToLeft = RightToLeft.Yes;
            tBarGeneration.Size = new Size(171, 45);
            tBarGeneration.TabIndex = 10;
            tBarGeneration.ValueChanged += tBarGeneration_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(23, 295);
            label4.Name = "label4";
            label4.Size = new Size(61, 17);
            label4.TabIndex = 9;
            label4.Text = "История";
            // 
            // tBarSpeed
            // 
            tBarSpeed.Location = new Point(3, 256);
            tBarSpeed.Maximum = 1000;
            tBarSpeed.Minimum = 1;
            tBarSpeed.Name = "tBarSpeed";
            tBarSpeed.RightToLeftLayout = true;
            tBarSpeed.Size = new Size(161, 45);
            tBarSpeed.SmallChange = 30;
            tBarSpeed.TabIndex = 8;
            tBarSpeed.Value = 100;
            tBarSpeed.ValueChanged += tBarSpeed_ValueChanged;
            // 
            // nudSpeed
            // 
            nudSpeed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudSpeed.Increment = new decimal(new int[] { 30, 0, 0, 0 });
            nudSpeed.Location = new Point(23, 227);
            nudSpeed.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudSpeed.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSpeed.Name = "nudSpeed";
            nudSpeed.Size = new Size(132, 23);
            nudSpeed.TabIndex = 6;
            nudSpeed.TextAlign = HorizontalAlignment.Right;
            nudSpeed.Value = new decimal(new int[] { 100, 0, 0, 0 });
            nudSpeed.ValueChanged += nudSpeed_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(23, 207);
            label3.Name = "label3";
            label3.Size = new Size(66, 17);
            label3.TabIndex = 7;
            label3.Text = "Скорость";
            // 
            // bPause
            // 
            bPause.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bPause.Location = new Point(23, 168);
            bPause.Name = "bPause";
            bPause.Size = new Size(132, 36);
            bPause.TabIndex = 5;
            bPause.Text = "Pause";
            bPause.UseVisualStyleBackColor = true;
            bPause.Click += bPause_Click;
            // 
            // nudDencity
            // 
            nudDencity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudDencity.Location = new Point(23, 97);
            nudDencity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDencity.Name = "nudDencity";
            nudDencity.Size = new Size(132, 23);
            nudDencity.TabIndex = 2;
            nudDencity.TextAlign = HorizontalAlignment.Right;
            nudDencity.Value = new decimal(new int[] { 13, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(23, 77);
            label2.Name = "label2";
            label2.Size = new Size(122, 17);
            label2.TabIndex = 3;
            label2.Text = "Плотность клеток";
            // 
            // nudResolution
            // 
            nudResolution.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudResolution.Location = new Point(23, 51);
            nudResolution.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudResolution.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudResolution.Name = "nudResolution";
            nudResolution.Size = new Size(132, 23);
            nudResolution.TabIndex = 0;
            nudResolution.TextAlign = HorizontalAlignment.Right;
            nudResolution.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // bStart
            // 
            bStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            bStart.Location = new Point(23, 126);
            bStart.Name = "bStart";
            bStart.Size = new Size(132, 36);
            bStart.TabIndex = 1;
            bStart.Text = "Start";
            bStart.UseVisualStyleBackColor = true;
            bStart.Click += bStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(23, 31);
            label1.Name = "label1";
            label1.Size = new Size(132, 17);
            label1.TabIndex = 0;
            label1.Text = "Размер клетки в px";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1075, 564);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 568);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Generation";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tBarGeneration).EndInit();
            ((System.ComponentModel.ISupportInitialize)tBarSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDencity).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudResolution).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private NumericUpDown nudDencity;
        private Label label2;
        private NumericUpDown nudResolution;
        private Button bStart;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Button bPause;
        private NumericUpDown nudSpeed;
        private Label label3;
        private TrackBar tBarSpeed;
        private TrackBar tBarGeneration;
        private Label label4;
    }
}