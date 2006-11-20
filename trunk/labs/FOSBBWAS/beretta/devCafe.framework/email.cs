/* Author: Alex Mackey
 * Date: 03/07/2005
 * Version: 1.0
 * Purpose: Email object
 */

using System;
using System.Web.Mail;

namespace devCafe.framework
{
	/// <summary>
	/// Summary description for email.
	/// </summary>
	public class email
	{
		private static System.Web.Mail.MailMessage objEmail=new System.Web.Mail.MailMessage();

		public email()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Sends an email
		/// </summary>
		/// <param name="strMessage">Email content</param>
		/// <param name="strFrom">Email from</param>
		/// <param name="strTo">Email to</param>
		/// <param name="strSubject">Subject</param>
		/// <param name="bolUseHtml">True=Html format, false = plain text</param>
		public static void send(string strMessage, string strFrom, string strTo, string strSubject, bool bolUseHtml)
		{
				
			objEmail.Body=strMessage;
			objEmail.From=strFrom;
			objEmail.Subject=strSubject;
			objEmail.To=strTo;
			objEmail.BodyFormat=System.Web.Mail.MailFormat.Html;

			SmtpMail.SmtpServer = settings.get("smtpServer");

			try
			{
				SmtpMail.Send(objEmail);
			}
			catch(System.Exception ex)
			{
				systemEventsDataAccess.add(14, ex.Message.ToString(), 0, "127.0.0.1");

			}
		}
	}
}
