# User CRUD Application

This repository contains a simple CRUD (Create, Read, Update, Delete) application for managing user information. The application is built using Microsoft's ASP.NET Core framework and Entity Framework Core for database operations.

## Overview

The User CRUD application provides a RESTful API for managing user data. It allows you to perform the following operations:

- **Get All Users**: Retrieve a list of all users.
- **Get Single User**: Retrieve information for a specific user based on their ID.
- **Insert User**: Add a new user to the system.
- **Update User**: Modify the details of an existing user.
- **Delete User**: Remove a user from the system.

## Technologies Used

- **ASP.NET Core**: The web framework used to build the API.
- **Entity Framework Core**: Object-Relational Mapping (ORM) for database operations.
- **C#**: The programming language used for the application.
- **Microsoft SQL Server**: The relational database used to store user information.

## Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/UserCRUDApplication.git
   
2. **Open the solution in Visual Studio or your preferred IDE.**

3. **Configure the database connection in the appsettings.json file.**

4. **Run the application. The database will be created and seeded with sample data.**

This API provides basic CRUD operations (Create, Read, Update, Delete) for managing user information. It is built using Microsoft's ASP.NET Core framework and Entity Framework Core for database operations.

## API Endpoints

### 1. Get All Users

- **Endpoint**: `GET /api/User/GetAllUsers`

### 2. Get Single User

- **Endpoint**: `GET /api/User/GetUser/{id}`
- **Parameters**: `{id}` - ID of the user to retrieve.

### 3. Insert User

- **Endpoint**: `POST /api/User/InsertUser`
- **Request Body**: JSON object with user details (FirstName, LastName, UserName, Password).

### 4. Update User

- **Endpoint**: `PUT /api/User/UpdateUser/{id}`
- **Parameters**: `{id}` - ID of the user to update.
- **Request Body**: JSON object with updated user details.

### 5. Delete User

- **Endpoint**: `DELETE /api/User/deleteUser/{id}`
- **Parameters**: `{id}` - ID of the user to delete.

## Sample Requests

Here are some sample requests using `curl` for testing the API:

1. **Get All Users:**
   ```bash
   curl -X GET https://localhost:7057/api/User/GetAllUsers
2. **Get Single User:**
   ```bash
   curl -X GET http://localhost:5000/api/User/GetUser/1

3. **Insert User:**
   ```bash
   curl -X POST -H "Content-Type: application/json" -d '{"FirstName": "John", "LastName": "Doe", "UserName": "john.doe", "Password": "password123"}' http://localhost:5000/api/User/InsertUser

4. **Update User:**
   ```bash
   curl -X PUT -H "Content-Type: application/json" -d '{"FirstName": "Updated", "LastName": "User", "UserName": "updated.user", "Password": "newpassword"}' http://localhost:5000/api/User/UpdateUser/1

5. **Delete User:**
   ```bash
   curl -X DELETE http://localhost:5000/api/User/deleteUser/1

