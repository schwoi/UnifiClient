using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace UnifiApi.Models
{
    public class GuestAccessSetting : BaseSetting, ICloneable
    {
        public GuestAccessSetting()
        {
            Key = "guest_access";
        }
        [JsonProperty("allowed_subnet_1", NullValueHandling = NullValueHandling.Ignore)]
        public string AllowedSubnet1 { get; set; }

        [JsonProperty("allowed_subnet_2", NullValueHandling = NullValueHandling.Ignore)]
        public string AllowedSubnet2 { get; set; }

        [JsonProperty("allowed_subnet_3", NullValueHandling = NullValueHandling.Ignore)]
        public string AllowedSubnet3 { get; set; }

        [JsonProperty("auth", NullValueHandling = NullValueHandling.Ignore)]
        public string Auth { get; set; }

        [JsonProperty("authorize_use_sandbox", NullValueHandling = NullValueHandling.Ignore)]
        public bool AuthorizeUseSandbox { get; set; }

        [JsonProperty("custom_ip", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomIp { get; set; }

        [JsonProperty("expire", NullValueHandling = NullValueHandling.Ignore)]
        public long Expire { get; set; }

        [JsonProperty("expire_number", NullValueHandling = NullValueHandling.Ignore)]
        public long ExpireNumber { get; set; }

        [JsonProperty("facebook_wifi_gw_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FacebookWifiGwName { get; set; }

        [JsonProperty("gateway", NullValueHandling = NullValueHandling.Ignore)]
        public string Gateway { get; set; }

        [JsonProperty("ippay_use_sandbox", NullValueHandling = NullValueHandling.Ignore)]
        public bool IppayUseSandbox { get; set; }

        [JsonProperty("merchantwarrior_use_sandbox", NullValueHandling = NullValueHandling.Ignore)]
        public bool MerchantwarriorUseSandbox { get; set; }

        [JsonProperty("payment_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentEnabled { get; set; }

        [JsonProperty("payment_fields_address_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsAddressEnabled { get; set; }

        [JsonProperty("payment_fields_address_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsAddressRequired { get; set; }

        [JsonProperty("payment_fields_city_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsCityEnabled { get; set; }

        [JsonProperty("payment_fields_city_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsCityRequired { get; set; }

        [JsonProperty("payment_fields_country_default", NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentFieldsCountryDefault { get; set; }

        [JsonProperty("payment_fields_country_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsCountryEnabled { get; set; }

        [JsonProperty("payment_fields_country_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsCountryRequired { get; set; }

        [JsonProperty("payment_fields_email_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsEmailEnabled { get; set; }

        [JsonProperty("payment_fields_email_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsEmailRequired { get; set; }

        [JsonProperty("payment_fields_first_name_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsFirstNameEnabled { get; set; }

        [JsonProperty("payment_fields_first_name_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsFirstNameRequired { get; set; }

        [JsonProperty("payment_fields_last_name_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsLastNameEnabled { get; set; }

        [JsonProperty("payment_fields_last_name_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsLastNameRequired { get; set; }

        [JsonProperty("payment_fields_state_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsStateEnabled { get; set; }

        [JsonProperty("payment_fields_state_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsStateRequired { get; set; }

        [JsonProperty("payment_fields_zip_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsZipEnabled { get; set; }

        [JsonProperty("payment_fields_zip_required", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaymentFieldsZipRequired { get; set; }

        [JsonProperty("paypal_use_sandbox", NullValueHandling = NullValueHandling.Ignore)]
        public bool PaypalUseSandbox { get; set; }

        [JsonProperty("portal_customized", NullValueHandling = NullValueHandling.Ignore)]
        public bool PortalCustomized { get; set; }

        [JsonProperty("portal_customized_bg_color", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedBgColor { get; set; }

        [JsonProperty("portal_customized_bg_image_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PortalCustomizedBgImageEnabled { get; set; }

        [JsonProperty("portal_customized_bg_image_tile", NullValueHandling = NullValueHandling.Ignore)]
        public bool PortalCustomizedBgImageTile { get; set; }

        [JsonProperty("portal_customized_box_color", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedBoxColor { get; set; }

        [JsonProperty("portal_customized_box_link_color", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedBoxLinkColor { get; set; }

        [JsonProperty("portal_customized_box_opacity", NullValueHandling = NullValueHandling.Ignore)]
        public long PortalCustomizedBoxOpacity { get; set; }

        [JsonProperty("portal_customized_box_text_color", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedBoxTextColor { get; set; }

        [JsonProperty("portal_customized_button_color", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedButtonColor { get; set; }

        [JsonProperty("portal_customized_button_text_color", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedButtonTextColor { get; set; }

        [JsonProperty("portal_customized_languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PortalCustomizedLanguages { get; set; }

        [JsonProperty("portal_customized_link_color", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedLinkColor { get; set; }

        [JsonProperty("portal_customized_logo_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PortalCustomizedLogoEnabled { get; set; }

        [JsonProperty("portal_customized_text_color", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedTextColor { get; set; }

        [JsonProperty("portal_customized_title", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalCustomizedTitle { get; set; }

        [JsonProperty("portal_customized_tos", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic PortalCustomizedTos { get; set; }

        [JsonProperty("portal_customized_tos_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PortalCustomizedTosEnabled { get; set; }

        [JsonProperty("portal_customized_welcome_text", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic PortalCustomizedWelcomeText { get; set; }

        [JsonProperty("portal_customized_welcome_text_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PortalCustomizedWelcomeTextEnabled { get; set; }

        [JsonProperty("portal_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool PortalEnabled { get; set; }

        [JsonProperty("portal_hostname", NullValueHandling = NullValueHandling.Ignore)]
        public string PortalHostname { get; set; }

        [JsonProperty("portal_use_hostname", NullValueHandling = NullValueHandling.Ignore)]
        public bool PortalUseHostname { get; set; }

        [JsonProperty("radius_auth_type", NullValueHandling = NullValueHandling.Ignore)]
        public string RadiusAuthType { get; set; }

        [JsonProperty("redirect_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool RedirectEnabled { get; set; }

        [JsonProperty("redirect_https", NullValueHandling = NullValueHandling.Ignore)]
        public bool RedirectHttps { get; set; }

        [JsonProperty("redirect_to_https", NullValueHandling = NullValueHandling.Ignore)]
        public bool RedirectToHttps { get; set; }

        [JsonProperty("redirect_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectUrl { get; set; }

        [JsonProperty("restricted_subnet_1", NullValueHandling = NullValueHandling.Ignore)]
        public string RestrictedSubnet1 { get; set; }

        [JsonProperty("restricted_subnet_2", NullValueHandling = NullValueHandling.Ignore)]
        public string RestrictedSubnet2 { get; set; }

        [JsonProperty("restricted_subnet_3", NullValueHandling = NullValueHandling.Ignore)]
        public string RestrictedSubnet3 { get; set; }

        [JsonProperty("template_engine", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateEngine { get; set; }

        [JsonProperty("voucher_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool VoucherEnabled { get; set; }

        [JsonProperty("x_authorize_loginid", NullValueHandling = NullValueHandling.Ignore)]
        public string XAuthorizeLoginid { get; set; }

        [JsonProperty("x_authorize_transactionkey", NullValueHandling = NullValueHandling.Ignore)]
        public string XAuthorizeTransactionkey { get; set; }

        [JsonProperty("x_ippay_terminalid", NullValueHandling = NullValueHandling.Ignore)]
        public string XIppayTerminalid { get; set; }

        [JsonProperty("x_merchantwarrior_apikey", NullValueHandling = NullValueHandling.Ignore)]
        public string XMerchantwarriorApikey { get; set; }

        [JsonProperty("x_merchantwarrior_apipassphrase", NullValueHandling = NullValueHandling.Ignore)]
        public string XMerchantwarriorApipassphrase { get; set; }

        [JsonProperty("x_merchantwarrior_merchantuuid", NullValueHandling = NullValueHandling.Ignore)]
        public string XMerchantwarriorMerchantuuid { get; set; }

        [JsonProperty("x_password", NullValueHandling = NullValueHandling.Ignore)]
        public string XPassword { get; set; }

        [JsonProperty("x_paypal_password", NullValueHandling = NullValueHandling.Ignore)]
        public string XPaypalPassword { get; set; }

        [JsonProperty("x_paypal_signature", NullValueHandling = NullValueHandling.Ignore)]
        public string XPaypalSignature { get; set; }

        [JsonProperty("x_paypal_username", NullValueHandling = NullValueHandling.Ignore)]
        public string XPaypalUsername { get; set; }

        [JsonProperty("x_quickpay_md5secret", NullValueHandling = NullValueHandling.Ignore)]
        public string XQuickpayMd5Secret { get; set; }

        [JsonProperty("x_quickpay_merchantid", NullValueHandling = NullValueHandling.Ignore)]
        public string XQuickpayMerchantid { get; set; }

        [JsonProperty("x_stripe_api_key", NullValueHandling = NullValueHandling.Ignore)]
        public string XStripeApiKey { get; set; }

        public object Clone()
        {
            return (GuestAccessSetting)this.MemberwiseClone();
        }
    }
}
