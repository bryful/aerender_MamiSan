using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aerender_MamiSan
{
	public class selectionArea
	{
		private int _start = -1;
		private int _end = -1;
		private int _length = 0;
		public void shift(int v)
		{
			_start += v;
			_end += v;
		}
		private void calcLength()
		{
			if (_start < 0)
			{
				_length = 0;
			}
			else
			{
				_length = _end - _start + 1;
			}
		}
		public int start
		{
			get { return _start; }
			set
			{
				_start = value;
				if (_end < _start) _end = _start;
				calcLength();
			}
		}
		public int end
		{
			get { return _end; }
			set
			{
				_end = value;
				if (_end < _start)  _start = _end;
				calcLength();
			}
		}
		public int length
		{
			get { return _length; }
		}
		public void set(int s, int e)
		{
			_start = s;
			_end = e;
			if (_start > _end)
			{
				int v = _start;
				_start = _end;
				_end = v;
			}
			calcLength();
		}

	}
}
