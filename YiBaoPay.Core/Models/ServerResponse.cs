using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.Utils;

namespace YiBaoPay.Core.Models
{

    public class ServerResponse
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string EncryptKey { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get { return this.Error_Code == null || this.Error_Code == "200"; }
        }
        /// <summary>
        /// 错误代码
        /// </summary>
        public string Error_Code { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string Error_Msg { get; set; }

        public TResposne ToResponse<TResposne>() where TResposne : BaseResponse
        {
            if (this.Data == null)
            {
                LogSystem.LogInjection.Log.Error("获取返回会结果时Data为null", String.Format("ServerResponse.ToResponse<{0}>", typeof(TResposne).FullName));
                //TODO throw new Exception("Data不能为null(没有数据).");
                return default(TResposne);
            }

            var dataBytes = Convert.FromBase64String(this.Data);

            //AES密钥
            /* 
             * Step 11: 用 RSA 解密接口返回的密钥密文 encryptkey，获取 ybAesKey
             */
            var encryptedKeyBytes = Convert.FromBase64String(this.EncryptKey);
            var aesKey = SecurityUtils.RsaDecrypt(encryptedKeyBytes, ConfigUtil.Config.CurrentConfig.MerchantPrivateKeyBase64);

            //AES解密后的对象
            /*
             * Step12：用 ybAesKey 将接口返回的业务密文 data 解密
             */
            var response = SecurityUtils.AesDecrypt(dataBytes, Encoding.UTF8.GetBytes(aesKey));
            return response.UtilParseJson<TResposne>();
        }

    }

}
