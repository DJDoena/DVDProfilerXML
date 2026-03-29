# DoenaSoft.DVDProfiler.Xml

[![NuGet](https://img.shields.io/nuget/v/DoenaSoft.DVDProfiler.Xml.svg)](https://www.nuget.org/packages/DoenaSoft.DVDProfiler.Xml/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A comprehensive .NET library for working with DVD Profiler XML exports.

## Table of Contents

- [About DVD Profiler](#about-dvd-profiler)
- [About This Library](#about-this-library)
- [Features](#features)
- [Installation](#installation)
- [Supported Versions](#supported-versions)
- [Target Frameworks](#target-frameworks)
- [Usage](#usage)
- [DVD Profiler Version Support](#dvd-profiler-version-support)
- [Dependencies](#dependencies)
- [Building from Source](#building-from-source)
- [Contributing](#contributing)
- [License](#license)
- [Author](#author)

## About DVD Profiler

DVD Profiler is a comprehensive DVD cataloging software application developed by Invelos LLC (https://www.invelos.com). It allows users to catalog their DVD, Blu-ray, and 4K UHD collections with detailed information including cast, crew, technical specifications, and custom data. DVD Profiler can export collection data to XML files, which can be used for backup, sharing, or integration with other applications.

## About This Library

`DoenaSoft.DVDProfiler.Xml` is a .NET library that provides strongly-typed classes and helper functions for reading, writing, and manipulating DVD Profiler XML export files. This library eliminates the need to manually parse XML files and provides a clean, object-oriented API for working with DVD Profiler data.

## Features

- **Strongly-typed classes** for all DVD Profiler XML elements
- **Serialization and deserialization** support for DVD Profiler XML exports
- **Multiple version support** for DVD Profiler XML schemas (3.5.1 through 4.0.0)
- **Helper methods** for common operations on DVD data
- **Locality and Country of Origin (COO) support** for regional information
- **Collection tree** management for organizing DVDs
- **Crew sorting** utilities for cast and crew information
- **Person data** handling with interfaces for consistency
- **XSD schema files** included for validation

## Installation

### Via NuGet Package Manager

`ash
Install-Package DoenaSoft.DVDProfiler.Xml
`

### Via .NET CLI

`ash
dotnet add package DoenaSoft.DVDProfiler.Xml
`

### Via Package Reference

Add the following to your `.csproj` file:

`xml
<PackageReference Include="DoenaSoft.DVDProfiler.Xml" Version="6.0.0" />
`

## Supported Versions

This library supports the following DVD Profiler XML export versions:

- **3.5.1** - Legacy support
- **3.6.0** - With Localities support
- **3.8.0** - Enhanced features
- **3.8.1** - With COO (Country of Origin) and enhanced Localities
- **3.9.0** - Updated schema
- **4.0.0** - Latest version with full Localities support

## Target Frameworks

- **.NET Framework 4.7.2** - For legacy Windows applications
- **.NET 10** - For modern cross-platform applications

## Usage

### Reading a DVD Profiler Collection

`csharp
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using System.Xml.Serialization;

// Deserialize a DVD Profiler XML file
var serializer = new XmlSerializer(typeof(Collection));
using (var reader = new StreamReader("MyCollection.xml"))
{
    var collection = (Collection)serializer.Deserialize(reader);
    
    Console.WriteLine($"Total DVDs: {collection.DVDList.Length}");
    
    foreach (var dvd in collection.DVDList)
    {
        Console.WriteLine($"Title: {dvd.Title}");
        Console.WriteLine($"Year: {dvd.ProductionYear}");
        Console.WriteLine($"UPC: {dvd.UPC}");
    }
}
`

### Writing a DVD Profiler Collection

`csharp
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;
using System.Text;

// Create a new collection
var collection = new Collection();

// Serialize to XML file
collection.Serialize("MyCollection.xml", Encoding.GetEncoding(1252));
`

### Working with DVD Data

`csharp
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

// Create a new DVD entry
var dvd = new DVD
{
    Title = "The Matrix",
    ProductionYear = 1999,
    UPC = "012345678901",
    Edition = "Special Edition",
    CollectionNumber = "001",
    CollectionType = new CollectionType { IsOwned = true },
    GenreList = new[] { "Science Fiction", "Action" }
};

// Add to collection
collection.DVDList = new[] { dvd };
`

### Working with Cast and Crew

`csharp
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400;

var dvd = new DVD
{
    Title = "Example Movie",
    CastList = new Actor[]
    {
        new Actor
        {
            FirstName = "John",
            LastName = "Doe",
            Role = "Main Character",
            BirthYear = 1970
        }
    },
    CrewList = new CrewMember[]
    {
        new CrewMember
        {
            FirstName = "Jane",
            LastName = "Smith",
            CreditType = "Director",
            BirthYear = 1965
        }
    }
};
`

### Using Version-Specific Namespaces

Each DVD Profiler version has its own namespace:

`csharp
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version351; // For 3.5.1
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version360; // For 3.6.0
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version380; // For 3.8.0
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version381; // For 3.8.1
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version390; // For 3.9.0
using DoenaSoft.DVDProfiler.DVDProfilerXML.Version400; // For 4.0.0 (Latest)
`

## DVD Profiler Version Support

| Library Version | DVD Profiler Versions Supported |
|----------------|--------------------------------|
| 6.0.0 (Current)| 3.5.1, 3.6.0, 3.8.0, 3.8.1, 3.9.0, 4.0.0 |

The library maintains backward compatibility with older DVD Profiler XML formats while supporting the latest schema.

## Dependencies

- **DoenaSoft.AbstractionLayer.WinForms** (v2.0.4) - Abstraction layer for Windows Forms interactions
- **DoenaSoft.DVDProfiler.Helper** (v4.0.0) - Common helper utilities for DVD Profiler operations

## Building from Source

### Prerequisites

- Visual Studio 2022 or later (or Visual Studio 2026 as in development)
- .NET Framework 4.7.2 SDK
- .NET 10 SDK

### Build Steps

1. Clone the repository:
   `ash
   git clone https://github.com/DJDoena/DVDProfilerXML.git
   cd DVDProfilerXML
   `

2. Open the solution in Visual Studio or build from command line:
   `ash
   dotnet build
   `

3. Run tests (if available):
   `ash
   dotnet test
   `

### Project Structure

`
DVDProfilerXML/
|-- 3.5.1/           # DVD Profiler 3.5.1 schema and classes
|-- 3.6.0/           # DVD Profiler 3.6.0 schema and classes
|-- 3.8.0/           # DVD Profiler 3.8.0 schema and classes
|-- 3.8.1/           # DVD Profiler 3.8.1 schema and classes (with COO)
|-- 3.9.0/           # DVD Profiler 3.9.0 schema and classes
|-- 4.0.0/           # DVD Profiler 4.0.0 schema and classes (Latest)
|-- *.cs             # Common interfaces and utilities
|-- DVDProfiler.Xml.csproj
`

## Contributing

Contributions are welcome! If you'd like to contribute to this project:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Guidelines

- Follow the existing code style and conventions
- Add XML documentation comments for public APIs
- Ensure backward compatibility when possible
- Update the README if you add new features

## License

This project is licensed under the MIT License. See the LICENSE file for details.

Copyright (c) Doena Soft. 2010 - 2026

## Author

**DJ Doena**  
Doena Soft.

- GitHub: [@DJDoena](https://github.com/DJDoena)
- Project URL: https://github.com/DJDoena/DVDProfilerXML
- NuGet Package: https://www.nuget.org/packages/DoenaSoft.DVDProfiler.Xml/

---

## Disclaimer

This library is not affiliated with, endorsed by, or connected to Invelos LLC or the DVD Profiler software. DVD Profiler is a trademark of Invelos LLC. This library is an independent tool created to work with DVD Profiler's XML export functionality.

## Support

For bug reports, feature requests, or questions, please open an issue on the [GitHub repository](https://github.com/DJDoena/DVDProfilerXML/issues).

---

*Made with care for the DVD Profiler community*
