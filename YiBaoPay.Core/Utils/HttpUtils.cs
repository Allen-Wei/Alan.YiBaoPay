using System;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using YiBaoPay.Core.Models;

namespace YiBaoPay.Core.Utils
{
    /// <summary>
    /// 接口请求实体类
    /// </summary>
    /// <typeparam name="TRequest">接口请求参数类型</typeparam>
    internal class HttpUtils<TRequest>
        where TRequest : YiBaoPay.Core.Models.BaseRequest
    {
        /// <summary>
        /// URL
        /// </summary>
        private string url;
        private string httpMethod;

        /// <summary>
        /// 初始化URL
        /// </summary>
        /// <param name="u">接口URL</param>
        /// <param name="m">HttpMethod</param>
        public HttpUtils(string u, string m)
        {
            this.url = u;
            this.httpMethod = m;
        }

        /// <summary>
        /// 发送网络请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ServerResponse Send(TRequest request)
        {

            if (this.httpMethod.ToLower() == "post")
            {
                return NetUtils.PostRequest<TRequest, ServerResponse>(this.url, request);
            }
            return NetUtils.GetRequest<TRequest, ServerResponse>(this.url, request);
        }



    }
}
