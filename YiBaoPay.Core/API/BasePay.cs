using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.Models;
using YiBaoPay.Core.Utils;

namespace YiBaoPay.Core.API
{
    /// <summary>
    /// 支付相关基类
    /// </summary>
    /// <typeparam name="TReqeust">请求参数类型</typeparam>
    /// <typeparam name="TResponse">返回参数类型</typeparam>
    public class BasePay<TReqeust, TResponse> : IPay<TReqeust, ServerResponse>
        where TReqeust : BaseRequest
        where TResponse : BaseResponse
    {
        private ServerResponse _serverResponse;

        protected string Url;
        protected string Method;


        private BasePay() { }
        public BasePay(string url, string method)
        {
            this.Url = url;
            this.Method = method;
        }
        public TResponse GetResponse()
        {
            return this._serverResponse.ToResponse<TResponse>();
        }

        public ServerResponse Send(TReqeust request)
        {
            var http = new HttpUtils<TReqeust>(this.Url, this.Method);
            //TODO Hash校验数据有效性
            this._serverResponse = http.Send(request);
            return this._serverResponse;
        }
    }
}
