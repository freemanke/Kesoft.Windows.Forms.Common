using System;
using System.ComponentModel;

namespace System.Windows.Forms
{
    /// <summary>
    /// “ISynchronizeInvoke”接口方法扩展，
    /// 使得实现了“ISynchronizeInvoke”
    /// 接口的对象能够跨线程安全调用。
    /// </summary>
    public static class SafeInvokeExtensions
    {
        /// <summary>
        /// 线程安全调用。
        /// </summary>
        /// <typeparam name="T">支持同步调用接口的类型。</typeparam>
        /// <typeparam name="TResult">返回类型。</typeparam>
        /// <param name="t">支持同步调用接口的对象。</param>
        /// <param name="call">委托。</param>
        /// <returns>返回类型对象。</returns>
        public static TResult SafeInvoke<T, TResult>(
            this T t,
            Func<T, TResult> call)
            where T : ISynchronizeInvoke
        {
            var endResult = default(TResult);
            try
            {
                if (t.InvokeRequired)
                {
                    var result = t.BeginInvoke(call, new object[] {t});
                    var end = t.EndInvoke(result);
                    endResult = (TResult) end;
                }
                else
                {
                    endResult = call(t);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return endResult;
        }

        /// <summary>
        /// 线程安全调用。
        /// </summary>
        /// <typeparam name="T">支持同步调用接口的类型。</typeparam>
        /// <param name="t">支持同步调用接口的对象。</param>
        /// <param name="call">委托。</param>
        public static void SafeInvoke<T>(this T t, Action<T> call)
            where T : ISynchronizeInvoke
        {
            try
            {
                if (t.InvokeRequired) t.BeginInvoke(call, new object[] {t});
                else call(t);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}