using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace aerender_MamiSan
{
	//********************************************************************
	public class aerenderOpt
	{
		private char sepa = ',';
		private char WQ = '"';
		private string _filename = "";

		public renderTarget renderTarget = renderTarget.none;
		public string comp = "";
		public int rqindex = 1;

		public bool outputON = false;
		public string output = "";

		public bool OMtemplateON = false;
		public string OMtemplateName = "";
		public bool RStemplateON = false;
		public string RStemplateName = "";

		public bool reuse = false;

		public bool mem_usageON = false;
		public int image_cache_percent = 50;
		public int max_mem_percent = 50;

		public bool start_frameON = false;
		public int start_frame = 0;
		public bool end_frameON = false;
		public int end_frame = 0;
		public bool incrementON = false;
		public int increment = 1;

		public bool logON = false;
		public string log = "";
		public bool sound_flag = false;
		public bool verboseOn = false;
		public verboseFlag verbose_flag = verboseFlag.ERRORS_AND_PROGRESS;
		public bool closeOn = false;
		public closeFlag close = closeFlag.DO_NOT_SAVE_CHANGES;
		public bool mpOn = false;
		public mp_enableFlag mp_enable_flag = mp_enableFlag.ZERO;
		public bool continueOnMissingFootage = false;
		//----------------------------------------------------------------
		public aerenderOpt(string path)
		{
			Clear();
			if (File.Exists(path) == true)
			{
				_filename = path;
			}
		}
		//----------------------------------------------------------------
		public bool Exists
		{
			get { return File.Exists(_filename); }
		}
		//----------------------------------------------------------------
		public string Filename
		{
			get { return _filename; }
			set
			{
				if (File.Exists(value) == true)
				{
					_filename = value;
				}
			}
		}
		//----------------------------------------------------------------
		public string Project
		{
			get { return Path.GetFileName(_filename); }
		}
		//----------------------------------------------------------------
		public string ProjectInfo
		{
			get 
			{
				string s = Path.GetFileName( Path.GetDirectoryName(_filename));
				s = s + "/" + Path.GetFileName(_filename);
				return s;
			}
		}
		//----------------------------------------------------------------
		public void Clear()
		{
			renderTarget = renderTarget.none;
			comp = "";
			rqindex = 1;
			outputON = false;
			output = "";
			OMtemplateON = false;
			OMtemplateName = "";
			RStemplateON = false;
			RStemplateName = "";
			reuse = false;
			mem_usageON = false;
			image_cache_percent = 100;
			max_mem_percent = 100;
			start_frameON = false;
			start_frame = 0;
			end_frameON = false;
			end_frame = 0;
			incrementON = false;
			increment = 1;
			logON = false;
			log = "";
			sound_flag = false;
			verboseOn = false;
			verbose_flag = verboseFlag.ERRORS_AND_PROGRESS;
			closeOn = false;
			close = closeFlag.DO_NOT_SAVE_CHANGES;
			mpOn = false;
			mp_enable_flag = mp_enableFlag.ZERO;
			continueOnMissingFootage = false;

		}
		//----------------------------------------------------------------
		private string ADDWQ(string s,bool aSepa)
		{
			if (aSepa == true)
			{
				return WQ + s + WQ + sepa;
			}
			else
			{
				return WQ + s + WQ;
			}
		}
		//----------------------------------------------------------------
		private string ADDWQ(string s)
		{
			return WQ + s + WQ;
		}
		private string ADDWQ(int v, bool aSepa)
		{
			return ADDWQ(v.ToString(), aSepa);
		}
		private string ADDWQ(bool b, bool aSepa)
		{
			return ADDWQ(b.ToString(), aSepa);
		}
		public string toLine()
		{
			string line = "";
			line += ADDWQ(_filename,true);
			line += ADDWQ(((int)renderTarget),true);
			line += ADDWQ(comp,true);
			line += ADDWQ(rqindex,true);
			line += ADDWQ(outputON,true);
			line += ADDWQ(output,true);
			line += ADDWQ(OMtemplateON, true);
			line += ADDWQ(OMtemplateName, true);
			line += ADDWQ(RStemplateON, true);
			line += ADDWQ(RStemplateName, true);
			line += ADDWQ(reuse,true);
			line += ADDWQ(mem_usageON,true);
			line += ADDWQ(image_cache_percent,true);
			line += ADDWQ(max_mem_percent,true);
			line += ADDWQ(start_frameON,true);
			line += ADDWQ(start_frame,true);
			line += ADDWQ(end_frameON,true);
			line += ADDWQ(end_frame,true);
			line += ADDWQ(incrementON,true);
			line += ADDWQ(increment,true);
			line += ADDWQ(logON,true);
			line += ADDWQ(log,true);
			line += ADDWQ(sound_flag,true);
			line += ADDWQ(verboseOn, true);
			line += ADDWQ(((int)verbose_flag), true);
			line += ADDWQ(closeOn, true);
			line += ADDWQ(((int)close), true);
			line += ADDWQ(mpOn, true);
			line += ADDWQ(((int)mp_enable_flag), true);
			line += ADDWQ(continueOnMissingFootage, false);

			return line;
		}
		//----------------------------------------------------------------
		public string header
		{
			get
			{
				return
					ADDWQ("#Mami fileName",true)+
					ADDWQ("renderTarget",true)+
					ADDWQ("comp",true)+
					ADDWQ("rqindex",true)+
					ADDWQ("outputON",true)+
					ADDWQ("output",true)+
					ADDWQ("OMtemplateON",true)+
					ADDWQ("OMtemplateName", true) +
					ADDWQ("RStemplateON", true) +
					ADDWQ("RStemplateName", true) +
					ADDWQ("reuse",true)+
					ADDWQ("mem_usageON",true)+
					ADDWQ("image_cache_percent",true)+
					ADDWQ("max_mem_percent",true)+
					ADDWQ("start_frameON",true)+
					ADDWQ("start_frame",true)+
					ADDWQ("end_frameON",true)+
					ADDWQ("end_frame",true)+
					ADDWQ("incrementON",true)+
					ADDWQ("increment",true)+
					ADDWQ("logON",true)+
					ADDWQ("log",true)+
					ADDWQ("sound_flag",true)+
					ADDWQ("verboseOn", true) +
					ADDWQ("verbose_flag", true) +
					ADDWQ("closeOn", true) +
					ADDWQ("close", true) +
					ADDWQ("mpOn", true) +
					ADDWQ("mp_enable_flag", true) +
					ADDWQ("continueOnMissingFootage", false);
			}
		}
		//----------------------------------------------------------------
		private string[] WQSplit(string s)
		{
			if (s == "")
			{
				return new string[0];
			}
			else
			{
				string[] sa = s.Split(sepa);
				for (int i = 0; i < sa.Length; i++)
				{
					string ss = sa[i];
					if (ss.Length >= 2)
					{
						if ((ss[0] == WQ) && (ss[ss.Length - 1] == WQ))
						{
							sa[i] = ss.Substring(1, ss.Length - 2);
						}
					}
				}
				return sa;
			}
		}

		//----------------------------------------------------------------
		public bool fromLine(string line)
		{
			string[] lines = WQSplit(line);
			if (lines.Length < 30) return false;
			if (lines[0].Trim().IndexOf("#Mami") == 0) return false;
			ClearALL();
			bool b=false;
			int v = 0;
			_filename = lines[0];
			if (File.Exists(_filename) == false){return false;}
			if (int.TryParse(lines[1], out v) == true) { renderTarget = (renderTarget)v; }
			comp = lines[2];
			if (int.TryParse(lines[3], out v) == true) { rqindex = v; }
			if (bool.TryParse(lines[4], out b) == true) { outputON = b; }
			output = lines[5];
			if (bool.TryParse(lines[6], out b) == true) { OMtemplateON = b; }
			OMtemplateName = lines[7];
			if (bool.TryParse(lines[8], out b) == true) { RStemplateON = b; }
			RStemplateName = lines[9];
			if (bool.TryParse(lines[10], out b) == true) { reuse = b; }
			if (bool.TryParse(lines[11], out b) == true) { mem_usageON = b; }
			if (int.TryParse(lines[12], out v) == true) { image_cache_percent = v; }
			if (int.TryParse(lines[13], out v) == true) { max_mem_percent = v; }
			if (bool.TryParse(lines[14], out b) == true) { start_frameON = b; }
			if (int.TryParse(lines[15], out v) == true) { start_frame = v; }
			if (bool.TryParse(lines[16], out b) == true) { end_frameON = b; }
			if (int.TryParse(lines[17], out v) == true) { end_frame = v; }
			if (bool.TryParse(lines[18], out b) == true) { incrementON = b; }
			if (int.TryParse(lines[19], out v) == true) { increment = v; }
			if (bool.TryParse(lines[20], out b) == true) { logON = b; }
			log = lines[21];
			if (bool.TryParse(lines[22], out b) == true) { sound_flag = b; }
			if (bool.TryParse(lines[23], out b) == true) { verboseOn = b; }
			if (int.TryParse(lines[24], out v) == true) { verbose_flag = (verboseFlag)v; }
			if (bool.TryParse(lines[25], out b) == true) { closeOn = b; }
			if (int.TryParse(lines[26], out v) == true) { close = (closeFlag)v; }
			if (bool.TryParse(lines[27], out b) == true) { mpOn = b; }
			if (int.TryParse(lines[28], out v) == true) { mp_enable_flag = (mp_enableFlag)v; }
			if (bool.TryParse(lines[29], out b) == true) { continueOnMissingFootage = b; }

			return true;
		}
		//----------------------------------------------------------------
		public void ClearALL()
		{
			_filename = "";
			Clear();
		}
		//----------------------------------------------------------------
		public void Copy(aerenderOpt op)
		{
			Copy(op, false);
		}
		//----------------------------------------------------------------
		public void Copy(aerenderOpt op,bool filenameNotCopy)
		{
			if (filenameNotCopy == false)
			{
				_filename = op._filename;
			}
			renderTarget = op.renderTarget;
			comp = op.comp;
			rqindex = op.rqindex;
			outputON = op.outputON;
			output = op.output;
			OMtemplateON = op.OMtemplateON;
			OMtemplateName = op.OMtemplateName;
			RStemplateON = op.RStemplateON;
			RStemplateName = op.RStemplateName;
			reuse = op.reuse;
			mem_usageON = op.mem_usageON;
			image_cache_percent = op.image_cache_percent;
			max_mem_percent = op.max_mem_percent;
			start_frameON = op.start_frameON;
			start_frame = op.start_frame;
			end_frameON = op.end_frameON;
			end_frame = op.end_frame;
			incrementON = op.incrementON;
			increment = op.increment;
			logON = op.logON;
			log = op.log;
			sound_flag = op.sound_flag;
			verboseOn = op.verboseOn;
			verbose_flag = op.verbose_flag;
			closeOn = op.closeOn;
			close = op.close;
			mpOn = op.mpOn;
			mp_enable_flag = op.mp_enable_flag;
			continueOnMissingFootage = op.continueOnMissingFootage;

		}
		//----------------------------------------------------------------
		//----------------------------------------------------------------
		public string makeOptions()
		{
			string opt = " ";
			//++++++++++++++++++++++++
			if (reuse == true)
			{
				opt += " -reuse";
			}
			//++++++++++++++++++++++++
			if (_filename != "")
			{
				opt += " -project " + ADDWQ(_filename);
			}
			//++++++++++++++++++++++++
			switch (renderTarget)
			{
				case renderTarget.comp:
					opt += " -comp " + ADDWQ(comp);
					break;
				case renderTarget.rqindex:
					opt += " -rqindex " + rqindex.ToString();
					break;
				case renderTarget.ProjctName:
					opt += " -comp " + ADDWQ(Path.GetFileNameWithoutExtension(_filename));
					break;
			}
			//++++++++++++++++++++++++
			if ((RStemplateON == true)&&(RStemplateName!=""))
			{
				opt += " -RStemplate " + ADDWQ(RStemplateName); 
			}
			//++++++++++++++++++++++++
			if ((OMtemplateON == true) && (OMtemplateName != ""))
			{
				opt += " -OMtemplate " + ADDWQ(OMtemplateName);
			}
			//++++++++++++++++++++++++
			if ((outputON == true) && (output != ""))
			{
				opt += " -output " + ADDWQ(output);
			}
			//++++++++++++++++++++++++
			if ((logON == true) && (log != ""))
			{
				opt += " -log " + ADDWQ(log);
			}
			//++++++++++++++++++++++++
			if ((start_frameON == true) && (start_frame >= 0))
			{
				opt += " -s " + start_frame.ToString();
			}
			//++++++++++++++++++++++++
			if ((end_frameON == true) && (end_frame >= 0))
			{
				opt += " -e " + end_frame.ToString();
			}
			//++++++++++++++++++++++++
			if ((incrementON == true) && (increment >= 1))
			{
				opt += " -i " + increment.ToString();
			}
			//++++++++++++++++++++++++
			if (mem_usageON == true)
			{
				opt += " -mem_usage " + image_cache_percent.ToString() + " " +max_mem_percent.ToString();
			}
			//++++++++++++++++++++++++
			if (mpOn == true)
			{
				switch (mp_enable_flag)
				{
					case mp_enableFlag.ZERO:
						opt += " -mp 0";
						break;
					case mp_enableFlag.ONE:
						opt += " -mp 1";
						break;
				}
			}
			//++++++++++++++++++++++++
			if (verboseOn == true)
			{
				switch (verbose_flag)
				{
					case verboseFlag.ERRORS_AND_PROGRESS:
						opt += " -v ERRORS_AND_PROGRESS";
						break;
					case verboseFlag.ERRORS:
						opt += " -v ERRORS";
						break;
				}
			}
			//++++++++++++++++++++++++
			if (closeOn == true)
			{
				switch (close)
				{
					case closeFlag.DO_NOT_SAVE_CHANGES:
						opt += " -close DO_NOT_SAVE_CHANGES";
						break;
					case closeFlag.SAVE_CHANGE:
						opt += " -close SAVE_CHANGE";
						break;
					case closeFlag.DO_NOT_CLOSE:
						opt += " -close DO_NOT_CLOSE";
						break;
				}
			}
			//++++++++++++++++++++++++
			if (sound_flag == true)
			{
				opt += " -sound ON";
			}
			//++++++++++++++++++++++++
			if (closeOn == true)
			{
				switch (close)
				{
					case closeFlag.DO_NOT_SAVE_CHANGES:
						opt += " -close DO_NOT_SAVE_CHANGES";
						break;
					case closeFlag.SAVE_CHANGE:
						opt += " -close SAVE_CHANGE";
						break;
					case closeFlag.DO_NOT_CLOSE:
						opt += " -close DO_NOT_CLOSE";
						break;
				}
			}
			//++++++++++++++++++++++++
			if (continueOnMissingFootage == true)
			{
				opt += " -continueOnMissingFootage";
			}

			return opt;
		}
		//----------------------------------------------------------------
		public string cmdline(string cmd)
		{
			return ADDWQ(cmd) + makeOptions();

		}
		//----------------------------------------------------------------
	}
	//********************************************************************
	public enum verboseFlag
	{
		ERRORS_AND_PROGRESS=0,
		ERRORS
	}
	public enum closeFlag
	{
		DO_NOT_SAVE_CHANGES=0,
		SAVE_CHANGE,
		DO_NOT_CLOSE
	}
	public enum renderTarget
	{
		none = 0,
		ProjctName,
		comp,
		rqindex
	}
	public enum mp_enableFlag
	{
		ZERO =0,
		ONE
	}
	//********************************************************************
}
