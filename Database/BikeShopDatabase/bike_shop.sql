CREATE DATABASE BikeShop;
GO

USE BikeShop;
GO

-- ===========================================
-- PRODUCTS
-- ===========================================
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1, 1),
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    PromotionPrice DECIMAL(18, 2) NOT NULL,
    ProductDescription NVARCHAR(255) NULL,
    TagName NVARCHAR(100) NULL,
    CategoryId INT NOT NULL,                 -- FK to Categories
    States TINYINT NOT NULL DEFAULT 1,       -- 0 = Stopped, 1 = On Sale, 2 = Out of Stock, 3 = Hidden
    ProductType NVARCHAR(255) NOT NULL,
	ImageUrl NVARCHAR(255) NULL,
);
GO

INSERT INTO Products (ProductName, Price, PromotionPrice, ProductDescription, TagName, CategoryId, States, ProductType, ImageUrl)
VALUES
-- BIKES
(N'Mountain Bike Alpha', 750.00, 699.00, N'Strong alloy frame, 27 gears, durable tires.', N'Mountain', 1, 1, N'Bike', N'bik1.jpg'),
(N'Mountain Bike GreenX', 780.00, 720.00, N'Lightweight frame, Shimano gears, disc brakes.', N'Mountain', 1, 1, N'Bike', N'bik1.jpg'),
(N'Mountain Bike SkyBlue', 820.00, 770.00, N'Perfect for off-road rides, hydraulic brakes.', N'Mountain', 1, 1, N'Bike', N'bik1.jpg'),
(N'Mountain Bike Shadow', 890.00, 850.00, N'Carbon fork, strong grip tires.', N'Mountain', 2, 1, N'Bike', N'bik1.jpg'),
(N'Single Speed Aero', 400.00, 350.00, N'Simple and sleek design for city use.', N'SingleSpeed', 2, 1, N'Bike', N'bik2.jpg'),
(N'Single Speed Racer', 420.00, 370.00, N'Classic single speed with lightweight frame.', N'SingleSpeed', 2, 1, N'Bike', N'bik2.jpg'),
(N'Single Speed Metro', 450.00, 390.00, N'Urban style, minimal maintenance.', N'SingleSpeed', 3, 1, N'Bike', N'bik2.jpg'),
(N'Single Speed WhiteLine', 480.00, 420.00, N'Elegant white design for smooth riding.', N'SingleSpeed', 3, 1, N'Bike', N'bik2.jpg'),
(N'Road Bike Flash', 950.00, 899.00, N'Light carbon frame, 18 gears, fast performance.', N'Road', 2, 1, N'Bike', N'bik3.jpg'),
(N'Road Bike Sprint', 980.00, 930.00, N'Perfect for long distance rides and speed.', N'Road', 3, 1, N'Bike', N'bik3.jpg'),
(N'Road Bike OrangeX', 1020.00, 950.00, N'High traction tires, aerodynamic design.', N'Road', 3, 1, N'Bike', N'bik3.jpg'),
(N'Road Bike SilverWing', 1100.00, 1049.00, N'Premium road bike with race-level parts.', N'Road', 2, 1, N'Bike', N'bik3.jpg'),

-- PARTS
(N'KMC Z8.3 Bike Chain', 12.99, 10.99, N'Durable 8-speed chain for city and mountain bikes.', N'chain', 4, 1, N'Part', N'p1.jpg'),
(N'Shimano CN-HG601 Chain', 24.99, 19.99, N'Shimano 11-speed chain with SIL-TEC coating.', N'chain', 6, 1, N'Part', N'p1.jpg'),
(N'Schwalbe Inner Tube 700x23C', 7.99, 6.49, N'High-quality road bike inner tube with Presta valve.', N'tube', 7, 1, N'Part', N'p1.jpg'),
(N'Michelin Airstop Tube 26x1.75', 6.49, 5.49, N'Durable inner tube for MTB bikes.', N'tube', 4, 1, N'Part', N'p2.jpg'),
(N'Continental Grand Prix 5000 Tire', 64.99, 59.99, N'Performance road tire with excellent grip and durability.', N'tire', 2, 1, N'Part', N'p2.jpg'),
(N'Maxxis Minion DHF Tire 27.5"', 59.99, 54.99, N'MTB tire designed for aggressive trail riding.', N'tire', 6, 1, N'Part', N'p2.jpg'),
(N'Shimano XT Disc Brake Set', 89.99, 79.99, N'Hydraulic disc brake for powerful stopping performance.', N'disc-brake', 2, 1, N'Part', N'p3.jpg'),
(N'Tektro HD-M275 Disc Brake', 74.50, 69.00, N'Affordable hydraulic brake set for beginners.', N'disc-brake', 7, 1, N'Part', N'p3.jpg'),
(N'SRAM Centerline Rotor 160mm', 29.90, 24.99, N'Smooth braking and low vibration rotor.', N'disc-brake', 7, 1, N'Part', N'p4.jpg'),
(N'Shimano BR-MT200 Brake Pads', 12.50, 10.99, N'Replacement pads for disc brakes.', N'disc-brake', 4, 1, N'Part', N'p4.jpg'),

-- ACCESSORIES
(N'KMC Z8.3 Bike Chain', 12.99, 10.99, N'Durable 8-speed chain for city and mountain bikes.', N'chain', 11, 1, N'Accessories', N'a1.jpg'),
(N'Shimano CN-HG601 Chain', 24.99, 19.99, N'Shimano 11-speed chain with SIL-TEC coating.', N'chain', 8, 1, N'Accessories', N'a1.jpg'),
(N'Schwalbe Inner Tube 700x23C', 7.99, 6.49, N'High-quality road bike inner tube with Presta valve.', N'tube', 9, 1, N'Accessories', N'a1.jpg'),
(N'Michelin Airstop Tube 26x1.75', 6.49, 5.49, N'Durable inner tube for MTB bikes.', N'tube', 11, 1, N'Accessories', N'a2.jpg'),
(N'Continental Grand Prix 5000 Tire', 64.99, 59.99, N'Performance road tire with excellent grip and durability.', N'tire', 2, 1, N'Accessories', N'a2.jpg'),
(N'Maxxis Minion DHF Tire 27.5"', 59.99, 54.99, N'MTB tire designed for aggressive trail riding.', N'tire', 8, 1, N'Accessories', N'a2.jpg'),
(N'Shimano XT Disc Brake Set', 89.99, 79.99, N'Hydraulic disc brake for powerful stopping performance.', N'disc-brake', 2, 1, N'Accessories', N'a3.jpg'),
(N'Tektro HD-M275 Disc Brake', 74.50, 69.00, N'Affordable hydraulic brake set for beginners.', N'disc-brake', 9, 1, N'Accessories', N'a3.jpg'),
(N'SRAM Centerline Rotor 160mm', 29.90, 24.99, N'Smooth braking and low vibration rotor.', N'disc-brake', 7, 1, N'Accessories', N'a4.jpg'),
(N'Shimano BR-MT200 Brake Pads', 12.50, 10.99, N'Replacement pads for disc brakes.', N'disc-brake', 10, 1, N'Accessories', N'a4.jpg')

-- ===========================================
-- TAG NAME
-- ===========================================
CREATE TABLE Tags (
    TagId INT PRIMARY KEY IDENTITY(1, 1),
    TagName NVARCHAR(100) NOT NULL
);
GO

INSERT INTO Tags (TagName)
VALUES
(N'Mountain'),
(N'SingleSpeed'),
(N'Road'),
(N'chain'),
(N'tube'),
(N'tire'),
(N'disc-brake'),
(N'lock'),
(N'helmet'),
(N'arm-cover'),
(N'jersey'),
(N'gloves'),
(N'light');

-- ===========================================
-- CATEGORIES
-- ===========================================
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1, 1),
    CategoryName NVARCHAR(100) NOT NULL,     -- BIKE = 1, PARTS = 2, ACCESS = 3
    States TINYINT NOT NULL DEFAULT 1,       -- 0 = Stopped, 1 = On Sale, 2 = Out of Stock, 3 = Hidden
    Slug NVARCHAR(150) NULL
);
GO

INSERT INTO Categories (CategoryName, States, Slug) VALUES
-- KEYS FROM 1 TO 3 => BIKE TYPE.
(N'FIXED / SINGLE SPEED', 1, 'fixed-single-speed'),
(N'CITY BIKES', 1, 'city-bikes'),
(N'PREMIUM SERIES', 1, 'premium-series'),

-- KEYS FROM 4 TO 7 => PART TYPE.
(N'CHAINS', 1, 'chains'),
(N'TUBES', 1, 'tubes'),
(N'TIRES', 1, 'tires'),
(N'DISC BREAKS', 1, 'disc-breaks'),

-- Level 8 TO 11 - ACCESSORIES
(N'LOCKS', 1, 'locks'),
(N'HELMETS', 1, 'helmets'),
(N'ARM COVERS', 1, 'arm-covers'),
(N'JERSEYS', 1, 'jerseys');

-- ===========================================
-- REVIEWS
-- ===========================================
CREATE TABLE Reviews (
    ReviewId INT PRIMARY KEY IDENTITY(1, 1),
    UserId INT NULL,
    UserName NVARCHAR(100) NOT NULL,
    ParentId INT NULL,
    Content TEXT NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    DateTimes DATE NOT NULL DEFAULT GETDATE(),
    ProductId INT NOT NULL                   -- FK to Products
);
GO

-- ===========================================
-- USERS
-- ===========================================
CREATE TABLE Staffs (
    UserId INT IDENTITY(1, 1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL,
    HashedPassword NVARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL,
    StaffAddress NVARCHAR(255) NOT NULL,
    Roles TINYINT NOT NULL, --1=Staff, 0=Admin
    States TINYINT DEFAULT 1
);
GO

INSERT INTO Staffs (Username, HashedPassword, Email, PhoneNumber, StaffAddress, Roles, States)
VALUES
(N'admin', N'adminhashedpassword', 'admin@example.com', '0123456789', 'Di An, Binh Duong', 0, 1),
(N'staff', N'staffhashedpassword', 'staff@example.com', '0987654321', 'Phuong Dong Hoan, Di An, Binh Duong', 1, 1)

-- ===========================================
-- CUSTOMERS
-- ===========================================
CREATE TABLE Customers (
    CustomerId INT IDENTITY(1, 1) PRIMARY KEY,
    CustomerName NVARCHAR(100) NOT NULL,
    HashedPassword NVARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL,
    CustomerAddress NVARCHAR(255) NOT NULL,
    States TINYINT DEFAULT 1
);
GO

INSERT INTO Customers(CustomerName, HashedPassword, Email, PhoneNumber, CustomerAddress, States)
VALUES
(N'Bùi Minh Quân', 'minhquan', 'minhquan@gmail.com', '0978654321', 'Cu Chi, Thanh pho Ho Chi Minh', 1),
(N'Nguyễn Thái Nguyên', 'thainguyen', 'anhngontinh@gmail.com', '0967854321', 'Kien Tuong, Long An', 1)

-- ===========================================
-- BILLS (ORDERS)
-- ===========================================
CREATE TABLE Bills (
    OrderId INT PRIMARY KEY IDENTITY(1, 1),
    ProductId INT NOT NULL,                  -- FK to Products
    CustomerId INT NOT NULL,                 -- FK to Customers
    StaffId INT NOT NULL,                    -- FK to Staffs
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalItems INT NOT NULL,                 -- Total quantity
    TotalAmount DECIMAL(18, 2) NOT NULL               -- Total payment
);
GO

-- ===========================================
-- BILL DETAIL
-- ===========================================
CREATE TABLE BillDetail (
    OrderDetailId INT PRIMARY KEY IDENTITY(1, 1),
    OrderId INT NOT NULL,                    -- FK to Bills
    ProductId INT NOT NULL,                  -- FK to Products
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    PromotionPrice DECIMAL(18, 2) NOT NULL,
    Quantity INT NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL
);
GO

-- ===========================================
-- WEB SETTINGS
-- ===========================================
CREATE TABLE WebSettings (
    SettingId INT PRIMARY KEY IDENTITY(1, 1),
    Logo NVARCHAR(255) NOT NULL,
    MaxSizeImage INT NOT NULL,
    SettingDescription NVARCHAR(255) NULL,
    SettingURL NVARCHAR(255) NOT NULL,
    Header NVARCHAR(255) NOT NULL,
    Footer NVARCHAR(255) NOT NULL
);
GO

INSERT INTO WebSettings (Logo, MaxSizeImage, SettingDescription, SettingURL, Header, Footer)
VALUES
(N'logo.png', 4096, N'Website configuration for BikeShop', N'https://bikeshop.com', N'Welcome to BikeShop', N'© 2025 BikeShop. All rights reserved.');