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
    public abstract class ResponseBodyContainsConditionBase : ResponseBodyConditionBase
    {
        protected string matchString;
        protected bool caseSensitive;

        [System.Xml.Serialization.XmlElement("Value")]
        public virtual string MatchString
        {
            get { return matchString; }
            set { matchString = value; }
        }

        [System.Xml.Serialization.XmlIgnore()]
        public virtual bool CaseSensitive
        {
            get { return caseSensitive; }
            set { caseSensitive = value; }
        }

        public override string ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(matchString))
                    return "Match string must be set.";
                else
                    return null;
            }
        }
    }
}
