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
			this.components = new System.ComponentModel.Container();
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
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox_AccordionHolder = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.richTextBox_EscapeCharacters = new System.Windows.Forms.RichTextBox();
			this.label_Speaker = new System.Windows.Forms.Label();
			this.textBox_Speaker = new System.Windows.Forms.TextBox();
			this.treeView_Dialog = new System.Windows.Forms.TreeView();
			this.contextMenuStrip_DataTree = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addNewEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.triggeredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.zoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addNewDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addNewLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox_NeedSave = new System.Windows.Forms.PictureBox();
			this.label_ChangesMade = new System.Windows.Forms.Label();
			this.accordion_Dialog = new Opulos.Core.UI.Accordion();
			this.menuStrip1.SuspendLayout();
			this.tabControl_Main.SuspendLayout();
			this.tabPage_Dialog.SuspendLayout();
			this.groupBox_AccordionHolder.SuspendLayout();
			this.contextMenuStrip_DataTree.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_NeedSave)).BeginInit();
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
			this.saveToolStripMenuItem.ShortcutKeyDisplayString = "ctrl+s";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveAsToolStripMenuItem.Text = "Save As";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem.Text = "Load Game";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
			this.tabPage_Dialog.Controls.Add(this.label_ChangesMade);
			this.tabPage_Dialog.Controls.Add(this.pictureBox_NeedSave);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Dialog Events";
			// 
			// groupBox_AccordionHolder
			// 
			this.groupBox_AccordionHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_AccordionHolder.Controls.Add(this.button1);
			this.groupBox_AccordionHolder.Controls.Add(this.accordion_Dialog);
			this.groupBox_AccordionHolder.Location = new System.Drawing.Point(270, 32);
			this.groupBox_AccordionHolder.Name = "groupBox_AccordionHolder";
			this.groupBox_AccordionHolder.Size = new System.Drawing.Size(625, 451);
			this.groupBox_AccordionHolder.TabIndex = 7;
			this.groupBox_AccordionHolder.TabStop = false;
			this.groupBox_AccordionHolder.Text = "Dialog Flow";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(7, 422);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "New Dialog Block";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// richTextBox_EscapeCharacters
			// 
			this.richTextBox_EscapeCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.richTextBox_EscapeCharacters.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.richTextBox_EscapeCharacters.Location = new System.Drawing.Point(98, 415);
			this.richTextBox_EscapeCharacters.Name = "richTextBox_EscapeCharacters";
			this.richTextBox_EscapeCharacters.ReadOnly = true;
			this.richTextBox_EscapeCharacters.Size = new System.Drawing.Size(162, 65);
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
			this.treeView_Dialog.Size = new System.Drawing.Size(253, 382);
			this.treeView_Dialog.TabIndex = 0;
			this.treeView_Dialog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_Dialog_MouseDoubleClick);
			this.treeView_Dialog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp_EventsTreeView);
			// 
			// contextMenuStrip_DataTree
			// 
			this.contextMenuStrip_DataTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEventToolStripMenuItem,
            this.addNewDialogToolStripMenuItem,
            this.addNewLocationToolStripMenuItem,
            this.deleteEventToolStripMenuItem});
			this.contextMenuStrip_DataTree.Name = "contextMenuStrip_DataTree";
			this.contextMenuStrip_DataTree.Size = new System.Drawing.Size(173, 92);
			// 
			// addNewEventToolStripMenuItem
			// 
			this.addNewEventToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.triggeredToolStripMenuItem,
            this.zoneToolStripMenuItem});
			this.addNewEventToolStripMenuItem.Name = "addNewEventToolStripMenuItem";
			this.addNewEventToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.addNewEventToolStripMenuItem.Text = "Add New Event";
			// 
			// deleteEventToolStripMenuItem
			// 
			this.deleteEventToolStripMenuItem.Name = "deleteEventToolStripMenuItem";
			this.deleteEventToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.deleteEventToolStripMenuItem.Text = "Delete Event";
			// 
			// triggeredToolStripMenuItem
			// 
			this.triggeredToolStripMenuItem.Name = "triggeredToolStripMenuItem";
			this.triggeredToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.triggeredToolStripMenuItem.Text = "Triggered";
			// 
			// zoneToolStripMenuItem
			// 
			this.zoneToolStripMenuItem.Name = "zoneToolStripMenuItem";
			this.zoneToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.zoneToolStripMenuItem.Text = "Zone";
			// 
			// addNewDialogToolStripMenuItem
			// 
			this.addNewDialogToolStripMenuItem.Name = "addNewDialogToolStripMenuItem";
			this.addNewDialogToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.addNewDialogToolStripMenuItem.Text = "Add New Dialog";
			this.addNewDialogToolStripMenuItem.Click += new System.EventHandler(this.addNewDialogToolStripMenuItem_Click);
			// 
			// addNewLocationToolStripMenuItem
			// 
			this.addNewLocationToolStripMenuItem.Name = "addNewLocationToolStripMenuItem";
			this.addNewLocationToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.addNewLocationToolStripMenuItem.Text = "Add New Location";
			// 
			// pictureBox_NeedSave
			// 
			this.pictureBox_NeedSave.Image = global::MakerEngine.Properties.Resources.Green;
			this.pictureBox_NeedSave.Location = new System.Drawing.Point(874, 9);
			this.pictureBox_NeedSave.Name = "pictureBox_NeedSave";
			this.pictureBox_NeedSave.Size = new System.Drawing.Size(16, 16);
			this.pictureBox_NeedSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox_NeedSave.TabIndex = 9;
			this.pictureBox_NeedSave.TabStop = false;
			// 
			// label_ChangesMade
			// 
			this.label_ChangesMade.AutoSize = true;
			this.label_ChangesMade.Location = new System.Drawing.Point(783, 9);
			this.label_ChangesMade.Name = "label_ChangesMade";
			this.label_ChangesMade.Size = new System.Drawing.Size(65, 13);
			this.label_ChangesMade.TabIndex = 10;
			this.label_ChangesMade.Text = "No changes";
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
			this.accordion_Dialog.GrabWidth = 0;
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
			this.accordion_Dialog.Size = new System.Drawing.Size(619, 432);
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
			this.contextMenuStrip_DataTree.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_NeedSave)).EndInit();
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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_DataTree;
		private System.Windows.Forms.ToolStripMenuItem addNewEventToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteEventToolStripMenuItem;
		private System.Windows.Forms.PictureBox pictureBox_NeedSave;
		private System.Windows.Forms.ToolStripMenuItem triggeredToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem zoneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addNewDialogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addNewLocationToolStripMenuItem;
		private System.Windows.Forms.Label label_ChangesMade;
	}
}

