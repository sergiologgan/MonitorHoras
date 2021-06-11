using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01
{
    public static class Generic
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public static string SumGetString<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
        {
            return Util.FormatarHoras(source.Select(selector).Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2));
        }

        public static TimeSpan SumGetTimeSpan<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
        {
            return source.Select(selector).Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);
        }
    }
}
