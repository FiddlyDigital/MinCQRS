using Microsoft.Extensions.Logging;
using MinCQRS.BLL.Services.Base;
using MinCQRS.BLL.Services.Base.Interfaces;
using MinCQRS.DAL.Entities;
using MinCQRS.DAL.Repos;
using MinCQRS.Domain.Models;

namespace MinCQRS.BLL.Services
{
    public interface ICardService : ICrudService<CardService, CardModel>
    {

    }

    public sealed class CardService : CRUDService<CardService, CardModel, CardEntity>, ICardService
    {

        public CardService(ILogger<CardService> logger, ICardRepo repository) : base(logger, repository)
        {

        }
    }
}
