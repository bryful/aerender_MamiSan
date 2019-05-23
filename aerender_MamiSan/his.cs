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
	public class his :Component
	{
		private string header = "Mami His";
		private string hisPath = "";
		private ComboBox comp;
		private ComboBox output;
		private ComboBox log;

		//---------------------------------------
		public his()
		{
			hisPath = Path.ChangeExtension(Application.ExecutablePath, ".his");
		}
		//---------------------------------------
		public ComboBox CompComb
		{
			get { return comp; }
			set
			{
				comp = value;
			}
		}
		//---------------------------------------
		public ComboBox OutputComb
		{
			get { return output; }
			set
			{
				output = value;
			}
		}
		//---------------------------------------
		public ComboBox LogComb
		{
			get { return log; }
			set
			{
				log = value;
			}
		}
		//---------------------------------------
		private string getCombItem(ComboBox cmb)
		{
			string ret = "";
			if ((cmb == null) || (cmb.Items.Count <= 0)) return ret;
			for (int i = 0; i < cmb.Items.Count; i++)
			{
				ret += cmb.Items[i].ToString() + "\r\n";
			}
			return ret;
		}
		//---------------------------------------
		public void save()
		{
			string ret = header + "\r\n";
			string s = "";
			s = getCombItem(comp);
			if (s != string.Empty)ret += "*comp\r\n" + s;
			s = getCombItem(output);
			if (s != string.Empty) ret += "*output\r\n" + s;
			s = getCombItem(log);
			if (s != string.Empty) ret += "*log\r\n" + s;
			ret += "*end\r\n";
			File.WriteAllText(hisPath, ret, Encoding.GetEncoding("utf-8"));
		}
		//---------------------------------------
		private void setCombItem(string[] ary, ComboBox cmb, string tag)
		{
			if (cmb == null) return;
			if (ary.Length <= 2) return;
			bool mode = false;
			cmb.SuspendLayout();
			cmb.Items.Clear();
			for (int i = 0; i < ary.Length; i++)
			{
				string line = ary[i].Trim();
				if (line == string.Empty)
				{
					continue;
				}
				else if (line == tag)
				{
					mode = true;
					continue;
				}
				else if (mode == false)
				{
					continue;
				}
				else if ((mode == true) && (line[0] == '*'))
				{
					break;
				}
				else
				{
					cmb.Items.Add(line);
				}
			}
			cmb.ResumeLayout();
		}
		//---------------------------------------
		public void load()
		{
			if (File.Exists(hisPath) == false) return;
			string[] lines = File.ReadAllLines(hisPath, Encoding.GetEncoding("utf-8"));
			if (lines.Length <= 2) return;
			if (lines[0].Trim() != header) return;

			setCombItem(lines, comp, "*comp");
			setCombItem(lines, output, "*output");
			setCombItem(lines, log, "*log");
		}
		//---------------------------------------
		private void pushComb(ComboBox cmb)
		{
			if (cmb == null) return;
			if (cmb.Text == string.Empty) return;
			if (cmb.Items.Count <= 0)
			{
				cmb.Items.Add(cmb.Text);
			}
			else
			{
				for (int i = 0; i < cmb.Items.Count; i++)
				{
					if (cmb.Items[i].ToString() == cmb.Text)
					{
						cmb.Items.RemoveAt(i);
						break;
					}
				}
				cmb.Items.Insert(0, cmb.Text);
			}
		}
		//---------------------------------------
		public void push()
		{
			pushComb(comp);
			pushComb(output);
			pushComb(log);

		}
	
	}
}
