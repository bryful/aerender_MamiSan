using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aerender_MamiSan
{
	public partial class versionDialog : Form
	{
		public versionDialog()
		{
			InitializeComponent();
		}

		private void versionDialog_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void versionDialog_KeyDown(object sender, KeyEventArgs e)
		{
			this.Close();
		}

		private void versionDialog_Paint(object sender, PaintEventArgs e)
		{
			int w = this.ClientSize.Width;
			int h = this.ClientSize.Height;
			Rectangle r = new Rectangle(0, 0, w-1, h-1);
			Pen p = new Pen(Color.Black);
			try
			{
				e.Graphics.DrawRectangle(p, r);
			}
			finally
			{
				p.Dispose();
			}
		}
	}
}
