using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PushShitaiYoServerApp.Controllers
{
    public class PushController : ApiController
    {
        public class PushRequestModel
        {
            public string DeviceToken { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }

        [HttpPost]
        [ActionName("push")]
        public async Task<HttpResponseMessage> Push(PushRequestModel model)
        {
            var message = new Message
            {
                Token = model.DeviceToken,
                Notification = new Notification
                {
                    Title = model.Title,
                    Body = model.Description
                }
            };

            var responseContent = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(responseContent, System.Text.Encoding.UTF8, "application/json");
            return response;
        }
    }
}
