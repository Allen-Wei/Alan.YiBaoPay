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
    /// 无需短验的确认支付
    /// </summary>
    public class PayWithoutSms : BasePay<PayWithoutSmsRequest, PayWithoutSmsResponse>
    {
        public PayWithoutSms()
            : base(ConfigUtil.Config.CurrentApiUrl.PayConfirmWithoutSms, "POST")
        {
        }
    }
}
