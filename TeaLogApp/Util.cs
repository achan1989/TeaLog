using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

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

            return System.Windows.Forms.MessageBox.Show(sb.ToString(), caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Find a particular type of ancestor in an object's visual tree.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static T FindAncestor<T>(DependencyObject from) where T : class
        {
            if (from == null)
            {
                return null;
            }

            T candidate = from as T;
            if (candidate != null)
            {
                return candidate;
            }

            return FindAncestor<T>(VisualTreeHelper.GetParent(from));
        }
    }
}
