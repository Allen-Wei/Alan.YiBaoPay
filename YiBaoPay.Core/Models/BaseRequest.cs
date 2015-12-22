using System;
using YiBaoPay.Core.Utils;

namespace YiBaoPay.Core.Models
{
    public abstract class BaseRequest 
    {

        private string _merchantAccount;
        /// <summary>
        /// 商户编号
        /// </summary>
        public string MerchantAccount
        {
            get
            {
                return String.IsNullOrWhiteSpace(this._merchantAccount) ? ConfigUtil.Config.CurrentConfig.MerchantAccount : this._merchantAccount;
            }
            set { this._merchantAccount = value; }
        }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }

    }
}
