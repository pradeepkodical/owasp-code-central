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
