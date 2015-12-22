using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 解绑卡接口 请求参数
    /// </summary>
    public class UnbindBankCardRequest :BaseRequestIdentity, IBaseRequest<UnbindBankCardResponse>
    {

        /// <summary>
        /// 绑卡 ID
        /// </summary>
        public string BindId { get; set; }


        public  Tuple<bool, string, UnbindBankCardResponse> Send()
        {
            var api = new UnbindBankCard();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(UnbindBankCardResponse));
            var rep = api.GetResponse();
            return Tuple.Create(true, "", rep);
        }
    }
}
