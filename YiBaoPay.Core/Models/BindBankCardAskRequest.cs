using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 调用绑定银行卡请求参数
    /// </summary>
    public class BindBankCardAskRequest : BaseRequestIdentity, IBaseRequest<BindBankCardAskResponse>
    {

        /// <summary>
        /// 绑卡请求号
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string IdcardType { get { return "01"; } }
        /// <summary>
        /// 证件号
        /// </summary>
        public string IdcardNo { get; set; }
        /// <summary>
        /// 持卡人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 银行预留手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 用户注册手机号
        /// </summary>
        public string RegisterPhone { get; set; }
        /// <summary>
        /// 用户注册日期
        /// </summary>
        public string RegisterDate { get; set; }
        /// <summary>
        /// 用户注册ip
        /// </summary>
        public string RegisterIp { get; set; }
        /// <summary>
        /// 用户注册证件类型
        /// </summary>
        public string RegisterIdCardType { get; set; }
        /// <summary>
        /// 用户注册证件号
        /// </summary>
        public string RegisterIdCardNo { get; set; }
        /// <summary>
        /// 用户注册联系方式
        /// </summary>
        public string RegisterContact { get; set; }
        /// <summary>
        /// 用户使用的操作系统
        /// </summary>
        public string Os { get; set; }
        /// <summary>
        /// 设备唯一标示
        /// </summary>
        public string Imei { get; set; }
        /// <summary>
        /// 用户请求ip
        /// </summary>
        public string UserIp { get; set; }
        /// <summary>
        /// 用户使用的浏览器信息
        /// </summary>
        public string Ua { get; set; }

        public Tuple<bool, string, BindBankCardAskResponse> Send()
        {
            var api = new BindBankCardAsk();
            var svrRep = api.Send(this);
            if (!svrRep.IsSuccess) return Tuple.Create(false, svrRep.Error_Msg, default(BindBankCardAskResponse));
            var rep = api.GetResponse();
            if (String.IsNullOrWhiteSpace(rep.Error_Code))
            {
                return Tuple.Create(true, "", rep);
            }
            return Tuple.Create(false, rep.Error_Msg, rep);
        }
    }
}
