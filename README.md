# ItemsDotNetApi Documentation

## Description of the Web Application and Its Functionality

**Project Name:** ItemsDotNetApi

**Description:** The ItemsDotNetApi is a web API designed to perform CRUD operations on a collection of items, which include properties such as ID, name, description, and an optional image URL. This API is particularly useful for managing collections of various items, from inventory in a store to personal collectibles. The application is developed using .NET 7.0 and leverages Docker for containerization. By using Docker and Docker Compose, the application and its dependencies are encapsulated into containers, ensuring consistency across different development and production environments.

**Key Features:**
- Add, retrieve, update, and delete items.
- Auto migration of database schema on entity changes.
- Data persistence across container restarts using Docker volumes.
- API documentation and testing via Swagger UI.

## Docker Containerization

The application consists of two main Docker containers:
- **itemsdotnetapi:** This container runs the .NET 7.0 API application.
- **mssql-container:** This container runs Microsoft SQL Server.

These containers are managed and orchestrated using Docker Compose, which simplifies running multi-container Docker applications by defining services, networks, and volumes in a single file.

## Step-by-Step Guide to Running and Testing Your Application with Docker and Docker Compose

### Prerequisites
- Docker installed on your machine.
- Docker Compose installed on your machine.
- Git installed on your machine.

### Steps

1. **Clone the Repository:**
    ```sh
    git clone https://github.com/Tarek-Qa/ItemsDotNetApi.git
    cd ItemsDotNetApi
    ```

2. **Build and Run the Containers:**
    ```sh
    docker-compose up -d
    ```

3. **Access the Application:**
    - The API will be accessible at [http://localhost:8001](http://localhost:8001).
    - The SQL Server will be running on `localhost:8002`.

4. **Test the API Endpoints:**
    - You can use tools like Postman or curl to test the API endpoints.
    - Example to get all items: [http://localhost:8001/api/item](http://localhost:8001/api/item)

5. **Access Swagger UI for API documentation and testing:** [http://localhost:8001/swagger](http://localhost:8001/swagger)

## Description of the Technical Choices

**Framework Choice:** .NET 7.0

**Reason for Choosing .NET 7.0:**
- Robust and scalable framework.
- Good integration with SQL Server.
- Strong community support and extensive libraries.

**Tools and Libraries Used:**
- **Docker:** To containerize the application and the SQL Server.
- **Docker Compose:** To manage multi-container Docker applications.
- **Microsoft SQL Server:** As the database for storing item data.
- **Visual Studio:** For development and debugging.
- **Entity Framework Core:** For ORM (Object Relational Mapping) with auto migration.
- **Swagger (Swashbuckle):** For API documentation and testing.

## Docker and Docker Compose Setup

**Docker Containers:**
- **itemsdotnetapi:** This container runs the .NET 7.0 API application. The Dockerfile for this container sets up the necessary environment, restores dependencies, builds the application, and specifies the entry point.
- **mssql-container:** This container runs Microsoft SQL Server. It is configured with environment variables for the SQL Server settings and is exposed on a specific port.

**Networking:**

The containers are configured to communicate with each other using a custom Docker network named `apinetwork`. This network allows seamless interaction between the API container and the SQL Server container.

**Data Persistence:**

Data is persisted across container restarts using Docker volumes. This ensures that data is not lost when the containers are stopped or removed.

**Docker Compose Configuration:**

The `docker-compose.yml` file defines the services and their configurations. Both services are connected to the `apinetwork` to enable communication. Volumes are used to persist data.

## Warning : you have to delete the volumes file from docker if you run the app then you change the Entity and want it to do auto migration.
