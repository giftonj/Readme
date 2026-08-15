## Project Idea

Build a **C# Console Application** that scans a project folder and automatically generates a `README.md` file.

### Why this is useful

- Saves time writing documentation.
- Keeps project documentation consistent.
- Can work **locally** without uploading code to external AI services.
- Avoids concerns about AI tools creating commits or appearing as contributors in a Git repository.
- Great practice for advanced C# concepts.

---

# How the App Should Work

## Input

A path to a project folder.

Example:

```bash
ReadmeGenerator.exe "C:\Projects\InventorySystem"
```

## Process

The app should:

1. Scan the folder structure.
2. Ignore unnecessary folders (`bin`, `obj`, `.git`, `node_modules`).
3. Detect important files (`.csproj`, `.json`, `.vue`, etc.).
4. Read configuration files.
5. Detect technologies used.
6. Build a Markdown document.
7. Save it as `README.md`.

## Output

A generated `README.md` file.

---

# Recommended Project Structure

```text
Project/
│
├── Program.cs
│
├── Scanner/
│   └── ProjectScanner.cs
│
├── Readers/
│   ├── CsprojReader.cs
│   └── JsonReader.cs
│
├── Generators/
│   └── ReadmeGenerator.cs
│
└── Models/
    └── ProjectInfo.cs
```

---

# Prerequisites to Learn

## 1. File and Directory Handling (Most Important)

### Classes and Methods

- `Directory.GetFiles()`
- `Directory.GetDirectories()`
- `Directory.EnumerateFiles()`
- `File.ReadAllText()`
- `File.ReadAllLines()`
- `Path.Combine()`
- `Path.GetExtension()`
- `Path.GetFileName()`

### What You Should Be Able To Do

- Scan folders recursively.
- Find files by extension.
- Ignore specific folders.
- Read file contents safely.

---

## 2. Collections

### Learn

- `List<T>`
- `Dictionary<TKey, TValue>`
- `HashSet<T>`

### Example

```csharp
Dictionary<string, int> languageFiles;
```

Used to count file types.

---

## 3. LINQ

### Important Methods

- `Where`
- `Select`
- `Any`
- `FirstOrDefault`
- `OrderBy`
- `Count`
- `GroupBy`

LINQ will help filter and analyze files.

---

## 4. JSON Handling

### Namespace

```csharp
using System.Text.Json;
```

### Learn

- `JsonSerializer`
- `JsonDocument`

### Files to Read

- `package.json`
- `appsettings.json`
- `launchSettings.json`

---

## 5. XML Handling

### Namespace

```csharp
using System.Xml.Linq;
```

### Main Class

```csharp
XDocument
```

### Example

Read values from a `.csproj` file:

```xml
<TargetFramework>net9.0</TargetFramework>
```

---

## 6. Markdown Basics

A README is just text written in Markdown.

Learn:

- Headings (`#`)
- Lists (`-`)
- Code blocks (```)
- Tables
- Links

Example:

```md
# Inventory System

## Technologies

- ASP.NET Core
- Vue
- SQL Server
```

---

## 7. String Manipulation

### Learn

- `StringBuilder`
- String interpolation (`$"..."`)
- `Split`
- `Join`
- `Replace`

`StringBuilder` is ideal for generating large README files efficiently.

---

## 8. Regular Expressions (Optional)

### Namespace

```csharp
using System.Text.RegularExpressions;
```

Useful for detecting:

- TODO comments
- Route attributes
- Connection strings
- XML documentation comments

---

## 9. Recursive Directory Traversal

Projects contain folders inside folders.

Example:

```text
Project
│
├── Controllers
│   ├── UserController.cs
│   └── ProductController.cs
│
├── Services
├── Models
└── Data
```

Your scanner should visit every folder automatically.

---

# Suggested Development Phases

## Phase 1 — Scan the Project

Example output:

```text
Found:
45 .cs files
2 .csproj files
1 package.json
3 json files
```

---

## Phase 2 — Read the `.csproj`

Extract:

- Target framework
- Nullable enabled
- Implicit usings
- Package references

---

## Phase 3 — Read `package.json`

Extract:

- Framework
- Dependencies
- Scripts

---

## Phase 4 — Detect Technologies

Example:

```text
Backend:
✓ ASP.NET Core

Frontend:
✓ Vue

Database:
✓ SQL Server

ORM:
✓ Entity Framework Core
```

---

## Phase 5 — Generate a Basic README

Example:

```md
# Project Name

## Features

## Technologies

## Installation

## Running the project
```

---

## Phase 6 — Generate a Polished README

Add:

- Project tree
- API overview
- Database information
- Dependencies
- Environment variables
- Build instructions
- License
- Badges (optional)

---

# Important Design Advice

Do **not** put everything inside `Program.cs`.

Create separate classes for:

- Scanning
- Reading files
- Parsing configuration
- Generating Markdown
- Storing project information

This makes the project easier to maintain and extend.

---

# About AI and Git Contributors

Using ChatGPT in a conversation does **not** make OpenAI a Git contributor.

Some AI coding tools integrated with Git hosting or IDEs may create commits or add co-author information depending on their configuration.

A **local README generator** avoids that concern because everything runs on your machine.

---

# Future Improvements

Once the rule-based generator works, you can later add:

- AI-powered wording improvements
- Automatic API endpoint detection
- Extraction of XML documentation comments
- Environment variable detection
- Database migration summaries
- Interactive README templates

---

# Why This Is a Great Learning Project

This single project will help you practice:

- File I/O
- Collections
- LINQ
- JSON parsing
- XML parsing
- String manipulation
- Recursion
- Project architecture
- Markdown generation
- Real-world software design

It is an excellent step toward becoming a more advanced C# developer.