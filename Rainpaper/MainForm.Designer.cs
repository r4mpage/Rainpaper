/*
 * Created by SharpDevelop.
 * User: Jono
 * Date: 3/05/2019
 * Time: 1:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Rainpaper
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip menu;
		private System.Windows.Forms.ToolStripMenuItem chooseNew;
		private System.Windows.Forms.ToolStripMenuItem exitApplication;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.chooseNew = new System.Windows.Forms.ToolStripMenuItem();
			this.exitApplication = new System.Windows.Forms.ToolStripMenuItem();
			this.menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.menu;
			this.notifyIcon.Icon = global::Rainpaper.Resource1.ico;
			this.notifyIcon.Text = "Paper";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMouseClick);
			// 
			// menu
			// 
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.chooseNew,
			this.exitApplication});
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(175, 48);
			// 
			// chooseNew
			// 
			this.chooseNew.Name = "chooseNew";
			this.chooseNew.Size = new System.Drawing.Size(174, 22);
			this.chooseNew.Text = "Choose New Paper";
			this.chooseNew.Click += new System.EventHandler(this.ChooseNewClick);
			// 
			// exitApplication
			// 
			this.exitApplication.Name = "exitApplication";
			this.exitApplication.Size = new System.Drawing.Size(174, 22);
			this.exitApplication.Text = "Exit";
			this.exitApplication.Click += new System.EventHandler(this.ExitApplicationClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(200, 200);
			this.ControlBox = false;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Rainpaper";
			this.menu.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
