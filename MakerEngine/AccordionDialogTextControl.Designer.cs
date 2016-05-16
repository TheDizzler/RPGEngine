namespace MakerEngine {
	partial class AccordionDialogTextControl {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.richTextBox_dialogText = new System.Windows.Forms.TextBox();
			this.textBox_from = new System.Windows.Forms.TextBox();
			this.textBox_JumpTo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip_PreviousBlockLabel = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip_NextBlockLabel = new System.Windows.Forms.ToolTip(this.components);
			this.panel_ControlHolder = new System.Windows.Forms.Panel();
			this.button_CreateNewBlock = new System.Windows.Forms.Button();
			this.panel_ControlHolder.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox_dialogText
			// 
			this.richTextBox_dialogText.Dock = System.Windows.Forms.DockStyle.Top;
			this.richTextBox_dialogText.Location = new System.Drawing.Point(0, 0);
			this.richTextBox_dialogText.Multiline = true;
			this.richTextBox_dialogText.Name = "richTextBox_dialogText";
			this.richTextBox_dialogText.Size = new System.Drawing.Size(476, 115);
			this.richTextBox_dialogText.TabIndex = 0;
			this.richTextBox_dialogText.Text = "node.InnerText";
			this.richTextBox_dialogText.TextChanged += new System.EventHandler(this.textChanged);
			// 
			// textBox_from
			// 
			this.textBox_from.Location = new System.Drawing.Point(99, 122);
			this.textBox_from.MaxLength = 32;
			this.textBox_from.Name = "textBox_from";
			this.textBox_from.Size = new System.Drawing.Size(156, 20);
			this.textBox_from.TabIndex = 1;
			this.textBox_from.Text = "node.Attributes[\"from\"].InnerText";
			this.toolTip_NextBlockLabel.SetToolTip(this.textBox_from, "Leave blank to cascade to next dialog box");
			this.textBox_from.TextChanged += new System.EventHandler(this.textChanged);
			// 
			// textBox_JumpTo
			// 
			this.textBox_JumpTo.Location = new System.Drawing.Point(99, 146);
			this.textBox_JumpTo.MaxLength = 32;
			this.textBox_JumpTo.Name = "textBox_JumpTo";
			this.textBox_JumpTo.Size = new System.Drawing.Size(156, 20);
			this.textBox_JumpTo.TabIndex = 2;
			this.textBox_JumpTo.Text = "node.Attributes[\"to\"].InnerText";
			this.toolTip_NextBlockLabel.SetToolTip(this.textBox_JumpTo, "Leave blank to cascade to next dialog box");
			this.textBox_JumpTo.TextChanged += new System.EventHandler(this.textChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 125);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Block Name";
			this.toolTip_NextBlockLabel.SetToolTip(this.label1, "Came \"from\"");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 146);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Block to Jump to";
			this.toolTip_NextBlockLabel.SetToolTip(this.label2, "Jump to");
			// 
			// panel_ControlHolder
			// 
			this.panel_ControlHolder.AutoScroll = true;
			this.panel_ControlHolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel_ControlHolder.Controls.Add(this.button_CreateNewBlock);
			this.panel_ControlHolder.Controls.Add(this.richTextBox_dialogText);
			this.panel_ControlHolder.Controls.Add(this.textBox_from);
			this.panel_ControlHolder.Controls.Add(this.textBox_JumpTo);
			this.panel_ControlHolder.Controls.Add(this.label1);
			this.panel_ControlHolder.Controls.Add(this.label2);
			this.panel_ControlHolder.Location = new System.Drawing.Point(3, 3);
			this.panel_ControlHolder.Name = "panel_ControlHolder";
			this.panel_ControlHolder.Size = new System.Drawing.Size(476, 175);
			this.panel_ControlHolder.TabIndex = 5;
			// 
			// button_CreateNewBlock
			// 
			this.button_CreateNewBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button_CreateNewBlock.Location = new System.Drawing.Point(261, 144);
			this.button_CreateNewBlock.Name = "button_CreateNewBlock";
			this.button_CreateNewBlock.Size = new System.Drawing.Size(105, 23);
			this.button_CreateNewBlock.TabIndex = 5;
			this.button_CreateNewBlock.Text = "Create New Block";
			this.button_CreateNewBlock.UseVisualStyleBackColor = true;
			this.button_CreateNewBlock.Click += new System.EventHandler(this.button_CreateNewBlock_Click);
			// 
			// AccordionDialogTextControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.panel_ControlHolder);
			this.Name = "AccordionDialogTextControl";
			this.Size = new System.Drawing.Size(482, 181);
			this.panel_ControlHolder.ResumeLayout(false);
			this.panel_ControlHolder.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox richTextBox_dialogText;
		private System.Windows.Forms.TextBox textBox_from;
		private System.Windows.Forms.TextBox textBox_JumpTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolTip toolTip_PreviousBlockLabel;
		private System.Windows.Forms.ToolTip toolTip_NextBlockLabel;
		private System.Windows.Forms.Panel panel_ControlHolder;
		private System.Windows.Forms.Button button_CreateNewBlock;
	}
}
