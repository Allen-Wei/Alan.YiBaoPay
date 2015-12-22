using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 查询绑卡信息列表 请求参数
    /// </summary>
    public class BindBankCardListRequest : BaseRequestIdentity, IBaseRequest<BindBankCardListResponse>
    {

        public Tuple<bool, string, BindBankCardListResponse> Send()
        {
            var api = new BindBankCardList();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(BindBankCardListResponse));
            var rep = api.GetResponse();
            return Tuple.Create(true, "", rep);
        }
    }
}
