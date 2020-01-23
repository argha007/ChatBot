using System.Collections.Generic;

namespace IntermediatorBotSample.EF.Models.Repository
{
    public interface IDataRepository<TEntity, TDto>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TDto GetDto(long id);
        int Add(TDto entity);
        int Update(TEntity entityToUpdate, TEntity entity);
        int Delete(TEntity entity);
    }
}
