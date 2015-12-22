using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 确定绑卡请求参数
    /// </summary>
    public class BindBankCardConfirmRequest : BaseRequest, IBaseRequest<BindBankCardConfirmResponse>
    {
        /// <summary>
        /// 绑卡请求号
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        public string ValidateCode { get; set; }

        public  Tuple<bool, string, BindBankCardConfirmResponse> Send()
        {
            var bindBankConfirm = new BindBankCardConfirm();
            var svrRep = bindBankConfirm.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(BindBankCardConfirmResponse));
            var rep = bindBankConfirm.GetResponse();
            return Tuple.Create(true, "", rep);
        }
    }
}
