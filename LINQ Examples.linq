<Query Kind="Statements">
  <Connection>
    <ID>178d2904-dbad-4a19-9658-195d566f6da3</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DMIT-WB304\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>WestWind</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//All Regions
Regions.Select(region => region)

Regions.Select(x => x.RegionDescription)
//Cannot return more than one "THING" 
Regions.Select(x => x.RegionID,x.RegionDescription)
//Create a new "block" of results to return
Regions.Select(x => 
new{x.RegionID,x.RegionDescription})

//Use aggregates
Products.Sum(x => x.UnitPrice)

//Where 
Products
	.Where(prd => prd.ProductName.Contains("Sauce"))
//Count of Sauce products
Products
	.Count(prd => prd.ProductName.Contains("Sauce"))
//OR
Products
	.Where(prd => prd.ProductName.Contains("Sauce"))
	.Count()
//Highest sauce price
Products
	.Where(prd => prd.ProductName.Contains("Sauce"))
	.Max(prd =>prd.UnitPrice)

//Filtering
//Look at each instance in products table evaluate an expression for T/F
//look through all prices and return T if they are above 
//20 and false if not
Products.Select(x =>x.UnitPrice>20)

//We want the product names and unit price for products with unitprice over 20
Products
	.Where(product => product.UnitPrice>20)
	.Select(product => new{product.ProductName,product.UnitPrice})
//Reverse the order
Products
	.Select(product => new{product.ProductName,product.UnitPrice})
	.Where(product => product.UnitPrice>20)

//Ordering
//Order by  Discontinued status
Products
		.OrderBy(x=> x.Discontinued)
//Order by  Discontinued status and then ProductName
Products
		.OrderBy(x=> x.Discontinued)
		.ThenBy(x=> x.ProductName)

//Order by  Discontinued status and then ProductName desc
Products
		.OrderBy(x=> x.Discontinued)
		.ThenByDescending(x=> x.ProductName)
		.Select(x => new{x.Discontinued,x.ProductName})

//C# statement demo
if (Products.Any(x=>x.ProductName.Contains("Sauce")))
{
Console.WriteLine("Yup! we have sauces");
}

//FirstOrDefault()
//Find the first product that is a sauce and display it

//if not match is found for the given criteria, null is returned

var productFound = Products
					.Where(prd =>prd.ProductName.Contains("k"))
					.FirstOrDefault();
productFound.Dump();






