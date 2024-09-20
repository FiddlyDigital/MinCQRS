using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using YouTooCanKanban.BLL.Exceptions;
using YouTooCanKanban.BLL.Services.Base;
using YouTooCanKanban.BLL.Services.Base.Interfaces;
using YouTooCanKanban.DAL.Entities;
using YouTooCanKanban.DAL.Repos;
using YouTooCanKanban.Domain.Models;

namespace YouTooCanKanban.BLL.Services
{
    public interface ICardService : ICrudService<CardService, CardModel>
    {
        public Task<Result<bool>> AddLabelToCard(int cardId, int labelId, CancellationToken cancellationToken);
        public Task<Result<bool>> RemoveLabelFromCard(int cardId, int labelId, CancellationToken cancellationToken);
    }

    public sealed class CardService : CRUDService<CardService, CardModel, CardEntity>, ICardService
    {
        private ILabelRepo LabelRepo { get; set; }

        public CardService(ILogger<CardService> logger, ICardRepo repository, ILabelRepo labelRepo) : base(logger, repository)
        {
            this.LabelRepo = labelRepo;
        }

        public async Task<Result<bool>> AddLabelToCard(int cardId, int labelId, CancellationToken cancellationToken)
        {
            LabelEntity? existingLabel = await this.LabelRepo.GetById(labelId, cancellationToken);
            if (existingLabel is null)
            {
                return new Result<bool>(new NotFoundException($"Label {labelId} does not exist."));
            }

            CardEntity? existingCard = await this._modelRepository.GetById(cardId, cancellationToken);
            if (existingCard is null)
            {
                return new Result<bool>(new NotFoundException($"Card {cardId} does not exist."));
            }

            if (existingCard.Labels.Contains(existingLabel))
            {
                return new Result<bool>(new Exception("Card already contains this label."));
            }

            existingCard.Labels.Add(existingLabel);
            await _modelRepository.SaveChangesAsync(cancellationToken);

            return new Result<bool>(true);
        }

        public async Task<Result<bool>> RemoveLabelFromCard(int cardId, int labelId, CancellationToken cancellationToken)
        {
            LabelEntity? existingLabel = await this.LabelRepo.GetById(labelId, cancellationToken);
            if (existingLabel is null)
            {
                return new Result<bool>(new NotFoundException($"Label {labelId} does not exist."));
            }

            CardEntity? existingCard = await this._modelRepository.GetById(cardId, cancellationToken);
            if (existingCard is null)
            {
                return new Result<bool>(new NotFoundException($"Card {cardId} does not exist."));
            }

            if (!existingCard.Labels.Contains(existingLabel))
            {
                return new Result<bool>(new Exception("Card does not have this label."));
            }

            existingCard.Labels.Remove(existingLabel);
            await _modelRepository.SaveChangesAsync(cancellationToken);

            return new Result<bool>(true);
        }
    }
}
