# My Revit addin project template
![Revit Version](https://img.shields.io/badge/Revit%20Version-2019_--_2024-blue.svg) ![.NET](https://img.shields.io/badge/.NET-4.7.1_--_4.8-blue.svg) <br>
![Revit Version](https://img.shields.io/badge/Revit%20Version-2025-blue.svg) ![.NET](https://img.shields.io/badge/.NET-8-blue.svg)

![GitHub last commit](https://img.shields.io/github/last-commit/russgreen/RevitAddinTemplate)

A Visual Studio project template to build a Revit addin in C# that can target multiple versions of Revit using different solution configurations per Revit version.

To install the template locally by running the following command in the project folder

`dotnet new install .`

This command lets the .NET template engine to consider the current folder (.) as a template package.

To uninstall this template run the following commend in the project folder

`dotnet new uninstall .`

Clear the template engine cache 

`del C:\Users\<username>\.templateengine`

The project uses Nice3Point libraries to access the Revit SDK libraries.  Alternatively, the csproj file has some some properties commented out that could used local copies of the SDK assuming the Revit SDK DLL's are in a folder named RevitAPI with dated sub-folders next to the folder where this solution is stored. e.g.
<pre>
📦Repos
 ┣ 📂RevitAddinTemplate
 ┃ ┣ 📂RevitAddinTemplate
 ┃ ┗ 📜RevitAddinTemplate.sln
 ┣ 📂MyRevitAPI
 ┃ ┣ 📂2018
 ┃ ┃ ┗ 📜SDK DLLs
 ┃ ┣ 📂2019
 ┃ ┃ ┗ 📜SDK DLLs
 ┃ ┣ 📂2020
 ┃ ┃ ┗ 📜SDK DLLs
 ┃ ┣ 📂2021
 ┃ ┃ ┗ 📜SDK DLLs
 ┃ ┣ 📂2022
 ┃ ┃ ┗ 📜SDK DLLs
 </pre>