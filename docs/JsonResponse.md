# Products

```json
[
  {
    "Id": 1,
    "Name": "Product A",
    "Description": "Description for Product A",
    "Price": 29.99,
    "Image": "https://example.com/product_a.jpg",
    "Category": "Category A",
    "Stock": 100,
    "CreatedAt": "2023-01-15T10:30:00Z",
    "UpdatedAt": "2023-12-10T15:20:00Z"
  },
  {
    "Id": 2,
    "Name": "Product B",
    "Description": "Description for Product B",
    "Price": 49.99,
    "Image": "https://example.com/product_b.jpg",
    "Category": "Category B",
    "Stock": 50,
    "CreatedAt": "2023-02-20T09:45:00Z",
    "UpdatedAt": "2023-11-05T11:10:00Z"
  }
]
```
# Categories
```json
[
  {
    "Id": 1,
    "Name": "Category A",
    "Description": "Description for Category A",
    "ParentCategoryId": null
  },
  {
    "Id": 2,
    "Name": "Category B",
    "Description": "Description for Category B",
    "ParentCategoryId": null
  }
]
```
# Orders
```json
[
  {
    "Id": 1,
    "UserId": 1,
    "OrderDate": "2023-03-05T14:00:00Z",
    "OrderStatus": "Pending",
    "TotalAmount": 79.98,
    "ShippingAddress": "123 Main St, City, Country",
    "BillingAddress": "456 Street Ave, City, Country"
  },
  {
    "Id": 2,
    "UserId": 2,
    "OrderDate": "2023-04-10T11:30:00Z",
    "OrderStatus": "Delivered",
    "TotalAmount": 49.99,
    "ShippingAddress": "789 Oak Rd, City, Country",
    "BillingAddress": "789 Oak Rd, City, Country"
  }
]
```


# OrderItems
```json
[
  {
    "Id": 1,
    "OrderId": 1,
    "ProductId": 1,
    "Quantity": 2,
    "UnitPrice": 29.99
  },
  {
    "Id": 2,
    "OrderId": 2,
    "ProductId": 2,
    "Quantity": 1,
    "UnitPrice": 49.99
  }
]
```

