using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeaLog
{
    public class Util
    {
        public static DialogResult ShowException(string preamble, Exception ex)
        {
            return ShowException("TeaLog Error", preamble, ex);
        }

        public static DialogResult ShowException(string caption, string preamble, Exception ex)
        {
            Debug.Assert(caption != null, "Tried to show an exception with a null caption");
            Debug.Assert(ex != null, "Tried to show a null exception.");

            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(preamble))
            {
                sb.AppendLine(preamble);
            }

            while (ex != null)
            {
                sb.AppendLine();
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);

                ex = ex.InnerException;
            }

            return MessageBox.Show(sb.ToString(), caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
