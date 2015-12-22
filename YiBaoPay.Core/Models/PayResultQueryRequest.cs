using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 支付结果查询 请求参数
    /// </summary>
    public class PayResultQueryRequest : BaseRequest, IBaseRequest<PayResultQueryResponse>
    {
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string OrderId { get; set; }

        public Tuple<bool, string, PayResultQueryResponse> Send()
        {
            var api = new PayResultQuery();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(PayResultQueryResponse));
            var rep = api.GetResponse();
            return Tuple.Create(true, "", rep);
        }
    }
}
