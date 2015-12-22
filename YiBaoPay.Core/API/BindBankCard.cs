using System;
using YiBaoPay.Core.Models;
using YiBaoPay.Core.Utils;

namespace YiBaoPay.Core.API
{
    /// <summary>
    /// 绑定银行卡请求
    /// </summary>
    public class BindBankCardAsk : BasePay<BindBankCardAskRequest, BindBankCardAskResponse>
    {
        public BindBankCardAsk() : base(ConfigUtil.Config.CurrentApiUrl.BindBankCardAsk, "POST") { }
    }

    /// <summary>
    /// 确认绑定银行卡
    /// </summary>
    public class BindBankCardConfirm : BasePay<BindBankCardConfirmRequest, BindBankCardConfirmResponse>
    {
        public BindBankCardConfirm()
            : base(ConfigUtil.Config.CurrentApiUrl.BindBankCardConfirm, "POST")
        {
        }
    }
}
