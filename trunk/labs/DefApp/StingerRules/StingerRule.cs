//using System;
//using System.Collections;
//using System.Net;
//using System.Web;
//using System.Text.RegularExpressions;
//namespace Owasp.DefApp.StingerRules
//{
//	public class StingerRule
//	{
//		public const int COOKIE = 1;
//		public const int HEADER = 2;
//		public const int PARAMETER = 3;
//
//		// ACTIONS
//		public const int IGNORE = 1;
//		public const int CONTINUE = 2;
//		public const int FATAL = 3;
//
//		// AUTOGENENERATED MESSAGE LEVEL
//		public const int CUSTOM = 0;
//		public const int BASIC = 1;
//		public const int STANDARD = 2;
//		public const int VERBOSE = 3;
//
//		// Class members
//		//protected Pattern valuePattern;
//		protected String extraMessage = null;
//		protected String malformedMessage = null;
//		protected String missingMessage = null;
//		protected String name; // Might be nice to use a pattern here, but JavaScript becomes difficult
//		protected String valueRegex;
//		protected bool hidden; // use for password and credit-card fields you don't want to show up in error messages
//		protected int extraAction = FATAL; // default secure
//		protected int malformedAction = FATAL; // default secure
//		protected int messageLevel = BASIC; // default secure
//		protected int missingAction = FATAL; // default secure
//		protected int type;
//		public StingerRule()
//		{
//		}
//		private String obfuscate(String value)
//		{
//			if (!hidden)
//			{
//				return value;
//			}
//			return ("*******");
//		}
//
//		public static String getActionString(int action)
//		{
//			switch (action)
//			{
//				case StingerRule.IGNORE:
//					return "ignore";
//				case StingerRule.CONTINUE:
//					return "continue";
//				case StingerRule.FATAL:
//					return "fatal";
//				default:
//					return "unknown";
//			}
//		}
//		public static String getMessageLevelString(int level)
//		{
//			switch (level)
//			{
//				case BASIC:
//					return "basic";
//				case STANDARD:
//					return "standard";
//				case VERBOSE:
//					return "verbose";
//				case CUSTOM:
//					return "custom";
//				default:
//					return "unknown";
//			}
//		}
//		public bool isCookie()
//		{
//			return type == COOKIE;
//		}
//		public bool isHeader()
//		{
//			return type == HEADER;
//		}
//		public void setHidden(bool hidden)
//		{
//			this.hidden = hidden;
//		}
//		public void setHidden(String hidden)
//		{
//			try
//			{				
//				setHidden(Boolean.Parse(hidden));
//			}
//			catch (Exception e)
//			{
//			}
//		}
//		public bool isHidden()
//		{
//			return hidden;
//		}
//		public void setMalformedAction(int action)
//		{
//			this.malformedAction = action;
//		}
//		public void setMalformedAction(String action)
//		{
//			try
//			{
//				setMalformedAction(getActionInt(action));
//			}
//			catch (Exception e)
//			{
//			}
//		}
//		public int getMalformedAction()
//		{
//			return malformedAction;
//		}
//		public void setMalformedMessage(String malformedMessage)
//		{
//			this.malformedMessage = HttpUtility.HtmlEncode(malformedMessage);
//		}
//		public String getMalformedMessage(String value)
//		{
//			if (malformedMessage == null)
//			{
//				switch (getMessageLevel())
//				{
//					case BASIC:
//						malformedMessage = "The [" + getName() + "] " + getTypeString(getType()) + " was malformed";
//						break;
//					case STANDARD:
//						malformedMessage = "The [" + getName() + "] " + getTypeString(getType()) + " did not match pattern " + getRegex();
//						break;
//					case VERBOSE:
//						malformedMessage = "The [" + getName() + "] " + getTypeString(getType()) + " value " + value + " did not match pattern " + getRegex();
//						break;
//					default:
//						malformedMessage = "The [" + getName() + "] " + getTypeString(getType()) + " was malformed";
//						break;
//				}
//			}
//			return malformedMessage;
//		}
//		/**
//	 * @param messageLevel the level of detail in the messages displayed.
//	 */
//		public void setMessageLevel(int messageLevel)
//		{
//			this.messageLevel = messageLevel;
//		}
//
//		/**
//		 * Set the message level for this Rule.
//		 *
//		 * @param level one of the static int level types defined in this class.
//		 */
//		public void setMessageLevel(String level)
//		{
//			try
//			{
//				setMessageLevel(getMessageLevelInt(level));
//			}
//			catch (Exception e)
//			{
//			}
//		}
//		public int getMessageLevel()
//		{
//			return messageLevel;
//		}
//		public void setMissingAction(int missingAction)
//		{
//			this.missingAction = missingAction;
//		}
//		public void setMissingAction(String action)
//		{
//			try
//			{
//				setMissingAction(getActionInt(action));
//			}
//			catch (Exception e)
//			{
//			}
//		}
//		public int getMissingAction()
//		{
//			return missingAction;
//		}
//		public void setMissingMessage(String missingMessage)
//		{
//			this.missingMessage = missingMessage;
//		}
//		public String getMissingMessage()
//		{
//			if (missingMessage == null)
//			{
//				missingMessage = "The [" + getName() + "] " + getTypeString(getType()) + " was missing";
//			}
//			return missingMessage;
//		}
//		public void setName(String name)
//		{
//			this.name = name;
//		}
//		public String getName()
//		{
//			return name;
//		}
//		public bool isParameter()
//		{
//			return type == PARAMETER;
//		}
//		public void setType(String type)
//		{
//			try
//			{
//				setType(getTypeInt(type));
//			}
//			catch (Exception e)
//			{
//			}
//		}
//		public void setType(int type)
//		{
//			this.type = type;
//		}
//		public int getType()
//		{
//			return type;
//		}
//		public static String getTypeString(int type)
//		{
//			switch (type)
//			{
//				case COOKIE:
//					return "cookie";
//				case HEADER:
//					return "header";
//				case PARAMETER:
//					return "parameter";
//				default:
//					return "unknown";
//			}
//		}
//		private System.Text.RegularExpressions.Regex valuePattern;
//		
//		public void setRegex(String valueRegex)
//		{
//			this.valueRegex = valueRegex;
//			this.valuePattern = new Regex(valueRegex,RegexOptions.Compiled);
//		}
//		public String getRegex()
//		{
//			return valueRegex;
//		}
//		public bool matches(String candidate, int ctype)
//		{
//			return (getName()==candidate) && (getType() == ctype);
//		}
//		
//		public bool matches(HttpRequest request)
//		{
//			switch (type)
//			{
//				case COOKIE:
//					if (request.Cookies == null)
//					{
//						return false;
//					}					
//					for (int i = 0; i < request.Cookies.Count; i++)
//					{
//						String candidate = request.Cookies.GetKey(i);
//						if (candidate.Equals(name))
//						{
//							return true;
//						}
//					}
//					break;
//				case HEADER:
//					Enumeration e = request.getHeaderNames();
//					while (e.hasMoreElements())
//					{
//						String candidate = (String) e.nextElement();
//						if (candidate.Equals(name))
//						{
//							return true;
//						}
//					}
//					break;
//				case PARAMETER:
//					String[] values = request.getParameterValues(name);
//					if ((values != null) && (values.Length > 0))
//					{
//						return true;
//					}
//					break;
//				default:
//					break;
//			}
//			return false;
//		}
//	public IList validateMalformed(HttpRequest request)
//	{
//		ArrayList list = new ArrayList();
//		if (getMalformedAction() == IGNORE)
//		{
//			return list;
//		}		
//		// handle the different request parts
//		switch (type)
//		{
//			case COOKIE:
//				if (request.Cookies == null)
//				{
//					return list;	
//				}
//				for (int i = 0; i < request.Cookies.Count; i++)
//				{
//					String candidate = request.Cookies[ i ].Name;
//					if (candidate.Equals(name))
//					{
//						String value = request.Cookies[ i ].Value;
//						list.Add(validateMalformed(name, value));
//					}
//				}
//				break;
//			case HEADER:
//				if (request.Headers == null)
//				{
//					return list;
//				}
//
//				for (int i=0;i<request.Headers.Count;i++)
//				{
//					String candidate = request.Headers.GetKey(i);
//					if (candidate.Equals(name))
//					{
//						list.Add(validateMalformed(name,request.Headers.Get(i)));
//					}
//				}			
//				break;
//			case PARAMETER:
//
//				String[] values = request.getParameterValues(name);
//				if (values != null)
//				{
//					for (int j = 0; j < values.Length; j++)
//					{
//						list.Add(validateMalformed(name, values[ j ]));
//					}
//				}
//				break;
//			default:
//				break;
//		}
//		return list;
//	}
//	private ValidationProblem validateMalformed(String candidate, String value) 
//	{
//	if (!name.Equals(candidate))
//	{
//		return null;
//	}
//		if (valuePattern.matcher(value).matches())
//	{
//		return null;
//	}
//		ValidationProblem p = new ValidationProblem(ValidationProblem.MALFORMED, getType(), getName(), obfuscate(value), getMalformedMessage(obfuscate(value)));
//		if (getMalformedAction() == FATAL)
//	{
//		throw new FatalValidationException(p);
//	}
//	return p;
//}
//
//		protected static int getTypeInt(String type)
//		{
//			if (type == null)
//			{
//				throw new ArgumentException("Type cannot be null");
//			}
//			if (type.Equals("header"))
//			{
//				return HEADER;
//			}
//			if (type.Equals("cookie"))
//			{
//				return COOKIE;
//			}
//			if (type.Equals("parameter"))
//			{
//				return PARAMETER;
//			}
//			throw new ArgumentException("Invalid type: " + type);
//		}
//
//		protected static int getMessageLevelInt(String level)
//		{
//			if (level == null)
//			{
//				throw new ArgumentException("Type cannot be null");
//			}
//			if (level.Equals("header"))
//			{
//				return HEADER;
//			}
//			if (level.Equals("cookie"))
//			{
//				return COOKIE;
//			}
//			if (level.Equals("parameter"))
//			{
//				return PARAMETER;
//			}
//			throw new ArgumentException("Invalid message level: " + level);
//		}
//
//		public StingerRule(int type, String name, String valueRegex, int action, int missingAction, bool hidden, String message)
//		{
//			setType(type);
//			setName(name);
//			setRegex(valueRegex);
//			setMalformedAction(malformedAction);
//			setMissingAction(missingAction);
//			setMalformedMessage(message);
//			setHidden(hidden);
//		}
//
//		public static int getActionInt(String action)
//		{
//			if (action == null)
//			{
//				throw new ArgumentException("Action cannot be null");
//			}
//			if (action.Equals("continue"))
//			{
//				return CONTINUE;
//			}
//			if (action.Equals("ignore"))
//			{
//				return IGNORE;
//			}
//			if (action.Equals("fatal"))
//			{
//				return FATAL;
//			}
//			throw new ArgumentException("Invalid action: " + action);
//		}
//
//	public bool validateMissing(HttpRequest request)
//	{
//		if (getMissingAction() == IGNORE)
//		{
//			return true;
//		}
//		switch (type)
//		{
//			case COOKIE:
//				Cookie[] cookies = request.getCookies();
//				if (cookies == null)
//				{
//					return false;
//				}
//				for (int i = 0; i < cookies.Length; i++)
//				{
//					String candidate = cookies[ i ].getName();
//					if (candidate==name)
//					{
//						return true;
//					}
//				}
//				break;
//			case HEADER:
//				Enumeration e = request.getHeaderNames();
//				while (e.hasMoreElements())
//				{
//					String candidate = (String) e.nextElement();
//					if (candidate.Equals(name))
//					{
//						return true;
//					}
//				}
//				break;
//			case PARAMETER:
//				String[] values = request.getParameterValues(name);
//				if ((values != null) && (values.Length > 0))
//				{
//					return true;
//				}
//				break;
//		}
//		if (getMissingAction() == FATAL)
//		{
//			throw new FatalValidationException(getMissingMessage());
//		}
//		return false;
//	}
//	}
//}