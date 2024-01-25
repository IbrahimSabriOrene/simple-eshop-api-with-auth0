-- Use or create the database

-- Create Categories table
CREATE TABLE Categories (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(255),
    -- other fields
);

-- Create SubCategories table
CREATE TABLE SubCategories (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(255),
    ParentCategoryId UNIQUEIDENTIFIER,
    FOREIGN KEY (ParentCategoryId) REFERENCES Categories(Id),
    -- other fields
);

-- Create Products table
CREATE TABLE Products (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(18, 2),
    Image NVARCHAR(MAX),
    Stock INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    SubCategoryId UNIQUEIDENTIFIER,
    FOREIGN KEY (SubCategoryId) REFERENCES SubCategories(Id),
    -- other fields
);

-- Create SubCategoryProducts table

-- Insert sample data into Categories table
INSERT INTO Categories (Id, Name, Description)
VALUES
    (NEWID(), 'Electronics', 'Electronics and Gadgets'),
    (NEWID(), 'Clothing', 'Fashion and Apparel');

-- Insert sample data into SubCategories table
INSERT INTO SubCategories (Id, Name, Description, ParentCategoryId)
VALUES
    (NEWID(), 'Smartphones', 'Mobile Phones and Accessories', (SELECT Id FROM Categories WHERE Name = 'Electronics')),
    (NEWID(), 'Laptops', 'Laptops and Notebooks', (SELECT Id FROM Categories WHERE Name = 'Electronics')),
    (NEWID(), 'T-Shirts', 'Casual T-Shirts', (SELECT Id FROM Categories WHERE Name = 'Clothing')),
    (NEWID(), 'Dresses', 'Formal Dresses', (SELECT Id FROM Categories WHERE Name = 'Clothing'));

-- Insert sample data into Products table
INSERT INTO Products (Id, Name, Description, Price, Image, Stock, SubCategoryId)
VALUES
    (NEWID(), 'iPhone 13', 'Latest iPhone model', 999.99, 'iphone_image.jpg', 50, (SELECT Id FROM SubCategories WHERE Name = 'Smartphones')),
    (NEWID(), 'Dell XPS 13', 'Powerful laptop for professionals', 1299.99, 'dell_xps_image.jpg', 30, (SELECT Id FROM SubCategories WHERE Name = 'Laptops')),
    (NEWID(), 'Cotton T-Shirt', 'Comfortable casual t-shirt', 19.99, 'cotton_tshirt_image.jpg', 100, (SELECT Id FROM SubCategories WHERE Name = 'T-Shirts')),
    (NEWID(), 'Evening Gown', 'Elegant evening dress', 149.99, 'evening_gown_image.jpg', 20, (SELECT Id FROM SubCategories WHERE Name = 'Dresses'));

