namespace aerender_MamiSan
{
	partial class outputPathDialog
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
			this.edPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDir = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.edName = new System.Windows.Forms.TextBox();
			this.cmbExt = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbKeta = new System.Windows.Forms.ComboBox();
			this.edPreview = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// edPath
			// 
			this.edPath.Location = new System.Drawing.Point(19, 87);
			this.edPath.Name = "edPath";
			this.edPath.Size = new System.Drawing.Size(527, 19);
			this.edPath.TabIndex = 3;
			this.edPath.TextChanged += new System.EventHandler(this.edPath_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(198, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "出力先(ここへフォルダをドラッグ＆ドロップ)";
			// 
			// btnDir
			// 
			this.btnDir.Location = new System.Drawing.Point(471, 65);
			this.btnDir.Name = "btnDir";
			this.btnDir.Size = new System.Drawing.Size(75, 20);
			this.btnDir.TabIndex = 4;
			this.btnDir.Text = "フォルダ選択";
			this.btnDir.UseVisualStyleBackColor = true;
			this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "出力ファイル名";
			// 
			// edName
			// 
			this.edName.Location = new System.Drawing.Point(19, 134);
			this.edName.Name = "edName";
			this.edName.Size = new System.Drawing.Size(164, 19);
			this.edName.TabIndex = 6;
			this.edName.TextChanged += new System.EventHandler(this.edPath_TextChanged);
			// 
			// cmbExt
			// 
			this.cmbExt.FormattingEnabled = true;
			this.cmbExt.Items.AddRange(new object[] {
            ".mov",
            ".avi",
            ".m4v",
            ".tga",
            ".png",
            ".jpg",
            ".tif"});
			this.cmbExt.Location = new System.Drawing.Point(292, 133);
			this.cmbExt.Name = "cmbExt";
			this.cmbExt.Size = new System.Drawing.Size(73, 20);
			this.cmbExt.TabIndex = 10;
			this.cmbExt.TextChanged += new System.EventHandler(this.edPath_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(290, 119);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = "拡張子";
			// 
			// cmbKeta
			// 
			this.cmbKeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbKeta.FormattingEnabled = true;
			this.cmbKeta.Location = new System.Drawing.Point(188, 133);
			this.cmbKeta.Name = "cmbKeta";
			this.cmbKeta.Size = new System.Drawing.Size(98, 20);
			this.cmbKeta.TabIndex = 8;
			this.cmbKeta.SelectedIndexChanged += new System.EventHandler(this.cmbKeta_SelectedIndexChanged);
			// 
			// edPreview
			// 
			this.edPreview.Location = new System.Drawing.Point(19, 20);
			this.edPreview.Multiline = true;
			this.edPreview.Name = "edPreview";
			this.edPreview.ReadOnly = true;
			this.edPreview.Size = new System.Drawing.Size(529, 43);
			this.edPreview.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 12);
			this.label5.TabIndex = 0;
			this.label5.Text = "output preview";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(473, 134);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(392, 134);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(186, 119);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "フレーム番号の桁数";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// outputPathDialog
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 174);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.edPreview);
			this.Controls.Add(this.cmbKeta);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbExt);
			this.Controls.Add(this.edName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnDir);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.edPath);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "outputPathDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "outputの指定";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.outputPathDialog_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.outputPathDialog_DragEnter);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox edPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDir;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edName;
		private System.Windows.Forms.ComboBox cmbExt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbKeta;
		private System.Windows.Forms.TextBox edPreview;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label4;
	}
}