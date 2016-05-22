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
			this.runGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newGameFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPage_Dialog = new System.Windows.Forms.TabPage();
			this.button_NewEvent = new System.Windows.Forms.Button();
			this.label_ChangesMade = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox_AccordionHolder = new System.Windows.Forms.GroupBox();
			this.richTextBox_EscapeCharacters = new System.Windows.Forms.RichTextBox();
			this.label_Speaker = new System.Windows.Forms.Label();
			this.textBox_Speaker = new System.Windows.Forms.TextBox();
			this.treeView_Dialog = new System.Windows.Forms.TreeView();
			this.tabPage_Map = new System.Windows.Forms.TabPage();
			this.tabPage_SpriteLoader = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button_Zoom = new System.Windows.Forms.Button();
			this.textBox_SpriteFilePath = new System.Windows.Forms.TextBox();
			this.button_LoadSprite = new System.Windows.Forms.Button();
			this.textBox_Dimensions = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.treeView_Sprites = new System.Windows.Forms.TreeView();
			this.contextMenuStrip_ZoneText = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.spriteList = new System.Windows.Forms.ImageList(this.components);
			this.openFileDialog_Sprite = new System.Windows.Forms.OpenFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.button3 = new System.Windows.Forms.Button();
			this.button_CreateSpriteFont = new System.Windows.Forms.Button();
			this.pictureBox_NeedSave = new System.Windows.Forms.PictureBox();
			this.pictureBox_SpriteView = new System.Windows.Forms.PictureBox();
			this.accordion_Dialog = new Opulos.Core.UI.Accordion();
			this.menuStrip1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPage_Dialog.SuspendLayout();
			this.groupBox_AccordionHolder.SuspendLayout();
			this.tabPage_SpriteLoader.SuspendLayout();
			this.contextMenuStrip_ZoneText.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_NeedSave)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_SpriteView)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runGameToolStripMenuItem});
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
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.saveAsToolStripMenuItem.Text = "Save As";
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.loadToolStripMenuItem.Text = "Load Game";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.newGameToolStripMenuItem.Text = "New Game";
			this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
			// 
			// runGameToolStripMenuItem
			// 
			this.runGameToolStripMenuItem.Name = "runGameToolStripMenuItem";
			this.runGameToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
			this.runGameToolStripMenuItem.Text = "Run Game";
			// 
			// newGameFileDialog
			// 
			this.newGameFileDialog.FileName = "Adventure Quest 13";
			this.newGameFileDialog.InitialDirectory = "D:\\github projects\\RPGEngine\\Debug";
			this.newGameFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.newGameFileDialog_FileOk);
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPage_Dialog);
			this.tabControl.Controls.Add(this.tabPage_Map);
			this.tabControl.Controls.Add(this.tabPage_SpriteLoader);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 24);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(906, 517);
			this.tabControl.TabIndex = 2;
			// 
			// tabPage_Dialog
			// 
			this.tabPage_Dialog.Controls.Add(this.button_NewEvent);
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
			// button_NewEvent
			// 
			this.button_NewEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_NewEvent.Location = new System.Drawing.Point(7, 415);
			this.button_NewEvent.Name = "button_NewEvent";
			this.button_NewEvent.Size = new System.Drawing.Size(85, 23);
			this.button_NewEvent.TabIndex = 1;
			this.button_NewEvent.Text = "New Event";
			this.button_NewEvent.UseVisualStyleBackColor = true;
			this.button_NewEvent.Click += new System.EventHandler(this.button_NewEvent_Click);
			// 
			// label_ChangesMade
			// 
			this.label_ChangesMade.AutoSize = true;
			this.label_ChangesMade.Location = new System.Drawing.Point(787, 8);
			this.label_ChangesMade.Name = "label_ChangesMade";
			this.label_ChangesMade.Size = new System.Drawing.Size(65, 13);
			this.label_ChangesMade.TabIndex = 10;
			this.label_ChangesMade.Text = "No changes";
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
			this.groupBox_AccordionHolder.Controls.Add(this.accordion_Dialog);
			this.groupBox_AccordionHolder.Location = new System.Drawing.Point(270, 32);
			this.groupBox_AccordionHolder.Name = "groupBox_AccordionHolder";
			this.groupBox_AccordionHolder.Size = new System.Drawing.Size(625, 451);
			this.groupBox_AccordionHolder.TabIndex = 7;
			this.groupBox_AccordionHolder.TabStop = false;
			this.groupBox_AccordionHolder.Text = "Dialog Flow";
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
			this.textBox_Speaker.TextChanged += new System.EventHandler(this.textChanged);
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
			// tabPage_Map
			// 
			this.tabPage_Map.Location = new System.Drawing.Point(4, 22);
			this.tabPage_Map.Name = "tabPage_Map";
			this.tabPage_Map.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_Map.Size = new System.Drawing.Size(898, 491);
			this.tabPage_Map.TabIndex = 2;
			this.tabPage_Map.Text = "Map Creator";
			this.tabPage_Map.UseVisualStyleBackColor = true;
			// 
			// tabPage_SpriteLoader
			// 
			this.tabPage_SpriteLoader.Controls.Add(this.button_CreateSpriteFont);
			this.tabPage_SpriteLoader.Controls.Add(this.button3);
			this.tabPage_SpriteLoader.Controls.Add(this.button1);
			this.tabPage_SpriteLoader.Controls.Add(this.button2);
			this.tabPage_SpriteLoader.Controls.Add(this.button_Zoom);
			this.tabPage_SpriteLoader.Controls.Add(this.textBox_SpriteFilePath);
			this.tabPage_SpriteLoader.Controls.Add(this.button_LoadSprite);
			this.tabPage_SpriteLoader.Controls.Add(this.textBox_Dimensions);
			this.tabPage_SpriteLoader.Controls.Add(this.label5);
			this.tabPage_SpriteLoader.Controls.Add(this.label4);
			this.tabPage_SpriteLoader.Controls.Add(this.textBox1);
			this.tabPage_SpriteLoader.Controls.Add(this.label3);
			this.tabPage_SpriteLoader.Controls.Add(this.label2);
			this.tabPage_SpriteLoader.Controls.Add(this.treeView_Sprites);
			this.tabPage_SpriteLoader.Controls.Add(this.pictureBox_SpriteView);
			this.tabPage_SpriteLoader.Location = new System.Drawing.Point(4, 22);
			this.tabPage_SpriteLoader.Name = "tabPage_SpriteLoader";
			this.tabPage_SpriteLoader.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_SpriteLoader.Size = new System.Drawing.Size(898, 491);
			this.tabPage_SpriteLoader.TabIndex = 3;
			this.tabPage_SpriteLoader.Text = "Sprite Loader";
			this.tabPage_SpriteLoader.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(868, 52);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "O";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(868, 84);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(24, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "-";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button_Zoom
			// 
			this.button_Zoom.Location = new System.Drawing.Point(868, 23);
			this.button_Zoom.Name = "button_Zoom";
			this.button_Zoom.Size = new System.Drawing.Size(24, 23);
			this.button_Zoom.TabIndex = 10;
			this.button_Zoom.Text = "+";
			this.button_Zoom.UseVisualStyleBackColor = true;
			this.button_Zoom.Click += new System.EventHandler(this.button_Zoom_Click);
			// 
			// textBox_SpriteFilePath
			// 
			this.textBox_SpriteFilePath.Location = new System.Drawing.Point(405, 460);
			this.textBox_SpriteFilePath.Name = "textBox_SpriteFilePath";
			this.textBox_SpriteFilePath.ReadOnly = true;
			this.textBox_SpriteFilePath.Size = new System.Drawing.Size(485, 20);
			this.textBox_SpriteFilePath.TabIndex = 9;
			// 
			// button_LoadSprite
			// 
			this.button_LoadSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_LoadSprite.Location = new System.Drawing.Point(787, 403);
			this.button_LoadSprite.Name = "button_LoadSprite";
			this.button_LoadSprite.Size = new System.Drawing.Size(75, 23);
			this.button_LoadSprite.TabIndex = 8;
			this.button_LoadSprite.Text = "Load Sprite";
			this.button_LoadSprite.UseVisualStyleBackColor = true;
			this.button_LoadSprite.Click += new System.EventHandler(this.button_LoadSprite_Click);
			// 
			// textBox_Dimensions
			// 
			this.textBox_Dimensions.Location = new System.Drawing.Point(405, 427);
			this.textBox_Dimensions.Name = "textBox_Dimensions";
			this.textBox_Dimensions.ReadOnly = true;
			this.textBox_Dimensions.Size = new System.Drawing.Size(72, 20);
			this.textBox_Dimensions.TabIndex = 7;
			this.textBox_Dimensions.Text = "0 , 0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(307, 467);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "File Path";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(307, 435);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Sprite Dimensions";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(405, 401);
			this.textBox1.MaxLength = 64;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(244, 20);
			this.textBox1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(307, 403);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Sprite Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Loaded Sprites";
			// 
			// treeView_Sprites
			// 
			this.treeView_Sprites.Location = new System.Drawing.Point(9, 23);
			this.treeView_Sprites.Name = "treeView_Sprites";
			this.treeView_Sprites.Size = new System.Drawing.Size(291, 425);
			this.treeView_Sprites.TabIndex = 1;
			this.treeView_Sprites.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView_Sprites_MouseDoubleClick);
			// 
			// contextMenuStrip_ZoneText
			// 
			this.contextMenuStrip_ZoneText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLocationToolStripMenuItem,
            this.deleteLocationToolStripMenuItem});
			this.contextMenuStrip_ZoneText.Name = "contextMenuStrip_ZoneText";
			this.contextMenuStrip_ZoneText.ShowImageMargin = false;
			this.contextMenuStrip_ZoneText.Size = new System.Drawing.Size(123, 48);
			// 
			// newLocationToolStripMenuItem
			// 
			this.newLocationToolStripMenuItem.Name = "newLocationToolStripMenuItem";
			this.newLocationToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.newLocationToolStripMenuItem.Text = "New Location";
			this.newLocationToolStripMenuItem.Click += new System.EventHandler(this.newLocationToolStripMenuItem_Click);
			// 
			// deleteLocationToolStripMenuItem
			// 
			this.deleteLocationToolStripMenuItem.Name = "deleteLocationToolStripMenuItem";
			this.deleteLocationToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.deleteLocationToolStripMenuItem.Text = "Delete Zone";
			// 
			// spriteList
			// 
			this.spriteList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.spriteList.ImageSize = new System.Drawing.Size(16, 16);
			this.spriteList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// openFileDialog_Sprite
			// 
			this.openFileDialog_Sprite.FileName = "openFileDialog_Sprite";
			this.openFileDialog_Sprite.Filter = "DDS files | *.dds";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(225, 458);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 13;
			this.button3.Text = "Save Sprite";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button_CreateSpriteFont
			// 
			this.button_CreateSpriteFont.Location = new System.Drawing.Point(9, 457);
			this.button_CreateSpriteFont.Name = "button_CreateSpriteFont";
			this.button_CreateSpriteFont.Size = new System.Drawing.Size(133, 23);
			this.button_CreateSpriteFont.TabIndex = 14;
			this.button_CreateSpriteFont.Text = "Create SpriteFont";
			this.button_CreateSpriteFont.UseVisualStyleBackColor = true;
			this.button_CreateSpriteFont.Click += new System.EventHandler(this.button_CreateSpriteFont_Click);
			// 
			// pictureBox_NeedSave
			// 
			this.pictureBox_NeedSave.Image = global::MakerEngine.Properties.Resources.Green;
			this.pictureBox_NeedSave.Location = new System.Drawing.Point(880, 5);
			this.pictureBox_NeedSave.Name = "pictureBox_NeedSave";
			this.pictureBox_NeedSave.Size = new System.Drawing.Size(16, 16);
			this.pictureBox_NeedSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox_NeedSave.TabIndex = 9;
			this.pictureBox_NeedSave.TabStop = false;
			// 
			// pictureBox_SpriteView
			// 
			this.pictureBox_SpriteView.BackColor = System.Drawing.Color.LavenderBlush;
			this.pictureBox_SpriteView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox_SpriteView.Location = new System.Drawing.Point(310, 23);
			this.pictureBox_SpriteView.Name = "pictureBox_SpriteView";
			this.pictureBox_SpriteView.Size = new System.Drawing.Size(552, 372);
			this.pictureBox_SpriteView.TabIndex = 0;
			this.pictureBox_SpriteView.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBox_SpriteView, "Click image to change background color");
			this.pictureBox_SpriteView.Click += new System.EventHandler(this.pictureBox_SpriteView_Click);
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
			this.Controls.Add(this.label_ChangesMade);
			this.Controls.Add(this.pictureBox_NeedSave);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MakerEngineForm";
			this.Text = "MakerEngine - No Game Loaded";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPage_Dialog.ResumeLayout(false);
			this.tabPage_Dialog.PerformLayout();
			this.groupBox_AccordionHolder.ResumeLayout(false);
			this.tabPage_SpriteLoader.ResumeLayout(false);
			this.tabPage_SpriteLoader.PerformLayout();
			this.contextMenuStrip_ZoneText.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_NeedSave)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_SpriteView)).EndInit();
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
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPage_Dialog;
		private System.Windows.Forms.TreeView treeView_Dialog;
		private System.Windows.Forms.Label label_Speaker;
		private System.Windows.Forms.TextBox textBox_Speaker;
		private System.Windows.Forms.RichTextBox richTextBox_EscapeCharacters;
		//private System.Windows.Forms.Panel panel1;
		private Opulos.Core.UI.Accordion accordion_Dialog;
		private System.Windows.Forms.GroupBox groupBox_AccordionHolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_NewEvent;
		private System.Windows.Forms.PictureBox pictureBox_NeedSave;
		private System.Windows.Forms.Label label_ChangesMade;
		private System.Windows.Forms.ToolStripMenuItem runGameToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ZoneText;
		private System.Windows.Forms.ToolStripMenuItem newLocationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteLocationToolStripMenuItem;
		private System.Windows.Forms.TabPage tabPage_Map;
		private System.Windows.Forms.TabPage tabPage_SpriteLoader;
		private System.Windows.Forms.Button button_LoadSprite;
		private System.Windows.Forms.TextBox textBox_Dimensions;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TreeView treeView_Sprites;
		private System.Windows.Forms.PictureBox pictureBox_SpriteView;
		private System.Windows.Forms.ImageList spriteList;
		private System.Windows.Forms.OpenFileDialog openFileDialog_Sprite;
		private System.Windows.Forms.TextBox textBox_SpriteFilePath;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button_Zoom;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button_CreateSpriteFont;
	}
}

