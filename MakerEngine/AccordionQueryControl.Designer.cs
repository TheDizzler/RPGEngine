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
			this.button_NewChoice = new System.Windows.Forms.Button();
			this.textBox_From = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel_ControlHolder.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_ControlHolder
			// 
			this.panel_ControlHolder.Controls.Add(this.label1);
			this.panel_ControlHolder.Controls.Add(this.textBox_From);
			this.panel_ControlHolder.Controls.Add(this.button_NewChoice);
			this.panel_ControlHolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_ControlHolder.Location = new System.Drawing.Point(0, 0);
			this.panel_ControlHolder.Name = "panel_ControlHolder";
			this.panel_ControlHolder.Size = new System.Drawing.Size(476, 175);
			this.panel_ControlHolder.TabIndex = 0;
			// 
			// button_NewChoice
			// 
			this.button_NewChoice.Location = new System.Drawing.Point(3, 38);
			this.button_NewChoice.Name = "button_NewChoice";
			this.button_NewChoice.Size = new System.Drawing.Size(112, 23);
			this.button_NewChoice.TabIndex = 0;
			this.button_NewChoice.Text = "New Choice";
			this.button_NewChoice.UseVisualStyleBackColor = true;
			// 
			// textBox_From
			// 
			this.textBox_From.Location = new System.Drawing.Point(75, 6);
			this.textBox_From.MaxLength = 32;
			this.textBox_From.Name = "textBox_From";
			this.textBox_From.Size = new System.Drawing.Size(185, 20);
			this.textBox_From.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Block Name";
			// 
			// AccordionQueryControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel_ControlHolder);
			this.Name = "AccordionQueryControl";
			this.Size = new System.Drawing.Size(476, 175);
			this.panel_ControlHolder.ResumeLayout(false);
			this.panel_ControlHolder.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel_ControlHolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_From;
		private System.Windows.Forms.Button button_NewChoice;
	}
}
