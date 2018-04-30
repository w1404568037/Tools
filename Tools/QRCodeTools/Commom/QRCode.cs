using System;
using System.Collections.Generic;
using System.Drawing;
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
