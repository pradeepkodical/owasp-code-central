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

namespace TigerClient.Document
{
    public class DocumentPartCollection<T>: System.Collections.ObjectModel.Collection<T> where T: DocumentPart
    {
        public event EventHandler<DocumentPartModifiedEventArgs> Modified;

        protected override void InsertItem(int index, T newItem)
        {
            base.InsertItem(index, newItem);
            if (Modified != null)
                Modified(this, new DocumentPartModifiedEventArgs(newItem, "", DocumentPartModificationType.DocumentPartAdded));
        }

        protected override void SetItem(int index, T newItem)
        {
            T removedItem = base.Items[index];

            base.SetItem(index, newItem);
            if (Modified != null)
            {
                Modified(this, new DocumentPartModifiedEventArgs(removedItem, "", DocumentPartModificationType.DocumentPartRemoved));
                Modified(this, new DocumentPartModifiedEventArgs(newItem, "", DocumentPartModificationType.DocumentPartAdded));
            }
        }

        protected override void RemoveItem(int index)
        {
            T removedItem = base.Items[index];

            base.RemoveItem(index);
            if (Modified != null)
                Modified(this, new DocumentPartModifiedEventArgs(removedItem, "", DocumentPartModificationType.DocumentPartRemoved));
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            if (Modified != null)
                Modified(this, new DocumentPartModifiedEventArgs(null, "", DocumentPartModificationType.ChildDocumentPartsCleared));
        }
    }
}
