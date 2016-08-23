using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Edu.Helpers
{
    public class CaptchaValidator : ICaptchaHelper
    {
        public bool ValidateCaptcha(string response)
        {

            //secret that was generated in key value pair
            string secret = System.Web.Configuration.WebConfigurationManager.AppSettings["ReCaptchaPrivateKey"];

            var client = new System.Net.WebClient();

            string reply;
            try
            {
                reply = client.DownloadString(
                    string.Format(@"https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            }
            catch (System.Net.WebException webex)
            {
                reply = string.Empty;
            }




            var cAnswer = JsonConvert.DeserializeObject<CaptchaAnswer>(reply);

            if (cAnswer != null)
            {
                return string.IsNullOrEmpty(cAnswer.Success) ? false :
                    (cAnswer.Success.ToLowerInvariant() == "true" ? true : false);
            }

            return false;
        }




    }
}