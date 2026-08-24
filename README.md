# Readme Generator

**Automated README.md file generation for .NET projects with AI-powered suggestions**

A tool that scans your project structure, analyzes source code, and generates a professional `README.md` file while providing feedback on project organization, missing files, and potential improvements.

## 🚀 Features

- **Project Scanning**: Automatically detects root folders, subfolders, and files
- **Code Analysis**: Reads and summarizes source code content
- **AI-Powered Suggestions**: Uses Mistral AI to:
    - Generate professional README content
    - Suggest folder structure improvements
    - Identify missing files (e.g., `LICENSE`, `CONTRIBUTING.md`)
    - Recommend best practices
- **Customizable Output**: Generates markdown-ready content

## 📁 Project Structure

```
Readme Generator/
├── Scanner/               # Project scanning utilities
│   ├── ProjectRootFinder.cs
│   └── ProjectScanner.cs
├── Readers/               # File content readers
│   └── ProjectReader.cs
├── Models/                # Data models
│   ├── ProjectFile.cs
│   ├── Message.cs
│   ├── ChatResponse.cs
│   ├── ProjectSummary.cs
│   └── Choice.cs
├── Generators/            # AI integration
│   └── MistralClient.cs
├── Program.cs             # Main entry point
└── Documentation.md       # Project documentation
```

## ⚙️ Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/giftonj/readme-generator.git
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

## 🛠 Usage

Run the generator:
```bash
dotnet run
```

The tool will:
1. Scan your project structure
2. Analyze source code files
3. Generate a README draft
4. Provide improvement suggestions

## 🔧 Configuration

Add your Mistral API key in `Program.cs`:
```csharp
var apiKey = "your-api-key-here";
```

## 📝 Example Output

The generator produces:
1. A complete `README.md` template
2. Suggestions like:
    - "Consider adding a `tests/` folder"
    - "Missing `LICENSE` file"
    - "Improve folder naming consistency"

## 🤖 AI Integration

Uses Mistral AI to:
- Understand project context
- Generate human-readable documentation
- Provide actionable feedback

## 📦 Dependencies

- .NET 10.0
- Mistral AI API

## 📄 License

[Add your license here]

---

## 🔍 Project Analysis & Suggestions

### ✅ What's Good
1. **Clear Architecture**: Well-organized folders (`Scanner`, `Readers`, `Models`, `Generators`)
2. **Modular Design**: Each component has a single responsibility
3. **AI Integration**: Smart use of Mistral for documentation generation
4. **Comprehensive Scanning**: Handles nested folder structures well

### 🔧 Suggested Improvements

1. **Folder Structure**:
    - Add a `Services/` folder for business logic
    - Consider `Utilities/` for helper classes
    - Move `Program.cs` to a `Cli/` folder if expanding CLI functionality

2. **Missing Files**:
    - `LICENSE` (critical for open source)
    - `CONTRIBUTING.md` (for community projects)
    - `CHANGELOG.md` (for version tracking)
    - `appsettings.json` (for configuration)
    - Unit tests (`Tests/` folder)

3. **Code Improvements**:
    - Add error handling for file operations
    - Implement logging (e.g., Serilog)
    - Add input validation
    - Consider async file operations
    - Add XML documentation for public methods

4. **Project File**:
    - Add package references explicitly
    - Consider multi-targeting for broader compatibility
    - Add `Nullable` context for better null safety

5. **Functionality**:
    - Add output customization (e.g., `--output README.md`)
    - Support for different AI providers
    - Template system for README styles
    - Project type detection (e.g., "This appears to be a CLI tool")

6. **Security**:
    - Don't hardcode API keys (use environment variables)
    - Add input sanitization for file paths

7. **Documentation**:
    - Expand `Documentation.md` with:
        - Architecture overview
        - Contribution guidelines
        - Example outputs
        - Configuration options

### 📊 Sample Improved Structure

```
Readme Generator/
├── src/
│   ├── Cli/               # CLI interface
│   ├── Scanner/           # Scanning logic
│   ├── Readers/           # File readers
│   ├── Models/            # Data models
│   ├── Generators/        # AI integration
│   └── Services/          # Business logic
├── tests/                 # Unit tests
├── docs/                  # Documentation
├── templates/             # README templates
└── Readme Generator.sln
```

## 🎯 Next Steps

1. Implement the suggested folder structure
2. Add missing critical files (`LICENSE`, `CONTRIBUTING.md`)
3. Enhance error handling and logging
4. Add configuration management
5. Expand test coverage
6. Implement output customization

---

This README provides:
1. Clear project overview
2. Installation/usage instructions
3. Technical details
4. Actionable improvement suggestions
5. Professional presentation