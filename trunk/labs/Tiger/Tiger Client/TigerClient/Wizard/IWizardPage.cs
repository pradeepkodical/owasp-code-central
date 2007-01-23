using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Wizard
{
    interface IWizardPage
    {
        IWizard Wizard { get; set; }
        string Caption { get; }
        string Description { get; }
        bool IsVisible { get; set; }
        object PageData { get; set; }

        void UpdateData();
    }
}
