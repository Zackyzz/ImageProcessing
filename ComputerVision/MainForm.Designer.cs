namespace ComputerVision
{
    partial class MainForm
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
            this.panelSource = new System.Windows.Forms.Panel();
            this.panelDestination = new System.Windows.Forms.Panel();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.ftjBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pragT = new System.Windows.Forms.TextBox();
            this.btnATreshold = new System.Windows.Forms.Button();
            this.btnThreshold = new System.Windows.Forms.Button();
            this.regionGrowing = new System.Windows.Forms.Label();
            this.TBox = new System.Windows.Forms.TextBox();
            this.btnGabor = new System.Windows.Forms.Button();
            this.btnFrei = new System.Windows.Forms.Button();
            this.btnSobel = new System.Windows.Forms.Button();
            this.btnRobi = new System.Windows.Forms.Button();
            this.btnKirsch = new System.Windows.Forms.Button();
            this.btnUnsharp = new System.Windows.Forms.Button();
            this.btnFTS = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnMarkov = new System.Windows.Forms.Button();
            this.rotBox = new System.Windows.Forms.TextBox();
            this.ftj = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.smalling = new System.Windows.Forms.Button();
            this.btnEqualizator = new System.Windows.Forms.Button();
            this.buttonNegativate = new System.Windows.Forms.Button();
            this.buttonGrayscale = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trackLuminosity = new System.Windows.Forms.TrackBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.trackContrast = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackLuminosity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSource
            // 
            this.panelSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelSource.Location = new System.Drawing.Point(12, 12);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(320, 240);
            this.panelSource.TabIndex = 0;
            this.panelSource.MouseDown += new System.Windows.Forms.MouseEventHandler(this.seq);
            // 
            // panelDestination
            // 
            this.panelDestination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDestination.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDestination.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelDestination.Location = new System.Drawing.Point(348, 12);
            this.panelDestination.Name = "panelDestination";
            this.panelDestination.Size = new System.Drawing.Size(320, 240);
            this.panelDestination.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 439);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // ftjBox
            // 
            this.ftjBox.Location = new System.Drawing.Point(278, 126);
            this.ftjBox.Name = "ftjBox";
            this.ftjBox.Size = new System.Drawing.Size(29, 20);
            this.ftjBox.TabIndex = 21;
            this.ftjBox.Text = "5";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pragT);
            this.panel1.Controls.Add(this.btnATreshold);
            this.panel1.Controls.Add(this.btnThreshold);
            this.panel1.Controls.Add(this.regionGrowing);
            this.panel1.Controls.Add(this.TBox);
            this.panel1.Controls.Add(this.btnGabor);
            this.panel1.Controls.Add(this.btnFrei);
            this.panel1.Controls.Add(this.btnSobel);
            this.panel1.Controls.Add(this.btnRobi);
            this.panel1.Controls.Add(this.btnKirsch);
            this.panel1.Controls.Add(this.btnUnsharp);
            this.panel1.Controls.Add(this.btnFTS);
            this.panel1.Controls.Add(this.btnSort);
            this.panel1.Controls.Add(this.btnMarkov);
            this.panel1.Controls.Add(this.rotBox);
            this.panel1.Controls.Add(this.ftjBox);
            this.panel1.Controls.Add(this.ftj);
            this.panel1.Controls.Add(this.btnRotate);
            this.panel1.Controls.Add(this.smalling);
            this.panel1.Controls.Add(this.btnEqualizator);
            this.panel1.Controls.Add(this.buttonNegativate);
            this.panel1.Controls.Add(this.buttonGrayscale);
            this.panel1.Location = new System.Drawing.Point(348, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 190);
            this.panel1.TabIndex = 3;
            // 
            // pragT
            // 
            this.pragT.Location = new System.Drawing.Point(142, 34);
            this.pragT.Name = "pragT";
            this.pragT.Size = new System.Drawing.Size(61, 20);
            this.pragT.TabIndex = 31;
            this.pragT.Text = "8";
            // 
            // btnATreshold
            // 
            this.btnATreshold.Location = new System.Drawing.Point(73, 32);
            this.btnATreshold.Name = "btnATreshold";
            this.btnATreshold.Size = new System.Drawing.Size(63, 23);
            this.btnATreshold.TabIndex = 30;
            this.btnATreshold.Text = "SaM";
            this.btnATreshold.UseVisualStyleBackColor = true;
            this.btnATreshold.Click += new System.EventHandler(this.btnATreshold_Click);
            // 
            // btnThreshold
            // 
            this.btnThreshold.Location = new System.Drawing.Point(74, 4);
            this.btnThreshold.Name = "btnThreshold";
            this.btnThreshold.Size = new System.Drawing.Size(62, 23);
            this.btnThreshold.TabIndex = 29;
            this.btnThreshold.Text = "Treshold";
            this.btnThreshold.UseVisualStyleBackColor = true;
            this.btnThreshold.Click += new System.EventHandler(this.btnThreshold_Click);
            // 
            // regionGrowing
            // 
            this.regionGrowing.AutoSize = true;
            this.regionGrowing.Location = new System.Drawing.Point(4, 95);
            this.regionGrowing.Name = "regionGrowing";
            this.regionGrowing.Size = new System.Drawing.Size(64, 13);
            this.regionGrowing.TabIndex = 19;
            this.regionGrowing.Text = "Segmentare";
            // 
            // TBox
            // 
            this.TBox.Location = new System.Drawing.Point(74, 90);
            this.TBox.Name = "TBox";
            this.TBox.Size = new System.Drawing.Size(46, 20);
            this.TBox.TabIndex = 0;
            this.TBox.Text = "18";
            // 
            // btnGabor
            // 
            this.btnGabor.Location = new System.Drawing.Point(7, 61);
            this.btnGabor.Name = "btnGabor";
            this.btnGabor.Size = new System.Drawing.Size(60, 23);
            this.btnGabor.TabIndex = 28;
            this.btnGabor.Text = "Gabor";
            this.btnGabor.UseVisualStyleBackColor = true;
            this.btnGabor.Click += new System.EventHandler(this.btnGabor_Click);
            // 
            // btnFrei
            // 
            this.btnFrei.Location = new System.Drawing.Point(241, 90);
            this.btnFrei.Name = "btnFrei";
            this.btnFrei.Size = new System.Drawing.Size(66, 23);
            this.btnFrei.TabIndex = 27;
            this.btnFrei.Text = "Frei-Chen";
            this.btnFrei.UseVisualStyleBackColor = true;
            this.btnFrei.Click += new System.EventHandler(this.btnFrei_Click);
            // 
            // btnSobel
            // 
            this.btnSobel.Location = new System.Drawing.Point(241, 61);
            this.btnSobel.Name = "btnSobel";
            this.btnSobel.Size = new System.Drawing.Size(66, 23);
            this.btnSobel.TabIndex = 26;
            this.btnSobel.Text = "Sobel";
            this.btnSobel.UseVisualStyleBackColor = true;
            this.btnSobel.Click += new System.EventHandler(this.btnSobel_Click);
            // 
            // btnRobi
            // 
            this.btnRobi.Location = new System.Drawing.Point(241, 32);
            this.btnRobi.Name = "btnRobi";
            this.btnRobi.Size = new System.Drawing.Size(66, 23);
            this.btnRobi.TabIndex = 25;
            this.btnRobi.Text = "Roberts";
            this.btnRobi.UseVisualStyleBackColor = true;
            this.btnRobi.Click += new System.EventHandler(this.btnRobi_Click);
            // 
            // btnKirsch
            // 
            this.btnKirsch.Location = new System.Drawing.Point(241, 3);
            this.btnKirsch.Name = "btnKirsch";
            this.btnKirsch.Size = new System.Drawing.Size(66, 23);
            this.btnKirsch.TabIndex = 24;
            this.btnKirsch.Text = "Kirsch";
            this.btnKirsch.UseVisualStyleBackColor = true;
            this.btnKirsch.Click += new System.EventHandler(this.btnKirsch_Click);
            // 
            // btnUnsharp
            // 
            this.btnUnsharp.Location = new System.Drawing.Point(142, 126);
            this.btnUnsharp.Name = "btnUnsharp";
            this.btnUnsharp.Size = new System.Drawing.Size(75, 23);
            this.btnUnsharp.TabIndex = 23;
            this.btnUnsharp.Text = "Unsharping";
            this.btnUnsharp.UseVisualStyleBackColor = true;
            this.btnUnsharp.Click += new System.EventHandler(this.btnUnsharp_Click);
            // 
            // btnFTS
            // 
            this.btnFTS.Location = new System.Drawing.Point(7, 32);
            this.btnFTS.Name = "btnFTS";
            this.btnFTS.Size = new System.Drawing.Size(60, 23);
            this.btnFTS.TabIndex = 22;
            this.btnFTS.Text = "FTS";
            this.btnFTS.UseVisualStyleBackColor = true;
            this.btnFTS.Click += new System.EventHandler(this.btnFTS_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(7, 3);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(60, 23);
            this.btnSort.TabIndex = 19;
            this.btnSort.Text = "Median";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnMarkov
            // 
            this.btnMarkov.Location = new System.Drawing.Point(80, 126);
            this.btnMarkov.Name = "btnMarkov";
            this.btnMarkov.Size = new System.Drawing.Size(56, 23);
            this.btnMarkov.TabIndex = 19;
            this.btnMarkov.Text = "Markov";
            this.btnMarkov.UseVisualStyleBackColor = true;
            this.btnMarkov.Click += new System.EventHandler(this.btnMarkov_Click);
            // 
            // rotBox
            // 
            this.rotBox.Location = new System.Drawing.Point(278, 157);
            this.rotBox.Name = "rotBox";
            this.rotBox.Size = new System.Drawing.Size(29, 20);
            this.rotBox.TabIndex = 19;
            this.rotBox.Text = "80";
            // 
            // ftj
            // 
            this.ftj.Location = new System.Drawing.Point(223, 126);
            this.ftj.Name = "ftj";
            this.ftj.Size = new System.Drawing.Size(49, 23);
            this.ftj.TabIndex = 19;
            this.ftj.Text = "FTJ";
            this.ftj.UseVisualStyleBackColor = true;
            this.ftj.Click += new System.EventHandler(this.ftj_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(223, 155);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(49, 23);
            this.btnRotate.TabIndex = 20;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.button2_Click);
            // 
            // smalling
            // 
            this.smalling.Location = new System.Drawing.Point(7, 126);
            this.smalling.Name = "smalling";
            this.smalling.Size = new System.Drawing.Size(67, 23);
            this.smalling.TabIndex = 19;
            this.smalling.Text = "Smalling";
            this.smalling.UseVisualStyleBackColor = true;
            this.smalling.Click += new System.EventHandler(this.smalling_Click);
            // 
            // btnEqualizator
            // 
            this.btnEqualizator.Location = new System.Drawing.Point(142, 155);
            this.btnEqualizator.Name = "btnEqualizator";
            this.btnEqualizator.Size = new System.Drawing.Size(75, 23);
            this.btnEqualizator.TabIndex = 19;
            this.btnEqualizator.Text = "Equalizator";
            this.btnEqualizator.UseVisualStyleBackColor = true;
            this.btnEqualizator.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonNegativate
            // 
            this.buttonNegativate.Location = new System.Drawing.Point(80, 155);
            this.buttonNegativate.Name = "buttonNegativate";
            this.buttonNegativate.Size = new System.Drawing.Size(56, 23);
            this.buttonNegativate.TabIndex = 14;
            this.buttonNegativate.Text = "Negativate";
            this.buttonNegativate.UseVisualStyleBackColor = true;
            this.buttonNegativate.Click += new System.EventHandler(this.buttonNegativate_Click);
            // 
            // buttonGrayscale
            // 
            this.buttonGrayscale.Location = new System.Drawing.Point(7, 155);
            this.buttonGrayscale.Name = "buttonGrayscale";
            this.buttonGrayscale.Size = new System.Drawing.Size(67, 23);
            this.buttonGrayscale.TabIndex = 13;
            this.buttonGrayscale.Text = "Grayscale";
            this.buttonGrayscale.UseVisualStyleBackColor = true;
            this.buttonGrayscale.Click += new System.EventHandler(this.buttonGrayscale_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Contrast:";
            // 
            // trackLuminosity
            // 
            this.trackLuminosity.Location = new System.Drawing.Point(12, 276);
            this.trackLuminosity.Maximum = 255;
            this.trackLuminosity.Minimum = -255;
            this.trackLuminosity.Name = "trackLuminosity";
            this.trackLuminosity.Size = new System.Drawing.Size(144, 45);
            this.trackLuminosity.TabIndex = 15;
            this.trackLuminosity.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackContrast
            // 
            this.trackContrast.Location = new System.Drawing.Point(12, 347);
            this.trackContrast.Maximum = 150;
            this.trackContrast.Minimum = -120;
            this.trackContrast.Name = "trackContrast";
            this.trackContrast.Size = new System.Drawing.Size(144, 45);
            this.trackContrast.TabIndex = 16;
            this.trackContrast.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Luminozitate:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 473);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackContrast);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.trackLuminosity);
            this.Controls.Add(this.panelDestination);
            this.Controls.Add(this.panelSource);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackLuminosity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackContrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSource;
        private System.Windows.Forms.Panel panelDestination;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TextBox ftjBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGabor;
        private System.Windows.Forms.Button btnFrei;
        private System.Windows.Forms.Button btnSobel;
        private System.Windows.Forms.Button btnRobi;
        private System.Windows.Forms.Button btnKirsch;
        private System.Windows.Forms.Button btnUnsharp;
        private System.Windows.Forms.Button btnFTS;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnMarkov;
        private System.Windows.Forms.TextBox rotBox;
        private System.Windows.Forms.Button ftj;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button smalling;
        private System.Windows.Forms.Button btnEqualizator;
        private System.Windows.Forms.Button buttonNegativate;
        private System.Windows.Forms.Button buttonGrayscale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackLuminosity;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TrackBar trackContrast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBox;
        private System.Windows.Forms.Label regionGrowing;
        private System.Windows.Forms.Button btnThreshold;
        private System.Windows.Forms.Button btnATreshold;
        private System.Windows.Forms.TextBox pragT;
    }
}

