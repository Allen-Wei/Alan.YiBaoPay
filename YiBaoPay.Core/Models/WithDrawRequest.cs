using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 提现请求参数
    /// </summary>
    public class WithdrawRequest : BaseRequestIdentityCard, IBaseRequest<WithdrawResponse>
    {
        /// <summary>
        /// 商户请求号
        /// 商户生成的唯一提现订单号， 最长 50 位
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 提现金额 分为单位
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public int Currency { get { return 156; } }
        /// <summary>
        /// 提现类型
        /// NATRALDAY_NORMAL (自然日 t+1)
        /// NATRALDAY_URGENT (自然日 t+0)
        /// </summary>
        public string DrawType { get; set; }

        /// <summary>
        /// 设备唯一标识
        /// </summary>
        public string Imei { get; set; }
        /// <summary>
        /// 用户请求Ip
        /// </summary>
        public string UserIp { get; set; }
        /// <summary>
        /// 用户使用的浏览器信息
        /// </summary>
        public string Ua { get; set; }

        public Tuple<bool, string, WithdrawResponse> Send()
        {
            var api = new Withdraw();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(WithdrawResponse));
            var rep = api.GetResponse();
            return Tuple.Create(true, "", rep);

        }
    }
}
