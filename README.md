# AutoCraft - Vehicle Manufacturer Inventory and Manufacturing System

## Overview

Welcome to AutoCraft, the solution for designing and developing a distributed, highly scalable system to automate
inventory and manufacturing processes for a vehicle manufacturer. This system aims to fulfill the basic tenets of
modularity, maintainability, and scalability, catering to the needs of a manufacturer with 3 independent factories
producing various vehicle components (Engines, Chassis & Option packs) on demand, along with a warehouse for storing
finished components and assembled vehicles.

## High-level System Process

At a high-level, customers place orders for vehicles, customizing them using three different components. The system
receives customer orders, checks for available stock in the warehouse, and schedules production for any unavailable
components. Once all components are available, the vehicle is assembled and delivered to the warehouse for collection.
Throughout the process, customers are kept informed of the order progress and have the option to cancel orders before
collection.

## Required Solution

The AutoCraft app is .NET Core-based and written in C#, incorporating various architectural patterns and best practices.
While the scenario is open-ended, it's recommended to consider the following elements:

- Containerization
- Microservice/Serverless architecture patterns
- Mediator patterns
- CQRS patterns
- DDD patterns
- Event-based patterns

Additionally, demonstrating the following aspects would be beneficial:

- Structured Logging
- Request Correlation
- Error handling
- Configuration

## Getting Started

To get started with the AutoCraft app, follow these steps:

1. **Clone the Repository:** Clone this repository to your local machine using:

   ```
   git clone https://github.com/yourusername/auto-craft-app.git
   ```

2. **Install Dependencies:** Navigate to the project directory and install dependencies using:

   ```
   cd auto-craft-app
   dotnet restore
   ```

3. **Build the Solution:** Build the solution using:

   ```
   dotnet build
   ```

4. **Run the Application:** Run the application using:

   ```
   dotnet run
   ```

## Directory Structure

The AutoCraft app repository is structured as follows:

- **/application**: Contains application-specific logic and services.
- **/Docker**: Contains Docker-related files for containerization.
- **/domain**: Contains domain models and business logic.
- **/infrastructure**: Contains infrastructure-related code, such as database access and external integrations.
- **/presentation**: Contains presentation layer code, including API endpoints or user interfaces.
- **AutoCraftApp.sln**: Solution file for the AutoCraft app.
- **README.md**: This file providing an overview of the project.
