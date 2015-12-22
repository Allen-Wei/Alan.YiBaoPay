using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 枚举定义
    /// </summary>
    public class Enumerations
    {
        /// <summary>
        /// 支付状态
        /// </summary>
        public enum PayStatus
        {
            /// <summary>
            /// 未定义
            /// </summary>
            Undefined = -1,
            /// <summary>
            /// 支付失败
            /// </summary>
            Fail = 0,
            /// <summary>
            /// 支付成功
            /// </summary>
            Success = 1,
            /// <summary>
            /// 未处理
            /// </summary>
            UnHandle = 2,
            /// <summary>
            /// 处理中
            /// </summary>
            Handling = 3
        }


        /// <summary>
        /// 用户表示类型
        /// </summary>
        public enum IdentityType
        {
            /// <summary>
            /// IMEI
            /// </summary>
            Imei = 0,
            /// <summary>
            /// MAC地址
            /// </summary>
            MacAddress = 1,
            /// <summary>
            /// 用户ID
            /// </summary>
            UserId = 2,
            /// <summary>
            /// 用户邮件
            /// </summary>
            UserEmail = 3,
            /// <summary>
            /// 用户手机号
            /// </summary>
            UserPhone = 4,
            /// <summary>
            /// 用户手机号
            /// </summary>
            UserIdCard = 5,
            /// <summary>
            /// 用户纸质订单协议号
            /// </summary>
            UserPaperProtocol = 6
        }


        /// <summary>
        /// 提现查询 返回状态
        /// </summary>
        public enum WithdrawStatus
        {
            /// <summary>
            /// 处理中
            /// </summary>
            Doing,
            /// <summary>
            /// 提现失败
            /// </summary>
            Failure,
            /// <summary>
            /// 提现退回
            /// </summary>
            Refund,
            /// <summary>
            /// 提现成功
            /// </summary>
            Success,
            /// <summary>
            /// 未知
            /// </summary>
            Unknow
        }
    }
}
