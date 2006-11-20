//using System;
//using System.Collections;
//
//namespace Owasp.DefApp.StingerRules
//{
//	public class ProblemList
//	{
//		private ArrayList list = new ArrayList();
//
//		/**
//		 * Creates a new ProblemList object.
//		 */
//		public ProblemList()
//		{
//		}
//
//		/**
//		 * Add a ValidationProblem to this ProblemList
//		 *
//		 * @param p the ValidationProblem to add
//		 */
//		public void add(ValidationProblem p)
//		{
//			// FIXME: Find out how a null is getting into this list
//			if ((p != null) && !list.Contains(p))
//			{
//				list.Add(p);
//			}
//		}
//
//		/**
//		 * Add all elements of a Collection of ValidationProblems to this ProblemList
//		 *
//		 * @param c the Collection to add
//		 */
//		public void addAll(ICollection c)
//		{
//			IEnumerator i= c.GetEnumerator();			
//			while (i.MoveNext())
//			{
//				add((ValidationProblem) i.Current);
//			}
//		}
//
//		/**
//		 * Get the ValidationProblem at the specified index.
//		 *
//		 * @param index the index of the problem to return.
//		 *
//		 * @return the ValidationProblem at the specified index.
//		 */
//		public ValidationProblem get(int index)
//		{
//			return (ValidationProblem) list[index];
//		}
//
//		/**
//		 * Returns true if this ProblemList has any ValidationProblems in it.
//		 *
//		 * @return boolean indicating whether this ProblemList has any ValidationProblems in it.
//		 */
//		public bool hasErrors()
//		{
//			return list.Count > 0;
//		}
//		/**
//		 * Return the size of this ProblemList.
//		 *
//		 * @return the size
//		 */
//		public int size()
//		{
//			return list.Count;
//		}
//	}
//}
