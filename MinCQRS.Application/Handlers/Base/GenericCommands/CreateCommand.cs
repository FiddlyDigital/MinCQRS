using LanguageExt.Common;
using MinCQRS.Application.Handlers.Base.Interfaces;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Application.Handlers.Base.GenericQueries
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
