# Simple HTML to PDF

[![.NET Publish](https://github.com/JaCraig/Simple-Html-To-Pdf/actions/workflows/dotnet-publish.yml/badge.svg)](https://github.com/JaCraig/Simple-Html-To-Pdf/actions/workflows/dotnet-publish.yml)

Simple HTML to PDF is a lightweight NuGet package that provides a simple HTML to PDF converter library for .NET projects. It allows you to easily convert HTML content to PDF documents using the `wkhtmltopdf` command-line tool.

## Installation

You can install the Simple HTML to PDF package via NuGet Package Manager or by using the .NET CLI.

### NuGet Package Manager

1. Open the NuGet Package Manager in Visual Studio.

2. Search for "SimpleHtmlToPdf" and select the package.

3. Click on the "Install" button to install the package into your project.

### .NET CLI

Execute the following command in the terminal:

```shell
dotnet add package SimpleHtmlToPdf
```

## Usage

To use the Simple HTML to PDF library in your project, follow these steps:

1. Install the Simple HTML to PDF package (as described in the Installation section).

2. Add a reference to the library in your project:

   ```csharp
    using SimpleHtmlToPdf.Interfaces;
    using SimpleHtmlToPdf.Settings;
    using SimpleHtmlToPdf.Settings.Enums;
    using SimpleHtmlToPdf.UnmanagedHandler;
   ```

3. Ask for an instance of the `IConverter` class from the system's IoC:

   ```csharp
   public HomeController(IConverter converter) { ... }
   ```

4. Convert an HTML string to a PDF document:

   ```csharp
    // Define the HTML-to-PDF request input
    var doc = new HtmlToPdfDocument()
    {
        GlobalSettings = {
            // Color mode of the output file
            ColorMode = ColorMode.Color,
            // Orientation of the output file
            Orientation = Orientation.Landscape,
            // Paper size of the output file
            PaperSize = PaperKind.A4Plus,
        },
        Objects = {
            new ObjectSettings()
            {
                // HTML content to convert
                HtmlContent = "<html><body>Test</body></html>",
                // The default encoding used.
                WebSettings = { DefaultEncoding = "utf-8" },
            },
        }
    };

    // Convert our HTML document to a PDF document
    var pdf = Converter.Convert(doc);
   ```

   Replace `HtmlContent` with the actual HTML content you want to convert.

5. Send the PDF file to the browser:

   ```csharp
   return File(pdf, "application/pdf", "Test.pdf");
   ```

   Customize based on your requirements.

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

1. Fork the repository.

2. Create a new branch:

   ```shell
   git checkout -b feature/your-feature-name
   ```

3. Make your changes and commit them:

   ```shell
   git commit -m "Add your commit message"
   ```

4. Push your changes to your forked repository:

   ```shell
   git push origin feature/your-feature-name
   ```

5. Open a pull request in this repository, and provide a detailed description of your changes.

## License

This project is licensed under the [Apache 2 License](https://github.com/JaCraig/Simple-Html-To-Pdf/blob/master/LICENSE).

## Acknowledgments

- The `wkhtmltopdf` tool, which enables HTML to PDF conversion.
- The [DinkToPDF](https://github.com/rdvojmoc/DinkToPdf) library, which provided the initial code.
