using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.LogSystem
{
    /// <summary>
    /// 日志模块接口
    /// </summary>
    public interface ILog
    {

        /// <summary>
        /// 信息日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="position"></param>
        void Info(string message, string position);

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="position"></param>
        void Error(string message, string position);

    }
}
