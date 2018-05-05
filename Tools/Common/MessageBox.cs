using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Common
{
	internal partial class MessageBox : Form
	{
		private MessageBox()
		{
			InitializeComponent();
		}
		public MessageBox(string text,string caption):this()
		{
			this.label1.Text = text;
			this.Text = caption;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		//public new DialogResult ShowDialog()
		//{
		//	base.ShowDialog();
		//	return this.DialogResult;
		//}
	}
}
