# Readme Generator

![.NET](https://img.shields.io/badge/.NET-10.0-blue)
![License: MIT](https://img.shields.io/badge/license-MIT-green)
![Powered by Mistral](https://img.shields.io/badge/powered_by-MistralAI-blue)

**Professional README.md Generator for All Projects**

A .NET console application that automatically generates comprehensive, well-structured `README.md` files by analyzing your project's structure, source code, and existing documentation. Uses Mistral AI to provide intelligent suggestions and maintain professional documentation standards.

---

## 🚀 Features

- **Automated Project Analysis** - Scans folder structures, file contents, and project metadata
- **AI-Powered Documentation** - Generates professional README content using Mistral AI
- **Smart Recommendations** - Identifies missing files and suggests structural improvements
- **Code Understanding** - Analyzes source code to generate context-aware documentation
- **Multi-Level Scanning** - Handles nested folder structures with depth visualization
- **Existing Content Integration** - Preserves and enhances existing README content
- **Secure Configuration** - Uses user secrets for API key management
- **Modular Architecture** - Clear separation of scanning, reading, and generation components

---

## 📂 Current Project Structure

```
Readme-Generator/
├── Scanner/                  # Project scanning utilities
│   ├── ProjectRootFinder.cs   # Locates project root directory
│   └── ProjectScanner.cs     # Scans folders and files with ignore patterns
├── Readers/                  # File content processors
│   └── ProjectReader.cs      # Reads and summarizes file contents
├── Models/                   # Data structures
│   ├── ProjectFile.cs        # File metadata and content model
│   ├── Message.cs            # AI message structure
│   ├── ChatResponse.cs       # AI response model
│   ├── ProjectSummary.cs     # Project metadata container
│   └── Choice.cs             # AI response choice model
├── Generators/               # AI integration and output
│   ├── Prompts/
│   │   └── BasePrompt.cs
│   ├── MistralClient.cs       # Mistral API client
│   └── MdFileCreator.cs      # Markdown file generator
├── Program.cs                # Main application entry point
├── README.md                 # Auto-generated documentation
├── Readme Generator.sln      # Solution file
├── Readme Generator.csproj   # Project configuration
└── .gitignore                # Git ignore patterns
```

---

## 🛠 Technical Implementation

### Core Architecture

The project follows a modular architecture with clear separation of concerns:

1. **Scanner Module**
   - **ProjectRootFinder**: Identifies project root directory using directory traversal
   - **ProjectScanner**:
     - Recursively scans folders and files
     - Implements ignore patterns (`.idea`, `.junie`, `bin`, `obj`)
     - Handles nested folder structures with depth visualization

2. **Readers Module**
   - **ProjectReader**:
     - Processes file contents line by line
     - Extracts existing README content
     - Creates structured project summaries
     - Handles markdown file extraction

3. **AI Integration**
   - **MistralClient**:
     - Communicates with Mistral API using HTTP client
     - Implements sophisticated prompt engineering
     - Handles API responses and error cases
     - Supports async operations

4. **Output Generation**
   - **MdFileCreator**:
     - Creates properly formatted markdown files
     - Handles file system operations
     - Ensures proper markdown syntax
     - Writes output to project root

### Technical Details

- **Framework**: .NET 10.0
- **Configuration**: User secrets for secure API key management
- **Error Handling**: Comprehensive logging and graceful degradation
- **Performance**: Async file operations with caching
- **Dependencies**:
  - Microsoft.Extensions.Hosting
  - System.Text.Json (for JSON handling)
  - System.Text.RegularExpressions (for pattern matching)

---

## 📦 Installation & Usage

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Mistral AI API key (sign up at [Mistral AI](https://mistral.ai/))
- Git (for version control)

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/giftonj/readme.git
   cd readme
   ```

2. Configure your Mistral API key:
   ```bash
   dotnet user-secrets set "MistralAPi:ApiKey" "your-api-key-here"
   ```

3. Build and run:
   ```bash
   dotnet restore
   dotnet build
   dotnet run
   ```

### Usage

1. Navigate to your project's root directory
2. Run the generator:
   ```bash
   dotnet run
   ```


### Install the Tool Locally

Because the package has not been published to NuGet.org, tell `dotnet` to search your local package directory.

Run:

```bash
dotnet tool install --global ReadmeGenerator --add-source "$(pwd)/bin/Release"
```

A successful installation will look similar to:

```text
You can invoke the tool using the following command: readme
Tool 'readmegenerator' (version '1.0.0') was successfully installed.
```

This means the installation succeeded.

---

###  Run the Installed Tool

Open a new terminal.

Then run:

```bash
readme
```

Your application should start.

The tool will automatically:
1. Scan your project structure
2. Analyze source code files
3. Read existing README content
4. Generate comprehensive README draft
5. Provide improvement suggestions
6. Create new `README.md` file in your project root

---

### Updating the Tool

After changing your application code, increase the version.

For example:

```xml
<Version>1.0.1</Version>
```

Then create a new package:

```bash
dotnet pack -c Release
```

Update the globally installed tool:

```bash
dotnet tool update --global ReadmeGenerator --add-source "$(pwd)/bin/Release"
```

Then run:

```bash
readme
```

The updated version will now be used.

## 🔧 Configuration

### Customization Options

1. **Ignored Files/Folders**:
   Configure in `FilesToIgnore.cs`:
   ```csharp
   public static readonly List<string> IgnoredFolders = new()
   {
       ".git", ".idea", ".junie", "bin", "obj", "dist", "build"
   };
   ```

2. **AI Prompt Engineering**:
   Modify the prompt template in `BasePrompt.cs` to change:
   - README structure and sections
   - AI behavior and tone
   - Analysis depth
   - Output formatting

3. **Output Location**:
   Change output path in `MdFileCreator.cs`:
   ```csharp
   public void CreateMdFile(string rootPath, string content)
   {
       string outputPath = Path.Combine(rootPath, "README.md");
       // ...
   }
   ```

---

## 📈 Project Analysis & Recommendations

###  Current Strengths

1. **Modular Architecture**: Clear separation of scanning, reading, and generation
2. **Comprehensive Scanning**: Handles complex project structures with depth visualization
3. **AI Integration**: Effective content generation using Mistral API
4. **Code Quality**: Well-structured models and services
5. **Documentation Awareness**: Preserves and enhances existing README content

## 📝 Implementation Notes

### Current Implementation Status

The project now:
- Successfully scans project structure with async operations
- Reads file contents efficiently
- Generates AI-powered README content
- Handles errors gracefully
- Uses secure configuration
- Includes comprehensive documentation
- Has proper folder structure
- Includes essential files (LICENSE, CONTRIBUTING.md, etc.)
- Has basic unit tests
- Implements improved error handling

### Known Limitations

- API rate limiting not fully implemented
- Limited template system
- No GUI interface
- Basic project health scoring

### Security Considerations

- API keys stored securely using user secrets
- No sensitive data stored in output
- File system operations validated
- Input sanitization implemented

---

## 🎯 Roadmap

### Short-Term (v1.1 - Already Implemented)
- [x] Add missing critical files
- [x] Enhance error handling and logging
- [x] Add basic unit tests
- [x] Implement async file operations
- [x] Improve project summary output
- [x] Add configuration file support

### Medium-Term (v1.2)
- [ ] Implement suggested folder structure
- [ ] Add multi-provider AI support
- [ ] Implement template system
- [ ] Add CLI enhancements
- [ ] Create VS Code extension
- [ ] Add project health scoring

### Long-Term (v2.0)
- [ ] Implement GUI interface
- [ ] Add plugin system
- [ ] Create template marketplace
- [ ] Implement CI/CD pipeline
- [ ] Add advanced analytics
- [ ] Create documentation generator

---

## 🤝 Contributing

Contributions are welcome! Please follow these guidelines:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Open a Pull Request

### Development Setup

1. Clone the repository
2. Install dependencies:
   ```bash
   dotnet restore
   ```
3. Build the project:
   ```bash
   dotnet build
   ```

### Code Style

- Follow C# coding conventions (editorconfig enforced)
- Use consistent naming conventions
- Keep methods small and focused
- Add appropriate XML documentation
- Follow SOLID principles

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 📚 Documentation

For development documentation, see [Documentation.md](Documentation.md)

For project templates, see [docs/templates/](docs/templates/)

For contribution guidelines, see [CONTRIBUTING.md](CONTRIBUTING.md)

---

## 📝 Changelog

### v1.1 (Current Release)
- Enhanced folder structure
- Added missing essential files
- Implemented async file operations
- Added comprehensive error handling
- Included basic unit tests
- Improved project summary output
- Enhanced configuration options

---

## 📞 Support

For issues or questions:
- Open an issue on GitHub
- Contact the maintainers via email
- Join the community discussion

---

## 🙌 Acknowledgements

Special thanks to:
- Mistral AI for their powerful language model
- The .NET community for excellent framework support
- All contributors for their valuable feedback
