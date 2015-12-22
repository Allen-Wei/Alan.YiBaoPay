using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 支付结果查询 返回参数
    /// </summary>
    public class PayResultQueryResponse : BaseResponse
    {
        /// <summary>
        /// 客户订单号 
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 易宝交易流水号
        /// </summary>
        public string YbOrderId { get; set; }

        /// <summary>
        /// 支付金额 以"分"为单位的整型
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 绑卡 ID
        /// </summary>
        public string BindId { get; set; }

        /// <summary>
        /// 绑卡有效期 
        /// 最后期限, 时间戳, 例如: 1361324896, 精确到秒
        /// </summary>
        public int BindValidthru { get; set; }

        /// <summary>
        /// 银行信息
        /// 支付卡所属银行的名称
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 银行缩写
        /// 银行缩写, 如 ICBC
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 支付时间
        /// 返回支付时间为， 交易变成当前状态的时间： closetime
        /// </summary>
        public int CloseTime { get; set; }

        /// <summary>
        /// 银行卡类型
        /// 1：储蓄卡 2：信用卡
        /// </summary>
        public int BankCardType { get; set; }

        /// <summary>
        /// 卡号后 4 位
        /// 支付卡卡号后 4 位
        /// </summary>
        public string LastNo { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// 用户标识类型
        /// </summary>
        public int IdentityType { get; set; }

        /// <summary>
        /// 支付状态
        /// 0：失败 1：成功 2：未处理 3：处理中 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 获取可读的支付状态
        /// </summary>
        [JsonNoSearialize]
        public Enumerations.PayStatus GetStatus
        {
            get
            {
                try
                {
                    return (Enumerations.PayStatus)Status;
                }
                catch (Exception ex)
                {
                    LogSystem.LogInjection.Log.Error("支付状态获取失败 " + this.Status, ex.StackTrace);
                    return Enumerations.PayStatus.Undefined;
                }
            }
        }

        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }


    }
}
