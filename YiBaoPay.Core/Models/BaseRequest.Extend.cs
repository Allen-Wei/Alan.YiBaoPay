using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    /// <summary>
    /// 拥有IdentityId和IdentityType字段
    /// </summary>
    public class BaseRequestIdentity : BaseRequest
    {
        /// <summary>
        /// 用户标识 原值返回
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// 用户标识类型
        /// </summary>
        private int _identityType = (int)Enumerations.IdentityType.UserIdCard;

        /// <summary>
        /// 用户标识类型
        /// </summary>
        public int IdentityType
        {
            get { return _identityType; }
        }

        /// <summary>
        /// 设置 用户标识类型 IdentityType
        /// </summary>
        /// <param name="newIdType"></param>
        public void SetIdentityType(Enumerations.IdentityType newIdType)
        {
            this._identityType = (int)newIdType;
        }
    }

    /// <summary>
    /// IdentityId, IdentityType, Card_Top, Card_Last
    /// </summary>
    public class BaseRequestIdentityCard : BaseRequestIdentity
    {

        /// <summary>
        /// 卡号前6位 
        /// </summary>
        public string Card_Top { get; set; }
        /// <summary>
        /// 卡号后4位 
        /// </summary>
        public string Card_Last { get; set; }
    }
}
