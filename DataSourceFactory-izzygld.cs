using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyMustard.Interface.DataSource;
using HoneyMustard.EFDataImpl.DataSource;
using System.Data.Entity;

namespace HoneyMustard.Factories
{
    public class DataSourceFactory
    {
        public static IHoneyMustardDataSource GetDataSource()
        {
            return new HoneyMustardContext();
        }
    }
}
