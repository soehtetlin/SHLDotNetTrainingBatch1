using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHLDotNetTrainingBatch1
{
	internal static class Data
	{
		public static int ProductId = 4;
		public static List<Product> Products = new List<Product>()
		{
			new Product(1, "P001", "Apple", 3000m, 100, "Fruit"),
			new Product(2, "P002", "Banana", 1000, 150, "Fruit"),
			new Product(3, "P003", "Orange", 2000, 200, "Fruit"),
			new Product(4, "P004", "Mango", 5000, 50, "Fruit"),
		};
	}
}
