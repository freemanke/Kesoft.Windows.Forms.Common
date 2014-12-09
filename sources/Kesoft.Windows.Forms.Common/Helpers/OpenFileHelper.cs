using System.Diagnostics;
using System.IO;

namespace System.Windows.Forms
{
    /// <summary>
    /// 打开文件帮助类。
    /// </summary>
    public static class OpenFileHelper
    {
        /// <summary>
        /// 打开文件，
        /// 使用默认关联程序打开。
        /// </summary>
        /// <param name="fileName">文件名称。</param>
        public static void Open(string fileName)
        {
            if (File.Exists(fileName)) Process.Start(fileName);
        }
    }
}