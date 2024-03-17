using Solid.App.DIP.GoodAndBad;

var ProductService = new ProductService(new ProductRepositoryFromSqlServer());
var ProductService2 = new ProductService(new ProductRepositoryFromOracle());

ProductService.GetAll().ForEach(x => Console.WriteLine(x));
ProductService2.GetAll().ForEach(x => Console.WriteLine(x));