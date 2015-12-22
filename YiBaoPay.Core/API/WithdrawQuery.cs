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
    /// 提现查询
    /// </summary>
    public class WithdrawQuery:BasePay<WithdrawQueryRequest, WithdrawQueryResponse>
    {
        public WithdrawQuery() : base(ConfigUtil.Config.CurrentApiUrl.WithdrawQuery, "GET")
        {
        }
    }
}
