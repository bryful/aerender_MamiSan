using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace aerender_MamiSan
{
  //***************************************************************************************
  //***************************************************************************************
  public enum SaveKind
  {
    none = 0,
    str,
    color,
    integer,
    fnt,
    bol,
    cmt
  }
  //***************************************************************************************
  //***************************************************************************************
  //-----------------------------------------------------
  public class SavePrm
  {
    
    private const char Sepa = ',';
    private const string kind_str = "str";
    private const string kind_int = "int";
    private const string kind_col = "col";
    private const string kind_fnt = "fnt";
    private const string kind_bol = "bol";
    private const string kind_cmt = "cmt";

    private SaveKind m_kind;

    private string m_key;
    private string m_str;
    private int m_integer;
    private Color m_color;
    private int m_color_R;
    private int m_color_G;
    private int m_color_B;
    private Font m_font;
    private bool m_bool;
    public SavePrm()
    {
      init();
    }
    private void init()
    {
      m_kind = SaveKind.none;
      m_key = "";
      m_str = "";
      m_integer = 0;
      m_color_R = 0;
      m_color_G = 0;
      m_color_B = 0;
      m_font = new Font("System", 30);
      m_bool = false;
    }
    private void Split(string v)
    {
      init();
      string[] stArrayData = v.Trim().Split(Sepa);
      int cnt = stArrayData.Length; 
      if ( cnt >= 3)
      {
        string s = stArrayData[0].Trim();
        switch (s)
        {
          case kind_str:
            m_kind = SaveKind.str;
            m_key = stArrayData[1].Trim();
            m_str = stArrayData[2].Trim();
            break;
          case kind_int:
            m_kind = SaveKind.integer;
            m_key = stArrayData[1].Trim();
            m_integer = Convert.ToInt32(stArrayData[2]);
            break;
          case kind_col:
            m_kind = SaveKind.color;
            m_key = stArrayData[1].Trim();
            if (cnt >= 5)
            {
              m_color_R = Convert.ToUInt16(stArrayData[2]);
              m_color_G = Convert.ToUInt16(stArrayData[3]);
              m_color_B = Convert.ToUInt16(stArrayData[4]);
              m_color = Color.FromArgb(m_color_R, m_color_G, m_color_B);
            }
            break;
          case kind_fnt:
            m_kind = SaveKind.fnt;
            m_key = stArrayData[1].Trim();
            string nm = stArrayData[2];
            if (cnt >= 5)
            {
              int sz = Convert.ToInt16(stArrayData[3]);
              FontStyle st = (FontStyle)(Convert.ToInt16(stArrayData[4]));
              m_font = new Font(nm, sz,st);
            }
            else if (cnt >= 4)
            {
              int sz = Convert.ToInt16(stArrayData[3]);
              m_font = new Font(nm, sz);
            }
            else
            {
              m_font = new Font(nm, 24);
            }

            break;
          case kind_bol:
            m_kind = SaveKind.bol;
            m_key = stArrayData[1].Trim();
            m_bool = (stArrayData[2].Trim().ToUpper() == "TRUE");
            break;
          case kind_cmt:
            m_kind = SaveKind.cmt;
            m_key = stArrayData[1].Trim();
            m_str = stArrayData[2].Trim();
            break;

        }
      }

    }
    private string FontToStr(Font fnt)
    {
      string s,v;
      s = fnt.Name;
      v = ((int)fnt.Size).ToString();
      s = s + Sepa + v;
      v = ((int)fnt.Style).ToString();
      s = s + Sepa + v;
      return s;
    }
    private string Mix()
    {
      string s ="";
      switch (m_kind)
      {
        case SaveKind.str:
          s = kind_str + Sepa + m_key + Sepa + m_str; 
          break;
        case SaveKind.integer:
          s = kind_int + Sepa + m_key + Sepa + m_integer.ToString();
          break;
        case SaveKind.color:
          s = kind_col + Sepa + m_key + Sepa + m_color_R.ToString() + Sepa + m_color_G.ToString() + Sepa + m_color_B.ToString();
          break;
        case SaveKind.fnt:
          s = FontToStr(m_font);
          s = kind_fnt + Sepa + m_key + Sepa + s;
          break;
        case SaveKind.bol:
          if (m_bool==true) { s = "TRUE"; } else { s = "FALSE"; }
          s = kind_bol + Sepa + m_key + Sepa + s;
          break;
        case SaveKind.cmt:
          s = kind_str + Sepa + m_key + Sepa + m_str;
          break;
      }
      return s;
    }
    public void setColor(int r, int g, int b)
    {
      m_kind = SaveKind.color;
      m_color_R = r;
      m_color_G = g;
      m_color_B = b;
    }
    public int Integer
    {
      get { return m_integer; }
      set {
        m_kind = SaveKind.integer;
        m_integer = value;
      }
    }
    public Color Col
    {
      get { return Color.FromArgb(m_color_R, m_color_G, m_color_B); }
      set {
        m_kind = SaveKind.color;
        m_color_R = value.R; m_color_G = value.G; m_color_B = value.B; }
    }
    public string Str
    {
      get { return m_str; }
      set { m_kind = SaveKind.str; m_str = value; }
    }
    public string Cmt
    {
      get { return m_str; }
      set { m_kind = SaveKind.cmt; m_str = value; }
    }
    public Font Font
    {
      get { return m_font; }
      set { m_kind = SaveKind.fnt; m_font = value; }
    }
    public bool Bol
    {
      get { return m_bool; }
      set { m_kind = SaveKind.bol; m_bool = value; }
    }
    public string Text
    {
      get { return Mix(); }
      set { Split(value); }
    }
    public SaveKind Kind
    {
      get { return m_kind; }
      set { m_kind = value; }
    }
    public string Key
    {
      get { return m_key; }
      set { m_key = value.Trim(); }
    }
   
  }
  //***************************************************************************************
  //***************************************************************************************
  //-----------------------------------------------------
  public class SaveFiles
  {
    public const string HeaderDef = @";SaveFiles Header";
    private string m_Header = "";

    //private List<string> m_Items = new List<string>();

    private List<SavePrm> m_dp = new List<SavePrm>();
    public bool IsCreateBakFile = true;

    //-------------------------------------------------------------------
    public SaveFiles(string hed)
    {
      m_Header = hed.Trim();
      if (hed == "")
      {
        m_Header = HeaderDef;
      }

      if (m_Header[0] != ';')
      {
        m_Header = ';' + m_Header;
      }
      
    }
    //-------------------------------------------------------------------
    public int Count {
      get { return m_dp.Count; }
    }
    //-------------------------------------------------------------------
    public int FinedKey(string key)
    {
      int r = -1;
      int cnt = m_dp.Count;
      if (cnt <= 0) return r;
      string s = key.ToUpper().Trim();
      string d;
      for (int i = 0; i < cnt; i++)
      {
        d = m_dp[i].Key.ToUpper();
        if (s == d)
        {
          r = i;
          return i;
        }

      }
      return r;
    }
    //-------------------------------------------------------------------
    public int GetInt(string key, int df)
    {
      int r = df;
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        if (m_dp[idx].Kind == SaveKind.integer)
        {
          r = m_dp[idx].Integer;
        }
      }
      return r;
    }
    //-------------------------------------------------------------------
    public void SetInt(string key, int v)
    {
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        m_dp[idx].Integer = v;
      }
      else
      {
        SavePrm d = new SavePrm();
        d.Integer = v;
        d.Key = key;
        m_dp.Add(d);
      }
    }
    //-------------------------------------------------------------------
    public string GetStr(string key, string df)
    {
      string r = df;
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        if (m_dp[idx].Kind == SaveKind.str)
        {
          r = DecodeK( m_dp[idx].Str );
        }
      }
      return r;
    }

    //-------------------------------------------------------------------
    public void SetStr(string key, string v)
    {
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        m_dp[idx].Str = v;
      }
      else
      {
        SavePrm d = new SavePrm();
        d.Str = EncodeK(v);
        d.Key = key;
        m_dp.Add(d);
      }
    }
    //-------------------------------------------------------------------
    public void SetComment(string key, string v)
    {
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        m_dp[idx].Str = v;
      }
      else
      {
        SavePrm d = new SavePrm();
        d.Str = v;
        d.Key = key;
        m_dp.Add(d);
      }
    }
    //-------------------------------------------------------------------
    public Color GetColor(string key, Color df)
    {
      Color r = df;
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        if (m_dp[idx].Kind == SaveKind.color)
        {
          r = m_dp[idx].Col;
        }
      }
      return r;
    }

    //-------------------------------------------------------------------
    public void SetColor(string key, Color v)
    {
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        m_dp[idx].Col = v;
      }
      else
      {
        SavePrm d = new SavePrm();
        d.Col = v;
        d.Key = key;
        m_dp.Add(d);
      }
    }
    //-------------------------------------------------------------------
    public Font GetFont(string key, Font df)
    {
      Font r = df;
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        if (m_dp[idx].Kind == SaveKind.fnt)
        {
          r = m_dp[idx].Font;
        }
      }
      return r;
    }

    //-------------------------------------------------------------------
    public void SetFont(string key, Font v)
    {
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        m_dp[idx].Font = v;
      }
      else
      {
        SavePrm d = new SavePrm();
        d.Font = v;
        d.Key = key;
        m_dp.Add(d);
      }
    }
    //-------------------------------------------------------------------
    public bool GetBool(string key, bool df)
    {
      bool r = df;
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        if (m_dp[idx].Kind == SaveKind.bol)
        {
          r = m_dp[idx].Bol;
        }
      }
      return r;
    }

    //-------------------------------------------------------------------
    public void SetBool(string key, bool v)
    {
      int idx = FinedKey(key);
      if (idx >= 0)
      {
        m_dp[idx].Bol = v;
      }
      else
      {
        SavePrm d = new SavePrm();
        d.Bol = v;
        d.Key = key;
        m_dp.Add(d);
      }
    }
    //-------------------------------------------------------------------
    public bool createDP(List<string> items)
    {
      m_dp.Clear();
      if (items.Count <= 0)
      {
        return false;
      }
      if (items[0] == m_Header)
      {
        items.RemoveAt(0);
      }

      int cnt = items.Count;
      if (cnt <= 0)
      {
        return false;
      }
      for (int i = 0; i < cnt; i++)
      {
        SavePrm d = new SavePrm();
        d.Text = items[i];
        
        if (d.Kind != SaveKind.none)
        {
          m_dp.Add(d);
        }
      }
      if (m_dp.Count > 0)
      {

        return true;
      }
      else
      {
        return false;
      }
    }
    //-------------------------------------------------------------------
    public bool LoadFromFile(string path)
    {
      bool err = false;
      //ファイルがなければエラー
      if ( System.IO.File.Exists(path) == false) {
        return err;
      }
      System.IO.StreamReader sr = new System.IO.StreamReader(path);
      try {
        List<string> items = new List<string>();

        items.Clear();
        while (sr.Peek() >= 0) {
          items.Add(sr.ReadLine());
        }
        if (items.Count > 1) {
          if (items[0] == m_Header)
          {
            //ヘッダーは消しておく
            items.RemoveAt(0);
            err = createDP(items);
          }
        }
      } finally {
        sr.Close();
      }
      return err;
    }
    //-------------------------------------------------------------------
    public bool SaveToFile(string path) {

      if (Directory.Exists(Path.GetDirectoryName(path)) == false) {
        return false;
      }
      if (IsCreateBakFile) saveChk(path);
	  System.IO.StreamWriter sw = new System.IO.StreamWriter(path);
      try
      {
        sw.WriteLine(m_Header);
        if (m_dp.Count > 0)
        {
          foreach (SavePrm d in m_dp)
          {
            sw.WriteLine(d.Text);
          }
        }
      } finally {
        sw.Close();
      }
      return true;
    }
    //-------------------------------------------------------------------
    private void saveChk(string path)
    {
      if (System.IO.File.Exists(path) == false) return;

      string e = Path.GetExtension(path);

      //末尾がBackupなら無視
      int Len = e.Length;
      if (Len > 3)
      {
        if (e.Substring(Len - 3, 3) == "bak") return;
      }
      
      
      string eBak = e + ".bak";
      string bak = Path.ChangeExtension(path, eBak);
      if (System.IO.File.Exists(bak) == true)
      {
        System.IO.File.Delete(bak);
      }
      System.IO.File.Move(path, bak);
    }
    //-------------------------------------------------------------------
    public string EncodeK(string s)
    {
      return s.Replace(",", "<.>");
    }
    //-------------------------------------------------------------------
    public string DecodeK(string s)
    {
      return s.Replace("<.>", ",");
    }
  }
  //***************************************************************************************
  //***************************************************************************************

}
