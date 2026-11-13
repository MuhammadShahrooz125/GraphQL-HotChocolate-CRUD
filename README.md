# GraphQL Employee CRUD API

A GraphQL API built with **ASP.NET Core** and **HotChocolate** that performs CRUD operations on employee records stored in **SQL Server** using **Entity Framework Core**. It also supports filtering, sorting and cursor-based pagination.

## Features

- Create, read, update and delete employees using GraphQL queries and mutations
- Filtering with operators such as `eq`, `contains`, `gt`, `and` and `or`
- Sorting by one or more fields (ascending or descending)
- Cursor-based pagination with total count and page info
- Code-first database with EF Core migrations
- Asynchronous database operations and Dependency Injection

## Tech Stack

- C#, ASP.NET Core
- HotChocolate (GraphQL)
- Entity Framework Core
- SQL Server

## Data Model

**Employee**: `Id`, `Name`, `Email`, `Department`

## Getting Started

**Prerequisites:** .NET SDK, SQL Server (or SQL Server Express), Visual Studio

1. Clone the repository:
   ```bash
   git clone https://github.com/MuhammadShahrooz125/GraphQL-HotChocolate-CRUD.git
   ```

2. Open the solution in Visual Studio.
3. In `appsettings.json`, replace `YOUR_SERVER_NAME` with your SQL Server instance name.
4. Open **Tools > NuGet Package Manager > Package Manager Console** and run:
   ```
   Update-Database
   ```
5. Run the project and open `https://localhost:<port>/graphql` in your browser to use the GraphQL IDE.

## Example Queries

**Get employees with pagination**
```graphql
query {
  employees(first: 3) {
    totalCount
    pageInfo { hasNextPage endCursor }
    nodes { id name department }
  }
}
```

**Filter by department**
```graphql
query {
  employees(where: { department: { eq: "IT" } }) {
    nodes { id name department }
  }
}
```

**Sort by name (descending)**
```graphql

query {
  employees(order: { name: DESC }) {
    nodes { id name }
  }
}
```

**Filter, sort and paginate together**
```graphql
query {
  employees(
    first: 2
    where: { department: { eq: "IT" } }
    order: { name: ASC }
  ) {
    totalCount
    nodes { id name department }
  }
}
```

**Add an employee**
```graphql
mutation {
  addEmployee(name: "Ahmed", email: "ahmed@test.com", department: "Finance") {
    id name email department
  }
}
```

**Update an employee**
```graphql

mutation {
  updateEmployee(id: 1, name: "Ali Khan", email: "alikhan@test.com", dept: "IT") {
    id name email department
  }
}
```

**Delete an employee**
```graphql
mutation {
  deleteEmployee(id: 1)
}
```

## Author

Muhammad Shahrooz
[LinkedIn](https://linkedin.com/in/mshahrooz) | [GitHub](https://github.com/MuhammadShahrooz125)
