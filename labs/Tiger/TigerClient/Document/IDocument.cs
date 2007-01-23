using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Document
{
    public interface IDocument
    {
        event EventHandler<DocumentPartModifiedEventArgs> Modified;
        string Title { get; }
        string FilePath { get; }
        void Save();
        void SaveAs(string filePath);
        bool IsModified { get; }

        //string FileName { get; }
        //bool HasEverBeenSaved { get; }
        //bool Validate();
    }
}
