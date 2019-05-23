using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace aerender_MamiSan
{
	public partial class aerenderOptBox : UserControl
	{
		private aerenderListbox _list = null;
		private string [] OMtemplates = new string[0];
		private string[] RStemplates = new string[0];

		private aerenderOpt _opt = new aerenderOpt("");
		private bool editFlag = false;
		public event EventHandler SetClicked;
		public event EventHandler ChkClicked;

		//-------------------------------------------------
		protected virtual void OnSetClicked(EventArgs e)
		{
			if (SetClicked != null)
			{
				SetClicked(this, e);
			}
		}
		//-------------------------------------------------
		protected virtual void OnChkClicked(EventArgs e)
		{
			if (ChkClicked != null)
			{
				ChkClicked(this, e);
			}
		}
		//-------------------------------------------------
		public aerenderOptBox()
		{
			InitializeComponent();
			groupBox1.Dock = DockStyle.Fill;
			setOMtemplate(OMtemplates);
			setRStemplate(RStemplates);
			Clear();
			editFlag = false;
			chkEnabled();
		}
		//-------------------------------------------------
		public void savePref()
		{
			string path = Path.ChangeExtension(Application.ExecutablePath, ".lrs");
			string s = "";
			if (cmbRStemplate.Items.Count > 0)
			{
				for (int i = 0; i < cmbRStemplate.Items.Count; i++)
				{
					s += cmbRStemplate.Items[i].ToString() + "\r\n";
				}
			}
			File.WriteAllText(path, s, Encoding.GetEncoding("utf-8"));
			
			path = Path.ChangeExtension(Application.ExecutablePath, ".lom");
			s = "";
			if (cmbOMtemplate.Items.Count > 0)
			{
				for (int i = 0; i < cmbOMtemplate.Items.Count; i++)
				{
					s += cmbOMtemplate.Items[i].ToString() + "\r\n";
				}
			}
			File.WriteAllText(path, s, Encoding.GetEncoding("utf-8"));
			his1.save();
		}
		//-------------------------------------------------------
		public void loadPref()
		{
			string path = Path.ChangeExtension(Application.ExecutablePath, ".lrs");
			if (File.Exists(path) == true)
			{
				string[] lines = File.ReadAllLines(path, Encoding.GetEncoding("utf-8"));
				setRStemplate(lines);
			}
			path = Path.ChangeExtension(Application.ExecutablePath, ".lom");
			if (File.Exists(path) == true)
			{
				string[] lines = File.ReadAllLines(path, Encoding.GetEncoding("utf-8"));
				setOMtemplate(lines);
			}
			his1.load();
		}

		//-------------------------------------------------
		public void chkEnabled()
		{
			if (_list != null)
			{
				if ((editFlag == true)&&(_list.TargetList==true))
				{
					btnSet.Enabled = true;
				}
				else
				{
					btnSet.Enabled = false;
				}
			}
			else
			{
				btnSet.Enabled = false;
			}
		}
		//-------------------------------------------------
		public void Clear()
		{
			_opt.ClearALL();
			dispOpt();


		}
		//-------------------------------------------------
		private void dispOpt()
		{
			edProject.Text = _opt.Project;
			cmbRtarget.SelectedIndex = (int)_opt.renderTarget;
			cmbComp.Text = _opt.comp;
			cmbRQindex.SelectedIndex = ((int)_opt.rqindex)-1;
			cbOutput.Checked = _opt.outputON;
			cmbOutput.Text = _opt.output;

			cbOMtemplate.Checked = _opt.OMtemplateON;
			cmbOMtemplate.Text = _opt.OMtemplateName;
			cbRStemplate.Checked = _opt.RStemplateON;
			cmbRStemplate.Text = _opt.RStemplateName;
			cbMem_usage.Checked = _opt.mem_usageON;
			cmbImage_cache_percent.Text = _opt.image_cache_percent.ToString();
			cmbMax_mem_percent.Text = _opt.max_mem_percent.ToString();

			cbStart.Checked = _opt.start_frameON;
			cmbStart.Text = _opt.start_frame.ToString();
			cbEnd.Checked = _opt.end_frameON;
			cmbEnd.Text = _opt.end_frame.ToString();
			cbIncrement.Checked = _opt.incrementON;
			cmbIncrement.Text = _opt.increment.ToString();

			cbLog.Checked = _opt.logON;
			cmbLog.Text = _opt.log;
			cbSound.Checked = _opt.sound_flag;
			cbReuse.Checked = _opt.reuse;

			cbClose.Checked = _opt.closeOn;
			cmbClose.SelectedIndex = (int)_opt.close;
			cbVerbose.Checked = _opt.verboseOn;
			cmbVerbose_flag.SelectedIndex = (int)_opt.verbose_flag;
			cbMp.Checked = _opt.mpOn;
			cmbMp.SelectedIndex = (int)_opt.mp_enable_flag;

		}
		//-------------------------------------------------
		private bool ToOpt()
		{
			_opt.renderTarget = (renderTarget)cmbRtarget.SelectedIndex;
			_opt.comp = cmbComp.Text;
			if (_opt.renderTarget == renderTarget.comp)
			{
				if (_opt.comp == string.Empty)
				{
					MessageBox.Show("コンポ名が記入されていません！");
					return false;
				}
			}

			int v = -1;
			if (int.TryParse(cmbRQindex.Text, out v) == true)
			{
				_opt.rqindex = v;
			}
			else
			{
				_opt.rqindex = -1;
			}
			if ( v<=0)
			{
				if (_opt.renderTarget == renderTarget.rqindex)
				{
					MessageBox.Show("RQインデックスが不正です！");
					return false;
				}
				else
				{
					_opt.rqindex = 1;
				}
			}

			_opt.outputON = cbOutput.Checked;
			_opt.output = cmbOutput.Text;
			if (_opt.outputON == true)
			{
				if (_opt.output == "")
				{
					MessageBox.Show("outputが入力されていません！");
					return false;
				}
				if (Directory.Exists(Path.GetDirectoryName(_opt.output)) == false)
				{
					MessageBox.Show("保存先フォルダが存在しません！");
					return false;
				}
			}

			_opt.OMtemplateON = cbOMtemplate.Checked;
			_opt.OMtemplateName = cmbOMtemplate.Text;
			if (_opt.OMtemplateON == true)
			{
				if (_opt.OMtemplateName == string.Empty)
				{
					MessageBox.Show("OMtemplateが指定されていません！");
					return false;
				}
			}
			_opt.RStemplateON = cbRStemplate.Checked;
			_opt.RStemplateName = cmbRStemplate.Text;
			if (_opt.RStemplateON == true)
			{
				if (_opt.RStemplateName == string.Empty)
				{
					MessageBox.Show("RStemplateが指定されていません！");
					return false;
				}
			}
			_opt.mem_usageON = cbMem_usage.Checked;
			_opt.image_cache_percent = -1;
			_opt.max_mem_percent = -1;
			v = 100;
			if (int.TryParse(cmbImage_cache_percent.Text, out v) == true)
			{
				_opt.image_cache_percent = v;
			}
			v = 100;
			if (int.TryParse(cmbMax_mem_percent.Text, out v) == true)
			{
				_opt.max_mem_percent = v;
			}
			if (_opt.mem_usageON == true)
			{
				if ((_opt.image_cache_percent <= 0) || (_opt.image_cache_percent > 100))
				{
					MessageBox.Show("image_cache_percentの値が不正です！");
					return false;
				}
				if ((_opt.max_mem_percent <= 0) || (_opt.max_mem_percent > 100))
				{
					MessageBox.Show("max_mem_percentの値が不正です！");
					return false;
				}
			}
			else
			{
				if ((_opt.image_cache_percent <= 0) || (_opt.image_cache_percent > 100))
				{
					_opt.image_cache_percent = 100;
				}
				if ((_opt.max_mem_percent <= 0) || (_opt.max_mem_percent > 100))
				{
					_opt.max_mem_percent = 100;
				}
			}

			_opt.start_frameON = cbStart.Checked;
			_opt.start_frame = 0;
			if (int.TryParse(cmbStart.Text, out v) == true)
			{
				_opt.start_frame = v;
			}
			_opt.end_frameON = cbEnd.Checked;
			_opt.end_frame = 0;
			if (int.TryParse(cmbEnd.Text, out v) == true)
			{
				_opt.end_frame = v;
			}
			_opt.incrementON = cbIncrement.Checked;
			_opt.increment = 1;
			if (int.TryParse(cmbIncrement.Text, out v) == true)
			{
				_opt.increment = v;
			}

			_opt.logON = cbLog.Checked;
			_opt.log = cmbLog.Text;
			_opt.sound_flag = cbSound.Checked;
			_opt.reuse = cbReuse.Checked;

			_opt.closeOn = cbClose.Checked;
			_opt.close = (closeFlag)cmbClose.SelectedIndex;
			_opt.verboseOn = cbVerbose.Checked;
			_opt.verbose_flag = (verboseFlag)cmbVerbose_flag.SelectedIndex;
			_opt.mpOn = cbMp.Checked;
			_opt.mp_enable_flag = (mp_enableFlag)cmbMp.SelectedIndex;

			return true;

		}
		//-------------------------------------------------
		public void setOpt(aerenderOpt op)
		{
			_opt.Copy(op);
			dispOpt();
			editFlag = false;
			chkEnabled();
		}
		//-------------------------------------------------
		public void ClearALL()
		{
			_opt.ClearALL();
			dispOpt();
			editFlag = false;
			chkEnabled();
		}
		//-------------------------------------------------
		public aerenderOpt aerenderOpt
		{
			get { return _opt; }
			set {setOpt(value);}
			
		}
		//-------------------------------------------------
		public aerenderListbox aerenderListbox
		{
			get { return _list; }
			set
			{
				_list = value;
			}
		}
		//-------------------------------------------------
		public void setOMtemplate(string[] ary)
		{
			OMtemplates = ary;
			cmbOMtemplate.Items.Clear();
			if (ary.Length > 0)
			{
				for (int i = 0; i < ary.Length; i++)
				{
					if (ary[i] != string.Empty)
					{
						cmbOMtemplate.Items.Add(ary[i]);
					}
				}
			}
		}
		//-------------------------------------------------
		public void setRStemplate(string[] ary)
		{
			RStemplates = ary;
			cmbRStemplate.Items.Clear();
			if (ary.Length > 0)
			{
				for (int i = 0; i < ary.Length; i++)
				{
					if (ary[i] != string.Empty)
					{
						cmbRStemplate.Items.Add(ary[i]);
					}
				}
			}
		}
		//-------------------------------------------------------------------
		public void LoadARS(string path)
		{
			ARS_OM rs = new ARS_OM(path,ARS_OMmode.ars);
			if (rs.Length > 0)
			{
				setRStemplate(rs.Names);
			}
		}
		//-------------------------------------------------------------------
		public void LoadAOM(string path)
		{
			ARS_OM rs = new ARS_OM(path, ARS_OMmode.aom);
			if (rs.Length > 0)
			{
				setOMtemplate(rs.Names);
			}
		}
		//-------------------------------------------------------------------
		private void suji_KeyPress(object sender, KeyPressEventArgs e)
		{
			char c = e.KeyChar;
			if (((c >= '0') && (c <= '9')) || (c == '\b'))
			{
			}
			else
			{
				e.Handled = true;
			}

		}
		//-------------------------------------------------
		private void popup_TextChanged(object sender, EventArgs e)
		{
			editFlag = true;
			chkEnabled();
		}
		//-------------------------------------------------
		private void btnDef_Click(object sender, EventArgs e)
		{
			Clear();
			editFlag = true;
			chkEnabled();
			his1.push();
		}
		//-------------------------------------------------
		private void btnSet_Click(object sender, EventArgs e)
		{
			if (editFlag == false) return;
			if (ToOpt() == true)
			{
				editFlag = false;
				chkEnabled();
				his1.push();
				OnSetClicked(new EventArgs());
			}
		}
		//-------------------------------------------------
		public void push()
		{
			his1.push();
		}
		//-------------------------------------------------
		private void btnCgeck_Click(object sender, EventArgs e)
		{
			if ( (ToOpt() == true)&&(_list != null))
			{
				string s = _opt.cmdline(_list.aerenderPath);

				MessageBox.Show(s,"オプションの確認");
				his1.push();
			}
		}
		//-------------------------------------------------
		public bool BtnSetEnabled
		{
			get { return btnSet.Enabled; }
		}
		//-------------------------------------------------
		private void cmbRtarget_SelectedValueChanged(object sender, EventArgs e)
		{
			int idx = cmbRtarget.SelectedIndex;
			lbComp.Enabled =
			cmbComp.Enabled =
			lbRQindex.Enabled =
			cmbRQindex.Enabled = false;
			if (idx == 2)
			{
				lbComp.Enabled =
				cmbComp.Enabled = true;
			}
			else if (idx == 3)
			{
				lbRQindex.Enabled =
				cmbRQindex.Enabled = true;
			}
			editFlag = true;
			chkEnabled();
		}

		//-------------------------------------------------
		private void cbOutput_CheckedChanged(object sender, EventArgs e)
		{
			btnOutput.Enabled =
				cmbOutput.Enabled = cbOutput.Checked;
			editFlag = true;
			chkEnabled();
			editFlag = true;
			chkEnabled();
		}
		//-------------------------------------------------
		private void cbMem_usage_CheckedChanged(object sender, EventArgs e)
		{
			lbimage_cache_percent.Enabled =
				cmbImage_cache_percent.Enabled =
				lbmax_mem_percent.Enabled =
				cmbMax_mem_percent.Enabled = cbMem_usage.Checked;
			editFlag = true;
			chkEnabled();
		}

		//-------------------------------------------------
		private void cbStart_CheckedChanged(object sender, EventArgs e)
		{
			cmbStart.Enabled = cbStart.Checked;
			editFlag = true;
			chkEnabled();
		}
		//-------------------------------------------------
		private void cbEnd_CheckedChanged(object sender, EventArgs e)
		{
			cmbEnd.Enabled = cbEnd.Checked;
			editFlag = true;
			chkEnabled();
		}
		//-------------------------------------------------
		private void cbIncrement_CheckedChanged(object sender, EventArgs e)
		{
			cmbIncrement.Enabled = cbIncrement.Checked;
			editFlag = true;
			chkEnabled();
		}

		//-------------------------------------------------
		private void cbLog_CheckedChanged(object sender, EventArgs e)
		{
			btnLog.Enabled =
				cmbLog.Enabled = cbLog.Checked;
			editFlag = true;
			chkEnabled();
		}
		//-------------------------------------------------
		private void cbOMtemplate_CheckedChanged(object sender, EventArgs e)
		{
			cmbOMtemplate.Enabled = cbOMtemplate.Checked;
			editFlag = true;
			chkEnabled();
		}

		private void cbRStemplate_CheckedChanged(object sender, EventArgs e)
		{
			cmbRStemplate.Enabled = cbRStemplate.Checked;
			editFlag = true;
			chkEnabled();
		}

		private void cbClose_CheckedChanged(object sender, EventArgs e)
		{
			cmbClose.Enabled = cbClose.Checked;
			editFlag = true;
			chkEnabled();
		}

		private void cbVerbose_CheckedChanged(object sender, EventArgs e)
		{
			cmbVerbose_flag.Enabled = cbVerbose.Checked;
			editFlag = true;
			chkEnabled();
		}

		private void cbMp_CheckedChanged(object sender, EventArgs e)
		{
			cmbMp.Enabled = cbMp.Checked;
			editFlag = true;
			chkEnabled();
		}

		private void btnLog_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "logファイルを指定して下さい。";
			dlg.Filter = "log(*.log)|*.log|*.*|*.*";
			dlg.DefaultExt = ".log";
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				cmbLog.Text = dlg.FileName;
			}


		}

		private void btnOutput_Click(object sender, EventArgs e)
		{
			outputPathDialog dlg = new outputPathDialog();
			dlg.outputPath =  cmbOutput.Text;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				cmbOutput.Text = dlg.outputPath;
				editFlag = true;
				chkEnabled();
			}
		}

		//-------------------------------------------------

	}
}
