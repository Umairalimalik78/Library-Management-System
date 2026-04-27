# 📚 Library Management System

A fully functional **Library Management System** built as a Windows Forms desktop application using C# and SQL Server. It allows librarians to manage member records, track book issue and return dates, handle fees, upload member photos, and perform real-time search — all through a clean and interactive GUI.

---

## ✨ Features

- ➕ **Add Member Records** — Register new members with full details (name, phone, book, author, fees, status)
- 📅 **Issue & Return Date Picker** — Select book issue and return dates using date pickers
- 📷 **Member Photo Upload** — Upload and display member photos stored in the database
- 🗑️ **Double-Click to Delete** — Double-click any row in the grid to confirm and delete a record
- 🔍 **Real-Time Search** — Instantly filter records by member name or phone number
- 📊 **DataGridView Display** — View all members in a sortable, interactive data grid
- 🖼️ **Selected Row Photo Preview** — Click any row to preview the member's photo
- 🔄 **Reset Form** — Clear all input fields with one click
- 💾 **SQL Server Integration** — All data stored and retrieved from a local SQL Server database (`LibraryDB`)
- ✅ **Input Validation** — Alerts user if any required field is left empty before saving

---

## 🛠️ Built With

| Technology | Purpose |
|---|---|
| **C# (.NET)** | Core application logic & Windows Forms UI |
| **Windows Forms (WinForms)** | Desktop GUI framework |
| **SQL Server (LocalDB)** | Database for storing member & book records |
| **ADO.NET (SqlConnection)** | Database connectivity & queries |
| **Visual Studio** | IDE & project management |

---

## 🗄️ Database Schema

**Database:** `LibraryDB`
**Table:** `Members`

```sql
CREATE TABLE Members (
    MID        INT PRIMARY KEY IDENTITY(300,1),
    MemberName VARCHAR(100),
    PhoneNo    VARCHAR(20),
    BookName   VARCHAR(100),
    Author     VARCHAR(100),
    IssueDate  DATE,
    ReturnDate DATE,
    Fees       INT,
    Status     VARCHAR(20),
    Photo      VARBINARY(MAX)
);
```

---

## 📁 Project Structure

```
Library-Management-System/
│
├── Form1.cs               # Main form — member management, CRUD logic
├── Form1.Designer.cs      # Auto-generated UI layout for Form1
├── Form1.resx             # Resources for Form1
├── Form2.cs               # Secondary form
├── Form2.Designer.cs      # Auto-generated UI layout for Form2
├── Form2.resx             # Resources for Form2
├── Program.cs             # Application entry point
├── SQLQuery1.sql          # Database schema & sample data (20 records)
├── App.config             # Application configuration
├── LibraryDB.mdf          # SQL Server database file
├── LibraryDB.ldf          # SQL Server log file
├── Library Management System.csproj   # Project file
├── Library Management System.sln      # Solution file
├── images/                # UI image assets
├── Resources/             # Embedded resources
└── bin/Debug/             # Compiled output
```

---

## 🚀 Getting Started

### Prerequisites

- [Visual Studio 2019 or later](https://visualstudio.microsoft.com/)
- .NET Framework (Windows Forms support)
- SQL Server LocalDB (comes with Visual Studio)

### Run Locally

1. **Clone the repository**

```bash
git clone https://github.com/Umairalimalik78/Library-Management-System.git
```

2. **Open the solution in Visual Studio**

```
Open: Library Management System.sln
```

3. **Set up the database**

- Open **SQL Server Object Explorer** in Visual Studio
- Connect to `(localdb)\MSSQLLocalDB`
- Run `SQLQuery1.sql` to create the `LibraryDB` database and `Members` table
- Optionally run the INSERT statements to load 20 sample records

4. **Build & Run**

- Press `F5` or click **Start** in Visual Studio
- The application will launch as a Windows desktop app

---

## 👨‍💻 Author

**Umair Ali**

- GitHub: [@Umairalimalik78](https://github.com/Umairalimalik78)

---

<p align="center">Made with ❤️ by Umair Ali</p>
