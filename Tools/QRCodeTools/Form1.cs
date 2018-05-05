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
		public Form1()
		{
			InitializeComponent();
			this.txtQRCodeText.Text="这里输入内容";
			this.InitControl();
		}
		private void InitControl()
		{
			try
			{
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
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
				DialogResult result = this.openFileDialog1.ShowDialog();
				if (result == DialogResult.OK)
				{
					string path = openFileDialog1.FileName;
					if (File.Exists(path)==true)
					{
						this.txtPicturePath.Text = "";
						this.txtPicturePath.Text = path;
					}
					 
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
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
					using (Image image = this.picboxQRCodePicture.Image)
					{
						ImageFormat imageFormat = QRCodeCommon.GetImageFormat(path);
						image.Save(path,imageFormat);
					}
					this.txtPicturePath.Text = path;
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
			}
		}
		private void txtQRCodeText_TextChanged(object sender, EventArgs e)
		{
			try
			{
			
				string path = this.txtPicturePath.Text.Trim();
				string content = this.txtQRCodeText.Text;
				if (content == "")
				{
					this.picboxQRCodePicture.Image = this.picboxQRCodePicture.ErrorImage;
					return;
				}
				Size size = this.picboxQRCodePicture.Size;
				Image image = QRCodeCommon.TextToBitmap(content, size, ZXing.BarcodeFormat.QR_CODE);
				this.picboxQRCodePicture.Image = image;
				this.labWidth.Text = "宽:" + image.Size.Width.ToString();
				this.labHeight.Text = "高:" + image.Size.Height.ToString();
				this.labTextLength.Text = "内容长度:" + content.Length;
				//using (Stream stream = new MemoryStream())
				//{
				//	image.Save(stream, image.RawFormat);
				//	this.labPictureSIze.Text = "图片大小:" + (stream.Length / 1024 + "K");
				//}
				string strPath = DateTime.Now.ToFileTimeUtc().ToString() + ".png";
				image.Save(strPath);
				using (Stream stream=File.OpenRead(strPath))
				{
					this.labPictureSIze.Text = "图片大小:" + (stream.Length / 1024 + "K");
				}
				File.Delete(strPath);
				if (this.cheEditFile.Checked == true)
				{
					if (File.Exists(path) == true)
					{
						ImageFormat imageFormat = QRCodeCommon.GetImageFormat(path);
						image.Save(path, imageFormat);
						//image.Dispose();
					}
					else
					{
						throw new FileNotFoundException("需要修改的文件不存在，请先保存。");
					}
				}

			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
			}
		}

		private void txtPicturePath_TextChanged(object sender, EventArgs e)
		{
			try
			{
				string path = this.txtPicturePath.Text.Trim();
				if (path=="")
				{
					return;
				}
				if (File.Exists(path))
				{
					using (Stream stream = File.Open(path, FileMode.Open))
					{
						if (stream.Length == 0)
						{
							return;
						}
						this.picboxQRCodePicture.Image = Image.FromStream(stream);
					}
					this.txtQRCodeText.Text = QRCodeCommon.ImageToText(this.picboxQRCodePicture.Image);
				}
				else
				{
					this.picboxQRCodePicture.Image = this.picboxQRCodePicture.ErrorImage;
					this.txtQRCodeText.Text = "";
				}
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
				Image image = new Bitmap(rectangle.Width, rectangle.Height);
				using (Graphics graphics = Graphics.FromImage(image))
				{
					graphics.CopyFromScreen(0, 0, 0, 0, rectangle.Size);
				}
				using (ScreenForm screenForm= new ScreenForm(image))
				{
					screenForm.ShowDialog();
					if (screenForm.bSucceed==true)
					{
						this.txtQRCodeText.Text = QRCodeCommon.ImageToText(Clipboard.GetImage());
					}
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
			}
		}
		private void cheEditFile_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.cheEditFile.Checked==true)
				{
					string path = this.txtPicturePath.Text.Trim();
					if (File.Exists(path)==true)
					{
						using (Image image=this.picboxQRCodePicture.Image)
						{
							ImageFormat imageFormat = QRCodeCommon.GetImageFormat(path);
							image.Save(path, imageFormat);
						}
					}
					else
					{
						throw new FileNotFoundException("需要修改的文件不存在，请先保存。");
					}

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
				if (content != null && content != "")
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
				if (this.picboxQRCodePicture.Image == null)
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
		private class ScreenForm : Form
		{
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;

			/// <summary>
			/// 是否成功截图
			/// </summary>
			public bool bSucceed = false;

			/// <summary>
			/// 要绘制的矩形
			/// </summary>
			Rectangle rectangle;

			/// <summary>
			/// 鼠标的开始位置
			/// </summary>
			Point startPoint;
			/// <summary>
			/// 鼠标的现在位置
			/// </summary>
			Point endPoint;

			public ScreenForm(Image image)
			{
				try
				{
					InitializeComponent();
					this.FormBorderStyle = FormBorderStyle.None;
					this.BackgroundImage = image;
					//以下采用双缓冲方式，减少闪烁
					this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
					this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
					this.SetStyle(ControlStyles.UserPaint, true);
				}
				catch (Exception ee)
				{
					MessageBox.Show(ee.Message, "错误");
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
					this.startPoint = e.Location;
				}
				else
				{
					this.Close();
				}
			}

			private void Form1_MouseUp(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					Bitmap bitmap = new Bitmap(this.BackgroundImage);
					bitmap = bitmap.Clone(this.rectangle, PixelFormat.DontCare);
					Clipboard.SetImage(bitmap);
					this.bSucceed = true;
					this.Close();
				}
			}
			private void Form1_MouseLeave(object sender, MouseEventArgs e)
			{
				//重绘窗体
				this.Refresh();
				//在当前位置绘制全屏的十字
				//this.DrawCross(this.CreateGraphics(),e.Location, new Pen(Color.Red, 0.2f));
				if (e.Button == MouseButtons.Left)
				{
					//当前的绘制信息
					string message = "";
					// 绘制信息的容器
					RectangleF messgeRectangleF;
					//绘制信息的布局信息
					StringFormat stringFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);

					this.endPoint = e.Location;
					Size size = new Size()
					{
						Width = endPoint.X - startPoint.X,
						Height = endPoint.Y - startPoint.Y,
					};
					//提示信息
					message = $"Width:{size.Width},Height:{size.Height}";
					//测量提示信息需要的Size
					using (Graphics graphics = this.CreateGraphics())
					{
						SizeF sizeF = this.CreateGraphics().MeasureString(message, new Font("黑体", 10F), 200, stringFormat);
						messgeRectangleF = new RectangleF()
						{
							Size = new Size()
							{
								Width = (int)sizeF.Width,
								Height = (int)sizeF.Height,
							},
						};
					}
					//鼠标在左上角
					if ((endPoint.X < startPoint.X)
						&& (endPoint.Y < startPoint.Y))
					{
						this.rectangle = new Rectangle()
						{
							Size = size,
							Location = this.endPoint,
						};
						messgeRectangleF = new RectangleF()
						{
							Size = messgeRectangleF.Size,
							X = this.endPoint.X - messgeRectangleF.Width,
							Y = this.endPoint.Y - messgeRectangleF.Height,
						};
					}
					//鼠标在左下角
					else if ((endPoint.X < startPoint.X)
						&& (endPoint.Y > startPoint.Y))
					{
						this.rectangle = new Rectangle()
						{
							Size = size,
							Location = new Point()
							{
								X = this.endPoint.X,
								Y = this.startPoint.Y,
							},
						};
						messgeRectangleF = new RectangleF()
						{
							Size = messgeRectangleF.Size,
							X = this.endPoint.X - messgeRectangleF.Width,
							Y = this.endPoint.Y,
						};
					}
					//鼠标在右上角
					else if ((endPoint.X > startPoint.X)
						&& (endPoint.Y < startPoint.Y))
					{
						this.rectangle = new Rectangle()
						{
							Size = size,
							Location = new Point()
							{
								X = this.startPoint.X,
								Y = this.endPoint.Y,
							},
						};
						messgeRectangleF = new RectangleF()
						{
							Size = messgeRectangleF.Size,
							X = this.endPoint.X,
							Y = this.endPoint.Y - messgeRectangleF.Height,
						};
					}
					//鼠标在右下角
					else
					{
						this.rectangle = new Rectangle()
						{
							Size = size,
							Location = this.startPoint,
						};
						messgeRectangleF = new RectangleF()
						{
							Size = messgeRectangleF.Size,
							Location = this.endPoint,
						};
					}
					using (Graphics graphics = this.CreateGraphics())
					{
						Color color = Color.Red;
						Pen pen = new Pen(color, 0.1F);
						//绘制截图矩形
						graphics.DrawRectangle(pen, this.rectangle);
						//绘制截图信息
						Brush brush = new SolidBrush(color);
						graphics.DrawRectangle(pen, messgeRectangleF.X, messgeRectangleF.Y, messgeRectangleF.Width, messgeRectangleF.Height);
						graphics.DrawString(message, new Font("黑体", 10F), brush, messgeRectangleF, stringFormat);
					}
				}
			}
			/// <summary>
			/// 根据当前位置绘制十字
			/// </summary>
			/// <param name="graphics"></param>
			/// <param name="point"></param>
			/// <param name="pen"></param>
			public void DrawCross(Graphics graphics, Point point, Pen pen)
			{
				PointF p1 = new Point(0, point.Y);
				PointF p2 = new Point((int)graphics.DpiX, point.Y);
				PointF p3 = new Point(point.X, 0);
				PointF p4 = new Point(point.X, (int)graphics.DpiY);
				graphics.DrawLine(pen, p1, p2);
				graphics.DrawLine(pen, p3, p4);
				graphics.Dispose();
			}
		}

	}
}
