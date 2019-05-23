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
	public partial class outputPathDialog : Form
	{

		public outputPathDialog()
		{
			InitializeComponent();

			cmbExt.Items.Clear();
			cmbExt.Items.Clear();
			cmbExt.Items.Add(".mov");
			cmbExt.Items.Add(".avi");
			cmbExt.Items.Add(".mp4");
			cmbExt.Items.Add(".m4v");
			cmbExt.Items.Add(".tga");
			cmbExt.Items.Add(".png");
			cmbExt.Items.Add(".psd");
			cmbExt.Items.Add(".jpg");
			cmbExt.Items.Add(".tif");
			cmbExt.SelectedIndex = 5;
			cmbKeta.Items.Clear();
			cmbKeta.Items.Add("フレーム番号なし");
			cmbKeta.Items.Add("1桁");
			cmbKeta.Items.Add("2桁");
			cmbKeta.Items.Add("3桁");
			cmbKeta.Items.Add("4桁");
			cmbKeta.Items.Add("5桁");
			cmbKeta.Items.Add("6桁");
			cmbKeta.Items.Add("7桁");
			cmbKeta.Items.Add("8桁");
			cmbKeta.Items.Add("9桁");
			cmbKeta.Items.Add("10桁");
			cmbKeta.SelectedIndex = 5;
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}
		//-----------------------------------------------------------------
		public void SplitName(string n)
		{
			edPath.Text = "";
			edName.Text = "";
			cmbKeta.SelectedIndex = 5;
			cmbExt.Text = "";
			if (n == string.Empty) return;
			edPath.Text = Path.GetDirectoryName(n);
			cmbExt.Text = Path.GetExtension(n);

			string s = Path.GetFileNameWithoutExtension(n);
			int idx0 = s.IndexOf('[');
			int idx1 = s.IndexOf(']');
			cmbKeta.SelectedIndex = 0;
			int k = 0;
			if ((idx0 >= 0) && (idx0 >= 1))
			{
				//aaa[#####]
				//0123456789
				edName.Text = s.Substring(0, idx0);
				string f = s.Substring(idx0 + 1, idx1 - idx0 - 1).Trim();
				if (f != string.Empty)
				{
					for (int i = 0; i < f.Length; i++)
					{
						if (f[i] == '#') k++;
					}
				}
				cmbKeta.SelectedIndex = k;
			}
			else
			{
				edName.Text = s;
			}
			chkEnabled();
		}

		//-----------------------------------------------------------------
		public string makeName()
		{
			string ret = edPath.Text;
			string nn = edName.Text;

			if (nn != string.Empty)
			{
				ret = Path.Combine(ret, nn);
				if (IsMovie(cmbExt.Text) == false)
				{
					char c = nn[nn.Length - 1];
					if (cmbKeta.SelectedIndex > 0)
					{
						if ((c >= '0') && (c <= '9')) ret += "_";
						ret += "[";
						for (int i = 0; i < cmbKeta.SelectedIndex; i++) ret += "#";
						ret += "]";
					}
				}
			}
			ret += cmbExt.Text;
			chkEnabled();
			return ret;
		}
		//-----------------------------------------------------------------

		public string outputPath
		{
			get { return makeName(); }
			set { SplitName(value);}
		}
		//-----------------------------------------------------------------
		private bool chkEnabled()
		{
			bool ret = true;
			if ( Directory.Exists(edPath.Text)== false) ret = false;
			if ( edName.Text.Trim()==string.Empty) ret = false;
			btnOK.Enabled = ret;
			return true;
		}
		//-----------------------------------------------------------------
		private void edPath_TextChanged(object sender, EventArgs e)
		{
			chkEnabled();
			edPreview.Text = makeName();
		}
		//-----------------------------------------------------------------
		private void cmbKeta_SelectedIndexChanged(object sender, EventArgs e)
		{
			chkEnabled();
			edPreview.Text = makeName();
		}
		//-----------------------------------------------------------------
		private void outputPathDialog_DragDrop(object sender, DragEventArgs e)
		{
			string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (fileNames.Length > 0)
			{
				getFileName(fileNames[0]);
			}
		}
		//-----------------------------------------------------------------
		private void outputPathDialog_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				//ファイル以外は受け付けない
				e.Effect = DragDropEffects.None;
		}
		//-----------------------------------------------------------------
		private bool IsMovie(string e)
		{
			if (e == string.Empty) return false;
			string ee = e.ToLower();
			return ((e == ".mov") || (e == ".qt") || (e == ".avi") || (e == ".m4v") || (e == ".m4v"));
		}
		//-----------------------------------------------------------------
		public void getFileName(string path)
		{
			if (Directory.Exists(path) == true)
			{
				edPath.Text = path;
				chkEnabled();
				edPreview.Text = makeName();
				return;
			}
			else if (File.Exists(path) == false)
			{
				return;
			}
			edPath.Text = Path.GetDirectoryName(path);
			cmbExt.Text = Path.GetExtension(path);
			string n = Path.GetFileNameWithoutExtension(path);
			if (IsMovie(cmbExt.Text) == true)
			{
				edName.Text = n;
				cmbKeta.SelectedIndex = 0;
				chkEnabled();
				edPreview.Text = makeName();
				return;

			}


			if (n == string.Empty) return;
			int last = n.Length - 1;
			int idx = -1;
			//bbb_0001
			//012345678901
			for (int i = last; i >= 0; i--)
			{
				char c = n[i];
				if ((c < '0') || (c > '9'))
				{
					idx = i;
					break;
				}
			}
			if (idx == -1)
			{
				edName.Text = n;
				cmbKeta.SelectedIndex = 0;
			}else{
				int keta = last - idx;
				if (keta <= 2)
				{
					edName.Text = n;
					cmbKeta.SelectedIndex = 0;
				}
				else
				{
					edName.Text = n.Substring(0, idx+1);
					cmbKeta.SelectedIndex = keta;
				}

			}
			chkEnabled();
			edPreview.Text = makeName();

			
		}

		private void btnDir_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.SelectedPath = edPath.Text;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				edPath.Text = dlg.SelectedPath;
			}

		}
		//-----------------------------------------------------------------
	}
}
