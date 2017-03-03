﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AlexaSkill.Data;
using AlexaSkill.Data.Models;

namespace AlexaSkill.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/demo")]
        public AlexaResponseModel Pluralsight(AlexaRequestModel alexaRequest)
        {
            var request = new Requests().Create(new Data.Request
            {
                Intent = alexaRequest.Request.Intent == null ? "" : alexaRequest.Request.Intent.Name,
                AppId = alexaRequest.Session.Application.ApplicationId,
                RequestId = alexaRequest.Request.RequestId,
                SessionId = alexaRequest.Session.SessionId,
                UserId = alexaRequest.Session.User.UserId,
                IsNew = alexaRequest.Session.New,
                Version = alexaRequest.Version,
                Type = alexaRequest.Request.Type,
                DateCreated = DateTime.UtcNow
            });

            var response = new AlexaResponseModel("Hello world. Would you like for me to say it again? Yes or no?");


            return response;
        }
    }
}
