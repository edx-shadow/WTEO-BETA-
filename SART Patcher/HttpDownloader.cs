using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SART_Patcher
{
	// Token: 0x02000002 RID: 2
	internal class HttpDownloader
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public byte[] GetPatch()
		{
			byte[] result;
			try
			{
				result = this._download("https://www.dropbox.com/s/jhsj7ix1djnp2j1/patch.dat?dl=1");
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002084 File Offset: 0x00000284
		public string GetVersion()
		{
			string result;
			try
			{
				result = Encoding.ASCII.GetString(this._download("https://www.dropbox.com/s/us4etri5axc23kn/version?dl=1"));
			}
			catch (Exception)
			{
				result = "Error";
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020C4 File Offset: 0x000002C4
		private byte[] _download(string address)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(address);
			httpWebRequest.Method = "GET";
			Stream responseStream = ((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream();
			byte[] buffer = new byte[1024];
			MemoryStream memoryStream = new MemoryStream();
			int count;
			while ((count = responseStream.Read(buffer, 0, 1024)) != 0)
			{
				memoryStream.Write(buffer, 0, count);
			}
			return memoryStream.GetBuffer().ToArray<byte>();
		}
	}
}
