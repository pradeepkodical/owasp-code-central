//using System;
//
//namespace Owasp.DefApp.StingerRules
//{
//	public class ValidationProblem
//	{
//		public const int MISSING = 1;
//		public const int EXTRA = 2;
//		public const int MALFORMED = 3;
//		private String message;
//		private String name;
//		private String value;
//		private int problem;
//		private int type;
//
//		/**
//		 *
//		 */
//		public ValidationProblem(String message)
//		{
//			this.message = message;
//		}
//
//		/**
//		 * Creates a new ValidationProblem object.
//		 *
//		 * @param problem the type of the problem. One of the static int types defined in this class.
//		 * @param type the type of the part of the HTTP request this problem applies to.
//		 * @param name the name of the part of the HTTP request this problem applies to.
//		 */
//		public ValidationProblem(int problem, int type, String name)
//		{
//			this.problem = problem;
//			this.type = type;
//			this.name = name;
//		}
//
//		/**
//		 * Creates a new ValidationProblem object.
//		 *
//		 * @param problem the type of the problem. One of the static int types defined in this class.
//		 * @param type the type of the part of the HTTP request this problem applies to.
//		 * @param name the name of the part of the HTTP request this problem applies to.
//		 * @param value the value of the part of the HTTP request this problem applies to.
//		 */
//		public ValidationProblem(int problem, int type, String name, String value)
//		{
//			this.problem = problem;
//			this.type = type;
//			this.name = name;
//			this.value = value;
//		}
//
//		/**
//		 * Creates a new ValidationProblem object.
//		 *
//		 * @param problem the type of the problem. One of the static int types defined in this class.
//		 * @param part the type of the part of the HTTP request this problem applies to.
//		 * @param name the name of the part of the HTTP request this problem applies to.
//		 * @param value the value of the part of the HTTP request this problem applies to.
//		 * @param message the custom message to show for this ValidationProblem
//		 */
//		public ValidationProblem(int problem, int part, String name, String value, String message)
//		{
//			this.problem = problem;
//			this.type = part;
//			this.name = name;
//			this.value = value;
//			this.message = message;
//		}
//
//		/**
//		 * @return the message describing this ValidationProblem. You may want to use this message to display to users, or you may
//		 * want to put this in a log file and send the user a generic message.
//		 */
//		public String getMessage()
//		{
//			if ((message != null) && (message.Length > 0))
//			{
//				return message;
//			}
//			if (problem == MALFORMED)
//			{
//				return (getProblemString() + " " + StingerRule.getTypeString(type) + " '" + name + "' = '" + value + "'");
//			}
//			return (getProblemString() + " " + StingerRule.getTypeString(type) + " '" + name + "'");
//		}
//
//		/**
//		 * @return the name of the part of the HTTP request this problem applies to.
//		 */
//		public String getName()
//		{
//			return name;
//		}
//
//		/**
//		 * The type of this problem.
//		 *
//		 * @return one of the static int types defined in this class.
//		 */
//		public int getProblem()
//		{
//			return problem;
//		}
//
//		/**
//		 * The type of this problem.
//		 *
//		 * @return the string version of one of the static int types defined in this class.
//		 */
//		public String getProblemString()
//		{
//			switch (problem)
//			{
//				case MISSING:
//					return "Missing";
//				case EXTRA:
//					return "Extra";
//				case MALFORMED:
//					return "Malformed";
//			}
//			return "Unknown problem with";
//		}
//
//		/**
//		 * @return the type of the part of the HTTP request this problem applies to. One of the
//		 * static int types defined in the Rule class.
//		 */
//		public int getType()
//		{
//			return type;
//		}
//
//		/**
//		 * @return the value of the part of the HTTP request this problem applies to.
//		 */
//		public String getValue()
//		{
//			return value;
//		}
//
//		/**
//		 * Tests another object for equality with this ValidationProblem
//		 * @see java.lang.Object#equals(java.lang.Object)
//		 */
//		public override bool Equals(Object obj)
//		{
//			ValidationProblem other = (ValidationProblem) obj;
//			if (other.getName().Equals(getName()) && (other.getType() == getType()) && (other.getProblem() == getProblem()))
//			{
//				return true;
//			}
//			return false;
//		}
//
//		public override int GetHashCode()
//		{
//			return (name + value + type + problem).GetHashCode();
//		}
//		public override string ToString()
//		{
//			return getMessage();
//		}
//	}
//}