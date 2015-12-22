using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.Models;
using YiBaoPay.Core.Utils;

namespace YiBaoPay.Core.API
{
    public class Withdraw : BasePay<WithdrawRequest, WithdrawResponse>
    {
        public Withdraw() : base(ConfigUtil.Config.CurrentApiUrl.Withdraw, "POST")
        {
        }
    }
}
