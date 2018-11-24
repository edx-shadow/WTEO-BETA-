using System;
using System.Windows.Forms;

namespace SART_Patcher
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000271F File Offset: 0x0000091F
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
	}
}
