using System.Linq;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    /// <summary>
    /// 扩展方法类。
    /// </summary>
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// 通过标签获取行。
        /// </summary>
        /// <param name="dgv">数据网格视图控件。</param>
        /// <param name="value">对象实例。</param>
        /// <returns></returns>
        public static DataGridViewRow GetRowByTag(this DataGridView dgv, object value)
        {
            return dgv.Rows.Cast<DataGridViewRow>().FirstOrDefault(row => row.Tag == value);
        }
    }
}