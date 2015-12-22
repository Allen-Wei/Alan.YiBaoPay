using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 可提现余额接口 请求参数
    /// </summary>
    public class WithdrawAvaliableAmountRequest : BaseRequest, IBaseRequest<WithdrawAvaliableAmountResponse>
    {

        public  Tuple<bool, string, WithdrawAvaliableAmountResponse> Send()
        {
            var api = new WithdrawAvaliableAmount();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(WithdrawAvaliableAmountResponse));
            var response = api.GetResponse();
            return Tuple.Create(true, "", response);
        }
    }
}
