using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 解绑卡接口 返回参数
    /// </summary>
    public class UnbindBankCardResponse : BaseResponse
    {
        /// <summary>
        /// 绑卡 ID 原值返回
        /// </summary>
        public string BindId { get; set; }

        /// <summary>
        /// 用户标识 原值返回
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// 用户标识类型
        /// </summary>
        public int IdentityType { get; set; }
    }
}
