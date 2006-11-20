using System;
using System.Xml;

namespace mvc2
{
  public class Model1
	{
    public string Name = "Model1";
    public int X = 10;
    public int Y = 5;

    public XmlDocument Xml
    {
      get 
      {
        XmlDocument x = new XmlDocument();
        x.AppendChild(x.CreateElement("Model1"));
        x.FirstChild.AppendChild(x.CreateElement("X"));
        x.FirstChild.ChildNodes[0].InnerText=X.ToString();
        x.FirstChild.AppendChild(x.CreateElement("Y"));
        x.FirstChild.ChildNodes[1].InnerText=Y.ToString();

        return x;
      }
    }

    public XmlDocument Product
    {
      get 
      {
        XmlDocument x = new XmlDocument();
        x.AppendChild(x.CreateElement("Model1"));
        x.FirstChild.AppendChild(x.CreateElement("X"));
        x.FirstChild.ChildNodes[0].InnerText=X.ToString();
        x.FirstChild.AppendChild(x.CreateElement("Y"));
        x.FirstChild.ChildNodes[1].InnerText=Y.ToString();
        x.FirstChild.AppendChild(x.CreateElement("Product"));
        x.FirstChild.ChildNodes[2].InnerText=(X*Y).ToString();

        return x;
      }
    }
	}
}
