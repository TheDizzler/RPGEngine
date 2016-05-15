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
			this.richTextBox_dialogText = new System.Windows.Forms.RichTextBox();
			this.textBox_from = new System.Windows.Forms.TextBox();
			this.textBox_jumpTo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip_PreviousBlockLabel = new System.Windows.Forms.ToolTip(this.components);
			this.toolTip_NextBlockLabel = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// richTextBox_dialogText
			// 
			this.richTextBox_dialogText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox_dialogText.Location = new System.Drawing.Point(4, 4);
			this.richTextBox_dialogText.Name = "richTextBox_dialogText";
			this.richTextBox_dialogText.Size = new System.Drawing.Size(418, 115);
			this.richTextBox_dialogText.TabIndex = 0;
			this.richTextBox_dialogText.Text = "node.InnerText";
			// 
			// textBox_from
			// 
			this.textBox_from.Location = new System.Drawing.Point(75, 122);
			this.textBox_from.MaxLength = 32;
			this.textBox_from.Name = "textBox_from";
			this.textBox_from.Size = new System.Drawing.Size(144, 20);
			this.textBox_from.TabIndex = 1;
			this.textBox_from.Text = "node.Attributes[\"from\"].InnerText";
			this.toolTip_NextBlockLabel.SetToolTip(this.textBox_from, "Leave blank to cascade to next dialog box");
			// 
			// textBox_jumpTo
			// 
			this.textBox_jumpTo.Location = new System.Drawing.Point(266, 150);
			this.textBox_jumpTo.MaxLength = 32;
			this.textBox_jumpTo.Name = "textBox_jumpTo";
			this.textBox_jumpTo.Size = new System.Drawing.Size(156, 20);
			this.textBox_jumpTo.TabIndex = 2;
			this.textBox_jumpTo.Text = "node.Attributes[\"to\"].InnerText";
			this.toolTip_NextBlockLabel.SetToolTip(this.textBox_jumpTo, "Leave blank to cascade to next dialog box");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 125);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Block Name";
			this.toolTip_NextBlockLabel.SetToolTip(this.label1, "Came from");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(174, 153);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Block to Jump to";
			this.toolTip_NextBlockLabel.SetToolTip(this.label2, "Jump to");
			// 
			// AccordionDialogTextControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_jumpTo);
			this.Controls.Add(this.textBox_from);
			this.Controls.Add(this.richTextBox_dialogText);
			this.Name = "AccordionDialogTextControl";
			this.Size = new System.Drawing.Size(425, 173);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox_dialogText;
		private System.Windows.Forms.TextBox textBox_from;
		private System.Windows.Forms.TextBox textBox_jumpTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolTip toolTip_PreviousBlockLabel;
		private System.Windows.Forms.ToolTip toolTip_NextBlockLabel;
	}
}
