using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using YiBaoPay.Core;
using YiBaoPay.Core.Utils;
using YiBaoPay.Core.Models;
using YiBaoPay.Core.API;


namespace YiBaoPay.Test
{
    class Program
    {
        private static void Main(string[] args)
        {


            //提现余额查询
            WithdrawAvaliableAmountRequest withDrawAvaliableReq = new WithdrawAvaliableAmountRequest();
            //var withdrawRep = withDrawAvaliableReq.Send();


            //银行卡信息查询
            //方法 1
            BankCardInfoQueryRequest bankQueryReq = new BankCardInfoQueryRequest() { CardNo = "6222020302051546216" };
            BankCardInfoQuery query = new BankCardInfoQuery();
            var serverResponse = query.Send(bankQueryReq);
            if (serverResponse.IsSuccess)
            {
                var bankQueryResponseResult = query.GetResponse();
            }

            var requestId = "hello, world.";

            //调用绑卡请求
            var bindBankCardReq = new BindBankCardAskRequest()
            {
                IdentityId = "weimingming",
                RequestId = requestId,
                CardNo = "6222020302051546216",
                IdcardNo = "341221198910173751",
                UserName = "韦明明",
                Phone = "13695580720",
                /*
                RegisterPhone = "13695580720",
                RegisterDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                RegisterIp = "127.0.0.1",
                RegisterIdCardType = "01",
                RegisterIdCardNo = "341221198910173751",
                RegisterContact = "13695580720",
                 * */
                Os = "Windows XP",
                Imei = "548512369587485",
                UserIp = "127.0.0.1",
                Ua = String.Format("请求1 {0}", DateTime.Now.ToShortTimeString())
            };

            //var bindBankCardRep = bindBankCardReq.Send();

            var bindBankCardConfirmReq = new BindBankCardConfirmRequest()
            {
                RequestId = requestId,
                ValidateCode = "616731"
            };
            //var bindBankCardConfirmRep = bindBankCardConfirmReq.Send();

            BindBankCardListRequest bindBandCardListRequest = new BindBankCardListRequest()
            {
                IdentityId = "weimingming",
            };
            //var bindBandCardListRep = bindBandCardListRequest.Send();

            UnbindBankCardRequest unbindReq = new UnbindBankCardRequest()
            {
                IdentityId = "weimingming",
                BindId = "5500020"
            };
            //var unbindRep = unbindReq.Send();

            PayAskRequest payAskReq = new PayAskRequest()
            {
                Amount = 100,
                OrderId = "myfirstorder6",
                TransTime = Utils.GetNowTimeStamp(),
                ProductName = "surface pro 3",
                ProductDesc = "a tablet",
                CallbackUrl = "http://www.google.com",
                Card_Top = "622202",
                Card_Last = "6216",
                IdentityId = "weimingming",
                OrderExpireDate = TimeSpan.FromMinutes(10),
                UserIp = "127.0.0.1"
            };
            var payAskResult = payAskReq.Send();
            var payAskRep = payAskResult.Item3;

            SmsCaptchaRequest smsRequest = new SmsCaptchaRequest()
            {
                OrderId = payAskReq.OrderId
            };
            //var smsResult = smsRequest.Send();
            //var smsRep = smsResult.Item3;

            PayConfirmRequest payConfirmReq = new PayConfirmRequest()
            {
                OrderId = payAskReq.OrderId,
                ValidateCode = "667786"
            };
            //var payConfirmResult = payConfirmReq.Send();
            //var payConfirmRep = payConfirmResult.Item3;

            PayResultQueryRequest payResultQueryReq = new PayResultQueryRequest()
            {
                OrderId = "myfirstorder2"
            };
            var payResultResponse = payResultQueryReq.Send();
            var status = payResultResponse.Item3.GetStatus;


        }


    }
}
