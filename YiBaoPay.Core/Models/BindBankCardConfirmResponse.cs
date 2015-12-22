using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 确认绑卡返回参数
    /// </summary>
    public class BindBankCardConfirmResponse : BaseResponse
    {
        /// <summary>
        /// 绑卡请求号 原样返回商户所传
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 银行编码
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 卡号前6位
        /// </summary>
        public string Card_Top { get; set; }
        /// <summary>
        /// 卡号候4位
        /// </summary>
        public string Card_Last { get; set; }
    }
}
