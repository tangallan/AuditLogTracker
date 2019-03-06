# AuditLogTracker
Simple base class to audit log property changes

# To Test
1. Pull the repository
2. Build the project
3. Run the console app (AuditLogConsoleApp)

# To Use 
```csharp
	var product = new Product()
	{
	    ProductNumber = "p-1000",
	    Sku = "sku-100",
	    ProductCost = 23.99m,
	    Height = 15,
	    Length = 15,
	    Width = 15,
	    Weight = 23
	};
	var productWithTracker = new AuditLogTracker<Product>(product, userName);
	productWithTracker.UpdateAndTrack("Weight", 25);
	productWithTracker.UpdateAndTrack("ProductCost", 29.99m);
	productWithTracker.UpdateAndTrack("ProductCost", 30.99m);
	productWithTracker.UpdateAndTrack("ProductCost", 33.99m);
	productWithTracker.UpdateAndTrack("ProductCost", 35.99m);
```

