using Microsoft.Extensions.Logging;
using YouTooCanKanban.BLL.Services.Base;
using YouTooCanKanban.BLL.Services.Base.Interfaces;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.DAL.Repos;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.BLL.Services
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
