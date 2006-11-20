using System;

namespace mvc2
{
	/// <summary>
	/// Summary description for Logon.
	/// </summary>
	public class Page1 : ControllerBase
	{
		public Page1()
		{
		}

    public void View()
    {
      Model1 m = new Model1();
      xmlBody.Document = m.Xml;
      xmlBody.TransformSource = "Page1.xslt";
    }

    // This view method takes two parameters that are the manipulated
    // by the Model component.
    public void View(string x, string y)
    {
      Model1 m = new Model1();
      m.X = int.Parse(x);
      m.Y = int.Parse(y);
      xmlBody.Document = m.Xml;
      xmlBody.TransformSource = "Page1.xslt";
    }

	}
}
