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
    /// 请求支付
    /// </summary>
    public class PayAsk : BasePay<PayAskRequest, PayAskResponse>
    {
        public PayAsk() : base(ConfigUtil.Config.CurrentApiUrl.PayAsk, "POST")
        {
        }
    }
}
