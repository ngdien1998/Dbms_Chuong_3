using ConnectDatabaseDbms.Models.DatabaseAccessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectDatabaseDbms.Models.BusinessModels
{
    public abstract class DataBusinessModel<T>
    {
        protected DatabaseConnection database = DatabaseAccessor.Instance;

        public abstract List<T> GetAll();

        public abstract T Add(T model);

        public abstract T Delete(T model);

        public abstract bool Modify(T model);

        public abstract T Get(params object[] keys);
    }
}