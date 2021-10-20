using dotnet5.WebApi.SignalrDemo.Models;
using dotnet5.WebApi.SignalrDemo.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet5.WebApi.SignalrDemo.Services
{
    public interface ISignalService {
        Task<bool> SaveSignalAsync(SignalInputModel inputModel);
    }

    public class SignalService: ISignalService
    {
        private readonly MainDbContext _dbContext;
        public SignalService(MainDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveSignalAsync(SignalInputModel inputModel)
        {
            try
            {
                var signalModel = new SignalDataModel() {
                    CustomerName = inputModel.CustomerName,
                    Description = inputModel.Description,
                    AccessCode = inputModel.AccessCode,
                    Area = inputModel.Area,
                    Zone = inputModel.Zone,
                    SignalDate = DateTime.Now
                };  

                _dbContext.Signals.Add(signalModel);

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex) {
                throw ex;
                //return false;
            }
        }
    }
}
