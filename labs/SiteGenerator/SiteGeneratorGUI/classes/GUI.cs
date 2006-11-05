using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Owasp.SiteGenerator
{
    class GUI
    {
        delegate void updateTextBoxCallback(string strText, TextBox tbToUse);
        delegate void updateListViewCallback(ListView lvToUse, ListViewItem lvItemToAdd);

        public static void updateTextBox(string strText, TextBox tbToUse)
        {
            if (tbToUse.InvokeRequired)
            {
                updateTextBoxCallback utbCallback = new updateTextBoxCallback(updateTextBox);
                tbToUse.Invoke(utbCallback, new object[] { strText, tbToUse });
            }
            else
            {
                tbToUse.Text = strText + Environment.NewLine + tbToUse.Text;
            }
        }

        public static void updateListView(ListView lvToUse, ListViewItem lvItemToAdd)
        {
            if (lvToUse.InvokeRequired)
            {
                updateListViewCallback ulvCallback = new updateListViewCallback(updateListView);
                lvToUse.Invoke(ulvCallback, new object[] { lvToUse, lvItemToAdd });
            }
            else
            {
                lvToUse.Items.Insert(0, lvItemToAdd);
            }
        }

    }
}
