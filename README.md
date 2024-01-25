### Simple Eshop Web APi With Auth0


##### The main purpouse of this project is learning fundamentals of web api's, logging, exception handling.

### How to run this project:
```code
dotnet run --project Product.Api
```

EndPoints:
#### Category
```code
GET  https://localhost:7101/api/v1/category/find-all-category
PUT  https://localhost:7101/api/v1/category/update-category
GET  https://localhost:7101/api/v1/category/find-category/{id:Guid}
POST https://localhost:7101/api/v1/category/create-category
DELETE https://localhost:7101/api/v1/category/delete-category
```

#### Product
```code
GET  https://localhost:7101/api/v1/product/get-all-product
GET  https://localhost:7101/api/v1/product/create-product
PUT  https://localhost:7101/api/v1/category/update-product
GET  https://localhost:7101/api/v1/category/find-product/{id:Guid}
DELETE https://localhost:7101/api/v1/category/delete-product
```

#### SubCategory
```code
GET  https://localhost:7101/api/v1/category/find-all-subcategory
PUT  https://localhost:7101/api/v1/category/update-subcategory
GET  https://localhost:7101/api/v1/category/find-subcategory/{id:Guid}
POST https://localhost:7101/api/v1/category/create-subcategory
DELETE https://localhost:7101/api/v1/category/delete-subcategory
```





