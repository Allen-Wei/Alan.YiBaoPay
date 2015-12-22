using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 调用绑定银行卡返回参数
    /// </summary>
    public class BindBankCardAskResponse : BaseResponse
    {

        /// <summary>
        /// 绑卡请求号
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 短信验证码发送方
        /// </summary>
        public string CodeSender { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        public string SmsCode { get; set; }
    }
}
