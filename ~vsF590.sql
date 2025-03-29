CREATE DATABASE MyMvcDatabase;
GO
USE MyMvcDatabase;
CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Description NVARCHAR(255),
    ImageUrl NVARCHAR(255)
);
INSERT INTO Products (Name, Price, Description, ImageUrl) VALUES
('Laptop', 800.00, 'A powerful laptop for work.', 'laptop.jpg'),
('Phone', 500.00, 'Latest smartphone with great features.', 'phone.jpg'),
('Tablet', 300.00, 'Lightweight and portable tablet.', 'tablet.jpg');