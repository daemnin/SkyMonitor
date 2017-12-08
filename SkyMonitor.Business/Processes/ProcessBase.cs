using SkyMonitor.Commons.Entities;
using SkyMonitor.Data.Contracts;
using System;

namespace SkyMonitor.Business.Processes
{
    public abstract class ProcessBase
    {
        protected IUnitOfWork UnitOfWork { get; private set; }

        public ProcessBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected void FillErrors(Exception exception, Response response)
        {
            while (exception != null)
            {
                response.Errors.Add(exception.Message);
                exception = exception.InnerException;
            }

            response.Succeeded = false;
        }
    }
}
