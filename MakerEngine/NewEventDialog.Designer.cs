namespace MakerEngine {
	partial class NewEventDialog {
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
			this.radioButtons_EventSelect = new System.Windows.Forms.GroupBox();
			this.radioButton_Zone = new System.Windows.Forms.RadioButton();
			this.radioButton_Triggered = new System.Windows.Forms.RadioButton();
			this.radioButton_Intro = new System.Windows.Forms.RadioButton();
			this.radioButton_Custom = new System.Windows.Forms.RadioButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_Accept = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.radioButtons_EventSelect.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioButtons_EventSelect
			// 
			this.radioButtons_EventSelect.Controls.Add(this.textBox1);
			this.radioButtons_EventSelect.Controls.Add(this.radioButton_Custom);
			this.radioButtons_EventSelect.Controls.Add(this.radioButton_Intro);
			this.radioButtons_EventSelect.Controls.Add(this.radioButton_Triggered);
			this.radioButtons_EventSelect.Controls.Add(this.radioButton_Zone);
			this.radioButtons_EventSelect.Location = new System.Drawing.Point(12, 12);
			this.radioButtons_EventSelect.Name = "radioButtons_EventSelect";
			this.radioButtons_EventSelect.Size = new System.Drawing.Size(297, 124);
			this.radioButtons_EventSelect.TabIndex = 1;
			this.radioButtons_EventSelect.TabStop = false;
			this.radioButtons_EventSelect.Text = "Event Type";
			// 
			// radioButton_Zone
			// 
			this.radioButton_Zone.AutoSize = true;
			this.radioButton_Zone.Location = new System.Drawing.Point(7, 20);
			this.radioButton_Zone.Name = "radioButton_Zone";
			this.radioButton_Zone.Size = new System.Drawing.Size(74, 17);
			this.radioButton_Zone.TabIndex = 0;
			this.radioButton_Zone.TabStop = true;
			this.radioButton_Zone.Text = "Zone Text";
			this.radioButton_Zone.UseVisualStyleBackColor = true;
			// 
			// radioButton_Triggered
			// 
			this.radioButton_Triggered.AutoSize = true;
			this.radioButton_Triggered.Location = new System.Drawing.Point(7, 44);
			this.radioButton_Triggered.Name = "radioButton_Triggered";
			this.radioButton_Triggered.Size = new System.Drawing.Size(70, 17);
			this.radioButton_Triggered.TabIndex = 1;
			this.radioButton_Triggered.TabStop = true;
			this.radioButton_Triggered.Text = "Triggered";
			this.radioButton_Triggered.UseVisualStyleBackColor = true;
			// 
			// radioButton_Intro
			// 
			this.radioButton_Intro.AutoSize = true;
			this.radioButton_Intro.Location = new System.Drawing.Point(7, 68);
			this.radioButton_Intro.Name = "radioButton_Intro";
			this.radioButton_Intro.Size = new System.Drawing.Size(46, 17);
			this.radioButton_Intro.TabIndex = 2;
			this.radioButton_Intro.TabStop = true;
			this.radioButton_Intro.Text = "Intro";
			this.radioButton_Intro.UseVisualStyleBackColor = true;
			// 
			// radioButton_Custom
			// 
			this.radioButton_Custom.AutoSize = true;
			this.radioButton_Custom.Location = new System.Drawing.Point(7, 92);
			this.radioButton_Custom.Name = "radioButton_Custom";
			this.radioButton_Custom.Size = new System.Drawing.Size(60, 17);
			this.radioButton_Custom.TabIndex = 3;
			this.radioButton_Custom.TabStop = true;
			this.radioButton_Custom.Text = "Custom";
			this.radioButton_Custom.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(74, 92);
			this.textBox1.MaxLength = 32;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(195, 20);
			this.textBox1.TabIndex = 4;
			// 
			// button_Accept
			// 
			this.button_Accept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Accept.Location = new System.Drawing.Point(12, 142);
			this.button_Accept.Name = "button_Accept";
			this.button_Accept.Size = new System.Drawing.Size(75, 23);
			this.button_Accept.TabIndex = 2;
			this.button_Accept.Text = "Accept";
			this.button_Accept.UseVisualStyleBackColor = true;
			this.button_Accept.Click += new System.EventHandler(this.button_Accept_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(234, 142);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 3;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			// 
			// NewEventDialog
			// 
			this.AcceptButton = this.button_Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(317, 175);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_Accept);
			this.Controls.Add(this.radioButtons_EventSelect);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewEventDialog";
			this.ShowIcon = false;
			this.Text = "Create New Event";
			this.TopMost = true;
			this.radioButtons_EventSelect.ResumeLayout(false);
			this.radioButtons_EventSelect.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.RadioButton radioButton_Triggered;
		private System.Windows.Forms.RadioButton radioButton_Zone;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.RadioButton radioButton_Custom;
		private System.Windows.Forms.RadioButton radioButton_Intro;
		private System.Windows.Forms.Button button_Accept;
		private System.Windows.Forms.Button button_Cancel;
		public System.Windows.Forms.GroupBox radioButtons_EventSelect;
	}
}