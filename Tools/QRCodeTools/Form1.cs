using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.QRCodeTools.Commom;

namespace Tools.QRCodeTools
{
	public partial class Form1 : Form
	{
		ScreenForm screenForm = null;
		public Form1()
		{
			InitializeComponent();

			this.InitControl();
		}
		private void InitControl()
		{
			try
			{
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message,"错误");
			}
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
					this.picboxQRCodePicture.Image = this.picboxQRCodePicture.ErrorImage;
					this.txtQRCodeText.Text = "";
					string path = openFileDialog1.FileName;
					this.txtPicturePath.Text = path;
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
					string content = this.txtQRCodeText.Text;
					if (content!="")
					{
						Size size = this.picboxQRCodePicture.Image.Size;
						QRCode.SavePicture(path, content, size, ZXing.BarcodeFormat.QR_CODE, 0, "UTF-8", ZXing.QrCode.Internal.ErrorCorrectionLevel.H, QRCode.GetImageFormat(path));
					}
					this.txtPicturePath.Text = path;
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

				//ThreadStart threadStart = new ThreadStart(()=> this.picboxQRCodePicture.Image = global::Tools.Properties.Resources.await);
				//new Thread(threadStart).Start() ;
				string path = this.txtPicturePath.Text.Trim() ;
				string content = this.txtQRCodeText.Text;
				this.labWidth.Text = "宽:" ;
				this.labHeight.Text = "高:" ;
				this.labPictureSIze.Text = "文件大小:K";
				this.labTextLength.Text = "内容长度:"+ content.Length;
				if (content == "")
				{
					this.picboxQRCodePicture.Image = this.picboxQRCodePicture.ErrorImage;
					return;
				}
				Size size = this.picboxQRCodePicture.Size;
				Image image = QRCode.TextToBitmap(content, size, ZXing.BarcodeFormat.QR_CODE);
				if (File.Exists(path)==true)
				{
					if (this.cheEditFile.Checked == true)
					{
						ImageFormat imageFormat = QRCode.GetImageFormat(path);
						//QRCode.SavePicture(path,image, imageFormat);
						QRCode.SavePicture(path, content, size, ZXing.BarcodeFormat.QR_CODE, 0, "UTF=8",ZXing.QrCode.Internal.ErrorCorrectionLevel.H,imageFormat);
					}
					this.picboxQRCodePicture.Image=image;
					this.labWidth.Text = "宽:" + image.Size.Width.ToString();
					this.labHeight.Text = "高:" + image.Size.Height.ToString();
					this.labPictureSIze.Text = "文件大小:" + (new FileInfo(path).Length / 1024 + "K");
					this.labTextLength.Text = "内容长度:" + content.Length.ToString();
				}
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
					using (Stream stream=File.Open(path,FileMode.Open))
					{
						if (stream.Length==0)
						{
							return;
						}
						this.picboxQRCodePicture.Image = Image.FromStream(stream);
					}
					this.txtQRCodeText.Text = QRCode.BitmapToText((Bitmap)this.picboxQRCodePicture.Image);
				}
				else
				{
					this.picboxQRCodePicture.Image = this.picboxQRCodePicture.ErrorImage;
					this.txtQRCodeText.Text = "";
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
				string content = this.txtQRCodeText.Text;
				if (content != null&& content != "")
				{
					Clipboard.SetText(content);
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

		private void btnScreen_Click(object sender, EventArgs e)
		{
			try
			{
				Rectangle rectangle = Screen.PrimaryScreen.Bounds;
				rectangle.Width = 1920;
				rectangle.Height = 1080;
				Image image = new Bitmap(rectangle.Width,rectangle.Height);
				using (Graphics graphics=Graphics.FromImage(image))
				{
					graphics.CopyFromScreen(0, 0, 0, 0, rectangle.Size);
				}
				if (this.screenForm == null)
				{
					this.screenForm = new ScreenForm(image);
				}
				else
				{
					this.screenForm.BackgroundImage = image;
				}
				this.screenForm.ShowDialog();
			}
			catch (Exception)
			{

				throw;
			}
		}
		private class ScreenForm: Form
		{
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;

			Rectangle rectangle;

			Point startPoint;
			Point endPoint;
			Image backgroundImage = null;

			public ScreenForm(Image image)
			{
				try
				{
					InitializeComponent();
					this.FormBorderStyle = FormBorderStyle.None;
					this.backgroundImage = image;
					this.BackgroundImage = (Image)image.Clone();
				}
				catch (Exception ee)
				{
					MessageBox.Show(ee.Message,"错误");
				}
			}

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
			private void InitializeComponent()
			{
				try
				{
					this.components = new System.ComponentModel.Container();
					this.Size = Screen.PrimaryScreen.Bounds.Size;
					this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
					this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
					this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
					this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseLeave);
				}
				catch (Exception)
				{
					throw;
				}
			}
			private void Form1_KeyPress(object sender, KeyPressEventArgs e)
			{
				try
				{
					if (e.KeyChar == (char)Keys.Escape)
					{
						this.Close();
					}
				}
				catch (Exception ee)
				{
					MessageBox.Show(ee.Message, "错误");
				}
			}
			private void Form1_MouseDown(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					this.startPoint =e.Location;
				}
			}

			private void Form1_MouseUp(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					//this.endPoint= e.Location;
					//if (startPoint.Equals(endPoint))
					//{
					//	return;
					//}
					//Size size = new Size()
					//{
					//	Width = Math.Abs(endPoint.X - startPoint.X),
					//	Height = Math.Abs(endPoint.Y - startPoint.Y),
					//};
					//this.rectangle = new Rectangle()
					//{
					//	Size=size,
					//	Location=this.startPoint,
					//};
					Graphics graphics = Graphics.FromImage(this.BackgroundImage);
					Image image = (Image)this.BackgroundImage.Clone();
					graphics.DrawImage(image,this.rectangle);
					Clipboard.SetImage(image);
					this.Close();
				}
			}
			private void Form1_MouseLeave(object sender, MouseEventArgs e)
			{
				if (e.Button != MouseButtons.Left)
				{
					return;
				}
				else
				{
					this.endPoint = e.Location;
					Size size = new Size()
					{
						Width = Math.Abs(endPoint.X - startPoint.X),
						Height = Math.Abs(endPoint.Y - startPoint.Y),
					};
					this.rectangle = new Rectangle()
					{
						Size = size,
						Location = this.startPoint, 
					};
					Image image = (Image)this.backgroundImage.Clone();
					using (Graphics graphics = Graphics.FromImage(image))
					{
						Color color = Color.Black;
						Pen pen = new Pen(color, 0.2f);
						//graphics.Clear(this.BackColor);
						//this.Invalidate();
						graphics.DrawRectangle(pen, this.rectangle);
					}
					this.BackgroundImage = image;
				}
			}
		}

	}
}
