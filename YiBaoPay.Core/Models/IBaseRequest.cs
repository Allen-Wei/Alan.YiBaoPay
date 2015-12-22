using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiBaoPay.Core.Models
{
    public interface IBaseRequest<TResponse>
 where TResponse : BaseResponse
    {
        Tuple<bool, string, TResponse> Send();
    }
}
