
### Product

- **Id** (GUID): Unique identifier for the product.
- **Name** (string): Name of the product.
- **Description** (string): Detailed description of the product.
- **Price** (decimal): Price of the product.
- **Image** (string): URL or path to the product image.
- **SubCategoryId** (GUID): Category of the product.
- **Stock** (int): Available stock of the product.
- **CreatedAt** (DateTime): Date and time of product creation.
- **UpdatedAt** (DateTime): Date and time of last product update.

### Category

- **Id** (int or string): Unique identifier for the category.
- **Name** (string): Category name.
- **Description** (string): Description of the category.


### SubCategory


- **Id** (int or string): Unique identifier for the category.
- **Name** (string): Category name.
- **Description** (string): Description of the category.
- **ParentCategoryId** (int or string, optional): Id of the parent category.


### Authentication and Authorization

- **OAuth0** : Authentication via OAuth0.





