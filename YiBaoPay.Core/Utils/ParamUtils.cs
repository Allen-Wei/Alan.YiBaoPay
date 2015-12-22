using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Web;
using System.Net;
using YiBaoPay.Core.Models;

namespace YiBaoPay.Core.Utils
{
    /// <summary>
    /// 参数实体类
    /// </summary>
    /// <typeparam name="TRequest">请求参数</typeparam>
    internal class ParamUtils<TRequest>
        where TRequest : Models.BaseRequest
    {

        private TRequest request;

        public ParamUtils(TRequest req)
        {
            this.request = req;
        }


        /// <summary>
        /// 获取排序后的参数
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, object> GetSortedParas()
        {
            if (request == null)
            {
                throw new Exception("Request Paramter is null");
            }
            var sort = new SortedDictionary<string, object>();
            this.request.GetType().GetProperties().ToList().ForEach(prop =>
            {
                var key = prop.Name;
                var value = prop.GetValue(this.request, null);
                var noSerialize = prop.CustomAttributes.Any(att => att.AttributeType == typeof(JsonNoSearializeAttribute));
                if (noSerialize) { return; }


                if (value != null)
                {
                    sort.Add(key, value.ToString());
                }
            });
            return sort;
        }

        /// <summary>
        /// 获取发送参数
        /// </summary>
        /// <returns></returns>
        public RequestParam GetReqParams()
        {
            /* 
             * Step 2: 业务请求参数按参数名排序（按照字母顺序排序,从 a-z）
             * Step 3: 排序后的业务请求参数值拼接成字符串
             */
            var values = this.ValuesToString();
            if (String.IsNullOrWhiteSpace(values))
            {
                throw new Exception("Parameters is empty.");
            }
            var valueBytes = Encoding.UTF8.GetBytes(values);

            // RSA 数据签名
            /*
             * Step 4: 根据 RAS 商户私有密钥签名业务请求参数值字符串（paramValue），生成基于 SHA1的 RSA 数字签名
             */
            var signBytes = SecurityUtils.SignData(valueBytes, ConfigUtil.Config.CurrentConfig.MerchantPrivateKeyBase64);
            /*
             * Step 5: 将签名合并到业务请求参数中, 并生成 JSON 格式字符串
             */
            var sign = Convert.ToBase64String(signBytes);
            this.request.Sign = sign;

            //AES 加密数据
            /*
             * Step6：随机生成单次请求加密密钥(merchantAesKey，长度为 16 位，可以用 26 个字母和数字组成)
             */
            var aesKeyText = ConfigUtil.Config.CurrentConfig.MerchantAesKey;
            var aesKey = Encoding.UTF8.GetBytes(aesKeyText);

            var json = this.ToJson();
            /*
             * Step 7: 通过 merchantAesKey 加密业务请求的 JSON 格式字符串（realdata），生成通信密文
             */
            var data = Convert.ToBase64String(SecurityUtils.AesEncrypt(json, aesKey));

            /*
             * Step 8: 将AES的密钥使用提供商的公钥加密
             */
            var encryptedAesKeyBytes = SecurityUtils.RsaEncrypt(aesKeyText, ConfigUtil.Config.CurrentConfig.YbPublicKeyBase64);
            var encryptedAesKey = Convert.ToBase64String(encryptedAesKeyBytes);

            var reqParams = new RequestParam()
            {
                data = data,
                encryptkey = encryptedAesKey,
                merchantaccount = ConfigUtil.Config.CurrentConfig.MerchantAccount
            };
            return reqParams;
        }


        /// <summary>
        /// 获取排序后的所有参数值字符
        /// </summary>
        /// <returns></returns>
        public string ValuesToString()
        {
            var sortedParams = this.GetSortedParas();
            var values = new StringBuilder();
            foreach (var para in sortedParams)
            {
                values.Append(para.Value);
            }
            return values.ToString();
        }

        public string ToJson()
        {
            var properties = new Dictionary<string, object>();
            this.request.GetType().GetProperties().OrderBy(prop => prop.Name).ToList().ForEach(prop =>
            {
                var name = prop.Name;
                var value = prop.GetValue(this.request, null);
                var noSerialize = prop.CustomAttributes.Any(att => att.AttributeType == typeof(JsonNoSearializeAttribute));
                if (noSerialize) { return; }

                if (value != null)
                {
                    properties.Add(name.ToLower(), value);
                }
            });

            return properties.UtilToJson();
        }
    }


    /// <summary>
    /// 接口请求实体
    /// </summary>
    internal class RequestParam
    {
        public string data { get; set; }
        public string encryptkey { get; set; }
        public string merchantaccount { get; set; }


        private static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }
    }

}
