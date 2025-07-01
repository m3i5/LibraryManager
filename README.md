# LibraryManager

**LibraryManager** is a C# .NET console application designed to help manage a digital library system. It supports storing and managing a collection of resources including books, magazines, and journals, with features such as searching, borrowing, returning, and generating reports. All through a terminal-based interface.

This application uses **Entity Framework Core** and a **SQL Server** database.

---
## Features

### Resource Management
- **Create**: Add new resources with details like title, author, genre etc.
- **Read**: View all resources as formatted list.
- **Update**: Modify resource informations.
- **Delete**: Remove a resource permamently.

### Borrowing System
- Mark borrowed resources.
- Set automatic or custom return deadlines.
- Return items and update their status.

### Searching
- Search by **Title**, **Author**, or **Genre**
- Case-insensitive partial match search

### Reports
- View a list of overdue borrowed resources.
- Group resources by category (Books, Journals, Magazines).

### Validation
- Ensures all inputs (year, types, etc.) are valid and reasonable.
- Prevents invalid operations (e.g., borrowing already borrowed items).

### Unit Testing
- Tested using xUnit.
- In-memory database to simulate real scenarios without affecting real database.

---
## Prerequisites

Make sure the following tools are installed on your system:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server (LocalDB or full)](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)
- Optional: SQL Server Management Studio (SSMS) to view the database

---

## How to Run the Application

### Step 1: Clone the Repository
```bash
git clone https://github.com/m3i5/LibraryManager.git
cd LibraryManager
```
### Step 2: Build the project
```bash
dotnet build
```
### Step 3: Run the application
```bash
dotnet run --project LibraryManager
```

When the application starts, you'll se a console menu:

== Library Manager ==
1. View all resources
2. Add new resource
3. 
   ...
0. Exit

---

## Database Setup

The app uses SQL Server LocalDB by default.
- You must have [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) installed and running.
- The database is created automatically on the first execution (only if doesn't exist already).
- Connection string is located in `LibContext.cs`
```C#
{
    options.UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");
}
```

---

## How to run the Tests

Unit tests written in xUnit cover key areas of functionality:
- Search: ensures partial and casie-insensitive matching
- Input Validation: verifies valid year and correct resource type
- Borrowing: confirms that a resource cannot be borrowed if already checked out

To run all tests:
```bash
dotnet test
```
You should see something like this:

```diff
+Passed!  - Failed:     0, Passed:    11, Skipped:     0, Total:    11, Duration: 483 ms}
```

---
## Troubleshooting

If you encounter issues, here are some helpful tips:

### Cannot Connect to Database (SQL Server)
- Make sure **SQL Server** is installed and running
- Verify the connection string in `LibContext.cs`

### `dotnet tests` Does nothing
- Ensure the test project is added to solution
  ```bash
    dotnet sln list
  ```
  If missing add test project with following command
  ```bash
  dotnet sln add LibraryManager.Tests/LibraryManager.Tests.csproj
  ```
  Or run tests directly from LibraryManager.Tests directory
  ```bash
  cd LibraryManager.Tests
  dotnet test
  ```
### If your database seems empty
- Make sure
  ```C#
   LibCollection.populateCollection();
  ```
  is enabled in `Program.cs`

- If you want to reseed:
  
  Option 1: Delete existing LibraryDB using SMSS
  
  Option 2: Enable
     ```C#
     LibCollection.ClearDatabase();
     ```
     then run the application once and disable it again!

---

### Need more help? Open an Issue
1. Go to [Issues](https://github.com/m3i5/LibraryManager/issues)
2. Click **New Issue**
3. Provide **Title**, **Description**, **Steps to Reproduce**, **Error Messages**

## Author

**Name**: Jakub Zawadzki
**StudentID**: M00981994
