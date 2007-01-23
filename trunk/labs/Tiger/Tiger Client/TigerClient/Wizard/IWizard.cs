using System;
using System.Collections.Generic;
using System.Text;

namespace TigerClient.Wizard
{
    public interface IWizard
    {
        bool MoveNextEnabled { get; set; }
        bool MoveBackEnabled { get; set; }
    }
}
