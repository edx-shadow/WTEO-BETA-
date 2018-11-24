using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SART_Patcher
{
	// Token: 0x02000005 RID: 5
	internal class SARTPatcher
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600000F RID: 15 RVA: 0x00002738 File Offset: 0x00000938
		// (remove) Token: 0x06000010 RID: 16 RVA: 0x00002770 File Offset: 0x00000970
		public event SARTPatcher.ShowDialogHandler ShowDialog;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000011 RID: 17 RVA: 0x000027A8 File Offset: 0x000009A8
		// (remove) Token: 0x06000012 RID: 18 RVA: 0x000027E0 File Offset: 0x000009E0
		public event SARTPatcher.ToggleActionHandler ToggleAction;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000013 RID: 19 RVA: 0x00002818 File Offset: 0x00000A18
		// (remove) Token: 0x06000014 RID: 20 RVA: 0x00002850 File Offset: 0x00000A50
		public event SARTPatcher.UpdateVersionHandler VersionReceived;

		// Token: 0x06000015 RID: 21 RVA: 0x00002888 File Offset: 0x00000A88
		public SARTPatcher(ProgressBar progressBar)
		{
			this._path = this._getPath();
			this._progressBar = progressBar;
			this._worker.WorkerReportsProgress = true;
			this._worker.DoWork += this._doWork;
			this._worker.ProgressChanged += this._progressChanged;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000028FE File Offset: 0x00000AFE
		public bool BackupExists()
		{
			return File.Exists(this._path + "GameData.M00.backup");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002915 File Offset: 0x00000B15
		public bool CheckGameInstall()
		{
			return this._path != null;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002920 File Offset: 0x00000B20
		public bool GameDataExists()
		{
			return File.Exists(this._path + "GameData.M00");
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002938 File Offset: 0x00000B38
		public bool GameDataIsValid()
		{
			string text = this._generateMD5(this._path + "GameData.M00");
			return text != null && text.Equals("e3dd396cdf5a75e4b59e6ed4ece56882");
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000296C File Offset: 0x00000B6C
		public void GetVersion()
		{
			if (!this._worker.IsBusy)
			{
				this._worker.RunWorkerAsync(SARTPatcher.PatcherOperation.GETVERSION);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000298C File Offset: 0x00000B8C
		public void Patch()
		{
			if (!this._worker.IsBusy && !this._worker.IsBusy)
			{
				this._worker.RunWorkerAsync(SARTPatcher.PatcherOperation.PATCHFILE);
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000029B9 File Offset: 0x00000BB9
		public void Restore()
		{
			if (!this._worker.IsBusy)
			{
				this._worker.RunWorkerAsync(SARTPatcher.PatcherOperation.REVERTPATCH);
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000029DC File Offset: 0x00000BDC
		private string _getPath()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Sumo Digital\\Sonic and All-Stars Racing Transformed\\", false);
			string result;
			try
			{
				result = (string)registryKey.GetValue("installPath") + "Data\\";
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002A30 File Offset: 0x00000C30
		private void _doWork(object sender, DoWorkEventArgs e)
		{
			switch ((SARTPatcher.PatcherOperation)e.Argument)
			{
			case SARTPatcher.PatcherOperation.GETVERSION:
			{
				string version = this._downloader.GetVersion();
				this.VersionReceived(version);
				return;
			}
			case SARTPatcher.PatcherOperation.PATCHFILE:
				try
				{
					byte[] patch = this._downloader.GetPatch();
					this._worker.ReportProgress(50);
					this._patchFile(patch);
					this._worker.ReportProgress(100);
					this.ToggleAction("Restore");
					this.ShowDialog("Operation completed successfully", "Complete", MessageBoxIcon.Asterisk);
					return;
				}
				catch (Exception ex)
				{
					this.ShowDialog(ex.Message, "Error", MessageBoxIcon.Hand);
					return;
				}
				break;
			case SARTPatcher.PatcherOperation.REVERTPATCH:
				break;
			default:
				return;
			}
			try
			{
				this._revertPatch();
				this._worker.ReportProgress(100);
				this.ToggleAction("Patch");
				this.ShowDialog("Operation completed successfully", "Complete", MessageBoxIcon.Asterisk);
			}
			catch (Exception ex2)
			{
				this.ShowDialog(ex2.Message, "Error", MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002B60 File Offset: 0x00000D60
		private string _generateMD5(string file)
		{
			string result;
			try
			{
				using (MD5 md = MD5.Create())
				{
					using (FileStream fileStream = File.OpenRead(file))
					{
						result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLower();
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002BE0 File Offset: 0x00000DE0
		private void _patchFile(byte[] patch)
		{
			string text = this._path + "GameData.M00";
			File.Copy(text, text + ".backup");
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Open));
			for (int i = 0; i < patch.Length; i += 5)
			{
				int offset = BitConverter.ToInt32(new byte[]
				{
					patch[i],
					patch[i + 1],
					patch[i + 2],
					patch[i + 3]
				}, 0);
				byte value = patch[i + 4];
				binaryWriter.Seek(offset, SeekOrigin.Begin);
				binaryWriter.Write(value);
			}
			binaryWriter.Flush();
			binaryWriter.Close();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002C75 File Offset: 0x00000E75
		private void _progressChanged(object sender, ProgressChangedEventArgs e)
		{
			this._progressBar.Value = e.ProgressPercentage;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002C88 File Offset: 0x00000E88
		private void _revertPatch()
		{
			if (File.Exists(this._path + "GameData.M00"))
			{
				File.Delete(this._path + "GameData.M00");
			}
			File.Move(this._path + "GameData.M00.backup", this._path + "GameData.M00");
		}

		// Token: 0x0400000A RID: 10
		private HttpDownloader _downloader = new HttpDownloader();

		// Token: 0x0400000B RID: 11
		private string _path;

		// Token: 0x0400000C RID: 12
		private ProgressBar _progressBar;

		// Token: 0x0400000D RID: 13
		private BackgroundWorker _worker = new BackgroundWorker();

		// Token: 0x0200000A RID: 10
		// (Invoke) Token: 0x06000030 RID: 48
		public delegate void ShowDialogHandler(string dialog, string title, MessageBoxIcon icon);

		// Token: 0x0200000B RID: 11
		// (Invoke) Token: 0x06000034 RID: 52
		public delegate void ToggleActionHandler(string text);

		// Token: 0x0200000C RID: 12
		// (Invoke) Token: 0x06000038 RID: 56
		public delegate void UpdateVersionHandler(string version);

		// Token: 0x0200000D RID: 13
		public enum PatcherOperation
		{
			// Token: 0x04000016 RID: 22
			GETVERSION,
			// Token: 0x04000017 RID: 23
			PATCHFILE,
			// Token: 0x04000018 RID: 24
			REVERTPATCH
		}
	}
}
