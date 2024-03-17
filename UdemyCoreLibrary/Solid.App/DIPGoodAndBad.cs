using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.DIP.GoodAndBad
{
    public class ProductService // High Level Modül Low Level Modülü biliyor
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetAll()
        {
            return _repository.GetAll();
        }
    }

    public class ProductRepositoryFromSqlServer : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>
            {
               "SqlServer Kalem1","SqlServer Kalem2"
            };
        }
    }
    public class ProductRepositoryFromOracle : IRepository
    {
        public List<string> GetAll()
        {
            return new List<string>
            {
               "Oracle Kalem1","Oracle Kalem2"
            };
        }
    }


    public interface IRepository
    {
        List<string> GetAll();
    }
}
