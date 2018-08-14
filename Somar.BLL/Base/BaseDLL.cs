using Somar.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Somar.BLL.Base
{
    public abstract class BaseBLL<T>
    {
        protected GenericDAL<T> dal;

        public BaseBLL()
        {
            dal = new GenericDAL<T>();
        }

        /*
        public virtual void Add(T model)
        {
            dal.Add(model);
        }
        */

        public virtual T Get(int id)
        {
            return dal.GetSingle(null, null);
        }

        public virtual List<T> GetAll(T data)
        {
            return dal.GetAll(null);
        }

        /*
        public virtual void Delete(int id)
        {
            dal.Delete(id);
        }

        public virtual void Update()
        {
            dal.Update();
        }
        */
    }
}
