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
using System.ComponentModel;

namespace TigerClient.Document
{
    public class TestParameter: DocumentPart
    {
        private string name;
        private string value;

        [Category("Configuration")]
        public string Name
        {
            get { return name; }
            set
            { 
                name = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Name", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        [Category("Configuration")]
        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                OnModified(new DocumentPartModifiedEventArgs(this, "Value", DocumentPartModificationType.DocumentPartPropertyModified));
            }
        }

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    return "<Parameter>";
                else
                    return name;
            }
        }

        public override string ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    return "Parameter name must be provided.";
                else
                    return null;
            }
        }
    }
}
