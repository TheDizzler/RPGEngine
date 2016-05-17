namespace MakerEngine {
	partial class AccordionInputControl {
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_DefaultInput = new System.Windows.Forms.TextBox();
			this.textBox_saveTo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Default Input";
			// 
			// textBox_DefaultInput
			// 
			this.textBox_DefaultInput.Location = new System.Drawing.Point(107, 4);
			this.textBox_DefaultInput.MaxLength = 10;
			this.textBox_DefaultInput.Name = "textBox_DefaultInput";
			this.textBox_DefaultInput.Size = new System.Drawing.Size(121, 20);
			this.textBox_DefaultInput.TabIndex = 1;
			this.textBox_DefaultInput.TextChanged += new System.EventHandler(this.textChanged);
			// 
			// textBox_saveTo
			// 
			this.textBox_saveTo.Location = new System.Drawing.Point(107, 28);
			this.textBox_saveTo.MaxLength = 32;
			this.textBox_saveTo.Name = "textBox_saveTo";
			this.textBox_saveTo.Size = new System.Drawing.Size(121, 20);
			this.textBox_saveTo.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Variable to Save to";
			// 
			// AccordionInputControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox_saveTo);
			this.Controls.Add(this.textBox_DefaultInput);
			this.Controls.Add(this.label1);
			this.Name = "AccordionInputControl";
			this.Size = new System.Drawing.Size(476, 53);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_DefaultInput;
		private System.Windows.Forms.TextBox textBox_saveTo;
		private System.Windows.Forms.Label label2;
	}
}
