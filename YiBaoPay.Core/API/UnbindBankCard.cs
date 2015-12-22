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
    /// 解绑卡接口
    /// 该接口用于卡信息(如银行预留手机号)变更后的解绑使用, 解绑后只能绑定原卡, 不可换卡绑定.
    /// </summary>
    public class UnbindBankCard : BasePay<UnbindBankCardRequest, UnbindBankCardResponse>
    {
        public UnbindBankCard()
            : base(ConfigUtil.Config.CurrentApiUrl.UnbindBankCard, "POST")
        {
        }
    }
}
