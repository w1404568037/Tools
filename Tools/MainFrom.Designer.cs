﻿namespace Tools
{
	partial class MainFrom
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.treeMain = new System.Windows.Forms.TreeView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tabShowForm = new System.Windows.Forms.TabControl();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.treeMain);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 629);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "可选功能";
			// 
			// treeMain
			// 
			this.treeMain.Location = new System.Drawing.Point(6, 24);
			this.treeMain.Name = "treeMain";
			this.treeMain.Size = new System.Drawing.Size(188, 599);
			this.treeMain.TabIndex = 0;
			this.treeMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMain_AfterSelect);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tabShowForm);
			this.groupBox2.Location = new System.Drawing.Point(218, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(950, 629);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "窗口";
			// 
			// tabShowForm
			// 
			this.tabShowForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabShowForm.Location = new System.Drawing.Point(6, 23);
			this.tabShowForm.Multiline = true;
			this.tabShowForm.Name = "tabShowForm";
			this.tabShowForm.SelectedIndex = 0;
			this.tabShowForm.Size = new System.Drawing.Size(938, 600);
			this.tabShowForm.TabIndex = 0;
			this.tabShowForm.DoubleClick += new System.EventHandler(this.tabShowForm_DoubleClick);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon1.BalloonTipText = "By 星星";
			this.notifyIcon1.BalloonTipTitle = "Tools";
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "Tools";
			this.notifyIcon1.Visible = true;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.contextMenuStrip1.Size = new System.Drawing.Size(211, 56);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(210, 24);
			this.toolStripMenuItem1.Text = "关闭";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// MainFrom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1182, 653);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainFrom";
			this.Text = "Tools";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TreeView treeMain;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TabControl tabShowForm;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		public System.Windows.Forms.NotifyIcon notifyIcon1;
	}
}