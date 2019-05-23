using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace aerender_MamiSan
{
	public class ARS_OM
	{
		private string[] _names = new string[0];

		private int start = 0x00A6;
		private int rep = 0x01C2;


		public ARS_OM(string path,ARS_OMmode mode)
		{
			load(path,mode);
		}
		//----------------------------------------------------
		public void load(string path,ARS_OMmode mode)
		{
			Array.Resize(ref _names, 0);
			if (File.Exists(path) == false) return;
			byte [] buf = File.ReadAllBytes(path);
			if (buf.Length < 0x0F) return;
			if (!((buf[0x00] == 0x52) && (buf[0x01] == 0x49) && (buf[0x02] == 0x46) && (buf[0x03] == 0x58))) return;
			if (mode == ARS_OMmode.ars)
			{
				if (!((buf[0x0A] == 0x72) && (buf[0x0B] == 0x73))) return;
				start = 0x00A6;
				rep = 0x01C2;
			}
			else
			{
				if (!((buf[0x0A] == 0x6F) && (buf[0x0B] == 0x6D))) return;
				start = 0x0074;
				rep = 0x02C4;
			}


			int cnt = (buf.Length - start) / rep;
			if (cnt <= 0) return;
			List<string> cap = new List<string>();

			byte[] tmp = new byte[512];
			for (int i = 0; i < cnt; i++)
			{
				int idx = (rep * i) + start;
				for (int j = 0; j < 512; j++) tmp[i] = 0;
				for (int j = 0; j < 512; j++)
				{
					tmp[j] = buf[idx];
					if (buf[idx] == 0x00) break;
					idx++;
				}
				string s = Encoding.GetEncoding(932).GetString(tmp);
				if (s != string.Empty)
				{
					if (s.IndexOf("_HIDDEN ") == 0) break;
					cap.Add(s);
				}
			}
			_names = cap.ToArray();
		}
		//----------------------------------------------------
		public string[] Names
		{
			get { return _names; }
		}
		//----------------------------------------------------
		public int Length
		{
			get { return _names.Length; }
		}
		//----------------------------------------------------

	}
	public enum ARS_OMmode
	{
		ars =0,
		aom
	}
}
