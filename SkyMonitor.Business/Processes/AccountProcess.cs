using SkyMonitor.Commons.Entities;
using SkyMonitor.Commons.Extensions;
using SkyMonitor.Data.Contracts;
using SkyMonitor.Model;
using System;
using System.Linq;

namespace SkyMonitor.Business.Processes
{
    public class AccountProcess : ProcessBase
    {
        public AccountProcess(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public Response Create(string name, string phone)
        {
            var response = new Response();

            try
            {
                var user = new User
                {
                    Name = name,
                    Phone = phone
                };

                user = UnitOfWork.UserRepository.Create(user);

                response.Succeeded = UnitOfWork.Save() > 0;

                response.Result = new { Id = user.Id }.ToToken();
            }
            catch (Exception ex)
            {
                FillErrors(ex, response);
            }

            return response;
        }

        public Response Get(int id)
        {
            var response = new Response();

            try
            {
                var user = UnitOfWork.UserRepository.Read(id, i => i.Devices);

                response.Result = new
                {
                    user.Id,
                    user.Phone,
                    user.Name,
                    Devices = user.Devices.Select(d => new
                    {
                        d.Id,
                        d.Name,
                        d.Range,
                        d.Status,
                        d.Latitude,
                        d.Longitude
                    })
                }.ToToken();

                response.Succeeded = true;
            }
            catch (Exception ex)
            {
                FillErrors(ex, response);
            }

            return response;
        }
    }
}
