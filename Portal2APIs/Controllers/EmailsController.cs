using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Portal2APIs.Models;
using Portal2APIs.Common;
using System.Net.Mail;

namespace Portal2APIs.Controllers
{
    public class EmailsController : ApiController
    {
        [HttpPost]
        [Route("api/Emails/SendEmail/")]
        public HttpResponseMessage SendEmail(Email emailInfo)
        {
            try
            {
                MailMessage Message = new MailMessage(emailInfo.FromEmailAddress, emailInfo.ToEmailAddress);


                Message.Subject = emailInfo.Subject;
                Message.Body = emailInfo.Body;
                Message.IsBodyHtml = true;
                
                SmtpClient smtp = new SmtpClient();
                
                smtp.Host = "192.168.0.53";
                smtp.Send(Message);
                
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Success");
                return response;
            }
            catch
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadGateway, "Error");
                return response;
            }
            

        }
    }
}
