-- ===========================================
-- ADD FOREIGN KEYS & CONSTRAINTS
-- ===========================================

-- PRODUCTS → CATEGORIES
ALTER TABLE Products
ADD CONSTRAINT FK_Products_Categories
FOREIGN KEY (CategoryId)
REFERENCES Categories(CategoryId)

-- REVIEWS → PRODUCTS
ALTER TABLE Reviews
ADD CONSTRAINT FK_Reviews_Products
FOREIGN KEY (ProductId)
REFERENCES Products(ProductId)

-- Nếu muốn liên kết review với khách hàng:
ALTER TABLE Reviews
ADD CONSTRAINT FK_Reviews_Customers
FOREIGN KEY (UserId)
REFERENCES Customers(CustomerId)

-- BILLS → CUSTOMERS
ALTER TABLE Bills
ADD CONSTRAINT FK_Bills_Customers
FOREIGN KEY (CustomerId)
REFERENCES Customers(CustomerId)

--  BILLS → STAFFS
ALTER TABLE Bills
ADD CONSTRAINT FK_Bills_Staffs
FOREIGN KEY (StaffId)
REFERENCES Staffs(UserId)

-- BILLS → PRODUCTS (nếu 1 đơn hàng chỉ chứa 1 sản phẩm)
ALTER TABLE Bills
ADD CONSTRAINT FK_Bills_Products
FOREIGN KEY (ProductId)
REFERENCES Products(ProductId)

-- BILLDETAIL → BILLS
ALTER TABLE BillDetail
ADD CONSTRAINT FK_BillDetail_Bills
FOREIGN KEY (OrderId)
REFERENCES Bills(OrderId)

-- BILLDETAIL → PRODUCTS
ALTER TABLE BillDetail
ADD CONSTRAINT FK_BillDetail_Products
FOREIGN KEY (ProductId)
REFERENCES Products(ProductId)

-- ===========================================
-- ADD UNIQUE & CHECK CONSTRAINTS
-- ===========================================

-- Staffs: không trùng email hoặc số điện thoại
ALTER TABLE Staffs
ADD CONSTRAINT UQ_Staffs_Email UNIQUE (Email),
    CONSTRAINT UQ_Staffs_Phone UNIQUE (PhoneNumber);

-- Customers: không trùng email hoặc số điện thoại
ALTER TABLE Customers
ADD CONSTRAINT UQ_Customers_Email UNIQUE (Email),
    CONSTRAINT UQ_Customers_Phone UNIQUE (PhoneNumber);

-- Products: giá khuyến mãi phải <= giá gốc
ALTER TABLE Products
ADD CONSTRAINT CK_Products_Price CHECK (PromotionPrice <= Price);

-- Bills: tổng tiền phải > 0
ALTER TABLE Bills
ADD CONSTRAINT CK_Bills_TotalAmount CHECK (TotalAmount > 0);

-- BillDetail: số lượng > 0, tổng tiền > 0
ALTER TABLE BillDetail
ADD CONSTRAINT CK_BillDetail_Quantity CHECK (Quantity > 0),
    CONSTRAINT CK_BillDetail_Total CHECK (TotalPrice > 0);
