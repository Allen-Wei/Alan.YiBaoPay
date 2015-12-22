using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 确认支付请求参数
    /// </summary>
    public class PayConfirmRequest : BaseRequest, IBaseRequest<PayConfirmResponse>
    {
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 短信校验码
        /// 测试环境下不会真实发送短信验证码, 默认为 123456.
        /// </summary>
        public string ValidateCode { get; set; }

        public  Tuple<bool, string, PayConfirmResponse> Send()
        {
            var api = new PayConfirm();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(PayConfirmResponse));
            var rep = api.GetResponse();
            return Tuple.Create(true, "", rep);

            throw new NotImplementedException();
        }
    }
}
