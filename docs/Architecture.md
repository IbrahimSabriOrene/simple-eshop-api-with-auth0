
### Product

- **Id** (int or string): Unique identifier for the product.
- **Name** (string): Name of the product.
- **Description** (string): Detailed description of the product.
- **Price** (decimal): Price of the product.
- **Image** (string): URL or path to the product image.
- **Category** (string): Category of the product.
- **Stock** (int): Available stock of the product.
- **CreatedAt** (DateTime): Date and time of product creation.
- **UpdatedAt** (DateTime): Date and time of last product update.

### Category

- **Id** (int or string): Unique identifier for the category.
- **Name** (string): Category name.
- **Description** (string): Description of the category.
- **ParentCategoryId** (int or string, optional): Id of the parent category.

### Role

- **Id** (int or string): Unique identifier for the role.
- **Name** (string): Name of the role.
- **Description** (string): Description of the role's permissions.

### User

- **Id** (int or string): Unique identifier for the user.
- **Username** (string): Username for login.
- **Password** (string): Hashed password. -> this wont be in usermodel, this is OAUTH feature.
- **Email** (string): User email address.
- **FirstName** (string): User's first name.
- **LastName** (string): User's last name.
- **Roles** (ICollection<Role>): List of roles assigned to the user.

### Order

- **Id** (int or string): Unique identifier for the order.
- **UserId** (foreign key to User table): User who placed the order.
- **OrderDate** (DateTime): Date and time of order placement.
- **OrderStatus** (string): Current status of the order.
- **TotalAmount** (decimal): Total amount of the order.
- **ShippingAddress** (string): Address for delivery.
- **BillingAddress** (string): Address for billing.

### OrderItem

- **Id** (int or string): Unique identifier for the order item.
- **OrderId** (foreign key to Order table): Order the item belongs to.
- **ProductId** (foreign key to Product table): Product for the order item.
- **Quantity** (int): Number of items ordered.
- **UnitPrice** (decimal): Price of the item at the time of order.

# Relationships

- Products have a one-to-many relationship with OrderItems.
- Categories can have a one-to-many relationship with child categories (optional).
- Orders belong to a single User.
- OrderItems belong to a single Order and a single Product.

# Authentication and Authorization

- JWT (JSON Web Token) authentication will be implemented.
- Users register and log in with username/password.
- Upon successful login, the server generates a JWT token containing user information and claims.
- Subsequent requests include the JWT token in the authorization header for authentication.
- API endpoints will be authorized based on user roles and claims using authorization attributes.

# Database

- SQL Server or other relational database is recommended.
- Tables will be created for Products, Categories, Roles, Users, Orders, OrderItems, and UserRoles (to map user-role relationships).

# File Architecture

- **Models**: Definitions for all data entities.
- **Controllers**: Handle API requests and responses.
- **Services**: Business logic for managing data and operations.
- **Repository**: Abstraction layer for accessing and modifying data.
- **Infrastructure**: Database context and related configuration.
- **Startup**: Application configuration and service registration.
- **Program**: Main entry point for the application.
- Additional files: AppSettings.json, logging configuration, etc.

# Development Tools

- Visual Studio or other IDE
- ASP.NET Core MVC or Web API framework
- Entity Framework Core for database access
- JWT libraries for authentication
- Unit testing framework like NUnit or xUnit

# Deployment

- Docker containers for containerization and deployment
- Azure App Service or other cloud platform

# Further Considerations

- Secure password storage and hashing.
- Error handling and logging.
- Unit tests and code coverage.
- User interface for managing products, orders, users, etc.
- Payment gateway integration for online payments.
- Email notifications for order confirmation, etc.

