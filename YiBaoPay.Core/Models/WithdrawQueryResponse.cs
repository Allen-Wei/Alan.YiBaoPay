using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 提现查询接口 返回参数
    /// </summary>
    public class WithdrawQueryResponse : BaseResponse
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
        /// 卡号前 6 位
        /// </summary>
        public string Card_Top { get; set; }

        /// <summary>
        /// 卡号后 4 位
        /// </summary>
        public string Card_Last { get; set; }

        /// <summary>
        /// 提现状态
        /// </summary>
        public Enumerations.WithdrawStatus Status { get; set; }



    }
}
