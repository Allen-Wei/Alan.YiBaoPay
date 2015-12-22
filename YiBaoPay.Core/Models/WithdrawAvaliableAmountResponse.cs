using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 可提现余额接口 返回参数
    /// </summary>
    public class WithdrawAvaliableAmountResponse : BaseResponse
    {
        /// <summary>
        /// 可提现余额 单位为分
        /// </summary>
        public int ValidAmount { get; set; }
    }
}
