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

namespace TigerClient.Document.Condition
{
    public abstract class ResponseBodyConditionBase : ICondition
    {
        protected string actualResponseBody;

        [System.Xml.Serialization.XmlIgnore()]
        public virtual string ActualResponseBody
        {
            get { return actualResponseBody; }
            set { actualResponseBody = value; }
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

        public abstract string ErrorMessage
        {
            get;
        }

        public virtual void SetResponseBody(string responseBody)
        {
            actualResponseBody = responseBody;
        }

        public virtual void SetResponseStatusCode(int responseStatusCode)
        {
            // No-op
        }

        #endregion
    }
}
