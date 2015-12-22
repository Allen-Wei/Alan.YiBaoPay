using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.Models;

namespace YiBaoPay.Core.API
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IPay<in TRequest, out TResponse>
        where TRequest : BaseRequest
        where TResponse: class
    {
        TResponse Send(TRequest request);
    }
}
