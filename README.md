# Retail Management System

This project is a **Retail Management System** built with **React + TypeScript + Vite** for the frontend and **.NET 8** for the backend.  
It provides a complete solution for managing products, orders, users, groups, and employee data with role-based access.

---

## Project Overview

### Frontend
- Built with **React, TypeScript, and Vite**  
- Supports **Admin** and **User** roles  
- Admin can manage products, users, stock, carts, reports, and settings  
- User can manage products, carts, stock, and view reports  
- Manager section allows filtering reports by specific dates  

### Backend
- Built with **.NET 8**  
- Provides **RESTful APIs** for products, orders, users, groups, and employees  
- Uses **JWT authentication**  
- Includes **Swagger** for testing endpoints  
- Connects to a **local SQL Server database** (script included in repository)

---

## Test Users

- **Admin**  
  Email: `bobo@gmail.com`  
  Password: `bobo1234`

- **User**  
  Email: `susu@gmail.com`  
  Password: `susu1234`

---

## Prerequisites

- Node.js >= 18  
- npm >= 9  
- .NET 8 SDK  
- SQL Server (local or network)  

---

## Setup Instructions

### 1. Import Database

1. Open **SQL Server Management Studio (SSMS)**  
2. Create a new database (e.g., `RetailDB`)  
3. Open the provided SQL script from the backend repository  
4. Execute the script to create tables, stored procedures, and seed data  

> **Important:** Make sure the connection string in `appsettings.json` matches your local SQL Server configuration.

---

### 2. Backend Setup

1. Clone the backend repository:


git clone https://github.com/KhunMaungNgwee/RetailManagementAPI.git


Open the solution in Visual Studio

Restore NuGet packages

Run the project using IIS Express to ensure the correct port configuration with the frontend

Test the APIs using Swagger at:

https://localhost:<port>/swagger/index.html

3. Frontend Setup

Clone the frontend repository:

git clone https://github.com/KhunMaungNgwee/Retail-React-Project.git


Navigate to the project folder:

cd Retail-React-Project


Install dependencies:

npm install


Start the development server:

npm run dev


Open the browser at the URL shown in the terminal (usually http://localhost:5173)

Backend Endpoints
Employee

GET /GetAllEmployeeEXTByCompanyID?Cid=<companyId>

POST /FileUpload (multipart file upload)

Group

GET /GetAllGroup

GET /GetGroupByID?id=<id>

POST /AddNewGroup

POST /UpdateGroup

POST /DeleteGroup?gid=<groupId>

Login / User

POST /api/v1/Login/UserLogin

POST /api/v1/Login/AddNewUser

Product

GET /api/v1/Product/GetAllProduct

GET /api/v1/Product/GetProductById?id=<id>

POST /api/v1/Product/AddNewProduct

POST /api/v1/Product/UpdateProduct

POST /api/v1/Product/DeleteProduct?id=<id>

GET /api/v1/Product/GetAllProductsWithPagination?page=1&pageSize=10

GET /api/v1/Product/GetProductOrderWithPagination?page=1&pageSize=10&startDate=<date>&endDate=<date>

Order

POST /api/v1/Order/CalculateCost?productid=<id>&quantity=<qty>

POST /api/v1/Order/PurchaseProduct

GET /api/v1/Order/GetAllOrder

GET /api/v1/Order/GetOrderById?oid=<id>

GET /api/v1/Order/GetOrderByProductID?pid=<productId>

Weather (Example)

GET /WeatherForecast

Security

All endpoints require JWT Bearer Token authentication

Include the token in the Authorization header:

Bearer <your-token>

Notes

Ensure the backend is running first so that the frontend can connect successfully

Import the database script before running the backend

Frontend and backend ports should match for proper API communication
