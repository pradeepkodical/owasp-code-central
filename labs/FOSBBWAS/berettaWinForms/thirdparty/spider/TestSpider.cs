using System;
using System.Windows.Forms;


namespace Spider
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class TestSpider
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.Run(new SpiderForm());
		}
	}
}
