Product Catalog API

Project Description
-------------------
Product Catalog API is a RESTful API built with .NET 9 that allows you to manage products and users.
It supports:

- CRUD operations on products
- Filtering and pagination
- JWT-based authentication
- PostgreSQL database

The API comes with seeded sample products across multiple categories like Electronics, Books, Clothing, Home, Sports, Toys.

Prerequisites
-------------
Before running the project, make sure you have:

- .NET 9 SDK
- Docker
- Docker Compose

Setup Instructions
------------------
1. Clone the repository:

git clone https://github.com/Taco5k/Product-Catalog-API.git
cd Product-Catalog-API

2. Run the project with Docker Compose:

docker-compose up --build

3. The API will be available at:

http://localhost:5000

4. Swagger documentation is accessible at:

http://localhost:5000/swagger/index.html

Configuration
-------------
The project reads configuration from environment variables, already set in docker-compose.yml:

"ConnectionStrings": {
  "DefaultConnection": "Server=db;Port=5432;Database=ProductCatalogAPI;User Id=postgres;Password=postgres;trust server certificate=true"
}

- JWT Secret: Set in appsettings.json or as environment variable TokenKey.

API Endpoints
-------------

Authentication

POST /auth/register
Register a new user.

Request Body:
{
  "email": "user@example.com",
  "password": "password123"
}

Response: 200 OK

POST /auth/login
Login to get JWT token.

Request Body:
{
  "email": "user@example.com",
  "password": "password123"
}

Response:
{
  "token": "<JWT_TOKEN>"
}

Products

GET /products
List products with optional filters.

Query Parameters:

- search — search by name
- category — filter by category
- minPrice — minimum price
- maxPrice — maximum price
- pageNumber — page number (default 1)
- pageSize — items per page (default 10, max 50)

Example:
GET /products?category=Electronics&minPrice=50&maxPrice=1000&pageNumber=1&pageSize=10

POST /products
Create a new product (requires authorization).

Request Body:
{
  "name": "New Product",
  "description": "Product description",
  "category": "Electronics",
  "price": 199.99
}

Response: 201 Created

DELETE /products/{id}
Delete a product by ID (requires authorization).

Response:
- 204 No Content if deleted
- 404 Not Found if product does not exist
