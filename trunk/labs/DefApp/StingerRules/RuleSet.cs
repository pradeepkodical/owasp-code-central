//using System;
//using System.Collections;
//using System.Net;
//using System.Web;
//
//namespace Owasp.DefApp.StingerRules
//{
//public class RuleSet
//{
//	protected System.Collections.Hashtable rules = new Hashtable();
//	private String extraMessage;
//	private String name;
//	private String path;
//	private int extraCookieAction = StingerRule.FATAL;
//	private int extraHeaderAction = StingerRule.FATAL;
//	private int extraParameterAction = StingerRule.FATAL;
//
//	/**
//	 * Simple constructor for use in creating RuleSets programatically.
//	 */
//	public RuleSet()
//	{
//	}
//
//	/**
//	 * Simple constructor for use in creating RuleSets programatically.
//	 *
//	 * @param name a short name for this ruleset
//	 * @param path a String used to match this RuleSet with the appropriate requests.
//	 */
//	public RuleSet(String name, String path)
//	{
//		this.name = name;
//		this.path = path;
//	}
//
//	/**
//	 * @param extraCookieAction
//	 */
//	public void setExtraCookieAction(int extraCookieAction)
//	{
//		this.extraCookieAction = extraCookieAction;
//	}
//
//	/**
//	 * Set the action to perform if this RuleSet contains an extra cookie.
//	 *
//	 * @param action one of the static int actions declared in Rule
//	 */
//	public void setExtraCookieAction(String action)
//	{
//		try
//		{
//			setExtraCookieAction(StingerRule.getActionInt(action));
//		}
//		catch (ArgumentException e)
//		{
//		}
//	}
//
//	/**
//	 * @return the action to take when an extra cookie is detected.
//	 */
//	public int getExtraCookieAction()
//	{
//		return extraCookieAction;
//	}
//
//	/**
//	 * Set the action to perform if this RuleSet contains an extra header.
//	 *
//	 * @param extraHeaderAction one of the static int actions declared in Rule
//	 */
//	public void setExtraHeaderAction(int extraHeaderAction)
//	{
//		this.extraHeaderAction = extraHeaderAction;
//	}
//
//	/**
//	 * Set the action to perform if this RuleSet contains an extra header.
//	 *
//	 * @param action one of the static int actions declared in Rule
//	 */
//	public void setExtraHeaderAction(String action)
//	{
//		try
//		{
//			setExtraHeaderAction(StingerRule.getActionInt(action));
//		}
//		catch (ArgumentException e)
//		{
//		}
//	}
//
//	/**
//	 * @return the action to take when an extra header is detected.
//	 */
//	public int getExtraHeaderAction()
//	{
//		return extraHeaderAction;
//	}
//
//	/**
//	 * Set the message to use when any extra parts are discovered.
//	 *
//	 * @param message the message to return.
//	 */
//	public void setExtraMessage(String message)
//	{
//		extraMessage = message;
//	}
//
//	/**
//	 * @return the message to use when any extra parts with the specified name and type are discovered.
//	 */
//	public String getExtraMessage(String extraName, int type)
//	{
//		if (extraMessage == null)
//		{
//			extraMessage = "The [" + extraName + "] " + StingerRule.getTypeString(type) + " was unexpected";
//		}
//		return extraMessage;
//	}
//
//	/**
//	 * @param extraParameterAction the action to take when an extra parameter is detected
//	 */
//	public void setExtraParameterAction(int extraParameterAction)
//	{
//		this.extraParameterAction = extraParameterAction;
//	}
//
//	/**
//	 * Set the action to perform if this RuleSet contains an extra parameter.
//	 *
//	 * @param action the action to take when an extra parameter is detected
//	 */
//	public void setExtraParameterAction(String action)
//	{
//		try
//		{
//			setExtraParameterAction(StingerRule.getActionInt(action));
//		}
//		catch (ArgumentException e)
//		{
//		}
//	}
//
//	/**
//	 * @return the action to take when an extra parameter is detected.
//	 */
//	public int getExtraParameterAction()
//	{
//		return extraParameterAction;
//	}
//
//	/**
//	 * @param name the name for this RuleSet.
//	 */
//	public void setName(String name)
//	{
//		this.name = name;
//	}
//
//	/**
//	 * @return the name of this RuleSet
//	 */
//	public String getName()
//	{
//		return name;
//	}
//
//	/**
//	 * Set the path that this RuleSet will apply to. Any request that startsWith this path
//	 * will match. You can use / to create a ruleset that applies to all requests.
//	 *
//	 * @param path
//	 */
//	public void setPath(String path)
//	{
//		this.path = path;
//	}
//
//	/**
//	 * @return the path this RuleSet should be applied to
//	 */
//	public String getPath()
//	{
//		return path;
//	}
//
//	/**
//	 * Returns the list of rules that matches a particular type as specified in static int types
//	 * in the Rule class.
//	 *
//	 * @param type the type of the rules to be returned
//	 *
//	 * @return a List of the matching rules
//	 */
//	public IList getRules(int type)
//	{
//		IList list = new ArrayList();
//		Iterator i = rules.values().iterator();
//		while (i.hasNext())
//		{
//			StingerRule v = (StingerRule) i.next();
//			if (v.getType() == type)
//			{
//				list.Add(v);
//			}
//		}
//		return (list);
//	}
//
//	/**
//	 * Returns a list of all the rules in this RuleSet.
//	 *
//	 * @return the List of rules
//	 */
//	public IList getRules()
//	{
//		return new ArrayList(rules.Values);
//	}
//
//	/**
//	 * Add a check for a cookie.
//	 *
//	 * @param candidate the name of the cookie to validate
//	 * @param regex the regular expression to use in validatiing the cookie
//	 * @param action the action to take when malformed
//	 * @param missingAction the action to take when missing
//	 * @param hidden whether to obfuscate the value in any messages
//	 * @param message the message to display for any malformed errors
//	 */
//	public void addCookie(String candidate, String regex, int action, int missingAction, bool hidden, String message)
//	{
//		StingerRule v = new StingerRule(StingerRule.COOKIE, candidate, regex, action, missingAction, hidden, message);
//		rules.Add(candidate, v);
//	}
//
//	/**
//	 * Add a check for a header.
//	 *
//	 * @param candidate the name of the cookie to validate
//	 * @param regex the regular expression to use in validatiing the cookie
//	 * @param action the action to take when malformed
//	 * @param missingAction the action to take when missing
//	 * @param hidden whether to obfuscate the value in any messages
//	 * @param message the message to display for any malformed errors
//	 */
//	public void addHeader(String candidate, String regex, int action, int missingAction, bool hidden, String message)
//	{
//		StingerRule v = new StingerRule(StingerRule.HEADER, candidate, regex, action, missingAction, hidden, message);
//		rules.Add(candidate, v);
//	}
//
//	/**
//	 * Add a check for a required parameter. Required means that the parameter
//	 * must be present or a fatal exception will be thrown. The field must
//	 * also match the regular expression. If it does not match, then an
//	 * exception is thrown during validation according to the fatal flag.
//	 *
//	 * @param candidate the name of the cookie to validate
//	 * @param regex the regular expression to use in validatiing the cookie
//	 * @param action the action to take when malformed
//	 * @param missingAction the action to take when missing
//	 * @param hidden whether to obfuscate the value in any messages
//	 * @param message the message to display for any malformed errors
//	 */
//	public void addParameter(String candidate, String regex, int action, int missingAction, bool hidden, String message)
//	{
//		StingerRule v = new StingerRule(StingerRule.PARAMETER, candidate, regex, action, missingAction, hidden, message);
//		rules.Add(candidate, v);
//	}
//
//	/**
//	 * Add a rule to this RuleSet
//	 *
//	 * @param r the rule to add
//	 */
//	public void addRule(StingerRule r)
//	{
//		rules.Add(r.getName(), r);
//	}
//
//	/**
//	 * Returns true if this RuleSet contains a rule that matches the specified
//	 * name and type.
//	 *
//	 * @param candidate the name of the candidate to match.
//	 * @param type the type of the candidate to match.
//	 *
//	 * @return true if this RuleSet contains a rule that matches the specified
//	 * name and type.
//	 */
//	public bool containsMatchingRule(String candidate, int type)
//	{
//		Iterator i = rules.values().iterator();
//		while (i.hasNext())
//		{
//			Rule v = (StingerRule) i.next();
//			if (v.getName().equals(candidate) && (v.getType() == type))
//			{
//				return true;
//			}
//		}
//		return false;
//	}
//
//	/**
//	 * Returns true if this RuleSet's path startsWith the specified candidate. Generally,  the
//	 * candidate would be the HttpServletRequest.getRequestURI(), but it is possible
//	 * to imagine a different matching scheme for certain web applications.
//	 *
//	 * @param candidate the path of the candidate.
//	 *
//	 * @return true if the candidate matches this RuleSet.
//	 */
//	public bool matches(String candidate)
//	{
//		return candidate.StartsWith(path);
//	}
//
//	/**
//	 * Returns a String representation of this RuleSet.
//	 *
//	 * @return the String representation.
//	 */
//	public String toString()
//	{
//		return "RuleSet " + name + " " + path + " extra header " + StingerRule.getActionString(getExtraHeaderAction()) + " extra cookie " + StingerRule.getActionString(getExtraCookieAction());
//	}
//
//	/**
//	 * Returns a list of ValidationProblems for any parts that are not defined in any ruleset. Note
//	 * that this step must be done in the RuleSet and not in the Rule, like validateMalformed and
//	 * validateMissing. This is because you can't tell if something is extra by looking at a single
//	 * rule at a time.
//	 *
//	 * @param request the HttpServletRequest to search for extra parts.
//	 *
//	 * @return a List of the ValidationProblems uncovered.
//	 *
//	 * @throws FatalValidationException if any fatal rules are violated, throw the exception
//	 */
//	public IList validateExtra(HttpRequest request)
//	{
//		ArrayList list = new ArrayList();		
//		// check cookies
//		if (getExtraCookieAction() != StingerRule.IGNORE)
//		{
//			Cookie[] cookies = request.getCookies();
//			if (cookies != null)
//			{
//				for (int i = 0; i < cookies.Length; i++)
//				{
//					String candidate = cookies[ i ].getName();
//					if (!containsMatchingRule(candidate, Rule.COOKIE))
//					{
//						ValidationProblem p = new ValidationProblem(ValidationProblem.EXTRA, Rule.COOKIE, candidate, null, getExtraMessage(candidate, Rule.COOKIE));
//						if (getExtraCookieAction() == Rule.CONTINUE)
//						{
//							list.Add(p);
//						}
//						else
//						{
//							throw new FatalValidationException(p);
//						}
//					}
//				}
//			}
//		}
//
//		// check headers
//		if (getExtraHeaderAction() != StingerRule.IGNORE)
//		{
//			Enumeration e = request.getHeaderNames();
//			while (e.hasMoreElements())
//			{
//				String candidate = (String) e.nextElement();
//
//				// skip the cookie header since it's special and we handle it separately
//				if (!candidate.Equals("cookie"))
//				{
//					if (!containsMatchingRule(candidate, StingerRule.HEADER))
//					{
//						ValidationProblem p = new ValidationProblem(ValidationProblem.EXTRA, Rule.HEADER, candidate, null, getExtraMessage(candidate, Rule.HEADER));
//						if (getExtraHeaderAction() == StingerRule.CONTINUE)
//						{
//							list.Add(p);
//						}
//						else
//						{
//							throw new FatalValidationException(p);
//						}
//					}
//				}
//			}
//		}
//
//		// check parameters
//		if (getExtraParameterAction() != Rule.IGNORE)
//		{
//			Enumeration ne = request.getParameterNames();
//			while (ne.hasMoreElements())
//			{
//				String candidate = (String) ne.nextElement();
//				if (!containsMatchingRule(candidate, Rule.PARAMETER))
//				{
//					ValidationProblem p = new ValidationProblem(ValidationProblem.EXTRA, Rule.PARAMETER, candidate, null, getExtraMessage(candidate, Rule.PARAMETER));
//					if (getExtraParameterAction() == Rule.CONTINUE)
//					{
//						list.Add(p);
//					}
//					else
//					{
//						throw new FatalValidationException(p);
//					}
//				}
//			}
//		}
//
//		return list;
//	}
//
//	/**
//	 * Returns a list of ValidationProblems for any parts that are malformed.
//	 *
//	 * @param request the HttpServletRequest to search for malformed parts.
//	 *
//	 * @return a List of the ValidationProblems uncovered.
//	 *
//	 * @throws FatalValidationException if any fatal rules are violated, throw the exception
//	 */
//	public IList validateMalformed(HttpRequest request)
//	{
//		IList list = new ArrayList();
//		Iterator j = rules.values().iterator();
//		while (j.hasNext())
//		{
//			StingerRule r = (StingerRule) j.next();
//			list.Add(r.validateMalformed(request));
//		}
//		return list;
//	}
//
//	/**
//	 * Returns a list of ValidationProblems for any parts that are missing.
//	 *
//	 * @param request the HttpServletRequest to search for missing parts.
//	 *
//	 * @return a List of the ValidationProblems uncovered.
//	 *
//	 * @throws FatalValidationException if any fatal rules are violated, throw the exception
//	 */
//	public IList validateMissing(HttpRequest request)
//	{
//		IList list = new ArrayList();
//		Iterator i = rules.values().iterator();
//		while (i.hasNext())
//		{
//			StingerRule r = (StingerRule) i.next();
//			if (!r.validateMissing(request))
//			{
//				list.Add(new ValidationProblem(ValidationProblem.MISSING, r.getType(), r.getName(), null, r.getMissingMessage()));
//			}
//		}
//		return list;
//	}
//}
//}
