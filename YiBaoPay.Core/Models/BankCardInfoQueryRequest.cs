using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 银行卡信息查询接口 请求参数
    /// </summary>
    public class BankCardInfoQueryRequest : BaseRequest, IBaseRequest<BankCardInfoQueryResponse>
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 发送银行卡查询
        /// </summary>
        /// <returns></returns>
        public  Tuple<bool, string, BankCardInfoQueryResponse> Send()
        {
            var api = new BankCardInfoQuery();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(BankCardInfoQueryResponse));
            var rep = api.GetResponse();
            return Tuple.Create(true, "", rep);
        }

     
    }
}
