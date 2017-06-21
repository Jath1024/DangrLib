# Publishing a Nuget package

## Create .nuspec

A new .nuspec file can be created by copying one from another package. 

Most of the properties will be pulled from the projects AssemblyInfo.cs file. Make sure the following properties are present:
* AssemblyTitle
* AssemblyVersion
* AssemblyDescription
* AssemblyCompany
* AssemblyCopyright

Manually update the \<tags\> attribute.</br>
Add dependency packages.

## Publishing package
1. Update .nuspec file
   1. Make sure dependencies are up to date.
   1. Make sure tags are up to date.
   1. Make sure Copyright is up to date.
   1. Add any necessary release notes.
1. Create a Release build of the solution.
    * This will create the binaries and the nuget package.
1. Create a NugetDeploy build of the solution.
    * This will upload the packages to Nuget.
1. View packages on [nuget.org](https://www.nuget.org/account/Packages).
