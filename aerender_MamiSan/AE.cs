using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace aerender_MamiSan
{
	public class AE
	{
		public static string[] basePath = new string[]
 		{
			@"C:\Program Files",
			@"C:\Program Files(x86)"
		};

		public static string[] AES = new string[]
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
		public static string aerender = "aerender.exe";
		//----------------------------------------------------------
		public AE()
		{
		}
		//----------------------------------------------------------
		public static string [] getFolder()
		{
			List<string> lst = new List<string>();
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					string p = Path.Combine(basePath[i], AES[j]);
					if (Directory.Exists(p) == true)
					{
						lst.Add(p);
					}
				}
			}
			return lst.ToArray();
		}
		//----------------------------------------------------------
		public static string[] getAerender()
		{
			List<string> lst = new List<string>();
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					string p = Path.Combine(basePath[i], AES[j]);
					p = Path.Combine(p, aerender);
					if (File.Exists(p) == true)
					{
						lst.Add(p);
					}
				}
			}
			return lst.ToArray();
		}
		//----------------------------------------------------------



	}
}
