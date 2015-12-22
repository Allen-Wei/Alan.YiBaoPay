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
    /// 查询绑卡信息列表
    /// 查询用户的绑卡信息时调用，只返回未过绑卡有效期且未被解绑的绑卡信息。
    /// </summary>
    public class BindBankCardList : BasePay<BindBankCardListRequest, BindBankCardListResponse>
    {
        public BindBankCardList() : base(ConfigUtil.Config.CurrentApiUrl.BindBankCardList, "GET")
        {
        }
    }
}
