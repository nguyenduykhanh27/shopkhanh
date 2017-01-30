using ShopKhanh.Model.Models;
using ShopKhanh.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopKhanh.Web.infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpRespone(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage reponse = null;
            try
            {
                reponse = function.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{ eve.Entry.Entity.GetType().Name}\" instate \"{eve.Entry.State}\" has the following validation errors.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property:\"{  ve.PropertyName}\",Error:\"{ve.ErrorMessage}\"");
                    }
                }
                logError(ex);
                reponse = requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                logError(dbEx);
                reponse = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                logError(ex);
                reponse = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return reponse;
        }

        private void logError(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.CreatedDate = DateTime.Now;
                error.Message = ex.Message;
                error.stackTrace = ex.StackTrace;
                _errorService.Create(error);
                _errorService.Save();
            }
            catch
            {
            }
        }
    }
}