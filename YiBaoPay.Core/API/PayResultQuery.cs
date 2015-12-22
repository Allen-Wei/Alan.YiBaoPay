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
    /// 支付结果查询
    /// </summary>
    public class PayResultQuery : BasePay<PayResultQueryRequest, PayResultQueryResponse>
    {
        public PayResultQuery()
            : base(ConfigUtil.Config.CurrentApiUrl.PayResultQuery, "GET")
        {
        }
    }
}
