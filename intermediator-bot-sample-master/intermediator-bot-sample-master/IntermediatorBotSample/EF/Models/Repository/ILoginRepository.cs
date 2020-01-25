using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models.Repository
{
    public interface ILoginRepository<TEntity, TDto>
    {
        TEntity Login(TDto user);
    }
}
