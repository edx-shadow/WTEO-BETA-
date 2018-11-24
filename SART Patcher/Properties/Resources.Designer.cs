using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SART_Patcher.Properties
{
	// Token: 0x02000006 RID: 6
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00002CE6 File Offset: 0x00000EE6
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002CEE File Offset: 0x00000EEE
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("SART_Patcher.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002D1A File Offset: 0x00000F1A
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002D21 File Offset: 0x00000F21
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400000E RID: 14
		private static ResourceManager resourceMan;

		// Token: 0x0400000F RID: 15
		private static CultureInfo resourceCulture;
	}
}
