using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.API;

namespace YiBaoPay.Core.Models
{
    public class JavaDemoRequest : BaseRequest, IBaseRequest<JavaDemoResponse>
    {
        public  Tuple<bool, string, JavaDemoResponse> Send()
        {
            var api = new JavaDemonstration();
            var svrRep = api.Send(this);
            if (svrRep.IsSuccess)
            {
                return Tuple.Create(false, svrRep.Error_Msg, default(YiBaoPay.Core.Models.JavaDemoResponse));
            }
            JavaDemoResponse rep = api.GetResponse();
            return Tuple.Create(true, "", rep);
        }
     
    }
}
