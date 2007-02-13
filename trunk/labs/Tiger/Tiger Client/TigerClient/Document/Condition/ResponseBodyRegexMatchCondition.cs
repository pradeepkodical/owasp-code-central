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
    [System.Xml.Serialization.XmlType("ResponseBodyMatchesRegex")]
    public class ResponseBodyRegexMatchCondition : ResponseBodyRegexConditionBase
    {
        public override bool Result
        {
            get
            {
                if (actualResponseBody == null)
                    return false;

                if (caseSensitive)
                    return System.Text.RegularExpressions.Regex.IsMatch(actualResponseBody, regex, System.Text.RegularExpressions.RegexOptions.None);
                else
                    return System.Text.RegularExpressions.Regex.IsMatch(actualResponseBody, regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(regex))
                return "Invalid condition";
            else
                return "Response body contains match for regex \"" + regex + "\"";
        }
    }
}
