namespace Tools.QRCodeTools
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.picboxQRCodePicture = new System.Windows.Forms.PictureBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtQRCodeText = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOpenPicture = new System.Windows.Forms.Button();
			this.txtPicturePath = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labHeight = new System.Windows.Forms.Label();
			this.labPictureSIze = new System.Windows.Forms.Label();
			this.labTextLength = new System.Windows.Forms.Label();
			this.labWidth = new System.Windows.Forms.Label();
			this.btnCopyText = new System.Windows.Forms.Button();
			this.btnCopyPicture = new System.Windows.Forms.Button();
			this.btnScreen = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnSavePicture = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.cheEditFile = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtWidth = new System.Windows.Forms.TextBox();
			this.txtHeight = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picboxQRCodePicture)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// picboxQRCodePicture
			// 
			this.picboxQRCodePicture.ContextMenuStrip = this.contextMenuStrip1;
			this.picboxQRCodePicture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picboxQRCodePicture.ErrorImage = global::Tools.Properties.Resources.lodging;
			this.picboxQRCodePicture.Image = global::Tools.Properties.Resources.lodging;
			this.picboxQRCodePicture.Location = new System.Drawing.Point(3, 21);
			this.picboxQRCodePicture.Name = "picboxQRCodePicture";
			this.picboxQRCodePicture.Size = new System.Drawing.Size(320, 320);
			this.picboxQRCodePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picboxQRCodePicture.TabIndex = 0;
			this.picboxQRCodePicture.TabStop = false;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(184, 100);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 24);
			this.toolStripMenuItem1.Text = "选择图形码类型";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 24);
			this.toolStripMenuItem2.Text = "复制图片";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.btnCopyPicture_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(183, 24);
			this.toolStripMenuItem3.Text = "复制图片内容";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.btnCopyText_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(183, 24);
			this.toolStripMenuItem4.Text = "清除图片";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
			// 
			// txtQRCodeText
			// 
			this.txtQRCodeText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtQRCodeText.Location = new System.Drawing.Point(3, 21);
			this.txtQRCodeText.Multiline = true;
			this.txtQRCodeText.Name = "txtQRCodeText";
			this.txtQRCodeText.Size = new System.Drawing.Size(345, 320);
			this.txtQRCodeText.TabIndex = 1;
			this.txtQRCodeText.TextChanged += new System.EventHandler(this.txtQRCodeText_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.picboxQRCodePicture);
			this.groupBox1.Location = new System.Drawing.Point(364, 110);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(326, 344);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "二维码图片";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtQRCodeText);
			this.groupBox2.Location = new System.Drawing.Point(9, 110);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(351, 344);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "二维码内容";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 15);
			this.label1.TabIndex = 4;
			this.label1.Text = "图片路径";
			// 
			// btnOpenPicture
			// 
			this.btnOpenPicture.Location = new System.Drawing.Point(530, 13);
			this.btnOpenPicture.Name = "btnOpenPicture";
			this.btnOpenPicture.Size = new System.Drawing.Size(75, 23);
			this.btnOpenPicture.TabIndex = 5;
			this.btnOpenPicture.Text = "打开图片";
			this.btnOpenPicture.UseVisualStyleBackColor = true;
			this.btnOpenPicture.Click += new System.EventHandler(this.btnOpenPicture_Click);
			// 
			// txtPicturePath
			// 
			this.txtPicturePath.Location = new System.Drawing.Point(82, 10);
			this.txtPicturePath.Name = "txtPicturePath";
			this.txtPicturePath.Size = new System.Drawing.Size(442, 25);
			this.txtPicturePath.TabIndex = 6;
			this.txtPicturePath.TextChanged += new System.EventHandler(this.txtPicturePath_TextChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.labHeight);
			this.groupBox3.Controls.Add(this.labPictureSIze);
			this.groupBox3.Controls.Add(this.labTextLength);
			this.groupBox3.Controls.Add(this.labWidth);
			this.groupBox3.Location = new System.Drawing.Point(457, 51);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(230, 63);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "图片信息";
			// 
			// labHeight
			// 
			this.labHeight.AutoSize = true;
			this.labHeight.Location = new System.Drawing.Point(6, 45);
			this.labHeight.Name = "labHeight";
			this.labHeight.Size = new System.Drawing.Size(61, 15);
			this.labHeight.TabIndex = 3;
			this.labHeight.Text = "高：100";
			// 
			// labPictureSIze
			// 
			this.labPictureSIze.AutoSize = true;
			this.labPictureSIze.Location = new System.Drawing.Point(103, 45);
			this.labPictureSIze.Name = "labPictureSIze";
			this.labPictureSIze.Size = new System.Drawing.Size(115, 15);
			this.labPictureSIze.TabIndex = 2;
			this.labPictureSIze.Text = "文件大小:100KB";
			// 
			// labTextLength
			// 
			this.labTextLength.AutoSize = true;
			this.labTextLength.Location = new System.Drawing.Point(103, 21);
			this.labTextLength.Name = "labTextLength";
			this.labTextLength.Size = new System.Drawing.Size(99, 15);
			this.labTextLength.TabIndex = 1;
			this.labTextLength.Text = "内容长度:100";
			// 
			// labWidth
			// 
			this.labWidth.AutoSize = true;
			this.labWidth.Location = new System.Drawing.Point(6, 21);
			this.labWidth.Name = "labWidth";
			this.labWidth.Size = new System.Drawing.Size(61, 15);
			this.labWidth.TabIndex = 0;
			this.labWidth.Text = "宽：100";
			// 
			// btnCopyText
			// 
			this.btnCopyText.Location = new System.Drawing.Point(15, 81);
			this.btnCopyText.Name = "btnCopyText";
			this.btnCopyText.Size = new System.Drawing.Size(75, 23);
			this.btnCopyText.TabIndex = 8;
			this.btnCopyText.Text = "复制文本";
			this.btnCopyText.UseVisualStyleBackColor = true;
			this.btnCopyText.Click += new System.EventHandler(this.btnCopyText_Click);
			// 
			// btnCopyPicture
			// 
			this.btnCopyPicture.Location = new System.Drawing.Point(376, 81);
			this.btnCopyPicture.Name = "btnCopyPicture";
			this.btnCopyPicture.Size = new System.Drawing.Size(75, 23);
			this.btnCopyPicture.TabIndex = 9;
			this.btnCopyPicture.Text = "复制图片";
			this.btnCopyPicture.UseVisualStyleBackColor = true;
			this.btnCopyPicture.Click += new System.EventHandler(this.btnCopyPicture_Click);
			// 
			// btnScreen
			// 
			this.btnScreen.Location = new System.Drawing.Point(285, 79);
			this.btnScreen.Name = "btnScreen";
			this.btnScreen.Size = new System.Drawing.Size(75, 23);
			this.btnScreen.TabIndex = 10;
			this.btnScreen.Text = "截屏";
			this.btnScreen.UseVisualStyleBackColor = true;
			this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.RestoreDirectory = true;
			// 
			// btnSavePicture
			// 
			this.btnSavePicture.Location = new System.Drawing.Point(611, 13);
			this.btnSavePicture.Name = "btnSavePicture";
			this.btnSavePicture.Size = new System.Drawing.Size(75, 23);
			this.btnSavePicture.TabIndex = 12;
			this.btnSavePicture.Text = "保存图片";
			this.btnSavePicture.UseVisualStyleBackColor = true;
			this.btnSavePicture.Click += new System.EventHandler(this.btnSavePicture_Click);
			// 
			// cheEditFile
			// 
			this.cheEditFile.AutoSize = true;
			this.cheEditFile.Font = new System.Drawing.Font("宋体", 7F);
			this.cheEditFile.Location = new System.Drawing.Point(376, 56);
			this.cheEditFile.Name = "cheEditFile";
			this.cheEditFile.Size = new System.Drawing.Size(75, 17);
			this.cheEditFile.TabIndex = 2;
			this.cheEditFile.Text = "编辑文件";
			this.cheEditFile.UseVisualStyleBackColor = true;
			this.cheEditFile.CheckedChanged += new System.EventHandler(this.cheEditFile_CheckedChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(100, 51);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 23);
			this.comboBox1.TabIndex = 13;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 15);
			this.label2.TabIndex = 14;
			this.label2.Text = "图形码种类";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(97, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 15);
			this.label3.TabIndex = 15;
			this.label3.Text = "宽";
			// 
			// txtWidth
			// 
			this.txtWidth.Location = new System.Drawing.Point(124, 80);
			this.txtWidth.Name = "txtWidth";
			this.txtWidth.Size = new System.Drawing.Size(57, 25);
			this.txtWidth.TabIndex = 17;
			this.txtWidth.TextChanged += new System.EventHandler(this.Size_TextChanged);
			// 
			// txtHeight
			// 
			this.txtHeight.Location = new System.Drawing.Point(212, 80);
			this.txtHeight.Name = "txtHeight";
			this.txtHeight.Size = new System.Drawing.Size(57, 25);
			this.txtHeight.TabIndex = 19;
			this.txtHeight.TextChanged += new System.EventHandler(this.Size_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(185, 85);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(22, 15);
			this.label4.TabIndex = 18;
			this.label4.Text = "高";
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(700, 466);
			this.Controls.Add(this.txtHeight);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtWidth);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.cheEditFile);
			this.Controls.Add(this.btnSavePicture);
			this.Controls.Add(this.btnScreen);
			this.Controls.Add(this.btnCopyPicture);
			this.Controls.Add(this.btnCopyText);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.txtPicturePath);
			this.Controls.Add(this.btnOpenPicture);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "QRCodeTools";
			((System.ComponentModel.ISupportInitialize)(this.picboxQRCodePicture)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picboxQRCodePicture;
		private System.Windows.Forms.TextBox txtQRCodeText;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOpenPicture;
		private System.Windows.Forms.TextBox txtPicturePath;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label labHeight;
		private System.Windows.Forms.Label labPictureSIze;
		private System.Windows.Forms.Label labTextLength;
		private System.Windows.Forms.Label labWidth;
		private System.Windows.Forms.Button btnCopyText;
		private System.Windows.Forms.Button btnCopyPicture;
		private System.Windows.Forms.Button btnScreen;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnSavePicture;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.CheckBox cheEditFile;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.Label label4;
	}
}