using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Gecko;

namespace Rainpaper
{
	public partial class MainForm : Form
	{
		[DllImport("user32.dll",EntryPoint="FindWindow")]
		private static extern IntPtr FindWindow(string sClass, string sWindow);
		[DllImport("user32.dll",EntryPoint="SendMessageTimeout")]
		private static extern int SendMessageTimeout(IntPtr HWND, uint MSG, IntPtr wParam, IntPtr lParam, uint flags, uint timeout, out IntPtr result);
		[DllImport("user32")] public static extern int EnumWindows(IntPtr lpEnumFunc, IntPtr lParam);
		[DllImport("user32", EntryPoint="FindWindowEx")]
		public static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);
		
		[DllImport("user32.dll")]
		private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
		
		[DllImport("user32")] public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, IntPtr fdwOptions);
		
		[DllImport("user32")] public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
		
		[DllImport("user32")] public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
		 
		public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
		
		IntPtr workerw = IntPtr.Zero;
		GeckoWebBrowser geckoWebBrowser;
		
		public MainForm()
		{
			InitializeComponent();
			
			string url = Prompt.ShowDialog("https://58406979-c515-4181-b3ee-24546dba0f72.htmlpasta.com/", "Please enter the URL");
			if(url=="-1") {
				Environment.Exit(0);
			}
			
			
			IntPtr progman = FindWindow("Progman", null);
			IntPtr result = IntPtr.Zero;
			
			SendMessageTimeout(progman, 0x052C, new IntPtr(0), IntPtr.Zero, 0, 1000, out result);
			
			
			IntPtr p = IntPtr.Zero;
			EnumWindows(new EnumWindowsProc((tophandle, topparamhandle) =>
			{
			    p = FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", "");
			
			    if (p != IntPtr.Zero)
			    {
			        workerw = FindWindowEx(IntPtr.Zero, tophandle, "WorkerW", "");
			    }
			
			    return true;
			}), IntPtr.Zero);
			
			this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
			this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
			
			//*
			Xpcom.Initialize();
			geckoWebBrowser = new GeckoWebBrowser {Dock = DockStyle.Fill};
			
			this.Controls.Add(geckoWebBrowser);
			
			if(url != "-1") {
				geckoWebBrowser.Navigate(url);
				geckoWebBrowser.Load += (s, e) => {SetParent(this.Handle, workerw);};
			}else {
				geckoWebBrowser.Dispose();
				this.Close();
				Application.Exit();
			}
		}

		void t_Tick(object sender, EventArgs e)
		{
			
			MessageBox.Show("Finished Loading");
		}
		
		void ChooseNewClick(object sender, EventArgs e)
		{
			string url = Prompt.ShowDialog("https://58406979-c515-4181-b3ee-24546dba0f72.htmlpasta.com/", "Please enter the URL");
			if(url=="-1") {
				Environment.Exit(0);
			}
			
			geckoWebBrowser.Navigate(url);
		}
		
		void ExitApplicationClick(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}
		void NotifyIconMouseClick(object sender, MouseEventArgs e)
		{
			MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
        	mi.Invoke(notifyIcon, null);
		}
	}
	
	public static class Prompt
	{
	    public static string ShowDialog(string text, string caption)
	    {
	        Form prompt = new Form()
	        {
	            Width = 500,
	            Height = 150,
	            FormBorderStyle = FormBorderStyle.FixedDialog,
	            Text = caption,
	            StartPosition = FormStartPosition.CenterScreen
	        };
	        
	        TextBox textBox = new TextBox() { Left = 50, Top=10, Width=400 };
	        textBox.Text = text;
	        Button confirmation = new Button() { Text = "Ok", Left=50, Width=70, Top=30, DialogResult = DialogResult.Cancel};
	        Button cancel = new Button() { Text = "Exit", Left=120, Width=70, Top=30, DialogResult = DialogResult.OK };
	        Button find = new Button() { Text = "Browse", Left=190, Width=70, Top=30, DialogResult = DialogResult.None };
	        
	        OpenFileDialog ofd = new OpenFileDialog();
	        
	        confirmation.Click += (sender, e) => { prompt.Close(); };
	        prompt.Controls.Add(textBox);
	        prompt.Controls.Add(confirmation);
	        prompt.Controls.Add(cancel);
	        prompt.Controls.Add(find);
	        
	        prompt.AcceptButton = confirmation;
	        prompt.CancelButton = cancel;
			
	        find.Click += (s, e) => {ofd.ShowDialog(); textBox.Text = ofd.FileName;};
	        
	        string url = "-1";
	        
	        confirmation.Click += (s, e) => {url = textBox.Text;};
	        
	        prompt.ShowDialog();
	        
	        return url;
	    }
	}
}
