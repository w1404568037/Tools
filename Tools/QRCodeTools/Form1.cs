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
			this.InitControl();
		}
		/// <summary>
		/// 当前选择的图形码类型
		/// </summary>
		private ZXing.BarcodeFormat barcodeFormat = ZXing.BarcodeFormat.QR_CODE;
		/// <summary>
		/// 一个获取当前键盘按键的钩子
		/// </summary>
		Tools.Common.KeyBordHook keyBordHook = null;

		/// <summary>
		/// 当前程序运行中获取的所有按键
		/// </summary>
		List<Keys> keys = new List<Keys>();
		private void InitControl()
		{
			try
			{
				this.txtWidth.Text = (this.picboxQRCodePicture.Image.Width * 2).ToString();
				this.txtHeight.Text = (this.picboxQRCodePicture.Image.Height * 2).ToString();
				this.txtWidth.LostFocus += this.Size_LostFocus;
				this.txtHeight.LostFocus += this.Size_LostFocus;
				this.txtWidth.TextChanged += this.Size_TextChanged;
				this.txtHeight.LostFocus += this.Size_TextChanged;
				this.txtQRCodeText.Text="这里输入内容";
				string[] barcodeFormats = Enum.GetNames(typeof(ZXing.BarcodeFormat));
				foreach (string item in barcodeFormats)
				{
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
					toolStripMenuItem.Text = item;
					toolStripMenuItem.Tag = Enum.Parse(typeof(ZXing.BarcodeFormat),item);
					toolStripMenuItem.Click += this.OptionGraphicsCodeType;
					this.toolStripMenuItem1.DropDownItems.Add(toolStripMenuItem);

					this.comboBox1.Items.Add(Enum.Parse(typeof(ZXing.BarcodeFormat), item));
				}
				this.comboBox1.SelectedItem= this.barcodeFormat;

				this.keyBordHook = new Common.KeyBordHook();
				this.keyBordHook.OnKeyDownEvent += new KeyEventHandler(this.On_KeyDownEvent);
				this.keyBordHook.OnKeyPressEvent += new KeyPressEventHandler(this.OnKeyPressEvent);
				this.keyBordHook.OnKeyUpEvent += new KeyEventHandler(this.On_KeyDownEvent);
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
				Size size;
				string path = this.txtPicturePath.Text.Trim();
				string content = this.txtQRCodeText.Text;
				if (content == "")
				{
					this.picboxQRCodePicture.Image = this.picboxQRCodePicture.ErrorImage;
					return;
				}
				size = new Size()
				{
					Width = int.Parse(this.txtWidth.Text) ,
					Height = int.Parse(this.txtHeight.Text),
				}; 
				Image image = QRCodeCommon.TextToBitmap(content, size, this.barcodeFormat);
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

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			this.txtQRCodeText.Text = "";
		}
		public void OptionGraphicsCodeType(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if ((toolStripMenuItem != null)
				&&(toolStripMenuItem.Tag is ZXing.BarcodeFormat))
			{
				this.barcodeFormat = (ZXing.BarcodeFormat)toolStripMenuItem.Tag;
				this.txtQRCodeText_TextChanged(this.txtQRCodeText,null);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.barcodeFormat = (ZXing.BarcodeFormat)this.comboBox1.SelectedItem;
			this.txtQRCodeText_TextChanged(this.txtQRCodeText, null);
		}

		private void Size_TextChanged(object sender, EventArgs e)
		{
			try
			{
				TextBox textBox = (TextBox)sender;
				if (textBox.Text.Length > 0)
				{
					textBox.Text = string.Join("", textBox.Text.Where(c => "0123456789".Contains(c))) ;
					int number = int.Parse(textBox.Text);
					if (number > 2000)
					{
						textBox.Text = "2000";
					}
					else if (number<300)
					{
						textBox.Text = "300";
					}
				}
				textBox.Text=textBox.Text.TrimStart('0');
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
			}
		}
		private void Size_LostFocus(object sender, EventArgs e)
		{
			try
			{
				this.txtQRCodeText_TextChanged(this.txtQRCodeText, null);
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
			}
		}

		private void OnKeyPressEvent(object sender, KeyPressEventArgs e)
		{
			char c = e.KeyChar;
		}

		private void On_KeyDownEvent(object sender, KeyEventArgs e)
		{
			 this.keys.Add(e.KeyCode);
		}
	}
}
