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
    /// 银行卡信息查询
    /// 此接口可以用来根据用户输入的银行卡号查询银行卡的借贷类型、银行名称等信息
    /// </summary>
    public class BankCardInfoQuery : BasePay<BankCardInfoQueryRequest, BankCardInfoQueryResponse>
    {
        public BankCardInfoQuery()
            : base(ConfigUtil.Config.CurrentApiUrl.BankCardInfoQuery, "POST")
        {
        }
    }
}
