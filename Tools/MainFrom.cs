﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace Tools
{
	public partial class MainFrom : Form
	{
		
		public MainFrom()
		{
			InitializeComponent();
			IEnumerable<TreeNode> treeNodes = this.InitTreeNodes();
			foreach (TreeNode item in treeNodes)
			{
				this.treeMain.Nodes.Add(item);
			}
		}
		/// <summary>
		/// 初始化节点
		/// </summary>
		/// <returns></returns>
		private IEnumerable<TreeNode> InitTreeNodes()
		{
			try
			{
				List<string> nameSpaces = new List<string>()
				{
					//"Tools.QRCodeTools",
					//当前运行的程序集
					Assembly.GetExecutingAssembly().FullName,
				};
				//父节点集合
				List<TreeNode> treeNodes = new List<TreeNode>();
				foreach (string item in nameSpaces)
				{
					//加载集合中的程序集
					Assembly assembly = Assembly.Load(item);
					//程序集中所有的公开类型
					Type[] types = assembly.GetExportedTypes();
					//父节点
					TreeNode parentNode = new TreeNode();
					foreach (Type type in types)
					{
						//排除MainForm
						if (type == this.GetType()) continue;
						//实例化公开类型对象
						Object obj = assembly.CreateInstance(type.FullName);
						if (obj is Form)
						{
							parentNode.Text = obj.GetType().Namespace;
							Form form = (Form)obj;
							TreeNode chikdNode = new TreeNode() {Text=form.Text,Tag=form };
							parentNode.Nodes.Add(chikdNode);
						}
					}
					treeNodes.Add(parentNode);
				}
				return treeNodes;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void treeMain_AfterSelect(object sender, TreeViewEventArgs e)
		{
			try
			{
				TreeNode treeNode = this.treeMain.SelectedNode;
				if (treeNode.Tag is System.Windows.Forms.Form)
				{
					Form form = treeNode.Tag as System.Windows.Forms.Form;
					form.TopLevel = false;
					TabControl.TabPageCollection tabPageCollection= this.tabShowForm.TabPages;
					foreach (TabPage item in tabPageCollection)
					{
						if (item.Controls.Contains(form))
						{
							this.tabShowForm.SelectedTab = item;
							return;
						}
					}
					TabPage tabPage = new TabPage(form.Text);
					tabPage.Controls.Add(form);
					this.tabShowForm.TabPages.Add(tabPage);
					form.Show();
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}
	}
}