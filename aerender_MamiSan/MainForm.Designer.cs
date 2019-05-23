namespace aerender_MamiSan
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.addAepMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.exportBatchMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.execBatchMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.loadAOMMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.loadARSMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.quitMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.selectALLMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.clearALLMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.prefMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.showHelpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.versionMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnDup = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.lbAl = new System.Windows.Forms.Label();
			this.aerenderOptBox1 = new aerender_MamiSan.aerenderOptBox();
			this.aerenderListbox1 = new aerender_MamiSan.aerenderListbox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAddAep = new System.Windows.Forms.ToolStripButton();
			this.btnExportBatch = new System.Windows.Forms.ToolStripButton();
			this.btnExecBatch = new System.Windows.Forms.ToolStripButton();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.HelpMenu});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(512, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAepMenu,
            this.toolStripMenuItem2,
            this.exportBatchMenu,
            this.execBatchMenu,
            this.toolStripMenuItem1,
            this.loadAOMMenu,
            this.loadARSMenu,
            this.toolStripMenuItem3,
            this.quitMenu});
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(66, 20);
			this.fileMenu.Text = "ファイル(&F)";
			// 
			// addAepMenu
			// 
			this.addAepMenu.Image = global::aerender_MamiSan.Properties.Resources.OpenFile;
			this.addAepMenu.Name = "addAepMenu";
			this.addAepMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.addAepMenu.Size = new System.Drawing.Size(211, 22);
			this.addAepMenu.Text = "AEPファイルを追加する";
			this.addAepMenu.Click += new System.EventHandler(this.addAepMenu_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(208, 6);
			// 
			// exportBatchMenu
			// 
			this.exportBatchMenu.Enabled = false;
			this.exportBatchMenu.Image = global::aerender_MamiSan.Properties.Resources.saveHS;
			this.exportBatchMenu.Name = "exportBatchMenu";
			this.exportBatchMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.exportBatchMenu.Size = new System.Drawing.Size(211, 22);
			this.exportBatchMenu.Text = "バッチファイルを出力";
			this.exportBatchMenu.Click += new System.EventHandler(this.exportBatchMenu_Click);
			// 
			// execBatchMenu
			// 
			this.execBatchMenu.Enabled = false;
			this.execBatchMenu.Image = global::aerender_MamiSan.Properties.Resources.TaskHS;
			this.execBatchMenu.Name = "execBatchMenu";
			this.execBatchMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.execBatchMenu.Size = new System.Drawing.Size(211, 22);
			this.execBatchMenu.Text = "バッチを実行";
			this.execBatchMenu.Click += new System.EventHandler(this.execBatchMenu_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
			// 
			// loadAOMMenu
			// 
			this.loadAOMMenu.Name = "loadAOMMenu";
			this.loadAOMMenu.Size = new System.Drawing.Size(211, 22);
			this.loadAOMMenu.Text = "aomアイルを読み込む";
			this.loadAOMMenu.Click += new System.EventHandler(this.loadAOMMenu_Click);
			// 
			// loadARSMenu
			// 
			this.loadARSMenu.Name = "loadARSMenu";
			this.loadARSMenu.Size = new System.Drawing.Size(211, 22);
			this.loadARSMenu.Text = "arsファイルを読み込む";
			this.loadARSMenu.Click += new System.EventHandler(this.loadARSMenu_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(208, 6);
			// 
			// quitMenu
			// 
			this.quitMenu.Name = "quitMenu";
			this.quitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.quitMenu.Size = new System.Drawing.Size(211, 22);
			this.quitMenu.Text = "Quit";
			// 
			// editMenu
			// 
			this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectALLMenu,
            this.clearALLMenu,
            this.toolStripMenuItem4,
            this.prefMenu});
			this.editMenu.Name = "editMenu";
			this.editMenu.Size = new System.Drawing.Size(56, 20);
			this.editMenu.Text = "編集(&E)";
			// 
			// selectALLMenu
			// 
			this.selectALLMenu.Enabled = false;
			this.selectALLMenu.Name = "selectALLMenu";
			this.selectALLMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectALLMenu.Size = new System.Drawing.Size(162, 22);
			this.selectALLMenu.Text = "前選択";
			this.selectALLMenu.Click += new System.EventHandler(this.selectALLToolStripMenuItem_Click);
			// 
			// clearALLMenu
			// 
			this.clearALLMenu.Enabled = false;
			this.clearALLMenu.Name = "clearALLMenu";
			this.clearALLMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
			this.clearALLMenu.Size = new System.Drawing.Size(162, 22);
			this.clearALLMenu.Text = "全て削除";
			this.clearALLMenu.Click += new System.EventHandler(this.clearALLMenu_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(159, 6);
			// 
			// prefMenu
			// 
			this.prefMenu.Name = "prefMenu";
			this.prefMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
			this.prefMenu.Size = new System.Drawing.Size(162, 22);
			this.prefMenu.Text = "環境設定";
			this.prefMenu.Click += new System.EventHandler(this.prefMenu_Click);
			// 
			// HelpMenu
			// 
			this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelpMenu,
            this.versionMenu});
			this.HelpMenu.Name = "HelpMenu";
			this.HelpMenu.Size = new System.Drawing.Size(62, 20);
			this.HelpMenu.Text = "ヘルプ(&H)";
			// 
			// showHelpMenu
			// 
			this.showHelpMenu.Enabled = false;
			this.showHelpMenu.Name = "showHelpMenu";
			this.showHelpMenu.Size = new System.Drawing.Size(152, 22);
			this.showHelpMenu.Text = "Helpの表示";
			// 
			// versionMenu
			// 
			this.versionMenu.Name = "versionMenu";
			this.versionMenu.Size = new System.Drawing.Size(152, 22);
			this.versionMenu.Text = "バージョンの表示";
			this.versionMenu.Click += new System.EventHandler(this.versionMenu_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 676);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(512, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddAep,
            this.toolStripSeparator1,
            this.btnExportBatch,
            this.btnExecBatch});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(512, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(105, 74);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(41, 20);
			this.btnDel.TabIndex = 7;
			this.btnDel.Text = "Del";
			this.btnDel.UseVisualStyleBackColor = true;
			// 
			// btnDown
			// 
			this.btnDown.Location = new System.Drawing.Point(58, 74);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(41, 20);
			this.btnDown.TabIndex = 6;
			this.btnDown.Text = "Down";
			this.btnDown.UseVisualStyleBackColor = true;
			// 
			// btnDup
			// 
			this.btnDup.Location = new System.Drawing.Point(152, 74);
			this.btnDup.Name = "btnDup";
			this.btnDup.Size = new System.Drawing.Size(41, 20);
			this.btnDup.TabIndex = 8;
			this.btnDup.Text = "Dup";
			this.btnDup.UseVisualStyleBackColor = true;
			// 
			// btnUp
			// 
			this.btnUp.Location = new System.Drawing.Point(12, 74);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(40, 20);
			this.btnUp.TabIndex = 5;
			this.btnUp.Text = "Up";
			this.btnUp.UseVisualStyleBackColor = true;
			// 
			// lbAl
			// 
			this.lbAl.AutoSize = true;
			this.lbAl.Location = new System.Drawing.Point(12, 57);
			this.lbAl.Name = "lbAl";
			this.lbAl.Size = new System.Drawing.Size(119, 12);
			this.lbAl.TabIndex = 9;
			this.lbAl.Text = "対象AEPファイル(*.aep)";
			// 
			// aerenderOptBox1
			// 
			this.aerenderOptBox1.aerenderListbox = this.aerenderListbox1;
			this.aerenderOptBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.aerenderOptBox1.Location = new System.Drawing.Point(210, 57);
			this.aerenderOptBox1.Name = "aerenderOptBox1";
			this.aerenderOptBox1.Size = new System.Drawing.Size(293, 607);
			this.aerenderOptBox1.TabIndex = 4;
			// 
			// aerenderListbox1
			// 
			this.aerenderListbox1.aerenderOptBox = this.aerenderOptBox1;
			this.aerenderListbox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.aerenderListbox1.DellBtn = this.btnDel;
			this.aerenderListbox1.DownBtn = this.btnDown;
			this.aerenderListbox1.DupBtn = this.btnDup;
			this.aerenderListbox1.FormattingEnabled = true;
			this.aerenderListbox1.ItemHeight = 12;
			this.aerenderListbox1.Location = new System.Drawing.Point(12, 96);
			this.aerenderListbox1.Name = "aerenderListbox1";
			this.aerenderListbox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.aerenderListbox1.Size = new System.Drawing.Size(191, 568);
			this.aerenderListbox1.TabIndex = 3;
			this.aerenderListbox1.UpBtn = this.btnUp;
			this.aerenderListbox1.ItemChanged += new System.EventHandler(this.aerenderListbox1_ItemChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnAddAep
			// 
			this.btnAddAep.Image = global::aerender_MamiSan.Properties.Resources.OpenFile;
			this.btnAddAep.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddAep.Name = "btnAddAep";
			this.btnAddAep.Size = new System.Drawing.Size(71, 22);
			this.btnAddAep.Text = "AEP追加";
			this.btnAddAep.ToolTipText = "AEPファイルを追加します";
			this.btnAddAep.Click += new System.EventHandler(this.addAepMenu_Click);
			// 
			// btnExportBatch
			// 
			this.btnExportBatch.Enabled = false;
			this.btnExportBatch.Image = global::aerender_MamiSan.Properties.Resources.saveHS;
			this.btnExportBatch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExportBatch.Name = "btnExportBatch";
			this.btnExportBatch.Size = new System.Drawing.Size(75, 22);
			this.btnExportBatch.Text = "バッチ出力";
			this.btnExportBatch.ToolTipText = "Batchファイルを出力";
			this.btnExportBatch.Click += new System.EventHandler(this.exportBatchMenu_Click);
			// 
			// btnExecBatch
			// 
			this.btnExecBatch.Enabled = false;
			this.btnExecBatch.Image = global::aerender_MamiSan.Properties.Resources.TaskHS;
			this.btnExecBatch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExecBatch.Name = "btnExecBatch";
			this.btnExecBatch.Size = new System.Drawing.Size(75, 22);
			this.btnExecBatch.Text = "バッチ実行";
			this.btnExecBatch.ToolTipText = "バッチを実行";
			this.btnExecBatch.Click += new System.EventHandler(this.execBatchMenu_Click);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.ClientSize = new System.Drawing.Size(512, 698);
			this.Controls.Add(this.lbAl);
			this.Controls.Add(this.btnDup);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.aerenderOptBox1);
			this.Controls.Add(this.aerenderListbox1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(520, 720);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "aerender_MamiSan";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private aerenderListbox aerenderListbox1;
		private aerenderOptBox aerenderOptBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addAepMenu;
		private System.Windows.Forms.ToolStripMenuItem loadAOMMenu;
		private System.Windows.Forms.ToolStripMenuItem loadARSMenu;
		private System.Windows.Forms.ToolStripMenuItem quitMenu;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnAddAep;
		private System.Windows.Forms.ToolStripButton btnExportBatch;
		private System.Windows.Forms.ToolStripButton btnExecBatch;
		//private System.Windows.Forms.ToolStripButton btnExecBatch;

		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnDup;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Label lbAl;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem exportBatchMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem execBatchMenu;
		private System.Windows.Forms.ToolStripMenuItem showHelpMenu;
		private System.Windows.Forms.ToolStripMenuItem versionMenu;
		private System.Windows.Forms.ToolStripMenuItem fileMenu;
		private System.Windows.Forms.ToolStripMenuItem editMenu;
		private System.Windows.Forms.ToolStripMenuItem selectALLMenu;
		private System.Windows.Forms.ToolStripMenuItem HelpMenu;
		private System.Windows.Forms.ToolStripMenuItem clearALLMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem prefMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

	}
}

