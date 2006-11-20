using System;

namespace mvc2
{
	public class Page2 : ControllerBase
	{
		public Page2()
		{
		}

    public void Test()
    {
      body.InnerHtml = "You called Page2.Test()!";
    }

    public void Multiply(string x, string y)
    {
      Model1 m = new Model1();
      m.X = int.Parse(x);
      m.Y = int.Parse(y);
      xmlBody.Document = m.Product;
      xmlBody.TransformSource = "Page2.xslt";
    }

	}
}
