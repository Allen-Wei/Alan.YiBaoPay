using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.API
{
    /// <summary>
    /// 确认支付异步通知回报
    /// 易宝异步通知商户支付请求传过来的 callbackurl 地址,每 2 秒通知一次，共通知 3 次. 
    /// 商户收到通知后需要回写，需要返回字符串大写的”SUCCESS”，否则会一直通知多次。
    /// </summary>
    public class PayConfirmCallback
    {
    }
}
