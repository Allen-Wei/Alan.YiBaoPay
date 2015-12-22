using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Utils
{
    /// <summary>
    /// 实用类
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetNowTimeStamp()
        {
            return GetTimeStamp(DateTime.UtcNow);
        }

        /// <summary>
        /// 获取time的时间戳
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime time)
        {
            var timeStamp = new DateTime(1970, 1, 1);
            return (int)(time - timeStamp).TotalSeconds;
        }
    }
}
