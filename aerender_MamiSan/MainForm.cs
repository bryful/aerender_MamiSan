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
	public partial class MainForm : Form
	{
		private string bakFile = "";
		private string prefFile = "";
		//----------------------------------------------------------------------
		public MainForm()
		{
			bakFile = Path.ChangeExtension(Application.ExecutablePath, ".bakup");
			prefFile = Path.ChangeExtension(Application.ExecutablePath, ".pref");
			InitializeComponent();
			aerenderOptBox1.loadPref();
			PrefLoad();
			//aerenderListbox1.loadList(bakFile);
			if (aerenderListbox1.aerenderPath == "")
			{
				string[] sa = AE.getAerender();
				if (sa.Length <= 0)
				{
					MessageBox.Show("環境設定でaerender.exeの場所を指定して下さい。");
				}
				else
				{
					aerenderListbox1.aerenderPath = sa[0];
				}
			}
			OpenFiles(System.Environment.GetCommandLineArgs(),true);
		}
		//----------------------------------------------------------------------
		public void PrefSave()
		{
			SaveFiles sv = new SaveFiles("MamiSun");
			sv.SetStr("aerender", aerenderListbox1.aerenderPath);
			sv.SetInt("Width", this.Width);
			sv.SetInt("Height", this.Height);
			sv.SetInt("Left", this.Left);
			sv.SetInt("Top", this.Top);

			sv.SaveToFile(prefFile);
		}
		//----------------------------------------------------------------------
		public void PrefLoad()
		{
			SaveFiles sv = new SaveFiles("MamiSun");
			sv.LoadFromFile(prefFile);
			aerenderListbox1.aerenderPath = sv.GetStr("aerender","");

			int w, h, t, l;
			w = sv.GetInt("Width", 0);
			h = sv.GetInt("Height", 0);
			t = sv.GetInt("Top", -999);
			l = sv.GetInt("Left", -999);
			this.SuspendLayout();
			if (w >= 520)
			{
				this.Width = w;
			}
			if (h >= 720)
			{
				this.Height = h;
			}
			if (t != -999)
			{
				this.Top = t;

			}
			if (l != -999)
			{
				this.Left = l;
			}
			//中央表示
			int dt = System.Windows.Forms.Screen.GetBounds(this).Top;
			int dl = System.Windows.Forms.Screen.GetBounds(this).Left;
			int dh = System.Windows.Forms.Screen.GetBounds(this).Height;
			int dw = System.Windows.Forms.Screen.GetBounds(this).Width;
			if ((this.Left <= dl) || (this.Top <= dt))
			{
				this.Top = dt + (dh - this.Height) / 2;
				this.Left  = dl + (dw - this.Width) / 2;
			}
			this.ResumeLayout();
		}
		//----------------------------------------------------------------------
		private void addAepMenu_Click(object sender, EventArgs e)
		{
			aerenderListbox1.addAeps();
		}
		//----------------------------------------------------------------------
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			aerenderOptBox1.savePref();
			aerenderListbox1.saveList(bakFile);

			PrefSave();
		}
		//----------------------------------------------------------------------
		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				//ファイル以外は受け付けない
				e.Effect = DragDropEffects.None;

		}
		//----------------------------------------------------------------------
		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			OpenFiles(fileName,false);
		}

		private void loadAOMMenu_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "出力モジュール設定ファイル(*.aom)の読み込み";
			dlg.Filter = "出力モジュール設定ファイル(*.aom)|*.aom";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				aerenderOptBox1.LoadAOM(dlg.FileName);
			}
		}

		private void loadARSMenu_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "レンダリング設定ファイル(*.ars)の読み込み";
			dlg.Filter = "レンダリング設定ファイル(*.ars)|*.ars";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				aerenderOptBox1.LoadARS(dlg.FileName);
			}

		}
		//----------------------------------------------------------------------
		private void prefMenu_Click(object sender, EventArgs e)
		{
			prefDialog dlg = new prefDialog();
			dlg.aerenderPath = aerenderListbox1.aerenderPath;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				aerenderListbox1.aerenderPath = dlg.aerenderPath;
			}

			

		}
		//----------------------------------------------------------------------
		private void exportBatchMenu_Click(object sender, EventArgs e)
		{
			if (aerenderListbox1.Count <= 0)
			{
				MessageBox.Show("aepが登録されていません");
				return;
			}
			aerenderListbox1.saveList(bakFile);
			aerenderListbox1.exportBatch();
		}

		private void execBatchMenu_Click(object sender, EventArgs e)
		{
			if (aerenderListbox1.Count <= 0)
			{
				//MessageBox.Show("aepが登録されていません");
				//return;
			}
			aerenderListbox1.saveList(bakFile);
			aerenderListbox1.excBatch();

		}

		private void selectALLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aerenderListbox1.SelectALL();
		}

		//----------------------------------------------------------------------
		private void aerenderListbox1_ItemChanged(object sender, EventArgs e)
		{
			exportBatchMenu.Enabled =
				execBatchMenu.Enabled =
				btnExportBatch.Enabled =
				btnExecBatch.Enabled =
				selectALLMenu.Enabled =
				clearALLMenu.Enabled =
				(aerenderListbox1.Count > 0);

		}

		private void aerenderListbox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void versionMenu_Click(object sender, EventArgs e)
		{
			(new versionDialog()).ShowDialog();
		}
		//----------------------------------------------------------------------
		public void OpenFiles(string[] lst, bool isClear)
		{
			if (lst.Length <= 0) return;
			string omP = "";
			string rsP = "";
			List<string> aeps = new List<string>();
			for (int i = 0; i < lst.Length; i++)
			{
				string e = Path.GetExtension(lst[i]).ToLower();
				if (e == ".aep")
				{
					if (File.Exists(lst[i]) == true)
						aeps.Add(lst[i]);
				}
				else if ((e == ".aom") && (omP == ""))
				{
					if (File.Exists(lst[i]) == true)
						omP = lst[i];
				}
				else if ((e == ".ars") && (rsP == ""))
				{
					if (File.Exists(lst[i]) == true)
						rsP = lst[i];
				}
			}
			if (omP != "")
			{
					aerenderOptBox1.LoadAOM(omP);
			}
			if (rsP != "")
			{
					aerenderOptBox1.LoadARS(rsP);
			}
			if (aeps.Count > 0)
			{
				if (isClear == true)
					aerenderListbox1.Clear();
				aerenderListbox1.addAeps(aeps.ToArray());
			}
		}

		private void clearALLMenu_Click(object sender, EventArgs e)
		{
			aerenderListbox1.saveList(bakFile);
			aerenderListbox1.Clear();
		}
	}
}
