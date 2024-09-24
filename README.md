LibraryAPI
Description
LibraryAPI is a .NET Core Web API for managing a library system. It allows users to manage authors, books, and the relationship between them. The API supports CRUD operations and has a structured organization to ensure clean, maintainable code.

Folder Structure
Below is an overview of the folder structure of the project, along with a description of each folder and its purpose:

Controllers/
This folder contains the API controllers that handle HTTP requests and return responses. Each controller corresponds to a specific entity in the system and is responsible for CRUD operations on that entity.

AuthorController.cs - Manages actions related to Author entity, including creation, reading, updating, and deletion of authors.
BookController.cs - Handles actions related to Book entity, such as adding, retrieving, updating, and deleting books.
PublishController.cs - Manages the relationship between authors and books through the Publish entity.
Models/
The Models folder contains the entity classes that represent the data structure for the API.

Author.cs - Represents the Author entity with properties such as AuthorId and Name.
Book.cs - Represents the Book entity with properties such as BookId and Name.
Publish.cs - Represents the Publish entity which links an Author to a Book through foreign keys.
Data/
This folder holds the database context and any data access logic.

LibraryContext.cs - The main database context class responsible for managing database operations. It inherits from DbContext and includes DbSet properties for Author, Book, and Publish.
Migrations/
Contains migration files generated by Entity Framework. These files represent changes in the database schema and are essential for versioning and applying updates to the database structure.

DTOs/
This folder includes Data Transfer Objects (DTOs), which are used to transfer data between the API and the client, abstracting the internal models to ensure data encapsulation and maintain separation of concerns.

AuthorDTO.cs - Defines the structure of author data as it is exposed through the API.
BookDTO.cs - Defines the structure of book data for API interactions.
PublishDTO.cs - Specifies the data format for the publish relationship.
Repositories/
This folder contains repository classes that abstract the data access logic, separating concerns between data retrieval/manipulation and business logic.

AuthorRepository.cs - Handles database operations specific to the Author entity.
BookRepository.cs - Manages data access operations related to the Book entity.
PublishRepository.cs - Responsible for handling the link between authors and books.
Services/
The Services folder contains service classes that handle business logic. The services communicate with the repositories to perform data operations.

AuthorService.cs - Manages business logic for author-related operations.
BookService.cs - Contains business logic for handling book operations.
PublishService.cs - Deals with the business logic surrounding the relationship between authors and books.
Helpers/
This folder contains utility classes or methods that assist with tasks such as validation, formatting, or other non-business logic.

CustomException.cs - Handles custom exception logic to provide more specific error messages and responses.
Properties/
This folder contains the configuration and metadata files used by the project.

launchSettings.json - Configuration file for defining different profiles for running the application.
Getting Started
Prerequisites
.NET Core SDK
Entity Framework Core
PostgreSQL or your preferred database
pgAdmin or your preferred database management tool
Installation
Clone the repository:
bash
Copy code
git clone https://github.com/TheodoulosChristou/LibraryAPI.git
Navigate to the project directory:
bash
Copy code
cd LibraryAPI/LibraryAPI
Install the required NuGet packages:
bash
Copy code
dotnet restore
Database Setup
Configure your database connection string in the appsettings.json file.
Run the migrations to set up the database schema:
bash
Copy code
dotnet ef database update
Running the Application
To run the application locally:
bash
Copy code
dotnet run
The API will be available at http://localhost:5000 by default.
