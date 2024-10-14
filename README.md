
# XYZ University API

## Overview
The XYZ University API allows Family Bank to securely communicate payment information to XYZ University in real time. The API includes endpoints for validating student information and receiving payment notifications, which are then stored in a database for further processing.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [Usage](#usage)
  - [Endpoints](#endpoints)
- [Error Handling](#error-handling)
- [Security Considerations](#security-considerations)
- [Contributing](#contributing)
- [License](#license)

## Features
- **Student Validation**: Validate students based on admission number before processing payments.
- **Payment Notification**: Receive and process payment notifications from Family Bank in real-time.
- **Data Storage**: Store student and payment data securely in a MySQL database.
- **Error Handling**: Provides meaningful error messages for failed operations.
- **Swagger Integration**: API documentation using Swagger UI.

## Technologies Used
- ASP.NET Core 6
- Entity Framework Core
- MySQL
- Swagger for API documentation
- Dependency Injection for service management
- JWT Authentication 

# Getting Started

## Prerequisites
- .NET 6 SDK or later
- MySQL Server installed and running.
- Visual Studio Code or Visual Studio for development.

## Installation
Clone the repository:

```bash
git clone https://github.com/yourusername/XYZUniversityStudentPaymentAPI.git
cd XYZUniversityStudentPaymentAPI
```

## Restore NuGet packages:

```bash
dotnet restore
```

## Database Setup

### Update the `appsettings.json` file with your MySQL connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=student_info;User=root;Password=YourPassword;"
  }
}
```

## Running the Application
Start the application using the following command:

```bash
dotnet run
```

By default, the application will be accessible at:

```
https://localhost:<port>
```

You can access the Swagger documentation at:

```
https://localhost:<port>/swagger
```


# Usage

## Endpoints

- **POST** `/api/v1/payments/notification`

  Receives a payment notification and saves it to the database.

  Sample Request Body:

  ```json
  {
    "paymentId": 0,
    "transactionId": "string",
    "admNo": "string",
    "amount": 0,
    "paymentDate": "2024-10-14T05:56:13.083Z",
    "paymentStatus": "string",
    "bankReference": "string",
    "paymentMethod": "string",
    "processedDate": "2024-10-14T05:56:13.083Z"
  }
  ```

- **GET** `/api/v1/students/validation`

  Validates if a student exists in the database using their admission number.

## Error Handling
The API uses global error handling middleware and custom error handling to catch and log errors. It returns appropriate HTTP status codes and messages:

- **400** Bad Request for validation errors.
- **404** Not Found when a requested resource is missing.
- **500** Internal Server Error for unhandled exceptions.
- **00** Success.
- **01** Failed.

# Security Considerations
- **Input Validation**: Ensure that all input data is validated to prevent SQL Injection and other attacks.
- **JWT Authentication**: Implement JWT-based authentication for securing endpoints.
- **HTTPS**: Ensure that the API runs over HTTPS in production to secure data in transit.

# Contributing
Contributions are welcome! Please fork this repository, make your changes, and submit a pull request for review.

# License
This project is licensed under the MIT License. See the LICENSE file for more details.
