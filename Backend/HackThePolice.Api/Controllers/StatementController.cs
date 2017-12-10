using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using ExpressMapper.Extensions;
using HackThePolice.Api.Models;
using HackThePolice.Infrastructure.Core;
using HackThePolice.Infrastructure.Core.Models;
using HackThePolice.QRCodeGenerator;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace HackThePolice.Api.Controllers
{
    public class StatementController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [ResponseType(typeof(StatementModel))]
        public IHttpActionResult Get(Guid id)
        {
            var repository = new Repository();
            var statement = repository.GetStatement(id);
            return Ok(statement.Map<Statement, StatementModel>());
        }

        [ResponseType(typeof(Guid))]
        public IHttpActionResult Post([FromBody] StatementModel request)
        {
            var repository = new Repository();
            var id = repository.Upsert(request.Map<StatementModel, Statement>());
            SendText(request);
            return Ok(id);
        }

        public IHttpActionResult Put(Guid id, [FromBody] StatementModel request)
        {
            var repository = new Repository();
            request.Id = id;
            repository.Upsert(request.Map<StatementModel, Statement>());
            return Ok(id);
        }

        public IHttpActionResult Delete(Guid id)
        {
            return Ok();
        }

        [HttpGet, Route("api/incident/statement/{id}")]
        public HttpResponseMessage QRCode(Guid id)
        {
            var generator = new Generator();
            var bitmap = generator.GetQRCode($"https://the-app-ox.firebaseapp.com/witnessformstart");
            var converter = new ImageConverter();
            var b = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(b, 0, b.Length);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.ToArray())
                };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            }
        }


        private void SendText(StatementModel statement)
        {
            // Your Account SID from twilio.com/console
            var accountSid = "<<ACCOUNT>>";
            // Your Auth Token from twilio.com/console
            var authToken = "<<TOKEN>>";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber("+447455697681"),
                from: new PhoneNumber("<<TWILIO PHONE NUMBER>>"),
                body: "Thank you for taking the time to submit your statement!");
        }
    }
}
