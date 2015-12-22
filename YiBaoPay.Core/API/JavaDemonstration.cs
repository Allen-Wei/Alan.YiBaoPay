using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiBaoPay.Core.Models;
using YiBaoPay.Core.Utils;

namespace YiBaoPay.Core.API
{
    public class JavaDemonstration : BasePay<JavaDemoRequest, JavaDemoResponse>
    {
        public JavaDemonstration() : base(ConfigUtil.Config.CurrentApiUrl.JavaDemostration, "GET") { }

    }
}
