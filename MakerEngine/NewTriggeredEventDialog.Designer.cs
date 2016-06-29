namespace MakerEngine {
	partial class NewTriggeredEventDialog {
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_NewEvent = new System.Windows.Forms.TextBox();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_Accept = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(139, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "New Triggered Event Name";
			// 
			// textBox_NewEvent
			// 
			this.textBox_NewEvent.Location = new System.Drawing.Point(11, 28);
			this.textBox_NewEvent.Name = "textBox_NewEvent";
			this.textBox_NewEvent.Size = new System.Drawing.Size(199, 20);
			this.textBox_NewEvent.TabIndex = 0;
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(135, 64);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 5;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			// 
			// button_Accept
			// 
			this.button_Accept.Location = new System.Drawing.Point(12, 64);
			this.button_Accept.Name = "button_Accept";
			this.button_Accept.Size = new System.Drawing.Size(75, 23);
			this.button_Accept.TabIndex = 4;
			this.button_Accept.Text = "Accept";
			this.button_Accept.UseVisualStyleBackColor = true;
			this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
			// 
			// NewTriggeredEventDialog
			// 
			this.AcceptButton = this.button_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(221, 101);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_NewEvent);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_Accept);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewTriggeredEventDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "New Triggered Event";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox textBox_NewEvent;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_Accept;
	}
}