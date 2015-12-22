using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Utils
{
    /// <summary>
    /// 网络请求的静态方法
    /// </summary>
    internal static class NetUtils
    {
        /// <summary>
        /// POST请求
        /// </summary>
        /// <typeparam name="TRequest">请求参数类型</typeparam>
        /// <typeparam name="TResponse">相应数据类型</typeparam>
        /// <param name="url">请求的URL</param>
        /// <param name="request">发送的数据</param>
        /// <param name="contentType">Content-Type</param>
        /// <returns></returns>
        public static TResponse PostRequest<TRequest, TResponse>(string url, TRequest request, string contentType = "application/x-www-form-urlencoded")
            where TRequest : Models.BaseRequest
            where TResponse : class
        {
            if (String.IsNullOrWhiteSpace(contentType)) { contentType = "application/x-www-form-urlencoded"; }

            ParamUtils<TRequest> paraUtils = new ParamUtils<TRequest>(request);
            var reqParam = paraUtils.GetReqParams();

            var data = Encoding.UTF8.GetBytes(reqParam.UtilToKeyValues(WebUtility.UrlEncode));

            var result = BaseRequest(url, "POST", data, beforeRequest: req => { req.ContentType = contentType; });

            if (result == null) throw new Exception("Can't get resposne result.");

            var json = Encoding.UTF8.GetString(result);
            return json.UtilParseJson<TResponse>();
        }

        /// <summary>
        /// GET请求
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static TResponse GetRequest<TRequest, TResponse>(string url, TRequest request)
            where TRequest : Models.BaseRequest
            where TResponse : class
        {
            string contentType = "application/x-www-form-urlencoded";

            ParamUtils<TRequest> paraUtils = new ParamUtils<TRequest>(request);
            var reqParam = paraUtils.GetReqParams();
            var fullUrl = String.Format("{0}?{1}", url, reqParam.UtilToKeyValues(WebUtility.UrlEncode));

            var result = BaseRequest(fullUrl, "GET", new byte[] { }, beforeRequest: req => { req.ContentType = contentType; });

            if (result == null) throw new Exception("Can't get resposne result.");

            var json = Encoding.UTF8.GetString(result);
            return json.UtilParseJson<TResponse>();
        }

        /// <summary>
        /// GET请求
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static TResponse GetRequest<TResponse>(string url)
            where TResponse : class
        {
            var result = BaseRequest(url, "GET", null, null);
            if (result == null) throw new Exception("Can't get resposne result.");

            var json = Encoding.UTF8.GetString(result);
            return json.UtilParseJson<TResponse>();
        }

        /// <summary>
        /// Web请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        /// <param name="beforeRequest"></param>
        /// <returns></returns>
        public static byte[] BaseRequest(string url, string method, byte[] data, Action<HttpWebRequest> beforeRequest)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = method;
            req.ContentType = "application/json";
            if (beforeRequest != null) beforeRequest(req);

            if (data != null && method.ToUpper() != "GET")
            {
                using (var writer = (req.GetRequestStream()))
                {
                    writer.Write(data, 0, data.Length);
                }
            }

            var response = req.GetResponse();
            var stream = response.GetResponseStream();
            if (stream == null)
            {
                throw new Exception(String.Format("Can't get response stream when request {0}.", url));
            }
            var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();
            var buffer = Encoding.UTF8.GetBytes(result);
            reader.Dispose();
            stream.Dispose();
            return buffer;
        }


        /// <summary>
        /// 序列化成JSON
        /// </summary>
        /// <param name="obj">带序列化的实体</param>
        /// <returns></returns>
        public static string UtilToJson(this object obj)
        {
            var serialize = new JavaScriptSerializer();
            return serialize.Serialize(obj);
        }

        /// <summary>
        /// 序列化成键值对
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="encode">编码方式</param>
        /// <returns></returns>
        public static string UtilToKeyValues(this object obj, Func<string, string> encode)
        {
            var values = new StringBuilder();
            obj.GetType().GetProperties().ToList().ForEach(prop =>
            {
                var name = prop.Name;
                var value = prop.GetValue(obj, null);
                values.AppendFormat("{0}={1}&", name, encode(value.ToString()));
            });
            values.Remove(values.Length - 1, 1);
            return values.ToString();
        }



        /// <summary>
        /// JSON反序列化
        /// </summary>
        /// <typeparam name="T">反序列化返回后的类型</typeparam>
        /// <param name="json">待反序列化的JSON</param>
        /// <returns></returns>
        public static T UtilParseJson<T>(this string json)
            where T : class
        {
            var serialize = new JavaScriptSerializer();
            return serialize.Deserialize<T>(json);
        }
    }
}
