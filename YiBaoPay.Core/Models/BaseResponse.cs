using System;
using System.Text;
using YiBaoPay.Core.Utils;

namespace YiBaoPay.Core.Models
{
    public abstract class BaseResponse
    {

        /// <summary>
        /// 商户账号编号
        /// </summary>
        public string MerchantAccount { get; set; }

        /// <summary>
        /// 易宝使用自己生成的 RSA 私钥对除参数 sign 以外的其他参数进行字母排序后串成的字符串进行签名
        /// </summary>
        public string Sign { get; set; }


        /// <summary>
        /// 错误代码
        /// </summary>
        public string Error_Code { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string Error_Msg { get; set; }
    }



}
