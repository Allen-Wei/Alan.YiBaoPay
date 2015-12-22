using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 提现查询接口 请求参数
    /// </summary>
    public class WithdrawQueryRequest : BaseRequest, IBaseRequest<WithdrawQueryResponse>
    {
        /// <summary>
        /// 商户请求号
        /// 商户生成的唯一提现订单号， 最长 50 位；商户订单号和易宝交易流水号不 可同时为空，都不为空时以易宝交易流水号为准。
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 易宝流水号
        /// </summary>
        public string YbDrawFlowId { get; set; }

        public  Tuple<bool, string, WithdrawQueryResponse> Send()
        {
            var api = new WithdrawQuery();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(WithdrawQueryResponse));
            var rep = api.GetResponse();
            return Tuple.Create(true, "", rep);
        }
    }
}
