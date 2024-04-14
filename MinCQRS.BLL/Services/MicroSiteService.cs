using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface IMicrositeService : ICrudService<MicrositeService, MicrositeModel> { }

    public sealed class MicrositeService : CRUDService<MicrositeService, MicrositeModel, MicrositeEntity>, IMicrositeService
    {
        public MicrositeService(ILogger<MicrositeService> logger, IMicrositeRepo repository) :
            base(logger, repository)
        { }
    }
}
