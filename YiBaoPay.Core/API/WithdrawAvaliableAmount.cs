using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.Models;
using YiBaoPay.Core.Utils;

namespace YiBaoPay.Core.API
{
    /// <summary>
    /// 可提现余额接口
    /// </summary>
    public class WithdrawAvaliableAmount : BasePay<WithdrawAvaliableAmountRequest, WithdrawAvaliableAmountResponse>
    {
        public WithdrawAvaliableAmount()
            : base(ConfigUtil.Config.CurrentApiUrl.WithdrawAvaliableAmount, "GET")
        {
        }
    }
}
