namespace MakerEngine {
	partial class NewLocationDialog {
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
			this.button_Accept = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.textBox_NewLocation = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button_Accept
			// 
			this.button_Accept.Location = new System.Drawing.Point(13, 64);
			this.button_Accept.Name = "button_Accept";
			this.button_Accept.Size = new System.Drawing.Size(75, 23);
			this.button_Accept.TabIndex = 0;
			this.button_Accept.Text = "Accept";
			this.button_Accept.UseVisualStyleBackColor = true;
			this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.Location = new System.Drawing.Point(136, 64);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 1;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			// 
			// textBox_NewLocation
			// 
			this.textBox_NewLocation.Location = new System.Drawing.Point(12, 28);
			this.textBox_NewLocation.Name = "textBox_NewLocation";
			this.textBox_NewLocation.Size = new System.Drawing.Size(199, 20);
			this.textBox_NewLocation.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Name of New Location";
			// 
			// NewLocationDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(225, 99);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_NewLocation);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_Accept);
			this.Name = "NewLocationDialog";
			this.Text = "New Location";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_Accept;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox textBox_NewLocation;
	}
}