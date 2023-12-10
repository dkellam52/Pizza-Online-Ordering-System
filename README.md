# **Pizza-Online-Ordering-System**
## Overview
**'PizzaOnlineOrderingSystem'** is a robust and user-friendly C# application developed for the Fall 2023 CS340 Ethics and Software Engineering class. Designed in Visual Studio, this application streamlines the process of ordering pizza online, offering functionalities like account creation, pizza ordering, order status tracking, order history review, and profile management.

Improvements: I ran out of time on this project, but if I had more time, I would have incorporated a member login to simplify members ordering pizza, editing profiles and checking order history. 

## Features
* Account Creation: Users can sign up to start placing pizza orders.

* Pizza Ordering: A diverse menu allows users to choose and order their favorite pizzas.

* Order Status: Enables users to track the status of their current orders in real-time.

* Order History: Users can view a history of their past orders.

* Profile Management: Provides functionality to update and manage personal and account information.

## Getting Started
### Prerequisites
* Visual Studio
* MySQL Database

### Installation
1. Clone the Repository:
   [bash](https://github.com/dkellam52/PizzaOnlineOrderingSystem.git)
2. Open the Solution in Visual Studio:
Navigate to the cloned directory and open PizzaOnlineOrderingSystem.sln.
3. Database Setup:
* Utilize the provided SQL file in the repository to set up your database schema.
* Modify the database connection string in the following classes as per your database configuration:
  * OrderPizza.cs
  * OrderManager.cs
  * Order.cs
  * History.cs
  * MemberManager.cs
  * Member.cs
4. Build and Run the Application:

Compile the solution and run the application to start using it.

## Usage
* Create an Account: Register a new account to begin ordering pizzas.
* Order Pizza: Log in, select and order pizzas from the menu.
* Check Order Status: Enter your order ID to view the current status of your order.
* View Order History: Access your past orders from your profile.
* Edit Profile: Update your personal and contact details in your account.
