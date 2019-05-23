using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace aerender_MamiSan
{
	public partial class prefDialog : Form
	{
		string[] basePath = new string[]
 		{
			@"C:\Program Files",
			@"C:\Program Files(x86)"
		};

		string[] AES = new string[]
		{
			@"Adobe\Adobe After Effects CS7\Support Files",
			@"Adobe\Adobe After Effects CS6.5\Support Files",
			@"Adobe\Adobe After Effects CS6\Support Files",
			@"Adobe\Adobe After Effects CS5.5\Support Files",
			@"Adobe\Adobe After Effects CS5\Support Files",
			@"Adobe\Adobe After Effects CS4\Support Files",
			@"Adobe\Adobe After Effects CS3\Support Files",
			@"Adobe\Adobe After Effects 7.0\Support Files",
			@"Adobe\Adobe After Effects 6.5\Support Files"
		};
		private string aerender = "aerender.exe";
		public prefDialog()
		{
			InitializeComponent();
			chkPath();
		}
		//------------------------------------------------------------
		private void chkPath()
		{
			cmbPath.Items.Clear();
			string[] lst = AE.getAerender();
			if (lst.Length > 0)
			{
				for (int i = 0; i < lst.Length; i++)
				{
					cmbPath.Items.Add(lst[i]);
				}
			}
	
		}
		//------------------------------------------------------------
		public string aerenderPath
		{
			get { return cmbPath.Text.Trim(); }
			set
			{
				string n = Path.GetFileName(value).ToLower();
				if (n == aerender)
				{
					if (File.Exists(value) == true)
					{
						cmbPath.Text = value;
					}

				}
			}
		}
		//------------------------------------------------------------
		private void btnSelect_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "aerender.exeを指定して下さい";
			dlg.Filter = "aerender.exe|aerender.exe";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				cmbPath.Text = dlg.FileName;
			}
		}
		//------------------------------------------------------------
	}

}
