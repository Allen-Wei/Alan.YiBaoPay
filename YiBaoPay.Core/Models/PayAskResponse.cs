using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 支付请求返回参数
    /// </summary>
    public class PayAskResponse : BaseResponse
    {
        /// <summary>
        /// 商户订单号
        /// 原样返回商户所传
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 短信确认
        /// 0：建议不需要进行短信校验 1：建议需要进行短信校验
        /// </summary>
        public int SmsConfirm { get; set; }

        /// <summary>
        ///短信验证码发送方 
        /// YEEPAY：易宝发送 BANK：银行发送
        /// </summary>
        public string CodeSender { get; set; }
    }
}
