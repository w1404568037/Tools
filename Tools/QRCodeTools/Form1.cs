using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.QRCodeTools.Commom;

namespace Tools.QRCodeTools
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 打开文件并解码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenPicture_Click(object sender, EventArgs e)
		{
			try
			{
				openFileDialog1.Filter = @"
所有图片| *.bmp; *.ico; *.gif; *.jpeg; *.jpg; *.png; *.tif; *.tiff | 
Windows Bitmap(*.bmp)|*.bmp|
Windows Icon(*.ico)|*.ico|
Graphics Interchange Format (*.gif)|(*.gif)|
JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|
Portable Network Graphics (*.png)|*.png|
Tag Image File Format (*.tif)|*.tif;*.tiff";
				DialogResult result=this.openFileDialog1.ShowDialog();
				if (result== DialogResult.OK)
				{
					string path = openFileDialog1.FileName;
					this.txtPicturePath.Text = path;
					Bitmap bitmap = new Bitmap(File.Open(path, FileMode.Open));

					this.txtQRCodeText.Text = QRCode.BitmapToText(new Bitmap((Image)bitmap.Clone()));
					bitmap.Dispose();
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message,"错误");
			}
		}

		/// <summary>
		/// 保存图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSavePicture_Click(object sender, EventArgs e)
		{
			try
			{
				this.saveFileDialog1.Filter = @"
所有图片| *.bmp; *.ico; *.gif; *.jpeg; *.jpg; *.png; *.tif; *.tiff | 
Windows Bitmap(*.bmp)|*.bmp|
Windows Icon(*.ico)|*.ico|
Graphics Interchange Format (*.gif)|(*.gif)|
JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|
Portable Network Graphics (*.png)|*.png|
Tag Image File Format (*.tif)|*.tif;*.tiff";
				DialogResult result = this.saveFileDialog1.ShowDialog();
				if (result == DialogResult.OK)
				{
					string path = this.saveFileDialog1.FileName;
					this.txtPicturePath.Text = path;
					File.Create(path);
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message,"错误");
			}
		}
		private void txtQRCodeText_TextChanged(object sender, EventArgs e)
		{
			try
			{
				string path = this.txtPicturePath.Text.Trim() ;
				string content = this.txtQRCodeText.Text;
				//QRCode.SavePicture(path, content, new Size(400, 400), ZXing.BarcodeFormat.QR_CODE);
				Image image = QRCode.TextToBitmap(content,new Size(400,400),ZXing.BarcodeFormat.QR_CODE);
				image.Save(path);
				this.labWidth.Text = "宽:"+image.Size.Width.ToString();
				this.labHeight.Text = "高:"+image.Size.Height.ToString();
				this.labPictureSIze.Text = "文件大小:"+(new FileInfo(path).Length / 1024 + "K");
				this.labTextLength.Text ="内容长度:"+ content.Length.ToString();
				this.picboxQRCodePicture.Image = image;
				image.Dispose();
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message,"错误");
			}
		}

		private void txtPicturePath_TextChanged(object sender, EventArgs e)
		{
			try
			{
				string path = this.txtPicturePath.Text.Trim();
				if (File.Exists(path))
				{
					this.txtQRCodeText.ReadOnly = false;
					if (this.txtQRCodeText.Text.Trim() == "")
					{
						return;
					}
					string content = this.txtQRCodeText.Text;
					QRCode.SavePicture(path, content, new Size(400, 400), ZXing.BarcodeFormat.QR_CODE);
					this.picboxQRCodePicture.Image = Image.FromFile(path);
				}
				else
				{
					this.txtQRCodeText.Text = "";
					this.txtQRCodeText.ReadOnly = true;
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message,"错误");
			}
		}

		private void btnCopyText_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.txtQRCodeText.Text!=null&&this.txtQRCodeText.Text!="")
				{
					Clipboard.SetText(this.txtQRCodeText.Text);
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
			}
		}

		private void btnCopyPicture_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.picboxQRCodePicture.Image==null)
				{
					throw new Exception("图片是空的。");
				}
				Clipboard.SetImage(this.picboxQRCodePicture.Image);
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
			}
		}
	}
}
