using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 确认支付返回参数
    /// 
    /// 通过短信校验码方式确认支付，该接口为异步接口，支付结果将异步发送给支付请求时提供的回调地址.
    /// 注：此接口成功状态的返回, 只是调用此接口成功, 具体的支付结果将异步发送给支付请求时提供的回调地址.
    /// 商户在调用支付请求接口后, 可以直接调用确认支付接口完成支付(直接调用确认支付接口时, validatecode 参数不传值，或者传空).
    /// 商户在调用支付请求接口后, 如果易宝支付返回建议进行短信校验, 那么可以调用短信验证码发送接口给用户发送短信验证码, 然后让用户在商户的交互解密输入接收到的短信验证码, 最后调用本确认支付接口完成支付.
    /// 调用确认支付接口时, 如果短信验证码错误, 那么该接口会同步返回验证码错误提示, 商户可以让用户在交互界面重新输入短信验证码, 或者重新调用短信发送接口给用户发送新的验证码
    /// (注: 每笔订单最多支持发送 5 次短信验证码, 同一笔订单调用发送短信验证码间隔需≥50s, 短信验证码为 6 位随机数字, 同一笔订单最多有 5 次失败校验)
    /// 调用确认支付结果成功后, 支付结果不管成功还是失败都会回调, 若想确认该笔订单是否成功可调用 交易记录查询接口
    /// </summary>
    public class PayConfirmResponse : BaseResponse
    {
        /// <summary>
        /// 商户订单号
        /// 原样返回商户所传
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 易宝交易流水号
        /// </summary>
        public string YbOrderId { get; set; }

        /// <summary>
        /// 交易金额 以分为单位
        /// </summary>
        public int Amount { get; set; }

    }
}
