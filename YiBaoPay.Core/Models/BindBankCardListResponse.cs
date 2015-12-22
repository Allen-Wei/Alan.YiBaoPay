using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 查询绑卡信息列表 返回参数
    /// </summary>
    public class BindBankCardListResponse : BaseResponse
    {

        /// <summary>
        /// 用户标识 原值返回
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// 用户标识类型
        /// </summary>
        public int IdentityType { get; set; }

        /// <summary>
        /// 获取用户标识类型
        /// </summary>
        [JsonNoSearialize]
        public Enumerations.IdentityType GetIdentityType
        {
            get
            {
                try
                {
                    return (Enumerations.IdentityType)this.IdentityType;
                }
                catch (Exception ex)
                {
                    LogSystem.LogInjection.Log.Error(String.Format("获取用户标识类型错误 {0}, Message: {1}", this.IdentityType, ex.Message), ex.StackTrace);
                    return Enumerations.IdentityType.UserPhone;
                }
            }
        }

        /// <summary>
        /// 绑卡列表
        /// </summary>
        public CardInfo[] CardList { get; set; }




        public class CardInfo
        {
            //{"bankcode":"ICBC","bindid":"5485509","bindvalidthru":1753957262,"card_last":"9458","card_name":"工商银行储蓄卡","card_top":"621226","merchantaccount":"10000419568","phone":"17701037274"}

            /// <summary>
            /// 绑卡 ID
            /// </summary>
            public string BindId { get; set; }

            /// <summary>
            /// 卡号前 6 位
            /// </summary>
            public string Card_Top { get; set; }

            /// <summary>
            /// 卡号后 4 位
            /// </summary>
            public string Card_Last { get; set; }

            /// <summary>
            /// 卡名称
            /// 例如 "中国银行信用卡"
            /// </summary>
            public string Card_Name { get; set; }

            /// <summary>
            /// 绑卡有效期
            /// 最后期限，时间戳，例如: 1361324896, 精确到秒
            /// </summary>
            public int BindValidthru { get; set; }

            /// <summary>
            /// 银行预留手机号
            /// 中间 4 位屏蔽, 例如"138****1234"
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// 银行缩写，如 ICBC
            /// </summary>
            public string BankCode { get; set; }

        }
    }
}
