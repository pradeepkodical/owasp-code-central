using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;

namespace mvc2
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class ControllerBase : System.Web.UI.Page
	{
    // These private static control declarations replace the 
    // standard "protected" declarations that VS.NET puts in.
    // Being static, all inheriting Controller classes will share
    // the same controls... hence only 1 .aspx page is actually needed.
    private static System.Web.UI.WebControls.Xml _xmlBody;
    private static System.Web.UI.HtmlControls.HtmlGenericControl _errors;
    private static System.Web.UI.HtmlControls.HtmlGenericControl _body;

    // The protected properties provide access for all of the 
    // controller classes to acces the body and xmlBody elements.
    protected System.Web.UI.WebControls.Xml xmlBody
    {
      get { return ControllerBase._xmlBody; }
      set { ControllerBase._xmlBody = value; }
    }

    protected System.Web.UI.HtmlControls.HtmlGenericControl body
    {
      get { return ControllerBase._body; }
      set { ControllerBase._body = value; }
    }

    protected System.Web.UI.HtmlControls.HtmlGenericControl errors
    {
      get { return ControllerBase._errors; }
      set { ControllerBase._errors = value; }
    }



    // Page_Load is used to process the incoming request
    // and direct control to the appropriate controller class.
    // The request is expected to provide two parameters:
    //  page   = The controller class to use.
    //  action = The method on that controller class to call.
    private void Page_Load(object sender, System.EventArgs e)
		{
      // //////////////////////////////////////////////////////////////////////////////
      // We need the page and action parameters to 
      // find the controller class and method to be called.
      string page   = Page.Request.Params.Get("page");
      string action = Page.Request.Params.Get("action");

      ControllerBase controller;          // variable to hold controller
      Type           pageType;            // type associated with the page
      MethodInfo     actionMethod;        // method associated with the action

      // //////////////////////////////////////////////////////////////////////////////
      // Try to create an instance of the requested class,
      // and find out what actual type it is.
      try
      {
        controller = (ControllerBase) Activator.CreateInstance("mvc2", "mvc2." + page).Unwrap();
        pageType   = controller.GetType();
      }
      catch (Exception ex)
      {
        errors.InnerHtml = "Could not create requested class (" + page + ")<p>";
        errors.InnerHtml += ex.Message;
        return;
      }

      // //////////////////////////////////////////////////////////////////////////////
      // Now figure out if we can find the right method with the right signature.
      int paramCount = 
        (Page.Request.RequestType == "GET") ?
        Page.Request.QueryString.Count - 2  :
        Page.Request.Form.Count - 2;

      try
      {
        if (paramCount > 0)
        {
          Type[] paramTypes = new Type[paramCount];
          for (int i=0; i<paramCount; i++) 
          { 
            paramTypes[i] = Type.GetType("System.String"); 
          }
          actionMethod = pageType.GetMethod(action, paramTypes);

          ParameterInfo paramInfo;
          object[] parameters = new object[paramCount];
          for (int i=0; i<paramCount; i++) 
          {
            paramInfo = actionMethod.GetParameters()[i];
            parameters[i] = Page.Request.Params.Get(paramInfo.Name).ToString();
          }
          
          actionMethod.Invoke((object)controller,parameters);
        }
        else
        {
          Type[] paramTypes = new Type[0];
          actionMethod = pageType.GetMethod(action, paramTypes);

          actionMethod.Invoke ((object)controller,null);
        }
      }
      catch (Exception ex)
      {
        errors.InnerHtml = "Could not find the requested method (" + page + "." + action + "(";
        for (int i=1; i<=paramCount; i++)
        {
          errors.InnerHtml += "string" + ((i<paramCount)?",":"");
        }
        errors.InnerHtml += "))<p>";
        errors.InnerHtml += ex.Message + "<p>";
        errors.InnerHtml += ex.InnerException.Message;
      }

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
      this.Load += new System.EventHandler(this.Page_Load);

    }
		#endregion
	}
}
