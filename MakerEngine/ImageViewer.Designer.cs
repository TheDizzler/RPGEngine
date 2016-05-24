namespace MakerEngine {
	partial class ImageViewer {
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
			this.flowLayoutPanel_ImageContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// flowLayoutPanel_ImageContainer
			// 
			this.flowLayoutPanel_ImageContainer.AutoScroll = true;
			this.flowLayoutPanel_ImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel_ImageContainer.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel_ImageContainer.Name = "flowLayoutPanel_ImageContainer";
			this.flowLayoutPanel_ImageContainer.Size = new System.Drawing.Size(284, 261);
			this.flowLayoutPanel_ImageContainer.TabIndex = 1;
			// 
			// ImageViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.flowLayoutPanel_ImageContainer);
			this.MinimizeBox = false;
			this.Name = "ImageViewer";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Tilesets Used";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_ImageContainer;
	}
}