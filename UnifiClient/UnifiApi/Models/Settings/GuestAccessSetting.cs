using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class GuestAccessSetting : BaseSetting
    {
        public GuestAccessSetting()
        {
            Key = "guest_access";
        }
        [JsonProperty("allowed_subnet_1")]
        public string AllowedSubnet1 { get; set; }

        [JsonProperty("allowed_subnet_2")]
        public string AllowedSubnet2 { get; set; }

        [JsonProperty("allowed_subnet_3")]
        public string AllowedSubnet3 { get; set; }

        [JsonProperty("auth")]
        public string Auth { get; set; }

        [JsonProperty("authorize_use_sandbox")]
        public bool AuthorizeUseSandbox { get; set; }

        [JsonProperty("custom_ip")]
        public string CustomIp { get; set; }

        [JsonProperty("expire")]
        public long Expire { get; set; }

        [JsonProperty("expire_number")]
        public long ExpireNumber { get; set; }

        [JsonProperty("facebook_wifi_gw_name")]
        public string FacebookWifiGwName { get; set; }

        [JsonProperty("gateway")]
        public string Gateway { get; set; }

        [JsonProperty("ippay_use_sandbox")]
        public bool IppayUseSandbox { get; set; }

        [JsonProperty("merchantwarrior_use_sandbox")]
        public bool MerchantwarriorUseSandbox { get; set; }

        [JsonProperty("payment_enabled")]
        public bool PaymentEnabled { get; set; }

        [JsonProperty("payment_fields_address_enabled")]
        public bool PaymentFieldsAddressEnabled { get; set; }

        [JsonProperty("payment_fields_address_required")]
        public bool PaymentFieldsAddressRequired { get; set; }

        [JsonProperty("payment_fields_city_enabled")]
        public bool PaymentFieldsCityEnabled { get; set; }

        [JsonProperty("payment_fields_city_required")]
        public bool PaymentFieldsCityRequired { get; set; }

        [JsonProperty("payment_fields_country_default")]
        public string PaymentFieldsCountryDefault { get; set; }

        [JsonProperty("payment_fields_country_enabled")]
        public bool PaymentFieldsCountryEnabled { get; set; }

        [JsonProperty("payment_fields_country_required")]
        public bool PaymentFieldsCountryRequired { get; set; }

        [JsonProperty("payment_fields_email_enabled")]
        public bool PaymentFieldsEmailEnabled { get; set; }

        [JsonProperty("payment_fields_email_required")]
        public bool PaymentFieldsEmailRequired { get; set; }

        [JsonProperty("payment_fields_first_name_enabled")]
        public bool PaymentFieldsFirstNameEnabled { get; set; }

        [JsonProperty("payment_fields_first_name_required")]
        public bool PaymentFieldsFirstNameRequired { get; set; }

        [JsonProperty("payment_fields_last_name_enabled")]
        public bool PaymentFieldsLastNameEnabled { get; set; }

        [JsonProperty("payment_fields_last_name_required")]
        public bool PaymentFieldsLastNameRequired { get; set; }

        [JsonProperty("payment_fields_state_enabled")]
        public bool PaymentFieldsStateEnabled { get; set; }

        [JsonProperty("payment_fields_state_required")]
        public bool PaymentFieldsStateRequired { get; set; }

        [JsonProperty("payment_fields_zip_enabled")]
        public bool PaymentFieldsZipEnabled { get; set; }

        [JsonProperty("payment_fields_zip_required")]
        public bool PaymentFieldsZipRequired { get; set; }

        [JsonProperty("paypal_use_sandbox")]
        public bool PaypalUseSandbox { get; set; }

        [JsonProperty("portal_customized")]
        public bool PortalCustomized { get; set; }

        [JsonProperty("portal_customized_bg_color")]
        public string PortalCustomizedBgColor { get; set; }

        [JsonProperty("portal_customized_bg_image_enabled")]
        public bool PortalCustomizedBgImageEnabled { get; set; }

        [JsonProperty("portal_customized_bg_image_tile")]
        public bool PortalCustomizedBgImageTile { get; set; }

        [JsonProperty("portal_customized_box_color")]
        public string PortalCustomizedBoxColor { get; set; }

        [JsonProperty("portal_customized_box_link_color")]
        public string PortalCustomizedBoxLinkColor { get; set; }

        [JsonProperty("portal_customized_box_opacity")]
        public long PortalCustomizedBoxOpacity { get; set; }

        [JsonProperty("portal_customized_box_text_color")]
        public string PortalCustomizedBoxTextColor { get; set; }

        [JsonProperty("portal_customized_button_color")]
        public string PortalCustomizedButtonColor { get; set; }

        [JsonProperty("portal_customized_button_text_color")]
        public string PortalCustomizedButtonTextColor { get; set; }

        [JsonProperty("portal_customized_languages")]
        public List<string> PortalCustomizedLanguages { get; set; }

        [JsonProperty("portal_customized_link_color")]
        public string PortalCustomizedLinkColor { get; set; }

        [JsonProperty("portal_customized_logo_enabled")]
        public bool PortalCustomizedLogoEnabled { get; set; }

        [JsonProperty("portal_customized_text_color")]
        public string PortalCustomizedTextColor { get; set; }

        [JsonProperty("portal_customized_title")]
        public string PortalCustomizedTitle { get; set; }

        [JsonProperty("portal_customized_tos")]
        public dynamic PortalCustomizedTos { get; set; }

        [JsonProperty("portal_customized_tos_enabled")]
        public bool PortalCustomizedTosEnabled { get; set; }

        [JsonProperty("portal_customized_welcome_text")]
        public dynamic PortalCustomizedWelcomeText { get; set; }

        [JsonProperty("portal_customized_welcome_text_enabled")]
        public bool PortalCustomizedWelcomeTextEnabled { get; set; }

        [JsonProperty("portal_enabled")]
        public bool PortalEnabled { get; set; }

        [JsonProperty("portal_hostname")]
        public string PortalHostname { get; set; }

        [JsonProperty("portal_use_hostname")]
        public bool PortalUseHostname { get; set; }

        [JsonProperty("radius_auth_type")]
        public string RadiusAuthType { get; set; }

        [JsonProperty("redirect_enabled")]
        public bool RedirectEnabled { get; set; }

        [JsonProperty("redirect_https")]
        public bool RedirectHttps { get; set; }

        [JsonProperty("redirect_to_https")]
        public bool RedirectToHttps { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("restricted_subnet_1")]
        public string RestrictedSubnet1 { get; set; }

        [JsonProperty("restricted_subnet_2")]
        public string RestrictedSubnet2 { get; set; }

        [JsonProperty("restricted_subnet_3")]
        public string RestrictedSubnet3 { get; set; }

        [JsonProperty("template_engine")]
        public string TemplateEngine { get; set; }

        [JsonProperty("voucher_enabled")]
        public bool VoucherEnabled { get; set; }

        [JsonProperty("x_authorize_loginid")]
        public string XAuthorizeLoginid { get; set; }

        [JsonProperty("x_authorize_transactionkey")]
        public string XAuthorizeTransactionkey { get; set; }

        [JsonProperty("x_ippay_terminalid")]
        public string XIppayTerminalid { get; set; }

        [JsonProperty("x_merchantwarrior_apikey")]
        public string XMerchantwarriorApikey { get; set; }

        [JsonProperty("x_merchantwarrior_apipassphrase")]
        public string XMerchantwarriorApipassphrase { get; set; }

        [JsonProperty("x_merchantwarrior_merchantuuid")]
        public string XMerchantwarriorMerchantuuid { get; set; }

        [JsonProperty("x_password")]
        public string XPassword { get; set; }

        [JsonProperty("x_paypal_password")]
        public string XPaypalPassword { get; set; }

        [JsonProperty("x_paypal_signature")]
        public string XPaypalSignature { get; set; }

        [JsonProperty("x_paypal_username")]
        public string XPaypalUsername { get; set; }

        [JsonProperty("x_quickpay_md5secret")]
        public string XQuickpayMd5Secret { get; set; }

        [JsonProperty("x_quickpay_merchantid")]
        public string XQuickpayMerchantid { get; set; }

        [JsonProperty("x_stripe_api_key")]
        public string XStripeApiKey { get; set; }
    }
}
