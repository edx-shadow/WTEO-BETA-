namespace SART_Patcher
{
	// Token: 0x02000003 RID: 3
	public partial class MainWindow : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002366 File Offset: 0x00000566
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002388 File Offset: 0x00000588
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mod Version:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.BackColor = System.Drawing.Color.Transparent;
            this.lblVer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVer.ForeColor = System.Drawing.Color.Aquamarine;
            this.lblVer.Location = new System.Drawing.Point(12, 30);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(94, 21);
            this.lblVer.TabIndex = 3;
            this.lblVer.Text = "Updating...";
            this.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 353);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(580, 23);
            this.progressBar.TabIndex = 4;
            // 
            // btnAction
            // 
            this.btnAction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.ForeColor = System.Drawing.Color.Orchid;
            this.btnAction.Location = new System.Drawing.Point(234, 301);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(125, 46);
            this.btnAction.TabIndex = 5;
            this.btnAction.Text = "Patch";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(604, 386);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "World Tour Events Online Patcher";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// Token: 0x04000002 RID: 2
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Label lblVer;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.ProgressBar progressBar;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Button btnAction;
	}
}
