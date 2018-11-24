using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SART_Patcher
{
	// Token: 0x02000003 RID: 3
	public partial class MainWindow : Form
	{
		// Token: 0x06000005 RID: 5 RVA: 0x0000213C File Offset: 0x0000033C
		public MainWindow()
		{
			this.InitializeComponent();
			this._patcher = new SARTPatcher(this.progressBar);
			this._patcher.ShowDialog += this._showDialog;
			this._patcher.ToggleAction += this._toggleAction;
			this._patcher.VersionReceived += this._updateVersion;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021AC File Offset: 0x000003AC
		private void MainWindow_Load(object sender, EventArgs e)
		{
			this._patcher.GetVersion();
			if (!this._patcher.CheckGameInstall())
			{
				this.btnAction.Enabled = false;
				this._showDialog("Unable to locate your game installation.\nMake sure you have run the game atleast once.", "Error", MessageBoxIcon.Hand);
			}
			if (this._patcher.BackupExists())
			{
				this.btnAction.Text = "Restore";
				return;
			}
			if (!this._patcher.GameDataExists())
			{
				this.btnAction.Enabled = false;
				this._showDialog("GameData.M00 not found.\nPatcher functionality disabled.", "Error", MessageBoxIcon.Exclamation);
				return;
			}
			if (!this._patcher.GameDataIsValid())
			{
				this._showDialog("GameData.M00 modifications detected.\nPatch at your own risk.", "Info", MessageBoxIcon.Exclamation);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002258 File Offset: 0x00000458
		private void btnAction_Click(object sender, EventArgs e)
		{
			if (this.btnAction.Text.Equals("Patch"))
			{
				this._patcher.Patch();
				return;
			}
			this._patcher.Restore();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002288 File Offset: 0x00000488
		private void _showDialog(string dialog, string title, MessageBoxIcon icon)
		{
			MessageBox.Show(dialog, title, MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
			this.progressBar.Invoke(new MethodInvoker(delegate()
			{
				this.progressBar.Value = 0;
			}));
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000022B0 File Offset: 0x000004B0
		private void _toggleAction(string text)
		{
			this.btnAction.Invoke(new MethodInvoker(delegate()
			{
				this.btnAction.Text = text;
			}));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000022EC File Offset: 0x000004EC
		private void _updateVersion(string version)
		{
			this.lblVer.Invoke(new MethodInvoker(delegate()
			{
				this.lblVer.Text = version;
			}));
			if (this.lblVer.Text.Equals("Error"))
			{
				this._showDialog("Failed to connect to server.\nPatcher functionality disabled.", "Error", MessageBoxIcon.Hand);
				this.btnAction.Invoke(new MethodInvoker(delegate()
				{
					this.btnAction.Enabled = false;
				}));
			}
		}

		// Token: 0x04000001 RID: 1
		private SARTPatcher _patcher;
	}
}
