using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace SART_Patcher.Properties
{
	// Token: 0x02000007 RID: 7
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002D29 File Offset: 0x00000F29
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000010 RID: 16
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
