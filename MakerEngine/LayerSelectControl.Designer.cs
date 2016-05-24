namespace MakerEngine {
	partial class LayerSelectControl {
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
			this.panel_LayerSelect = new System.Windows.Forms.Panel();
			this.groupBox_LayersGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel_LayersGroupBox = new System.Windows.Forms.TableLayoutPanel();
			this.panel_LayerSelect.SuspendLayout();
			this.groupBox_LayersGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_LayerSelect
			// 
			this.panel_LayerSelect.AutoSize = true;
			this.panel_LayerSelect.Controls.Add(this.groupBox_LayersGroupBox);
			this.panel_LayerSelect.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_LayerSelect.Location = new System.Drawing.Point(0, 0);
			this.panel_LayerSelect.Name = "panel_LayerSelect";
			this.panel_LayerSelect.Size = new System.Drawing.Size(284, 261);
			this.panel_LayerSelect.TabIndex = 3;
			// 
			// groupBox_LayersGroupBox
			// 
			this.groupBox_LayersGroupBox.AutoSize = true;
			this.groupBox_LayersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBox_LayersGroupBox.Controls.Add(this.tableLayoutPanel_LayersGroupBox);
			this.groupBox_LayersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_LayersGroupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox_LayersGroupBox.Name = "groupBox_LayersGroupBox";
			this.groupBox_LayersGroupBox.Size = new System.Drawing.Size(284, 261);
			this.groupBox_LayersGroupBox.TabIndex = 0;
			this.groupBox_LayersGroupBox.TabStop = false;
			this.groupBox_LayersGroupBox.Text = "Layers";
			// 
			// tableLayoutPanel_LayersGroupBox
			// 
			this.tableLayoutPanel_LayersGroupBox.AutoScroll = true;
			this.tableLayoutPanel_LayersGroupBox.AutoSize = true;
			this.tableLayoutPanel_LayersGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_LayersGroupBox.ColumnCount = 1;
			this.tableLayoutPanel_LayersGroupBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel_LayersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel_LayersGroupBox.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel_LayersGroupBox.Name = "tableLayoutPanel_LayersGroupBox";
			this.tableLayoutPanel_LayersGroupBox.Size = new System.Drawing.Size(278, 242);
			this.tableLayoutPanel_LayersGroupBox.TabIndex = 0;
			// 
			// LayerSelectControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.panel_LayerSelect);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LayerSelectControl";
			this.ShowIcon = false;
			this.Text = "LayerSelectControl";
			this.TopMost = true;
			this.panel_LayerSelect.ResumeLayout(false);
			this.panel_LayerSelect.PerformLayout();
			this.groupBox_LayersGroupBox.ResumeLayout(false);
			this.groupBox_LayersGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel_LayerSelect;
		private System.Windows.Forms.GroupBox groupBox_LayersGroupBox;
		public System.Windows.Forms.TableLayoutPanel tableLayoutPanel_LayersGroupBox;
	}
}