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
    /// 确认支付
    /// </summary>
    public class PayConfirm : BasePay<PayConfirmRequest, PayConfirmResponse>
    {
        public PayConfirm() : base(ConfigUtil.Config.CurrentApiUrl.PayConfirm, "POST")
        {
        }
    }
}
