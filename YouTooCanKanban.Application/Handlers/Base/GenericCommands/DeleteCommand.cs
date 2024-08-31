using LanguageExt.Common;
using YouTooCanKanban.Application.Handlers.Base.Interfaces;
using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.Application.Handlers.Base.GenericCommands
{
    public abstract class DeleteCommand<TModel> : ICommand<Result<TModel>>
        where TModel : BaseModel
    {
        public DeleteCommand() { }

        public DeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
