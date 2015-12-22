# Alan.YiBaoPay
易宝支付

# Config

	{
		"IsDevelopMode": true, /*是否是开发模式*/

		/*开发模式下的配置*/
		"DevelopConfig": {
			/*商家账号*/
			"MerchantAccount": "10000419568",
			/*商家私钥*/
			"MerchantPrivateKeyBase64": "",
			/*商家公钥*/
			"MerchantPublicKeyBase64": "",
			/*易宝公钥*/
			"YbPublicKeyBase64": "",
		},
		/*上线模式下的配置*/
		"OnlineConfig": {
			/*商家账号*/
			"MerchantAccount": "10000419568",
			/*商家私钥*/
			"MerchantPrivateKeyBase64": "",
			/*商家公钥*/
			"MerchantPublicKeyBase64": "",
			/*易宝公钥*/
			"YbPublicKeyBase64": "",
		},
		/*上线环境接口地址*/
		"OnlineApiUrl": {
			/*Java Demo*/
			"JavaDemostration": "https://ok.yeepay.com/payapi/api/tzt/drawvalidamount",
			/*绑定银行卡请求*/
			"BindBankCardAsk": "https://ok.yeepay.com/payapi/api/tzt/invokebindbankcard",
			/*确定绑定银行卡 */
			"BindBankCardConfirm": "https://ok.yeepay.com/payapi/api/tzt/confirmbindbankcard",
			/*短信验证码 */
			"SmsCaptcha": "https://ok.yeepay.com/payapi/api/tzt/pay/validatecode/send",
			/*支付请求 */
			"PayAsk": "https://ok.yeepay.com/payapi/api/tzt/pay/bind/reuqest",
			/*确定支付*/
			"PayConfirm": "https://ok.yeepay.com/payapi/api/tzt/pay/confirm/validatecode",
			/* 使用短验支付 */
			/*"PayWithoutSms": "https://ok.yeepay.com/payapi/api/tzt/directbindpay",*/
			/*支付结果查询接口*/
			"PayResultQuery": "https://ok.yeepay.com/payapi/api/query/order",
			/*提现接口*/
			"Withdraw": "https://ok.yeepay.com/payapi/api/tzt/withdraw",
			/*提现查询接口*/
			"WithdrawQuery": "https://ok.yeepay.com/payapi/api/tzt/drawrecord",
			"UnbindBankCard": "https://ok.yeepay.com/payapi/api/bankcard/unbind",
			"BindBankCardList": "https://ok.yeepay.com/payapi/api/bankcard/authbind/list",
			"BankCardInfoQuery": "https://ok.yeepay.com/payapi/api/bankcard/check",
			"WithdrawAvaliableAmount": "https://ok.yeepay.com/payapi/api/tzt/drawvalidamount"
		},
		/*开发环境接口地址*/
		"DevApiUrl": {
			/*Java Demo*/
			"JavaDemostration": "https://ok.yeepay.com/payapi/api/tzt/drawvalidamount",
			/*绑定银行卡请求*/
			"BindBankCardAsk": "https://ok.yeepay.com/payapi/api/tzt/invokebindbankcard",
			/*确定绑定银行卡 */
			"BindBankCardConfirm": "https://ok.yeepay.com/payapi/api/tzt/confirmbindbankcard",
			/*短信验证码 */
			"SmsCaptcha": "https://ok.yeepay.com/payapi/api/tzt/pay/validatecode/send",
			/*支付请求 */
			"PayAsk": "https://ok.yeepay.com/payapi/api/tzt/pay/bind/reuqest",
			/*确定支付*/
			"PayConfirm": "https://ok.yeepay.com/payapi/api/tzt/pay/confirm/validatecode",
			/* 使用短验支付 */
			/*"PayWithoutSms": "https://ok.yeepay.com/payapi/api/tzt/directbindpay",*/
			/*支付结果查询接口*/
			"PayResultQuery": "https://ok.yeepay.com/payapi/api/query/order",
			/*提现接口*/
			"Withdraw": "https://ok.yeepay.com/payapi/api/tzt/withdraw",
			/*提现查询接口*/
			"WithdrawQuery": "https://ok.yeepay.com/payapi/api/tzt/drawrecord",
			"UnbindBankCard": "https://ok.yeepay.com/payapi/api/bankcard/unbind",
			"BindBankCardList": "https://ok.yeepay.com/payapi/api/bankcard/authbind/list",
			"BankCardInfoQuery": "https://ok.yeepay.com/payapi/api/bankcard/check",
			"WithdrawAvaliableAmount": "https://ok.yeepay.com/payapi/api/tzt/drawvalidamount"
		}

	}
		

# Install

	Install-Package Alan.YiBaoPay

