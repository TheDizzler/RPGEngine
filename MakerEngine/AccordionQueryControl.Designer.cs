namespace MakerEngine {
	partial class AccordionQueryControl {
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
			this.panel_ControlHolder = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.button_JumpTo = new System.Windows.Forms.Button();
			this.richTextBox_Choice = new System.Windows.Forms.RichTextBox();
			this.textBox_JumpTo = new System.Windows.Forms.TextBox();
			this.panel_ControlHolder.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_ControlHolder
			// 
			this.panel_ControlHolder.AutoSize = true;
			this.panel_ControlHolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel_ControlHolder.Controls.Add(this.textBox_JumpTo);
			this.panel_ControlHolder.Controls.Add(this.label2);
			this.panel_ControlHolder.Controls.Add(this.button_JumpTo);
			this.panel_ControlHolder.Controls.Add(this.richTextBox_Choice);
			this.panel_ControlHolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_ControlHolder.Location = new System.Drawing.Point(0, 0);
			this.panel_ControlHolder.Name = "panel_ControlHolder";
			this.panel_ControlHolder.Size = new System.Drawing.Size(476, 112);
			this.panel_ControlHolder.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Pointer to Reply Block";
			// 
			// button_JumpTo
			// 
			this.button_JumpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_JumpTo.Location = new System.Drawing.Point(357, 80);
			this.button_JumpTo.Name = "button_JumpTo";
			this.button_JumpTo.Size = new System.Drawing.Size(111, 23);
			this.button_JumpTo.TabIndex = 2;
			this.button_JumpTo.Text = "Jump To Block";
			this.button_JumpTo.UseVisualStyleBackColor = true;
			// 
			// richTextBox_Choice
			// 
			this.richTextBox_Choice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox_Choice.AutoWordSelection = true;
			this.richTextBox_Choice.Location = new System.Drawing.Point(7, 4);
			this.richTextBox_Choice.MaxLength = 1500;
			this.richTextBox_Choice.Name = "richTextBox_Choice";
			this.richTextBox_Choice.Size = new System.Drawing.Size(462, 75);
			this.richTextBox_Choice.TabIndex = 1;
			this.richTextBox_Choice.Text = "answer.InnerText";
			// 
			// textBox_JumpTo
			// 
			this.textBox_JumpTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_JumpTo.Location = new System.Drawing.Point(116, 82);
			this.textBox_JumpTo.MaxLength = 32;
			this.textBox_JumpTo.Name = "textBox_JumpTo";
			this.textBox_JumpTo.Size = new System.Drawing.Size(234, 20);
			this.textBox_JumpTo.TabIndex = 4;
			this.textBox_JumpTo.Text = "answer.Attributes[\"to\"].InnerText";
			// 
			// AccordionQueryControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.panel_ControlHolder);
			this.Name = "AccordionQueryControl";
			this.Size = new System.Drawing.Size(476, 112);
			this.panel_ControlHolder.ResumeLayout(false);
			this.panel_ControlHolder.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel_ControlHolder;
		private System.Windows.Forms.Button button_JumpTo;
		private System.Windows.Forms.RichTextBox richTextBox_Choice;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_JumpTo;
	}
}
