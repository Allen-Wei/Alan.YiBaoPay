using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 发送短信验证码请求返回参数
    /// </summary>
    public class SmsCaptchaResponse : BaseResponse
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 短信发生时间
        /// </summary>
        public int SendTime { get; set; }
    }
}
