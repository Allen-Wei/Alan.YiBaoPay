using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 无需短验确认支付返回参数
    /// </summary>
    public class PayWithoutSmsResponse : BaseResponse
    {

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 易宝交易流水号
        /// </summary>
        public string YbOrderId { get; set; }

        /// <summary>
        /// 交易金额 以分为单位
        /// </summary>
        public int Amount { get; set; }

    }
}
