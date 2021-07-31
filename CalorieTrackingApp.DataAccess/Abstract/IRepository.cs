using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackingApp.DataAccess.Abstract
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
