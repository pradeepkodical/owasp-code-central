// Tiger Client 1.0
// Copyright (C) 2007 Boris Maletic
//
// This program is free software; you can redistribute it and/or modify it under 
// the terms of the GNU General Public License as published by the Free Software Foundation;
// either version 2 of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with this program;
// if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TigerClient.Document.Condition
{
    public abstract class BinaryCondition : ICondition
    {
        protected ICondition condition1;
        protected ICondition condition2;

        [XmlElement(typeof(ResponseStatusCodeEqualToCondition), Order = 1)]
        [XmlElement(typeof(ResponseStatusCodeEqualToNotCondition), Order = 1)]
        [XmlElement(typeof(ResponseBodyContainsCondition), Order = 1)]
        [XmlElement(typeof(ResponseBodyContainsNotCondition), Order = 1)]
        [XmlElement(typeof(ResponseBodyRegexMatchCondition), Order = 1)]
        [XmlElement(typeof(ResponseBodyRegexMatchNotCondition), Order = 1)]
        [XmlElement(typeof(AndCondition), Order = 1)]
        [XmlElement(typeof(OrCondition), Order = 1)]
        public object Condition1
        {
            get { return condition1; }
            set { condition1 = (ICondition) value; }
        }

        [XmlElement(typeof(ResponseStatusCodeEqualToCondition), Order = 2)]
        [XmlElement(typeof(ResponseStatusCodeEqualToNotCondition), Order = 2)]
        [XmlElement(typeof(ResponseBodyContainsCondition), Order = 2)]
        [XmlElement(typeof(ResponseBodyContainsNotCondition), Order = 2)]
        [XmlElement(typeof(ResponseBodyRegexMatchCondition), Order = 2)]
        [XmlElement(typeof(ResponseBodyRegexMatchNotCondition), Order = 2)]
        [XmlElement(typeof(AndCondition), Order = 2)]
        [XmlElement(typeof(OrCondition), Order = 2)]
        public object Condition2
        {
            get { return condition2; }
            set { condition2 = (ICondition) value; }
        }

        #region ICondition Members

        public abstract bool Result
        {
            get;
        }

        public virtual bool IsValid
        {
            get { return string.IsNullOrEmpty(ErrorMessage); }
        }

        public virtual string ErrorMessage
        {
            get
            {
                if (condition1 == null || condition2 == null) return "Both operands must be set.";
                if (!(condition1.IsValid && condition2.IsValid)) return "At least one operand is not valid.";
                return null;
            }
        }

        public virtual void SetResponseBody(string responseBody)
        {
            if (condition1 != null) condition1.SetResponseBody(responseBody);
            if (condition2 != null) condition2.SetResponseBody(responseBody);
        }

        public virtual void SetResponseStatusCode(int responseStatusCode)
        {
            if (condition1 != null) condition1.SetResponseStatusCode(responseStatusCode);
            if (condition2 != null) condition2.SetResponseStatusCode(responseStatusCode);
        }

        #endregion
    }
}
