namespace MakerEngine {
	partial class EscapeCharactersDialog {
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
			this.richTextBox_EscapeCharacters = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox_EscapeCharacters
			// 
			this.richTextBox_EscapeCharacters.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.richTextBox_EscapeCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox_EscapeCharacters.Location = new System.Drawing.Point(0, 0);
			this.richTextBox_EscapeCharacters.Name = "richTextBox_EscapeCharacters";
			this.richTextBox_EscapeCharacters.ReadOnly = true;
			this.richTextBox_EscapeCharacters.Size = new System.Drawing.Size(507, 253);
			this.richTextBox_EscapeCharacters.TabIndex = 4;
			this.richTextBox_EscapeCharacters.TabStop = false;
			this.richTextBox_EscapeCharacters.Text = "Special Characters:\n\\hero \t\t\t\tfor player\'s name\n\\speaker \t\t\t\tfor speakers name\n\\m" +
    "oveto LOCATION\t\tmoves speaker to location\n\\moveby X,Y\t\t\tmoves speaker by vector " +
    "(in pixels)";
			this.richTextBox_EscapeCharacters.TextChanged += new System.EventHandler(this.richTextBox_EscapeCharacters_TextChanged);
			// 
			// EscapeCharactersDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(507, 253);
			this.Controls.Add(this.richTextBox_EscapeCharacters);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EscapeCharactersDialog";
			this.ShowIcon = false;
			this.Text = "Escape Characters";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox_EscapeCharacters;

	}
}