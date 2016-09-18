using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomLibrary
{
    public static class GeneralUI
    {
        public static DialogResult InfoMsg(string msg, string title = "")
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ErrorMsg(string msg, string title = "")
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult QuestionMsg(string msg, string title = "", MessageBoxDefaultButton defaultBtn = MessageBoxDefaultButton.Button2)
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, defaultButton: defaultBtn);
        }

        public static DialogResult WarningMsg(string msg, string title = "")
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
