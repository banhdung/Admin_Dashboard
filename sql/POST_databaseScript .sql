-- Tạo database POST
create database POST;
GO

-- Sử dụng database POST
USE POST;
GO

-- Tạo bảng ProductCategory
CREATE TABLE ProductCategory (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    category_name VARCHAR(25)
);

-- Tạo bảng ProductUnit
CREATE TABLE ProductUnit (
    unit_id INT IDENTITY(1,1) PRIMARY KEY,
    unit_name VARCHAR(15)
);

-- Tạo bảng Product
CREATE TABLE Product (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_code VARCHAR(25),
    product_name VARCHAR(50),
    unit_id INT,
    category_id INT,
    unit_in_stock FLOAT,
    unit_price FLOAT,
    discount_percentage FLOAT,
    reorder_level FLOAT,
    account_id INT
);

-- Tạo bảng Account
CREATE TABLE Account (
    account_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(30),
    password VARCHAR(30),
    fullname VARCHAR(50),
    designation INT,
    contact VARCHAR(50),
    role INT
);

-- Tạo bảng ReceiveProduct
CREATE TABLE ReceiveProduct (
    receive_product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    quantity FLOAT,
    unit_price FLOAT,
    sub_total FLOAT,
    supplier_id INT,
    received_date DATE,
    account_id INT
);

-- Tạo bảng PurchaseOrder
CREATE TABLE PurchaseOrder (
    purchase_order_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    quantity FLOAT,
    unit_price FLOAT,
    sub_total FLOAT,
    supplier_id INT,
    order_date DATE,
    account_id INT
);

-- Tạo bảng Sales
CREATE TABLE Sales (
    sales_id INT IDENTITY(1,1) PRIMARY KEY,
    invoice_id INT,
    product_id INT,
    quantity FLOAT,
    unit_price FLOAT,
    sub_total FLOAT
);

-- Tạo bảng Invoice
CREATE TABLE Invoice (
    invoice_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT,
    payment_type INT,
    total_amount FLOAT,
    amount_tendered FLOAT,
    bank_account_name VARCHAR(50),
    bank_account_number VARCHAR(25),
    date_recorded DATE,
    account_id INT
);

-- Tạo bảng Customer
CREATE TABLE Customer (
    customer_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_code VARCHAR(25),
    customer_name VARCHAR(50),
    contact VARCHAR(15),
    address VARCHAR(100),
	point int default 0
);

-- Tạo bảng Supplier
CREATE TABLE Supplier (
    supplier_id INT IDENTITY(1,1) PRIMARY KEY,
    supplier_code VARCHAR(15),
    supplier_name VARCHAR(50),
    supplier_contact VARCHAR(50),
    supplier_address VARCHAR(50),
    supplier_email VARCHAR(50)
);

INSERT INTO Product (product_code, product_name, unit_id, category_id, unit_in_stock, unit_price, discount_percentage, reorder_level, account_id)
VALUES
('R001', 'Rice', 1, 1, 100, 5.99, 0, 20, 1),
('M001', 'Milk', 3, 2, 50, 2.49, 0, 10, 2),
('C001', 'Potato Chips', 2, 3, 75, 1.99, 5, 30, 3),
('D001', 'Laundry Detergent', 6, 4, 30, 8.49, 0, 15, 4),
('T001', 'Toothpaste', 7, 5, 40, 1.99, 10, 20, 5),
('S001', 'Soda', 8, 2, 60, 1.29, 5, 25, 1),
('B001', 'Bananas', 1, 1, 40, 0.99, 0, 15, 1),
('W001', 'Water', 3, 2, 70, 1.49, 0, 30, 2),
('P001', 'Pasta', 1, 1, 80, 1.29, 0, 25, 3),
('C002', 'Cookies', 2, 3, 60, 2.49, 5, 20, 4),
('J001', 'Juice', 8, 2, 55, 1.79, 0, 25, 1),
('S002', 'Shampoo', 7, 5, 35, 3.99, 0, 10, 2),
('L001', 'Lemonade', 8, 2, 70, 1.99, 5, 30, 3),
('C003', 'Cereal', 1, 1, 65, 3.49, 0, 15, 4),
('C004', 'Canned Soup', 8, 1, 40, 1.49, 0, 20, 5),
('B002', 'Broccoli', 1, 1, 45, 0.79, 0, 30, 1),
('I001', 'Ice Cream', 3, 3, 25, 4.99, 0, 5, 2),
('P002', 'Paper Towels', 6, 4, 20, 6.99, 0, 10, 3),
('S003', 'Soap', 7, 5, 50, 0.99, 5, 40, 4),
('E001', 'Earbuds', 10, 10, 100, 19.99, 0, 50, 5),
('C005', 'Chips', 2, 3, 80, 1.79, 0, 35, 1),
('B003', 'Bread', 2, 1, 60, 2.49, 0, 20, 2),
('C006', 'Candy', 9, 3, 100, 0.99, 5, 40, 3),
('S004', 'Shaving Cream', 7, 5, 45, 2.49, 0, 20, 4),
('W002', 'Wine', 4, 2, 30, 8.99, 0, 10, 5),
('H001', 'Hand Sanitizer', 7, 6, 40, 1.29, 0, 20, 1),
('O001', 'Oatmeal', 1, 1, 55, 2.79, 0, 25, 2),
('P003', 'Peanut Butter', 2, 1, 50, 3.29, 0, 25, 3),
('S005', 'Sponges', 6, 4, 75, 1.49, 5, 30, 4),
('T002', 'Tissues', 6, 4, 60, 1.99, 0, 20, 5),
('D002', 'Dish Soap', 6, 4, 70, 1.29, 0, 30, 1),
('M002', 'Muffins', 2, 1, 35, 1.99, 0, 15, 2),
('P004', 'Pancake Mix', 1, 1, 45, 2.49, 0, 20, 3),
('C007', 'Coffee', 10, 2, 40, 6.99, 0, 15, 4),
('I002', 'Insect Repellent', 6, 7, 60, 4.99, 0, 25, 5),
('C008', 'Candles', 6, 8, 80, 0.99, 0, 35, 1),
('G001', 'Garbage Bags', 6, 4, 65, 5.49, 0, 30, 2),
('F001', 'Face Mask', 7, 5, 75, 0.49, 0, 40, 3),
('W003', 'Window Cleaner', 6, 4, 50, 1.79, 0, 25, 4),
('T003', 'Tea', 8, 2, 30, 2.99, 0, 10, 5),
('B004', 'Butter', 2, 1, 40, 2.19, 0, 20, 1),
('C009', 'Cat Food', 5, 9, 55, 0.89, 5, 30, 2),
('D003', 'Dishwasher Detergent', 6, 4, 45, 4.29, 0, 20, 3),
('F002', 'Frozen Pizza', 3, 1, 25, 3.99, 0, 10, 4),
('H002', 'Hair Gel', 7, 5, 60, 2.29, 0, 30, 5),
('I003', 'Ibuprofen', 1, 6, 70, 3.49, 0, 25, 1),
('L002', 'Lotion', 7, 5, 35, 1.99, 0, 15, 2),
('N001', 'Napkins', 6, 4, 40, 0.79, 0, 20, 3),
('P005', 'Pickle', 2, 1, 50, 1.29, 0, 25, 4),
('T004', 'Trash Bags', 6, 4, 55, 4.99, 0, 30, 5),
('C010', 'Cotton Swabs', 7, 5, 45, 1.09, 0, 20, 1),
('H003', 'Hand Soap', 6, 4, 40, 1.49, 0, 25, 2),
('S006', 'Sunscreen', 6, 7, 35, 4.29, 0, 15, 3),
('D004', 'Dental Floss', 9, 5, 60, 0.99, 0, 30, 4),
('M003', 'Mouthwash', 9, 5, 40, 2.49, 0, 20, 5),
('C011', 'Crackers', 2, 3, 65, 1.79, 0, 25, 1),
('B005', 'Bagels', 2, 1, 50, 1.99, 0, 30, 2),
('P006', 'Popcorn', 2, 3, 45, 1.29, 0, 20, 3),
('S007', 'Sponges', 6, 4, 80, 1.29, 0, 40, 4),
('W004', 'Waffles', 2, 1, 60, 2.29, 0, 30, 5);

INSERT INTO ReceiveProduct (product_id, quantity, unit_price, sub_total, supplier_id, received_date, account_id)
VALUES
-- 10 hàng đầu
(1, 50, 5.99, 299.50, 1, '2023-10-01', 1),
(2, 100, 2.49, 249.00, 2, '2023-10-02', 2),
(3, 80, 1.99, 159.20, 3, '2023-10-03', 3),
(4, 40, 8.49, 339.60, 4, '2023-10-04', 4),
(5, 60, 1.99, 119.40, 5, '2023-10-05', 5),
(6, 75, 1.29, 96.75, 1, '2023-10-06', 1),
(7, 90, 0.99, 89.10, 2, '2023-10-07', 2),
(8, 55, 2.49, 136.95, 3, '2023-10-08', 3),
(9, 65, 0.79, 51.35, 4, '2023-10-09', 4),
(10, 55, 2.19, 120.45, 5, '2023-10-10', 5),
-- 10 hàng tiếp theo
(11, 40, 1.79, 71.60, 1, '2023-10-11', 1),
(12, 35, 3.99, 139.65, 2, '2023-10-12', 2),
(13, 70, 1.99, 139.30, 3, '2023-10-13', 3),
(14, 65, 3.49, 226.85, 4, '2023-10-14', 4),
(15, 40, 1.49, 59.60, 5, '2023-10-15', 5),
(16, 45, 0.79, 35.55, 1, '2023-10-16', 1),
(17, 25, 4.99, 124.75, 2, '2023-10-17', 2),
(18, 20, 6.99, 139.80, 3, '2023-10-18', 3),
(19, 50, 0.99, 49.50, 4, '2023-10-19', 4),
(20, 100, 19.99, 1999.00, 5, '2023-10-20', 5),
-- 10 hàng tiếp theo
(21, 80, 1.79, 143.20, 1, '2023-10-21', 1),
(22, 60, 2.49, 149.40, 2, '2023-10-22', 2),
(23, 100, 0.99, 99.00, 3, '2023-10-23', 3),
(24, 45, 2.49, 112.05, 4, '2023-10-24', 4),
(25, 30, 8.99, 269.70, 5, '2023-10-25', 5),
(26, 40, 1.29, 51.60, 1, '2023-10-26', 1),
(27, 55, 2.79, 153.45, 2, '2023-10-27', 2),
(28, 50, 3.29, 164.50, 3, '2023-10-28', 3),
(29, 75, 1.49, 111.75, 4, '2023-10-29', 4),
(30, 60, 1.99, 119.40, 5, '2023-10-30', 5),
-- 10 hàng tiếp theo
(31, 70, 1.29, 90.30, 1, '2023-10-31', 1),
(32, 35, 1.99, 69.65, 2, '2023-11-01', 2),
(33, 45, 2.49, 112.05, 3, '2023-11-02', 3),
(34, 40, 6.99, 279.60, 4, '2023-11-03', 4),
(35, 60, 4.99, 299.40, 5, '2023-11-04', 5),
(36, 80, 0.99, 79.20, 1, '2023-11-05', 1),
(37, 35, 5.49, 192.15, 2, '2023-11-06', 2),
(38, 75, 0.49, 36.75, 3, '2023-11-07', 3),
(39, 50, 1.79, 89.50, 4, '2023-11-08', 4),
(40, 60, 2.99, 179.40, 5, '2023-11-09', 5),
(41, 40, 2.19, 87.60, 1, '2023-11-10', 1),
(42, 55, 0.89, 48.95, 2, '2023-11-11', 2),
(43, 45, 4.29, 193.05, 3, '2023-11-12', 3),
(44, 25, 3.99, 99.75, 4, '2023-11-13', 4),
(45, 60, 2.29, 137.40, 5, '2023-11-14', 5),
(46, 70, 3.49, 244.30, 1, '2023-11-15', 1),
(47, 35, 1.99, 69.65, 2, '2023-11-16', 2),
(48, 40, 0.79, 31.60, 3, '2023-11-17', 3),
(49, 50, 1.29, 64.50, 4, '2023-11-18', 4),
(50, 55, 4.99, 274.45, 5, '2023-11-19', 5);



-- Thêm dữ liệu mẫu cho bảng ProductCategory
INSERT INTO ProductCategory (category_name)
VALUES
('Groceries'), ('Beverages'), ('Snacks'), ('Household'), ('Personal Care'),
('Cleaning Supplies'), ('Health and Wellness'), ('Baby Care'), ('Pet Supplies'), ('Electronics');

-- Thêm dữ liệu mẫu cho bảng ProductUnit
INSERT INTO ProductUnit (unit_name)
VALUES
('Pound'), ('Ounce'), ('Gallon'), ('Liter'), ('Dozen'),
('Piece'), ('Quart'), ('Packet'), ('Can'), ('Bottle');

-- Thêm dữ liệu mẫu cho bảng Account (tài khoản)
-- Role 1 là quản lý, Role 2 là nhân viên
INSERT INTO Account (username, password, fullname, designation, contact, role)
VALUES
('manager1', 'password1', 'John Manager', 1, 'manager1@store.com', 1),
('manager2', 'password2', 'Jane Manager', 1, 'manager2@store.com', 1),
('clerk1', 'password3', 'David Clerk', 2, 'clerk1@store.com', 2),
('clerk2', 'password4', 'Emily Clerk', 2, 'clerk2@store.com', 2),
('cashier1', 'password5', 'Michael Cashier', 2, 'cashier1@store.com', 2),
('cashier2', 'password6', 'Sara Cashier', 2, 'cashier2@store.com', 2),
('manager3', 'password7', 'Chris Manager', 1, 'manager3@store.com', 1),
('clerk3', 'password8', 'Sophie Clerk', 2, 'clerk3@store.com', 2),
('cashier3', 'password9', 'Oliver Cashier', 2, 'cashier3@store.com', 2),
('cashier4', 'password10', 'Ella Cashier', 2, 'cashier4@store.com', 2);


-- Thêm dữ liệu mẫu cho bảng Customer
INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C001', 'Johns Grocery', '123-456-7890', '123 Main St, Cityville');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C002', 'Marys Mart', '456-789-1234', '456 Elm St, Townsville');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C003', 'Mark Mini Mart', '789-123-4567', '789 Oak St, Villageton');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C004', 'Lisas Local Store', '567-234-8901', '567 Maple St, Villagetown');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C005', 'Paul Pantry', '234-901-3456', '234 Oak St, Cityville');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C006', 'Evas Emporium', '890-123-6789', '890 Elm St, Townsville');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C007', 'Mikes Market', '123-567-2345', '123 Oak St, Citytown');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C008', 'Sarah Supermart', '456-789-2345', '456 Maple St, Villagetown');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C009', 'Toms Tuck Shop', '678-234-9012', '678 Elm St, Townville');

INSERT INTO Customer (customer_code, customer_name, contact, address)
VALUES ('C010', 'Nina Neighborhood Store', '345-901-1234', '345 Main St, Citytown');


-- Thêm dữ liệu mẫu cho bảng Supplier
INSERT INTO Supplier (supplier_code, supplier_name, supplier_contact, supplier_address, supplier_email)
VALUES
('S001', 'ABC Distributors', '800-123-4567', '456 Supplier St, Supplyville', 'abc@supplier.com'),
('S002', 'XYZ Wholesalers', '888-555-9999', '999 Bulk Blvd, Warehouse City', 'xyz@wholesaler.com'),
('S003', 'Green Goods Inc.', '777-444-3333', '333 Distributor Ave, Goods City', 'gg@greengoods.com'),
('S004', 'Best Buy Supply', '999-666-2222', '222 Wholesaler Rd, Buytown', 'info@bestbuy.com'),
('S005', 'Fresh Farms Ltd.', '777-888-5555', '555 Produce St, Farmville', 'fresh@farms.com'),
('S006', 'Wholesale Warehouse', '555-777-1111', '111 Bulk Blvd, Warehouseville', 'wholesale@warehouse.com'),
('S007', 'Global Goods', '666-999-4444', '444 Import Ave, Global City', 'global@goods.com'),
('S008', 'Oceanic Suppliers', '888-111-7777', '777 Shipper Rd, Oceantown', 'info@oceanicsuppliers.com'),
('S009', 'Direct Distributors', '111-444-8888', '888 Provider Ave, Directville', 'direct@dist.com'),
('S010', 'City Wholesale', '444-222-5555', '555 Wholesaler St, Citytown', 'city@wholesale.com');



-- Tạo các foreign key cho các bảng
ALTER TABLE Product
ADD CONSTRAINT FK_Product_Unit FOREIGN KEY (unit_id) REFERENCES ProductUnit(unit_id);

ALTER TABLE Product
ADD CONSTRAINT FK_Product_Category FOREIGN KEY (category_id) REFERENCES ProductCategory(category_id);

ALTER TABLE ReceiveProduct
ADD CONSTRAINT FK_ReceiveProduct_Product FOREIGN KEY (product_id) REFERENCES Product(product_id);

ALTER TABLE ReceiveProduct
ADD CONSTRAINT FK_ReceiveProduct_Supplier FOREIGN KEY (supplier_id) REFERENCES Supplier(supplier_id);

ALTER TABLE ReceiveProduct
ADD CONSTRAINT FK_ReceiveProduct_Account FOREIGN KEY (account_id) REFERENCES Account(account_id);

ALTER TABLE PurchaseOrder
ADD CONSTRAINT FK_PurchaseOrder_Product FOREIGN KEY (product_id) REFERENCES Product(product_id);

ALTER TABLE PurchaseOrder
ADD CONSTRAINT FK_PurchaseOrder_Supplier FOREIGN KEY (supplier_id) REFERENCES Supplier(supplier_id);

ALTER TABLE PurchaseOrder
ADD CONSTRAINT FK_PurchaseOrder_Account FOREIGN KEY (account_id) REFERENCES Account(account_id);

ALTER TABLE Sales
ADD CONSTRAINT FK_Sales_Invoice FOREIGN KEY (invoice_id) REFERENCES Invoice(invoice_id);

ALTER TABLE Sales
ADD CONSTRAINT FK_Sales_Product FOREIGN KEY (product_id) REFERENCES Product(product_id);

ALTER TABLE Invoice
ADD CONSTRAINT FK_Invoice_Customer FOREIGN KEY (customer_id) REFERENCES Customer(customer_id);

ALTER TABLE Invoice
ADD CONSTRAINT FK_Invoice_Account FOREIGN KEY (account_id) REFERENCES Account(account_id);


