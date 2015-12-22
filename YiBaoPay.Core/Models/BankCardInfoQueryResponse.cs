using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 银行卡信息查询接口 返回参数
    /// </summary>
    public class BankCardInfoQueryResponse : BaseResponse
    {
        /// <summary>
        /// 卡号 原值返回
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 卡片类型
        /// 1：储蓄卡 2：信用卡 -1 未知银行卡
        /// </summary>
        public int CardType { get; set; }

        public ECardType GetCardType
        {
            get { return ((ECardType)this.CardType); }
        }

        /// <summary>
        /// 卡片类型
        /// </summary>
        public enum ECardType
        {
            /// <summary>
            /// 储蓄卡
            /// </summary>
            Debit = 1,
            /// <summary>
            /// 信用卡
            /// </summary>
            Credit = 2,
            /// <summary>
            /// 未知
            /// </summary>
            Unknown = -1
        }
    }
}
