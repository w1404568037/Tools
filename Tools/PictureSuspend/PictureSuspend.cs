using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.QRCodeTools.Commom;

namespace Tools.PictureSuspend
{
	public partial class PictureSuspend : Form
	{
		public PictureSuspend()
		{
			InitializeComponent();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
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
				using (ScreenForm screenForm = new ScreenForm(image))
				{
					screenForm.ShowDialog();
					if (screenForm.bSucceed == true)
					{
						this.pictureBox1.Image = Clipboard.GetImage();
					}
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message, "错误");
			}
		}

		private void PictureSuspend_Load(object sender, EventArgs e)
		{
			//打开当前界面时设置为悬浮窗
			this.ParentForm.TopMost = true;
		}

		private void PictureSuspend_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.ParentForm.TopMost = false;
		}
	}
}
