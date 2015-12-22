using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.LogSystem
{
    /// <summary>
    /// 日志模块注入
    /// </summary>
    public static class LogInjection
    {
        /// <summary>
        /// 默认日志
        /// </summary>
        private static readonly ILog NullableLog = new NullLog();

        private static ILog _log;

        /// <summary>
        /// 获取日志
        /// </summary>
        public static ILog Log
        {
            get { return _log ?? NullableLog; }
        }

        /// <summary>
        /// 注入日志模块
        /// </summary>
        /// <param name="log">日志模块</param>
        public static void InjectLog(ILog log)
        {
            _log = log;
        }

    }
}
