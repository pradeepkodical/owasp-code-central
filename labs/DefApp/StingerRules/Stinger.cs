///*
// * Stinger is an HTTP Request Validation Engine
// *
// * This library is free software; you can redistribute it and/or
// * modify it under the terms of the GNU Lesser General Public
// * License as published by the Free Software Foundation; either
// * version 2.1 of the License, or (at your option) any later version.
// *
// * This library is distributed in the hope that it will be useful,
// * but WITHOUT ANY WARRANTY; without even the implied warranty of
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// * Lesser General Public License for more details.
// *
// * You should have received a copy of the GNU Lesser General Public
// * License along with this library; if not, write to the Free Software
// * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// *
// */
//package owasp.stinger;
//
//import nu.xom.Builder;
//import nu.xom.Document;
//import nu.xom.Element;
//import nu.xom.Elements;
//
//import java.io.File;
//import java.io.FilenameFilter;
//
//import java.util.ArrayList;
//import java.util.Collection;
//import java.util.Date;
//import java.util.HashMap;
//import java.util.HashSet;
//import java.util.Iterator;
//import java.util.List;
//
//import javax.servlet.ServletConfig;
//import javax.servlet.http.HttpServletRequest;
//
//
///**
// * Stinger provides the public API for the Stinger package and can be used to create RuleSets, apply them
// * to HttpServletRequests, and handle the errors that are uncovered.  Essentially, Stinger models
// *  the validation requirements for an HTTP request. The Stinger singleton contains a list of
// * RuleSets that may or may not apply to a particular HTTP request. Stinger also provides methods
// * to generate the client side JavaScript to insert in a web page and format an error list into HTML.
// *
// * @author jeff.williams@aspectsecurity.com
// */
//public class Stinger
//{
//	protected static HashMap rulesets = new HashMap();
//	private static Stinger instance;
//	private HashMap times = new HashMap();
//
//	/**
//	 * Hide the constructor to force use of the getInstance() singleton method.
//	 */
//	private Stinger()
//	{
//	}
//
//	/**
//	 * Returns the singleton instance
//	 */
//	public static Stinger getInstance(ServletConfig config)
//	{
//		if (instance == null)
//		{
//			instance = new Stinger();
//		}
//
//		// FIXME: make this turn-offable for production
//		instance.loadRuleSets(config.getServletContext().getRealPath("rules"));
//		return instance;
//	}
//
//	/**
//	 * Returns a JavaScript suitable for inserting in a web page that will validate the parameters in
//	 * a form. The script displays an alert box containing ALL the errors found in the form. The
//	 * script uses the exact same regular expressions as the server side validation. However, the
//	 * JavaScript alone is easily bypassed and does not provide ANY security protection. It's only
//	 * benefit is in ease of use for users with a slow Internet connection.
//	 *
//	 * @param form the name of the form that the script will access to get parameters
//	 * @param target the action URI targeted by the form
//	 *
//	 * @return a String containing a JavaScript that will validate input on the client side and
//	 * create a dialog box with the results.
//	 */
//	public String getJavaScript(String target, String form)
//	{
//		System.out.println();
//		System.out.println("Getting JavaScript for " + target + ":" + form);
//
//		StringBuffer scriptPart1 = new StringBuffer();
//		StringBuffer scriptPart2 = new StringBuffer();
//
//		// FIXME: Cache generated scripts for for performance
//		List matchingRuleSets = getRuleSets(target);
//		Iterator i = rulesets.values().iterator();
//		while (i.hasNext())
//		{
//			RuleSet ruleset = (RuleSet) i.next();
//			List matchingRules = ruleset.getRules(Rule.PARAMETER);
//			Iterator j = matchingRules.iterator();
//
//			int loop = 0;
//			int n = 0;
//			scriptPart1.append("<SCRIPT>");
//			scriptPart2.append("function validate() { msg='Errors found:\\n'; err=0;");
//
//			while (j.hasNext())
//			{
//				Rule rule = (Rule) j.next();
//				String name = rule.getName();
//
//				// only test if rule is a parameter and is not set to ignore malformed
//				if (!rule.isParameter() || (rule.getMalformedAction() == Rule.IGNORE))
//				{
//					break;
//				}
//
//				// set up the regular expression
//				String regex = rule.getRegex();
//				scriptPart1.append("regex" + n + "=/");
//				scriptPart1.append(regex);
//				scriptPart1.append("/;");
//				String message = rule.getMalformedMessage(""); // FIXME: can't send value for detailed message
//
//				// if the parameter is required
//				if (rule.getMissingAction() != Rule.IGNORE)
//				{
//					scriptPart2.append("if (!regex" + n + ".test(" + form + "." + name + ".value)) {err+=1; msg+='\\n  " + message + "';}");
//					n++;
//				}
//
//				// if the parameter is not-required
//				else
//				{
//					scriptPart2.append("if ( form." + name + ".value" + " && !regex" + n + ".test(" + form + "." + name + ".value) ) {err+=1; msg+='\\n  " + message + "';}");
//					n++;
//				}
//			}
//
//			scriptPart2.append("if ( err > 0 ) alert(msg);");
//			scriptPart2.append("else form.submit();");
//			scriptPart2.append("} </SCRIPT>");
//		}
//		return scriptPart1.append(scriptPart2).toString();
//	}
//
//	/**
//	 * Lookup the appropriate rulesets for the path submitted.
//	 *
//	 * @param path RuleSets are returned that match this path
//	 *
//	 * @return a List containing all the RuleSets that match the path submitted
//	 */
//	public List getRuleSets(String path)
//	{
//		System.out.println("Searching for RuleSets matching " + path);
//		List list = new ArrayList();
//		Iterator i = rulesets.values().iterator();
//		while (i.hasNext())
//		{
//			RuleSet ruleset = (RuleSet) i.next();
//			if (ruleset.matches(path))
//			{
//				System.out.println("   > Found: " + ruleset);
//				list.add(ruleset);
//			}
//		}
//		return (list);
//	}
//
//	/**
//	 * Create a new validator and store it in the cache.
//	 */
//	public RuleSet createRuleSet(String name, String path)
//	{
//		RuleSet ruleset = new RuleSet(name, path);
//		System.out.println("Creating " + ruleset.toString());
//		rulesets.put(null, ruleset); // store programatically created rulesets with no filename
//		return ruleset;
//	}
//
//	/**
//	 * Formats a list of errors into an HTML list for easy displaying
//	 */
//	public String format(ProblemList errors)
//	{
//		StringBuffer sb = new StringBuffer("\n\n<!-- Validation errors detected by OWASP Stinger (www.owasp.org) -->\n");
//		for (int i = 0; i < errors.size(); i++)
//		{
//			sb.append("<DIV> - " + errors.get(i).getMessage() + "</DIV>\n");
//		}
//		return sb.toString();
//	}
//
//	/**
//	 * Replace any special characters  headers, cookies, querystring, and
//	 * parameters their HTML entity encoded version
//	 *
//	 * @param request the request full of parameters that need encoding
//	 */
//	public void htmlEntityEncode(HttpServletRequest request)
//	{
//		// FIXME -- this seems like the wrong place for this feature, but might be useful.
//		throw new UnsupportedOperationException("Not implemented yet");
//	}
//
//	/**
//	 * Validates the HTTP request against the rulesets in Stinger.
//	 *
//	 * @param request the HTTP request to be validated.
//	 *
//	 * @return a list of ValidationErrors detailing any problems found
//	 */
//	public ProblemList validate(HttpServletRequest request) throws FatalValidationException
//	{
//		System.out.println();
//		System.out.println("-------------------------------------------------");
//		System.out.println("Validating " + request.getRequestURI());
//		System.out.println("Validating with " + toString());
//		ProblemList errors = new ProblemList();
//		List list = getRuleSets(request.getRequestURI());
//		errors.addAll(validateExtra(list, request));
//		errors.addAll(validateMissing(list, request));
//		errors.addAll(validateMalformed(list, request));
//		return errors;
//	}
//
//	/**
//	 * Utility routine for extracting the String value from the first child matching the key
//	 *
//	 * @param e the element to search for a key.
//	 * @param key the name of the child element to extract the value from.
//	 *
//	 * @return the String value of the first child matching the key.
//	 */
//	private String getField(Element e, String key)
//	{
//		Element field = e.getFirstChildElement(key);
//		if (field == null)
//		{
//			return null;
//		}
//		return field.getValue();
//	}
//
//	/**
//	 * Load any rulesets stored in SVDL files on the path. This method stores the time each file was
//	 * modified in a hashmap, and reloads if any of the files were modified.
//	 *
//	 * @param path the path to the SVDL files
//	 */
//	private void loadRuleSets(String path)
//	{
//		Builder builder = new Builder();
//		FilenameFilter filter = new FilenameFilter()
//		{
//			public boolean accept(File dir, String name)
//			{
//				return (name.toUpperCase().endsWith(".SVDL")); // Security Validation Description Language
//			}
//		};
//
//		File dir = new File(path);
//		File[] list = dir.listFiles(filter);
//		if (list == null)
//		{
//			return;
//		}
//		System.out.println("Found: " + list.length + " SVDL files");
//		for (int i = 0; i < list.length; i++)
//		{
//			File f = list[ i ];
//			Date modified = new Date(f.lastModified());
//			Date loaded = (Date) times.get(f.getAbsolutePath());
//			if (loaded == null)
//			{
//				loaded = new Date(0);
//			}
//			if (modified.after(loaded))
//			{
//				System.out.println("Loading: " + f.getName());
//				times.put(f.getAbsolutePath(), modified);
//				rulesets.remove(f.getAbsolutePath());
//				try
//				{
//					Document d = builder.build(f);
//					rulesets.put(f.getAbsolutePath(), parseRuleSet(d));
//				}
//				catch (Exception e)
//				{
//					System.out.println("   > Error loading " + f.getName() + " -- skipping");
//					e.printStackTrace();
//				}
//			}
//			else
//			{
//				System.out.println("Not modified: " + f.getName());
//			}
//		}
//	}
//
//	/**
//	 * Parses an SVDL document and returns a RuleSet
//	 *
//	 * @param d the document to be parsed
//	 */
//	private RuleSet parseRuleSet(Document d)
//	{
//		RuleSet ruleset = new RuleSet();
//		Element root = d.getRootElement();
//		ruleset.setName(getField(root, "name"));
//		ruleset.setPath(getField(root, "path"));
//		ruleset.setExtraCookieAction(getField(root, "extraCookieAction"));
//		ruleset.setExtraHeaderAction(getField(root, "extraHeaderAction"));
//		ruleset.setExtraParameterAction(getField(root, "extraParameterAction"));
//		ruleset.setExtraMessage(getField(root, "extraMessage"));
//		System.out.println(ruleset);
//
//		Elements rules = root.getChildElements("rule");
//		for (int i = 0; i < rules.size(); i++)
//		{
//			Element rule = rules.get(i);
//			Rule r = new Rule();
//			r.setName(getField(rule, "name"));
//			r.setType(getField(rule, "type"));
//
//			// FIXME: add support for the regex definitions in regex.xml
//			r.setRegex(getField(rule, "regex"));
//			r.setMessageLevel(getField(rule, "messageLevel"));
//			r.setMalformedAction(getField(rule, "malformedAction"));
//			r.setMalformedMessage(getField(rule, "malformedMessage"));
//			r.setMissingAction(getField(rule, "missingAction"));
//			r.setMissingMessage(getField(rule, "missingMessage"));
//			r.setHidden(getField(rule, "hidden"));
//			ruleset.addRule(r);
//			System.out.println(" - " + r);
//		}
//		return ruleset;
//	}
//
//	/**
//	 * Validate the request for extra parts using the list of rulesets supplied
//	 *
//	 * @throws FatalValidationException
//	 */
//	private Collection validateExtra(List list, HttpServletRequest request) throws FatalValidationException
//	{
//		ArrayList errors = new ArrayList();
//		Iterator i = list.iterator();
//		while (i.hasNext())
//		{
//			RuleSet ruleset = (RuleSet) i.next();
//			errors.addAll(ruleset.validateExtra(request));
//		}
//
//		// FIXME: eliminate duplicates that might occur if a field is extra in multiple rulesets
//		return errors;
//	}
//
//	/**
//	 * Validate the request for malformed parts using the list of rulesets supplied
//	 *
//	 * @throws FatalValidationException
//	 */
//	private Collection validateMalformed(List list, HttpServletRequest request) throws FatalValidationException
//	{
//		ArrayList errors = new ArrayList(); // allow duplicates
//		Iterator i = list.iterator();
//		while (i.hasNext())
//		{
//			RuleSet ruleset = (RuleSet) i.next();
//			errors.addAll(ruleset.validateMalformed(request));
//		}
//		return errors;
//	}
//
//	/**
//	 * Validate the request for missing parts using the list of rulesets supplied
//	 *
//	 * @throws FatalValidationException
//	 */
//	private Collection validateMissing(List list, HttpServletRequest request) throws FatalValidationException
//	{
//		HashSet errors = new HashSet(); // no duplicates
//		Iterator i = list.iterator();
//		while (i.hasNext())
//		{
//			RuleSet ruleset = (RuleSet) i.next();
//			errors.addAll(ruleset.validateMissing(request));
//		}
//		return errors;
//	}
//}