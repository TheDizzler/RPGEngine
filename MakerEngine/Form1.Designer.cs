namespace MakerEngine {
	partial class MakerEngineForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newGameFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tabControl_Main = new System.Windows.Forms.TabControl();
			this.Main = new System.Windows.Forms.TabPage();
			this.tabPage_Dialog = new System.Windows.Forms.TabPage();
			this.groupBox_AccordionHolder = new System.Windows.Forms.GroupBox();
			this.richTextBox_EscapeCharacters = new System.Windows.Forms.RichTextBox();
			this.label_Speaker = new System.Windows.Forms.Label();
			this.textBox_Speaker = new System.Windows.Forms.TextBox();
			this.treeView_Dialog = new System.Windows.Forms.TreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.accordion_Dialog = new Opulos.Core.UI.Accordion();
			this.menuStrip1.SuspendLayout();
			this.tabControl_Main.SuspendLayout();
			this.tabPage_Dialog.SuspendLayout();
			this.groupBox_AccordionHolder.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(906, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.newGameToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.saveAsToolStripMenuItem.Text = "Save As";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.loadToolStripMenuItem.Text = "Load Game";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.newGameToolStripMenuItem.Text = "New Game";
			this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
			// 
			// newGameFileDialog
			// 
			this.newGameFileDialog.FileName = "Adventure Quest 13";
			this.newGameFileDialog.InitialDirectory = "D:\\github projects\\RPGEngine\\Debug";
			this.newGameFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.newGameFileDialog_FileOk);
			// 
			// tabControl_Main
			// 
			this.tabControl_Main.Controls.Add(this.Main);
			this.tabControl_Main.Controls.Add(this.tabPage_Dialog);
			this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl_Main.Location = new System.Drawing.Point(0, 24);
			this.tabControl_Main.Name = "tabControl_Main";
			this.tabControl_Main.SelectedIndex = 0;
			this.tabControl_Main.Size = new System.Drawing.Size(906, 517);
			this.tabControl_Main.TabIndex = 2;
			// 
			// Main
			// 
			this.Main.Location = new System.Drawing.Point(4, 22);
			this.Main.Name = "Main";
			this.Main.Padding = new System.Windows.Forms.Padding(3);
			this.Main.Size = new System.Drawing.Size(898, 491);
			this.Main.TabIndex = 0;
			this.Main.Text = "Main";
			this.Main.UseVisualStyleBackColor = true;
			// 
			// tabPage_Dialog
			// 
			this.tabPage_Dialog.Controls.Add(this.label1);
			this.tabPage_Dialog.Controls.Add(this.groupBox_AccordionHolder);
			this.tabPage_Dialog.Controls.Add(this.richTextBox_EscapeCharacters);
			this.tabPage_Dialog.Controls.Add(this.label_Speaker);
			this.tabPage_Dialog.Controls.Add(this.textBox_Speaker);
			this.tabPage_Dialog.Controls.Add(this.treeView_Dialog);
			this.tabPage_Dialog.Location = new System.Drawing.Point(4, 22);
			this.tabPage_Dialog.Name = "tabPage_Dialog";
			this.tabPage_Dialog.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_Dialog.Size = new System.Drawing.Size(898, 491);
			this.tabPage_Dialog.TabIndex = 1;
			this.tabPage_Dialog.Text = "Dialog Text";
			this.tabPage_Dialog.UseVisualStyleBackColor = true;
			// 
			// groupBox_AccordionHolder
			// 
			this.groupBox_AccordionHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_AccordionHolder.Controls.Add(this.accordion_Dialog);
			this.groupBox_AccordionHolder.Location = new System.Drawing.Point(470, 32);
			this.groupBox_AccordionHolder.Name = "groupBox_AccordionHolder";
			this.groupBox_AccordionHolder.Size = new System.Drawing.Size(425, 451);
			this.groupBox_AccordionHolder.TabIndex = 7;
			this.groupBox_AccordionHolder.TabStop = false;
			this.groupBox_AccordionHolder.Text = "Dialog Flow";
			// 
			// richTextBox_EscapeCharacters
			// 
			this.richTextBox_EscapeCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.richTextBox_EscapeCharacters.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.richTextBox_EscapeCharacters.Location = new System.Drawing.Point(270, 403);
			this.richTextBox_EscapeCharacters.Name = "richTextBox_EscapeCharacters";
			this.richTextBox_EscapeCharacters.ReadOnly = true;
			this.richTextBox_EscapeCharacters.Size = new System.Drawing.Size(162, 80);
			this.richTextBox_EscapeCharacters.TabIndex = 4;
			this.richTextBox_EscapeCharacters.TabStop = false;
			this.richTextBox_EscapeCharacters.Text = "Special Characters:\n\\hero for player\'s name\n\\speaker for speakers name";
			// 
			// label_Speaker
			// 
			this.label_Speaker.AutoSize = true;
			this.label_Speaker.Location = new System.Drawing.Point(267, 12);
			this.label_Speaker.Name = "label_Speaker";
			this.label_Speaker.Size = new System.Drawing.Size(47, 13);
			this.label_Speaker.TabIndex = 3;
			this.label_Speaker.Text = "Speaker";
			// 
			// textBox_Speaker
			// 
			this.textBox_Speaker.Location = new System.Drawing.Point(320, 6);
			this.textBox_Speaker.Name = "textBox_Speaker";
			this.textBox_Speaker.Size = new System.Drawing.Size(144, 20);
			this.textBox_Speaker.TabIndex = 2;
			// 
			// treeView_Dialog
			// 
			this.treeView_Dialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView_Dialog.Location = new System.Drawing.Point(7, 27);
			this.treeView_Dialog.Name = "treeView_Dialog";
			this.treeView_Dialog.Size = new System.Drawing.Size(253, 456);
			this.treeView_Dialog.TabIndex = 0;
			this.treeView_Dialog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_Dialog_MouseDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Dialog Events";
			// 
			// accordion_Dialog
			// 
			this.accordion_Dialog.AddResizeBars = false;
			this.accordion_Dialog.AllowMouseResize = false;
			this.accordion_Dialog.AnimateCloseEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalNegative | Opulos.Core.UI.AnimateWindowFlags.Hide) 
            | Opulos.Core.UI.AnimateWindowFlags.Slide)));
			this.accordion_Dialog.AnimateCloseMillis = 300;
			this.accordion_Dialog.AnimateOpenEffect = ((Opulos.Core.UI.AnimateWindowFlags)(((Opulos.Core.UI.AnimateWindowFlags.VerticalPositive | Opulos.Core.UI.AnimateWindowFlags.Show) 
            | Opulos.Core.UI.AnimateWindowFlags.Slide)));
			this.accordion_Dialog.AnimateOpenMillis = 300;
			this.accordion_Dialog.AutoFixDockStyle = true;
			this.accordion_Dialog.AutoScroll = true;
			this.accordion_Dialog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.accordion_Dialog.CheckBoxFactory = null;
			this.accordion_Dialog.CheckBoxMargin = new System.Windows.Forms.Padding(0);
			this.accordion_Dialog.ContentBackColor = null;
			this.accordion_Dialog.ContentMargin = null;
			this.accordion_Dialog.ContentPadding = new System.Windows.Forms.Padding(5);
			this.accordion_Dialog.ControlBackColor = null;
			this.accordion_Dialog.ControlMinimumHeightIsItsPreferredHeight = true;
			this.accordion_Dialog.ControlMinimumWidthIsItsPreferredWidth = true;
			this.accordion_Dialog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.accordion_Dialog.DownArrow = null;
			this.accordion_Dialog.FillHeight = true;
			this.accordion_Dialog.FillLastOpened = false;
			this.accordion_Dialog.FillModeGrowOnly = false;
			this.accordion_Dialog.FillResetOnCollapse = false;
			this.accordion_Dialog.FillWidth = true;
			this.accordion_Dialog.GrabCursor = System.Windows.Forms.Cursors.SizeNS;
			this.accordion_Dialog.GrabRequiresPositiveFillWeight = true;
			this.accordion_Dialog.GrabWidth =0;
			this.accordion_Dialog.GrowAndShrink = true;
			this.accordion_Dialog.Insets = new System.Windows.Forms.Padding(0);
			this.accordion_Dialog.Location = new System.Drawing.Point(3, 16);
			this.accordion_Dialog.Name = "accordion_Dialog";
			this.accordion_Dialog.OpenOnAdd = false;
			this.accordion_Dialog.OpenOneOnly = false;
			this.accordion_Dialog.ResizeBarFactory = null;
			this.accordion_Dialog.ResizeBarsAlign = 0.5D;
			this.accordion_Dialog.ResizeBarsArrowKeyDelta = 10;
			this.accordion_Dialog.ResizeBarsFadeInMillis = 800;
			this.accordion_Dialog.ResizeBarsFadeOutMillis = 800;
			this.accordion_Dialog.ResizeBarsFadeProximity = 24;
			this.accordion_Dialog.ResizeBarsFill = 1D;
			this.accordion_Dialog.ResizeBarsKeepFocusAfterMouseDrag = false;
			this.accordion_Dialog.ResizeBarsKeepFocusIfControlOutOfView = true;
			this.accordion_Dialog.ResizeBarsKeepFocusOnClick = true;
			this.accordion_Dialog.ResizeBarsMargin = null;
			this.accordion_Dialog.ResizeBarsMinimumLength = 50;
			this.accordion_Dialog.ResizeBarsStayInViewOnArrowKey = true;
			this.accordion_Dialog.ResizeBarsStayInViewOnMouseDrag = true;
			this.accordion_Dialog.ResizeBarsStayVisibleIfFocused = true;
			this.accordion_Dialog.ResizeBarsTabStop = true;
			this.accordion_Dialog.ShowPartiallyVisibleResizeBars = false;
			this.accordion_Dialog.ShowToolMenu = true;
			this.accordion_Dialog.ShowToolMenuOnHoverWhenClosed = false;
			this.accordion_Dialog.ShowToolMenuOnRightClick = true;
			this.accordion_Dialog.ShowToolMenuRequiresPositiveFillWeight = false;
			this.accordion_Dialog.Size = new System.Drawing.Size(419, 432);
			this.accordion_Dialog.TabIndex = 0;
			this.accordion_Dialog.UpArrow = null;
			// 
			// MakerEngineForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(906, 541);
			this.Controls.Add(this.tabControl_Main);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MakerEngineForm";
			this.Text = "MakerEngine - No Game Loaded";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl_Main.ResumeLayout(false);
			this.tabPage_Dialog.ResumeLayout(false);
			this.tabPage_Dialog.PerformLayout();
			this.groupBox_AccordionHolder.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog newGameFileDialog;
		private System.Windows.Forms.TabControl tabControl_Main;
		private System.Windows.Forms.TabPage Main;
		private System.Windows.Forms.TabPage tabPage_Dialog;
		private System.Windows.Forms.TreeView treeView_Dialog;
		private System.Windows.Forms.Label label_Speaker;
		private System.Windows.Forms.TextBox textBox_Speaker;
		private System.Windows.Forms.RichTextBox richTextBox_EscapeCharacters;
		//private System.Windows.Forms.Panel panel1;
		private Opulos.Core.UI.Accordion accordion_Dialog;
		private System.Windows.Forms.GroupBox groupBox_AccordionHolder;
		private System.Windows.Forms.Label label1;
	}
}

