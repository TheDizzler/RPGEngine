namespace MakerEngine {
	partial class NewBlockDialog {
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
			this.button_NewDialogText = new System.Windows.Forms.Button();
			this.button_NewQuery = new System.Windows.Forms.Button();
			this.button_NewAlphaInput = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button_NewDialogText
			// 
			this.button_NewDialogText.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button_NewDialogText.Location = new System.Drawing.Point(0, 29);
			this.button_NewDialogText.Name = "button_NewDialogText";
			this.button_NewDialogText.Size = new System.Drawing.Size(382, 23);
			this.button_NewDialogText.TabIndex = 0;
			this.button_NewDialogText.Text = "Dialog Text";
			this.button_NewDialogText.UseVisualStyleBackColor = true;
			this.button_NewDialogText.Click += new System.EventHandler(this.button_NewDialogText_Click);
			// 
			// button_NewQuery
			// 
			this.button_NewQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button_NewQuery.Location = new System.Drawing.Point(0, 52);
			this.button_NewQuery.Name = "button_NewQuery";
			this.button_NewQuery.Size = new System.Drawing.Size(382, 23);
			this.button_NewQuery.TabIndex = 1;
			this.button_NewQuery.Text = "New Query";
			this.button_NewQuery.UseVisualStyleBackColor = true;
			this.button_NewQuery.Click += new System.EventHandler(this.button_NewQuery_Click);
			// 
			// button_NewAlphaInput
			// 
			this.button_NewAlphaInput.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button_NewAlphaInput.Location = new System.Drawing.Point(0, 75);
			this.button_NewAlphaInput.Name = "button_NewAlphaInput";
			this.button_NewAlphaInput.Size = new System.Drawing.Size(382, 23);
			this.button_NewAlphaInput.TabIndex = 2;
			this.button_NewAlphaInput.Text = "New AlphaNum Input";
			this.button_NewAlphaInput.UseVisualStyleBackColor = true;
			this.button_NewAlphaInput.Click += new System.EventHandler(this.button_NewAlphaInput_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(123, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "What type of dialog block?";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button_Cancel.Location = new System.Drawing.Point(0, 98);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(382, 23);
			this.button_Cancel.TabIndex = 4;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			// 
			// NewBlockDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(382, 121);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button_NewDialogText);
			this.Controls.Add(this.button_NewQuery);
			this.Controls.Add(this.button_NewAlphaInput);
			this.Controls.Add(this.button_Cancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewBlockDialog";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Select Block Type";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_NewDialogText;
		private System.Windows.Forms.Button button_NewQuery;
		private System.Windows.Forms.Button button_NewAlphaInput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button_Cancel;
	}
}