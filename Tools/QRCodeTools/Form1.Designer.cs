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
			this.picboxQRCodePicture = new System.Windows.Forms.PictureBox();
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
			this.btnScanQRCode = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnSavePicture = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.picboxQRCodePicture)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// picboxQRCodePicture
			// 
			this.picboxQRCodePicture.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picboxQRCodePicture.Location = new System.Drawing.Point(3, 21);
			this.picboxQRCodePicture.Name = "picboxQRCodePicture";
			this.picboxQRCodePicture.Size = new System.Drawing.Size(320, 320);
			this.picboxQRCodePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picboxQRCodePicture.TabIndex = 0;
			this.picboxQRCodePicture.TabStop = false;
			// 
			// txtQRCodeText
			// 
			this.txtQRCodeText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtQRCodeText.Location = new System.Drawing.Point(3, 21);
			this.txtQRCodeText.Multiline = true;
			this.txtQRCodeText.Name = "txtQRCodeText";
			this.txtQRCodeText.ReadOnly = true;
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
			this.groupBox3.Text = "二维码信息";
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
			this.btnScreen.Location = new System.Drawing.Point(282, 41);
			this.btnScreen.Name = "btnScreen";
			this.btnScreen.Size = new System.Drawing.Size(75, 23);
			this.btnScreen.TabIndex = 10;
			this.btnScreen.Text = "截屏";
			this.btnScreen.UseVisualStyleBackColor = true;
			// 
			// btnScanQRCode
			// 
			this.btnScanQRCode.Location = new System.Drawing.Point(283, 81);
			this.btnScanQRCode.Name = "btnScanQRCode";
			this.btnScanQRCode.Size = new System.Drawing.Size(75, 23);
			this.btnScanQRCode.TabIndex = 11;
			this.btnScanQRCode.Text = "扫码";
			this.btnScanQRCode.UseVisualStyleBackColor = true;
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
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(700, 466);
			this.Controls.Add(this.btnSavePicture);
			this.Controls.Add(this.btnScanQRCode);
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
			this.Name = "Form1";
			this.Text = "二维码工具箱";
			((System.ComponentModel.ISupportInitialize)(this.picboxQRCodePicture)).EndInit();
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
		private System.Windows.Forms.Button btnScanQRCode;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnSavePicture;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
	}
}