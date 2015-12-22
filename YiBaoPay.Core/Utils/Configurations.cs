using System;
using System.Text;
using System.Text.RegularExpressions;

using System.Security;
using System.Security.Cryptography;
using System.Web.Script.Serialization;

namespace YiBaoPay.Core.Utils
{
    /// <summary>
    /// 获取配置实用方法
    /// </summary>
    public static class ConfigUtil
    {
        private static Configurations _config;

        /// <summary>
        /// 初始化变量
        /// </summary>
        /// <param name="devMode"></param>
        public static void Initial(bool devMode)
        {
            Refresh();
            Config.IsDevelopMode = devMode;
        }


        /// <summary>
        /// 配置实体
        /// </summary>
        internal static Configurations Config { get { if (_config == null) { Refresh(); } return _config; } }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string ConfigPath
        {
            get
            {
                var configPath = System.Configuration.ConfigurationManager.AppSettings["YiBaoConfigPath"];
                configPath = String.IsNullOrWhiteSpace(configPath) ? "~/App_Data/config.bin" : configPath;
                if (configPath.StartsWith("~/"))
                {
                    configPath = System.Web.Hosting.HostingEnvironment.MapPath(configPath);
                }
                return configPath;
            }
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        private static Configurations GetConfigurations()
        {
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            var fileFullPath = ConfigPath;
            if (!System.IO.File.Exists(fileFullPath))
            {
                throw new System.IO.IOException("Can't find configuration file.");
            }
            var configBase64 = System.IO.File.ReadAllText(fileFullPath);
            var strConfiguration = DecryptConfig(configBase64);

            strConfiguration = Regex.Replace(strConfiguration, @"/\*.+\*/", "", RegexOptions.Multiline);

            var config = serialize.Deserialize<Configurations>(strConfiguration);
            return config;
        }

        /// <summary>
        /// 刷新配置
        /// </summary>
        public static void Refresh()
        {
            _config = GetConfigurations();
        }


        #region 配置文件 加密/解密 处理
        private static readonly byte[] AesKey = Encoding.UTF8.GetBytes("6f59b43b c76e 41");

        private static string EncryptConfig(string jsonConfig)
        {
            var encryptedBytes = SecurityUtils.AesEncrypt(jsonConfig, AesKey);
            return Convert.ToBase64String(encryptedBytes);
        }

        private static string DecryptConfig(string configBase64)
        {
            var configBytes = Convert.FromBase64String(configBase64);
            var jsonConfig = SecurityUtils.AesDecrypt(configBytes, AesKey);
            return jsonConfig;
        }

        private static void ToEncryptedConfig(string jsonConfigFullPath, string outputConfigFullPath)
        {
            var jsonConfig = System.IO.File.ReadAllText(jsonConfigFullPath);
            var encryptedConfig = EncryptConfig(jsonConfig);
            System.IO.File.WriteAllText(outputConfigFullPath, encryptedConfig);
        }
        #endregion
    }

    /// <summary>
    /// 配置实体类
    /// </summary>
    internal class Configurations
    {
        private bool? ConfigDevelopMode
        {
            get
            {
                var mode = System.Configuration.ConfigurationManager.AppSettings["YiBaoPay-IsDevelopMode"];
                if (String.IsNullOrWhiteSpace(mode)) return null;
                return mode == "true";
            }
        }

        /// <summary>
        /// 开发者模式
        /// </summary>
        private bool _developMode;

        /// <summary>
        /// 是否是开发者模式
        /// </summary>
        public bool IsDevelopMode
        {
            get
            {
                return this.ConfigDevelopMode ?? this._developMode;
            }
            set { this._developMode = value; }
        }

        /// <summary>
        /// 当前环境使用的配置
        /// </summary>
        public YiBaoConfig CurrentConfig
        {
            get { return this.IsDevelopMode ? DevelopConfig : OnlineConfig; }
        }

        /// <summary>
        /// 开发环境下的配置
        /// </summary>
        public YiBaoConfig DevelopConfig { get; set; }

        /// <summary>
        /// 上线环境下的配置
        /// </summary>
        public YiBaoConfig OnlineConfig { get; set; }

        /// <summary>
        /// 当前环境使用的URL
        /// </summary>
        public ApiUrl CurrentApiUrl
        {
            get { return this.IsDevelopMode ? this.DevApiUrl : this.OnlineApiUrl; }
        }

        /// <summary>
        /// 开发时使用的接口地址
        /// </summary>
        public ApiUrl DevApiUrl { get; set; }

        /// <summary>
        /// 上线的接口地址
        /// </summary>
        public ApiUrl OnlineApiUrl { get; set; }



        #region Models

        /// <summary>
        /// 易宝密钥相关配置
        /// </summary>
        public class YiBaoConfig
        {
            /// <summary>
            /// 商户随机生成 AESKey,用于 AES 加密（长度为 16 位，可以用 26 个字母和数字组成）
            /// </summary>
            public string MerchantAesKey
            {
                get { return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16); }
            }
            /// <summary>
            /// 商户账户编号（如：YB01000000258），可从商户后台获取
            /// </summary>
            public string MerchantAccount { get; set; }
            /// <summary>
            /// 商户私钥，由商户用 RSA 算法生成，对应的公钥已在易宝商户后台报备
            /// </summary>
            public string MerchantPrivateKeyBase64 { get; set; }

            /// <summary>
            /// 商户公钥，由商户用 RSA 算法生成，该公钥已在易宝商户后台报备
            /// </summary>
            public string MerchantPublicKeyBase64 { get; set; }

            /// <summary>
            /// 易宝公钥，商户将自己的公钥在商户后台报备后获取的易宝支付分配的公钥
            /// </summary>
            public string YbPublicKeyBase64 { get; set; }
        }

        /// <summary>
        /// 接口URL
        /// </summary>
        public class ApiUrl
        {
            /// <summary>
            /// Java Demonstration
            /// </summary>
            public string JavaDemostration { get; set; }

            /// <summary>
            /// 绑定银行卡请求
            /// </summary>
            public string BindBankCardAsk { get; set; }

            /// <summary>
            /// 确认绑定银行卡
            /// </summary>
            public string BindBankCardConfirm { get; set; }

            /// <summary>
            /// 发送短信验证码接口
            /// </summary>
            public string SmsCaptcha { get; set; }

            /// <summary>
            /// 支付请求接口
            /// </summary>
            public string PayAsk { get; set; }

            /// <summary>
            /// 确认支付
            /// </summary>
            public string PayConfirm { get; set; }

            /// <summary>
            /// 确认支付 无需短信验证码
            /// </summary>
            //public string PayConfirmWithoutSms { get; set; }

            /// <summary>
            /// 支付结果查询
            /// </summary>
            public string PayResultQuery { get; set; }

            /// <summary>
            /// 提现
            /// </summary>
            public string Withdraw { get; set; }

            /// <summary>
            /// 提现查询
            /// </summary>
            public string WithdrawQuery { get; set; }

            /// <summary>
            /// 解绑卡接口
            /// </summary>
            public string UnbindBankCard { get; set; }

            /// <summary>
            /// 绑卡信息列表
            /// </summary>
            public string BindBankCardList { get; set; }

            /// <summary>
            /// 银行卡信息查询
            /// </summary>
            public string BankCardInfoQuery { get; set; }

            /// <summary>
            /// 可提现余额
            /// </summary>
            public string WithdrawAvaliableAmount { get; set; }
        }

        #endregion

        public string ToJson()
        {
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            var json = serialize.Serialize(this);
            return json;
        }

    }
}