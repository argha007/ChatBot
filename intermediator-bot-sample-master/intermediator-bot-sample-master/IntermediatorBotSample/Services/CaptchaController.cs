using BotDetect.Web;
using Microsoft.AspNetCore.Mvc;

namespace IntermediatorBotSample.Services
{
    [Route("api/[controller]")]
    public class CaptchaController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] EF.Models.CaptachaModel.Captcha value)
        {
            string userEnteredCaptchaCode = value.UserEnteredCaptchaCode;
            string captchaId = value.CaptchaId;

            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha objCaptcha = new SimpleCaptcha();
            // execute the captcha validation
            bool isHuman = objCaptcha.Validate(userEnteredCaptchaCode, captchaId);

            if (isHuman == false)
            {
                // captcha validation failed; notify the frontend 
                // TODO: consider logging the attempt
                return Content("{\"success\":false}", "application/json; charset=utf-8");
            }
            else
            {
                return Content("{\"success\":true}", "application/json; charset=utf-8");
            }
        }
    }
}
