using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document
{
    public enum DocumentPartModificationType
    {
        DocumentPartPropertyModified,
        DocumentPartAdded,
        DocumentPartRemoved,
        ChildDocumentPartsCleared
    }
}
