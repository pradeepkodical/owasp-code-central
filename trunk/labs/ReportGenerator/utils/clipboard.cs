using System;
using System.Drawing;
using System.Windows.Forms;

namespace Owasp.VulnReport.utils
{
	/// <summary>
	/// Summary description for clipboard.
	/// </summary>
	public class clipboard
	{
		public clipboard()
		{
		}

		public static bool isClipboardDataAnBitmap()
		{
			if (Clipboard.GetDataObject() != null)
			{
				IDataObject idoClipboardData = Clipboard.GetDataObject();
				if (idoClipboardData.GetDataPresent(DataFormats.Bitmap))
					return true;					
			}
			return false;
		}

		public static bool saveClipboardImageAsJpeg(string strJpegFileName)
		{
			try
			{
				if (Clipboard.GetDataObject() != null)
				{
					IDataObject idoClipboardData = Clipboard.GetDataObject();

					if (idoClipboardData.GetDataPresent(DataFormats.Bitmap))
					{
						Image iImageToSave = (Image)idoClipboardData.GetData(DataFormats.Bitmap,true);										
						iImageToSave.Save(strJpegFileName,System.Drawing.Imaging.ImageFormat.Jpeg);					
						return true;
					}
					else				
						MessageBox.Show("Data in clipboard is not an image");				
				}
				else
					MessageBox.Show("Clipboard.GetDataObject() == null");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while saving the image:" + ex.Message);
			}
			return false;
		}

		public static string getStringWithClipboardData()
		{
			if (Clipboard.GetDataObject() != null)
			{
				IDataObject idoClipboardData = Clipboard.GetDataObject();
				if (idoClipboardData.GetDataPresent(DataFormats.StringFormat))
					return (string)idoClipboardData.GetData(DataFormats.StringFormat);									
			}
			return "";
		}

		public static void SetClipboardData(object objClipboardData)
		{
			Clipboard.SetDataObject(objClipboardData);
		}
	}
}
