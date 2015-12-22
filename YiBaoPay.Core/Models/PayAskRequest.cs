using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 支付请求参数
    /// </summary>
    public class PayAskRequest : BaseRequestIdentityCard, IBaseRequest<PayAskResponse>
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public long TransTime { get; set; }
        /// <summary>
        /// 交易币种 (默认 156 人民币 (当前仅支持人民币)
        /// </summary>
        public int Currency { get { return 156; } }
        /// <summary>
        /// 交易金额
        /// </summary>
        public int Amount { get; set; }

        public string _productName;

        /// <summary>
        /// 商品名称 (最长50位)
        /// </summary>
        public string ProductName
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(this._productName) && this._productName.Length > 50)
                {
                    return this._productName.Substring(0, 50);
                }
                return this._productName;
            }
            set { this._productName = value; }
        }

        private string _productDesc;

        /// <summary>
        /// 商品描述 (最长 200 位)
        /// </summary>
        public string ProductDesc
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(this._productDesc) && this._productDesc.Length > 200)
                {
                    return this._productDesc.Substring(0, 200);
                }
                return _productDesc;
            }
            set { this._productDesc = value; }
        }

        /// <summary>
        /// 订单有效期
        /// </summary>
        [JsonNoSearialize]
        public TimeSpan OrderExpireDate { get; set; }

        /// <summary>
        /// 订单有效期
        /// 单位:分钟, 例如:60, 表示订单有效期为 60 分钟
        /// </summary>
        public int OrderExpDate { get { return OrderExpireDate.Minutes; } }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 设备唯一标识
        /// </summary>
        public string Imei { get; set; }

        /// <summary>
        /// 用户请求ip
        /// </summary>
        public string UserIp { get; set; }
        /// <summary>
        /// 用户使用的浏览器信息
        /// </summary>
        public string Ua { get; set; }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <returns></returns>
        public Tuple<bool, string, PayAskResponse> Send()
        {
            var api = new PayAsk();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(PayAskResponse));
            var rep = api.GetResponse();
            if (String.IsNullOrWhiteSpace(rep.Error_Code))
            {
                return Tuple.Create(true, "", rep);
            }
            return Tuple.Create(false, rep.Error_Msg, rep);
        }
    }
}
