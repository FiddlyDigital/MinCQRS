using LanguageExt.Common;
using MinCQRS.Application.Handlers.Base.Interfaces;
using MinCQRS.Domain.Models.Base;

namespace MinCQRS.Application.Handlers.Base.GenericQueries
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
