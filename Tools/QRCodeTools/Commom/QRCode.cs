using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode.Internal;

namespace Tools.QRCodeTools.Commom
{
	public class QRCode
	{
		private string _Content;
		private Image _Image;

		/// <summary>
		/// 在设置Content属性也会同步Image属性
		/// </summary>
		public string Content 
		{
			get
			{
				return this._Content;
			}
			set
			{
				try
				{
					this._Content = value;
					if (this._Image == null)
					{
						this._Image = QRCode.TextToBitmap(value,this.ImageSize, BarcodeFormat.QR_CODE);
					}
				}
				catch (Exception)
				{
					this._Content = null;
					throw;
				}
			}
		}
		public Size ImageSize = new Size() {Width=400,Height=400 };
		/// <summary>
		/// 在设置Image属性也会同步Content属性
		/// </summary>
		public Image Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				try
				{
					this._Image = value;
					if (this._Content == null)
					{
						this._Content = QRCode.BitmapToText(new Bitmap(value));
					}
				}
				catch (Exception)
				{
					this._Image = null;
					throw;
				}
			}
		}
		public QRCode()
		{

		}
		/// <summary>
		/// 把Bitmap转换成二维码
		/// </summary>
		/// <param name="bitmap"></param>
		/// <returns></returns>
		public static string BitmapToText(Bitmap bitmap)
		{
			try
			{
				BarcodeReader barcodeReader = new BarcodeReader();
				barcodeReader.Options.CharacterSet = "GB-2312";
				var result = barcodeReader.Decode(bitmap);
				if (result == null)
				{
					throw new Exception("图片解码失败。");
				}
				else
				{
					return result.Text;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		/// <summary>
		/// 把指定图片转换成Bitmap
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static Bitmap ImageToBitmap(Image image)
		{
			try
			{
				Bitmap bitmap = new Bitmap(image);
				return bitmap;
			}
			catch (Exception)
			{
				throw;
			}
		}
		/// <summary>
		/// 保存图片
		/// </summary>
		/// <param name="path"></param>
		/// <param name="image"></param>
		public static void SavePicture(
			string path, Image image, System.Drawing.Imaging.ImageFormat imageFormat= null)
		{
			try
			{
				using (Stream stream = File.Create(path))
				{
					image.Save(stream, imageFormat ?? System.Drawing.Imaging.ImageFormat.Png);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		/// <summary>
		/// 把文本保存为条码
		/// </summary>
		/// <param name="path">保存路径</param>
		/// <param name="content">文本内容</param>
		/// <param name="size">图片大小</param>
		/// <param name="barcodeFormat">条码种类</param>
		/// <param name="margin">外边距</param>
		/// <param name="encoding">编码模式</param>
		/// <param name="errorCorrectionLevel">错误修正等级</param>
		/// <param name="imageFormat">图片类型</param>
		public static void SavePicture(
			string path, string content,Size size, BarcodeFormat barcodeFormat,int margin=0,string encoding = "UTF-8", 
			ErrorCorrectionLevel errorCorrectionLevel = null, ImageFormat imageFormat = null)
		{
			try
			{
				using (Stream stream = File.Create(path))
				{
					Image image = QRCode.TextToBitmap(content,size, barcodeFormat,margin,encoding,errorCorrectionLevel );
					//保存不了Ico文件。。。不知道为什么
					image.Save(stream, imageFormat?? ImageFormat.Png);
					
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		/// <summary>
		/// 把文本转换成Bitmap
		/// </summary>
		/// <param name="content">文本内容</param>
		/// <param name="size">图片大小</param>
		/// <param name="barcodeFormat">条码种类</param>
		/// <param name="margin">外边距</param>
		/// <param name="encoding">编码模式</param>
		/// <param name="errorCorrectionLevel">错误修正等级</param>
		/// <returns></returns>
		public static Bitmap TextToBitmap(
			 string content, Size size, BarcodeFormat barcodeFormat,int margin=0, string encoding= "UTF-8", ErrorCorrectionLevel  errorCorrectionLevel=null)
		{
			try
			{
				//在生成图片之前先处理下Size然后在下方加上数据
				BarcodeWriter barcodeWriter = new BarcodeWriter();
				barcodeWriter.Format = barcodeFormat;
				barcodeWriter.Options.Width = size.Width;
				barcodeWriter.Options.Height = size.Height;
				barcodeWriter.Options.Margin = margin;
				barcodeWriter.Options.Hints.Add(EncodeHintType.CHARACTER_SET, encoding);
				barcodeWriter.Options.Hints.Add(EncodeHintType.ERROR_CORRECTION, errorCorrectionLevel ?? ErrorCorrectionLevel.H);
				///bit矩阵？？
				ZXing.Common.BitMatrix bitMatrix = barcodeWriter.Encode(content);
				Bitmap bitmap = barcodeWriter.Write(bitMatrix);
				RectangleF rectangleF = new RectangleF()
				{
					X = 0,
					Y = bitmap.Size.Height,
					Width = bitmap.Size.Width,
					Height = (bitmap.Size.Height / 10),
				};
				bitmap = (Bitmap)QRCode.QRCodeAddContent(bitmap,content,rectangleF);
				if (bitmap == null)
				{
					throw new Exception("生成二维码失败");
				}
				else
				{
					return bitmap;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		/// <summary>
		/// 在二维码的中添加它的内容的文字
		/// </summary>
		/// <param name="image"></param>
		/// <param name="content"></param>
		public static Image QRCodeAddContent(Image image,string content,RectangleF rectangleF,Font font=null, SolidBrush solidBrush=null, StringFormat stringFormat=null)
		{
			try
			{

				//参数为空时的默认值
				if (font == null)
				{
					font = new Font("黑体", (image.Height / 10) / 2);
				}
				if (solidBrush == null)
				{
					solidBrush = new SolidBrush(Color.Black);
				}
				if (stringFormat == null)
				{
					stringFormat = new StringFormat(StringFormatFlags.FitBlackBox);
				}
				//计算绘制文本所需的大小
				using (Graphics graphics = Graphics.FromImage(image))
				{
					SizeF sizef = graphics.MeasureString(content, font, image.Width, stringFormat);
					rectangleF = new RectangleF()
					{
						X = rectangleF.X,
						Y = rectangleF.Y,
						Width = rectangleF.Width,
						Height = sizef.Height,
					};
				}
				Size newSize = new Size()
				{
					Width = image.Size.Width,
					Height = Convert.ToInt32(image.Height + rectangleF.Height),
				};
				Point point = new Point()
				{
					X = 0,
					Y = 0,
				};
				image = QRCode.ChangImageSize(image, newSize, point);
				using (Graphics graphics = Graphics.FromImage(image))
				{
					graphics.DrawString(content, font, solidBrush, rectangleF, stringFormat);
				}
				return image;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static Image ChangImageSize(Image image,Size size,Point point)
		{
			try
			{
				Bitmap bitmap = new Bitmap(size.Width,size.Height);
				using (Graphics graphics=Graphics.FromImage(bitmap))
				{
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle() { Width=bitmap.Width,Height=bitmap.Height });
					graphics.DrawImage(image, point.X, point.Y,new Rectangle() { Width=image.Width,Height=image.Height }, GraphicsUnit.Pixel);
				}
				return bitmap;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static Image BitmapToImage(Bitmap bitmap)
		{
			try
			{
				return bitmap as Image;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public static ImageFormat GetImageFormat(string path)
		{
			try
			{

				string fileType = new FileInfo(path).Extension.ToUpper();
				ImageFormat imageFormat = null;
				switch (fileType)
				{
					case ".BMP":
						imageFormat = ImageFormat.Bmp;
						break;
					case ".EMF":
						imageFormat = ImageFormat.Emf;
						break;
					case ".EXIF":
						imageFormat = ImageFormat.Exif;
						break;
					case ".GIF":
						imageFormat = ImageFormat.Gif;
						break;
					case ".ICO":
					case ".ICON":
						imageFormat = ImageFormat.Icon;
						break;
					case ".JPEG":
						imageFormat = ImageFormat.Jpeg;
						break;
					case ".MEMORYBMP":
						imageFormat = ImageFormat.MemoryBmp;
						break;
					case ".PNG":
						imageFormat = ImageFormat.Png;
						break;
					case ".TIFF":
						imageFormat = ImageFormat.Tiff;
						break;
					case ".WMF":
						imageFormat = ImageFormat.Wmf;
						break;
					default:
						throw new Exception("保存文件时出错,文件类型为：" + fileType);
				}
				return imageFormat;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
