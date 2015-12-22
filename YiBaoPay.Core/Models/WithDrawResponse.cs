using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 提现返回参数
    /// </summary>
    public class WithdrawResponse : BaseResponse
    {
        /// <summary>
        /// 商户请求号
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 易宝流水号
        /// </summary>
        public string YbDrawFlowId { get; set; }
        /// <summary>
        /// 提现金额 以分为单位
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 卡号前6位
        /// </summary>
        public string Card_Top { get; set; }
        /// <summary>
        /// 卡号后4位
        /// </summary>
        public string Card_Last { get; set; }
        /// <summary>
        /// 提现请求状态
        /// FAILURE：请求失败 SUCCESS：请求成功 UNKNOW:未知
        /// </summary>
        public string Status { get; set; }
    }
}
