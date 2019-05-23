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
	public class aerenderListbox: ListBox
	{
		public string aerenderPath = "";
		private aerenderOptBox _box = null;
		public List<aerenderOpt> _list = new List<aerenderOpt>();


		private Button Bup = null;
		private Button Bdown = null;
		private Button Bdel = null;
		private Button Bdup = null;

		public event EventHandler ItemChanged;
		//-------------------------------------------------
		protected virtual void OnItemChanged(EventArgs e)
		{
			if (ItemChanged != null)
			{
				ItemChanged(this, e);
			}
		}
		//-------------------------------------------------------
		public aerenderListbox()
		{
		}
		//-------------------------------------------------------
		public void Clear()
		{
			_list.Clear();
			this.Items.Clear();
			if (_box != null) _box.ClearALL();
			OnItemChanged(new EventArgs());
		}
		//-------------------------------------------------------
		public int Count
		{
			get { return _list.Count; }
		}
		//-------------------------------------------------------
		public void saveList(string path)
		{
			string ret = "";
			aerenderOpt ao = new aerenderOpt("");
			ret += ao.header + "\r\n";
			if (_list.Count>0)
			{
				for (int i = 0; i < _list.Count; i++)
				{
					ret += _list[i].toLine() +"\r\n"; 
				}
			}
			File.WriteAllText(path, ret, Encoding.GetEncoding("utf-8"));

		}
		//-------------------------------------------------------
		public void loadList(string path)
		{
			if (File.Exists(path) == false) return;
			string[] lines = File.ReadAllLines(path, Encoding.GetEncoding("utf-8"));
			if (lines.Length < 2) return;
			aerenderOpt ao = new aerenderOpt("");
			string head = ao.header;
			if (lines[0] != head) return;
			
			this.SuspendLayout();
			Clear();
			for (int i = 1; i < lines.Length; i++)
			{
				string line = lines[i].Trim();
				if (line == string.Empty) continue;
				if (line[0] == '#') continue;
				aerenderOpt o = new aerenderOpt("");
				if (o.fromLine(line) == true)
				{
					_list.Add(o);
					this.Items.Add(o.ProjectInfo);
				}

			}
			this.ResumeLayout();
			OnItemChanged(new EventArgs());

		}
		//-------------------------------------------------------
		public aerenderOptBox aerenderOptBox
		{
			get { return _box; }
			set 
			{ 
				_box = value;
				if (_box != null)
				{
					_box.SetClicked += new EventHandler(_box_SetClicked);
					_box.ChkClicked += new EventHandler(_box_ChkClicked);
				}
			}
		}

		//-------------------------------------------------------
		void _box_ChkClicked(object sender, EventArgs e)
		{
			if (_box == null) return;
			//throw new NotImplementedException();
		}

		//-------------------------------------------------------
		void _box_SetClicked(object sender, EventArgs e)
		{
			if (_box == null) return;
			//throw new NotImplementedException();
			selectionArea sel = getSelection();
			if (sel.length <= 0) return;

			for ( int i= sel.start; i<=sel.end; i++)
			{
				_list[i].Copy(_box.aerenderOpt,true);
			}
			OnItemChanged(new EventArgs());

		}
		//-------------------------------------------------------
		private void AddAepFile(string path)
		{
			if (File.Exists(path) == false) return;
			aerenderOpt o = new aerenderOpt(path);
			_list.Add(o);
			this.Items.Add(o.ProjectInfo);
		}
		//-------------------------------------------------------
		private void swapList(int s, int d)
		{
			int ss = s;
			int dd = d;
			if ((ss==dd)||(ss < 0) || (ss >= _list.Count) || (dd < 0) || (dd >= _list.Count)) return;
			
			aerenderOpt o = new aerenderOpt("");
			o.Copy(_list[s]);
			_list[s].Copy(_list[d]);
			_list[d].Copy(o);

			object ob = this.Items[s];
			this.Items[s] = this.Items[d];
			this.Items[d] = ob;

		}
		//-------------------------------------------------------
		private void removeAt(int idx)
		{
			if ((idx < 0) || (idx >= _list.Count)) return;

			_list.RemoveAt(idx);
			this.Items.RemoveAt(idx);
			OnItemChanged(new EventArgs());

		}
		//-------------------------------------------------------
		private void listUp()
		{
			selectionArea sel = getSelection();
			int sLength = sel.length;
			if ((sel.start <= 0)||(sLength<=0)) return;
			if (sLength == 1)
			{
				swapList(sel.start, sel.start-1);
				sel.shift(-1);
				this.SuspendLayout();
				this.ClearSelected();
				this.SetSelected(sel.start, true);
				this.ResumeLayout();
			}
			else
			{
				aerenderOpt ao = new aerenderOpt("");
				ao.Copy(_list[sel.start - 1]);
				object ob = this.Items[sel.start - 1];
				this.SuspendLayout();
				this.ClearSelected();
				for (int i = sel.start; i <= sel.end; i++)
				{
					_list[i - 1].Copy(_list[i]);
					this.Items[i - 1] = this.Items[i];
				}
				_list[sel.end].Copy(ao);
				this.Items[sel.end] = ob;
				sel.shift(-1);
				for (int i = sel.start; i <= sel.end; i++) this.SetSelected(i,true);	
				this.ResumeLayout();

			}
		}
		//-------------------------------------------------------
		private void listDown()
		{
			selectionArea sel = getSelection();
			int sLength = sel.length;
			if ((sel.start < 0) || (sLength <= 0)||(sel.end>=_list.Count-1)) return;
			if (sLength == 1)
			{
				swapList(sel.start, sel.start + 1);
				sel.shift(1);
				this.SuspendLayout();
				this.ClearSelected();
				this.SetSelected(sel.start, true);
				this.ResumeLayout();
			}
			else
			{
				aerenderOpt ao = new aerenderOpt("");
				ao.Copy(_list[sel.end + 1]);
				object ob = this.Items[sel.end + 1];
				this.SuspendLayout();
				this.ClearSelected();
				for (int i = sel.end; i >= sel.start; i--)
				{
					_list[i + 1].Copy(_list[i]);
					this.Items[i + 1] = this.Items[i];
				}
				_list[sel.start].Copy(ao);
				this.Items[sel.start] = ob;
				sel.shift(1);
				for (int i = sel.start; i <= sel.end; i++) this.SetSelected(i, true);
				this.ResumeLayout();

			}
		}
		//-------------------------------------------------------
		private void dup(int idx)
		{
			if ((idx < 0) || (idx >= _list.Count)) return;

			aerenderOpt o = new aerenderOpt("");
			o.Copy(_list[idx]);
			_list.Insert(idx, o);
			object ob = this.Items[idx];
			this.Items.Insert(idx,ob);
		}
		//-------------------------------------------------------
		public void addAeps()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "aepファイルの取り込み";
			dlg.Filter = "aepファイル|*.aep";
			dlg.Multiselect = true;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (dlg.FileNames.Length > 0)
				{
					this.SuspendLayout();
					for (int i = 0; i < dlg.FileNames.Length; i++)
					{
						AddAepFile(dlg.FileNames[i]);
					}
					this.ResumeLayout();
					OnItemChanged(new EventArgs());

				}
			}
		}
		//-------------------------------------------------------
		public void addAeps(string[] lst)
		{
			if (lst.Length > 0)
			{
				this.SuspendLayout();
				for (int i = 0; i < lst.Length; i++)
				{
					string e = Path.GetExtension(lst[i]).ToLower();
					if (e == ".aep")
					{
						AddAepFile(lst[i]);
					}
				}
				this.ResumeLayout();
				OnItemChanged(new EventArgs());
			}
		}
		//-------------------------------------------------------
		public Button UpBtn
		{
			get { return Bup; }
			set
			{ 
				Bup = value;
				if (Bup != null)
				{
					Bup.Click += new EventHandler(Bup_Click);
				}
			}
		}
		//-------------------------------------------------------
		void Bup_Click(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			listUp();
		}
		//-------------------------------------------------------
		public Button DownBtn
		{
			get { return Bdown; }
			set
			{ 
				Bdown = value;
				if (Bdown != null)
				{
					Bdown.Click += new EventHandler(Bdown_Click);
				}
			}
		}
		//-------------------------------------------------------
		void Bdown_Click(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			listDown();
		}
		//-------------------------------------------------------
		public Button DellBtn
		{
			get { return Bdel; }
			set 
			{ 
				Bdel = value;
				if (Bdel != null)
				{
					Bdel.Click += new EventHandler(Bdel_Click);
				}
			}
		}
		//-------------------------------------------------------
		void Bdel_Click(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			int idx = this.SelectedIndex;
			selectionArea sel = getSelection();
			if (sel.length>0)
			{
				for (int i = sel.end; i >= sel.start; i--)
				{
					_list.RemoveAt(i);
					this.Items.RemoveAt(i);
				}
				OnItemChanged(new EventArgs());

			}
		}
		//-------------------------------------------------------
		public Button DupBtn
		{
			get { return Bdup; }
			set
			{
				Bdup = value;
				if (Bdup != null)
				{
					Bdup.Click += new EventHandler(Bdup_Click);
				}
			}
		}
		//-------------------------------------------------------
		void Bdup_Click(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			selectionArea sel = getSelection();
			if (sel.length == 1)
			{
				dup(sel.start);
			}
		}


		//-------------------------------------------------------
		public bool TargetList
		{
			get
			{
				return (this.SelectedIndices.Count > 0);
			}
		}
		//-------------------------------------------------------
		private selectionArea getSelection()
		{
			selectionArea ret = new selectionArea();
			ret.start = this.SelectedIndex;

			//選択範囲の処理
			if (this.SelectedIndices.Count > 0)
			{
				ret.start = this.SelectedIndices[0];
				ret.end= this.SelectedIndices[this.SelectedIndices.Count - 1];

				if ((this.SelectedIndices.Count == ret.length) == false)
				{
					this.ClearSelected();
					for (int i = ret.start; i <= ret.end; i++)
					{
						this.SetSelected(i,true);
					}
				}
			}
			return ret;
		}
		//-------------------------------------------------------
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			selectionArea sel = getSelection();
			int cnt = this.Items.Count - 1;
			if (_box != null)
			{
				if (this.SelectedIndices.Count == 1)
				{
					_box.setOpt(_list[sel.start]);
				}
				else
				{
					_box.ClearALL();
				}
			}
			else
			{
				_box.ClearALL();
			}


			if (Bup != null)
			{
				if ((sel.start <= 0))
				{
					Bup.Enabled = false;
				}
				else
				{
					Bup.Enabled = true;
				}
			}
			if (Bdown != null)
			{
				if ((sel.start < 0) || (sel.end >= cnt))
				{
					Bdown.Enabled = false;
				}
				else
				{
					Bdown.Enabled = true;
				}
			}
			if (Bdel != null)
			{
				if ((sel.start < 0) || (sel.end > cnt))
				{
					Bdel.Enabled = false;
				}
				else
				{
					Bdel.Enabled = true;
				}
			}
			if (Bdup != null)
			{
				if ((sel.start < 0) || (sel.end > cnt) || (sel.start != sel.end))
				{
					Bdup.Enabled = false;
				}
				else
				{
					Bdup.Enabled = true;
				}
			}

			base.OnSelectedIndexChanged(e);
		}
		//-------------------------------------------------------
		public string makeBatch()
		{
			if (_list.Count <= 0)
			{
				return "";
			}
			string ret = "";

			for (int i = 0; i < _list.Count; i++)
			{
				ret += _list[i].cmdline(aerenderPath) + "\r\n";
			}
			if (ret == "") return "";
			ret = "echo off\r\n" + ret;
			return ret;
		}
		//-------------------------------------------------------
		public void exportBatch()
		{
			string ret = makeBatch();
			if (ret == "")
			{
				MessageBox.Show("batch作成に失敗しました");
				return;
			}
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Batchファイルの出力";
			dlg.Filter = "Batchファイル(*.bat)|*.bat|全てのファイル(*.*)|*.*";
			dlg.DefaultExt = ".bat";

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(dlg.FileName, ret, Encoding.GetEncoding("shift-jis"));
			}


		}
		//-------------------------------------------------------
		private string zero2(int v)
		{
			if (v <= 0) return "00";
			else if (v < 10) return "0" + v.ToString();
			else return v.ToString();
		}
		private string makeFileName()
		{
			DateTime dt = DateTime.Now;
			string ret = "aerender";

			ret += zero2(dt.Hour);
			ret += zero2(dt.Minute);
			ret += zero2(dt.Second);

			ret += ".bat";
			return ret;

		}
		public void excBatch()
		{

			string ret = makeBatch();
			if (ret == "")
			{
				MessageBox.Show("batch作成に失敗しました");
				return;
			}
			string p = Path.GetTempPath();
			
			p = Path.Combine(p, makeFileName());
			File.WriteAllText(p, ret, Encoding.GetEncoding("shift-jis"));
			if (File.Exists(p) == true)
			{
				System.Diagnostics.Process.Start("cmd", "/c \"" + p + "\"");
			}
		}
		//-------------------------------------------------------
		public void SelectALL()
		{
			if (this.Items.Count <= 0) return;
			this.SuspendLayout();
			this.ClearSelected();
			for (int i = 0; i < this.Items.Count; i++)
			{

				this.SetSelected(i, true);
			}
			this.ResumeLayout();
		}
		//-------------------------------------------------------
		
		//-------------------------------------------------------

	}
}
