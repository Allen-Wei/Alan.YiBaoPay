using System;
using YiBaoPay.Core;
using YiBaoPay.Core.Models;
using YiBaoPay.Core.Utils;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 确认支付异步回调 第三方支付(易宝支付)回调请求参数
    /// </summary>
    public class PayConfirmCallbackResponse : BaseResponse
    {
        /// <summary>
        /// 商户订单号
        /// 商户生成的唯一订单号，最长 50 位
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 易宝交易流水号
        /// </summary>
        public string YbOrderId { get; set; }

        /// <summary>
        /// 交易金额 以"分"为单位的整型
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 最长 50 位，商户生成的用户唯一标识
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// 卡号前 6 位
        /// </summary>
        public string Card_Top { get; set; }

        /// <summary>
        /// 卡号后 4 位
        /// </summary>
        public string Card_Last { get; set; }

        /// <summary>
        /// 支付状态 
        /// 0: 失败 1: 成功
        /// </summary>
        public int Status { get; set; }


        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }

        public static PayConfirmCallbackResponse Get(string jsonResponse)
        {
            var serverRep = jsonResponse.UtilParseJson<ServerResponse>();
            var payResponse = serverRep.ToResponse<PayConfirmCallbackResponse>();
            return payResponse;
        }

        public static PayConfirmCallbackResponse Get(System.Web.HttpRequest req)
        {
            using (StreamReader reader = new StreamReader(req.InputStream))
            {
                var json = reader.ReadToEnd();
                return Get(json);
            }
        }

        public static PayConfirmCallbackResponse Get(System.Web.HttpRequestBase req)
        {
            using (StreamReader reader = new StreamReader(req.InputStream))
            {
                var json = reader.ReadToEnd();
                return Get(json);
            }
        }
    }
}
