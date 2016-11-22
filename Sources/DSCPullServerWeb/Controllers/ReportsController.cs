﻿using DSCPullServerWeb.Services;
using System;
using System.Web.Http;

namespace DSCPullServerWeb.Controllers
{
    public class ReportsController : ApiController
    {
        private ILogger _logger;

        private IDatabaseRepository _repository;

        public ReportsController(ILogger logger, IDatabaseRepository repository)
        {
            _logger     = logger;
            _repository = repository;
        }

        private IHttpActionResult HandleUnexpectedException(int id, Exception exception)
        {
            _logger.LogHttpRequestException(id, exception, Request, User);

#if DEBUG
            return InternalServerError(exception);
#else
            return InternalServerError();
#endif
        }

        // GET /api/reports
        [HttpGet]
        [Route("reports")]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_repository.GetReports());
            }
            catch (Exception e)
            {
                return HandleUnexpectedException(10031, e);
            }
        }
    }
}
