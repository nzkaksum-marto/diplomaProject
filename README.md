# diplomaProject

This is a simple web application I built for selling musical instruments.  
The project started as a diploma project for my high school graduation, but I continued developing it as a learning project.  
It’s built with **ASP.NET Core MVC**, **C#**, and **MS SQL Server**, using a layered structure and the Identity system for users and roles.

## About the project

### 1. Users and roles
There are 3 types of users:

**1.1 Guest** – can browse products, use filters, and view the contacts page  
**1.2 Customer** – can log in, use the cart, order products, and save items as favorites  
**1.3 Admin** – full control over products, orders, users, + access to statistics  

---

### 2. Products and ordering

- Browse all products  
- Filter by category or brand  
- View details for each instrument  
- Add/remove items from the cart  
- Update quantities  
- Place an order and see the final price  
- View your order history  

---

### 3. Wishlist  
You can add or remove products from your personal favorites list.

---

### 4. Admin panel  
Admins can:

- Add, edit, and delete products  
- View customer orders  
- Remove customers who don’t have an order  
- See statistics such as number of clients, products, orders, and total revenue  

---

## Technologies used

**Backend:** ASP.NET Core MVC (.NET 6), C#, Entity Framework Core (Code First)  
**Database:** MS SQL Server 2022  
**Frontend:** HTML, CSS, Bootstrap, JavaScript, Razor Views  
**Architecture:** MVC pattern, ASP.NET Identity
