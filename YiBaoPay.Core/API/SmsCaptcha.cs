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
    /// 发送短信校验码
    /// </summary>
    public class SmsCaptcha : BasePay<SmsCaptchaRequest, SmsCaptchaResponse>
    {
        public SmsCaptcha()
            : base(ConfigUtil.Config.CurrentApiUrl.SmsCaptcha, "POST")
        {
        }
    }
}
