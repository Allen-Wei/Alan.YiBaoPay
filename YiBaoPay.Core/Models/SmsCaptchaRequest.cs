using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 发送短信验证码请求参数
    /// </summary>
    public class SmsCaptchaRequest : BaseRequest, IBaseRequest<SmsCaptchaResponse>
    {
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string OrderId { get; set; }

        public  Tuple<bool, string, SmsCaptchaResponse> Send()
        {
            var api = new SmsCaptcha();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) Tuple.Create(false, svrRep.Error_Msg, default(SmsCaptchaResponse));
            var rep = api.GetResponse();
            return Tuple.Create(true, "", rep);
        }
    }
}
