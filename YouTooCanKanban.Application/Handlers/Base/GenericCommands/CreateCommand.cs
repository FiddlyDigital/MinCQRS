using LanguageExt.Common;
using YouTooCanKanban.Application.Handlers.Base.Interfaces;
using YouTooCanKanban.Domain.Models.Base;

namespace YouTooCanKanban.Application.Handlers.Base.GenericCommands
{
    public abstract class CreateCommand<TModel> : ICommand<Result<TModel>>
        where TModel : BaseModel
    {
        public CreateCommand() { }

        public CreateCommand(TModel model)
        {
            Model = model;
        }

        public TModel? Model { get; set; }
    }
}
