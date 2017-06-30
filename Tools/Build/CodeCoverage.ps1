# -----------------------------------------------------------------------
#  <copyright file="CodeCoverage.ps1" company="DangerDan9631">
#      Copyright (c) 2017 Dan Garvey. All rights reserved.
#      Licensed under the MIT License. 
#      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
#  </copyright>
# -----------------------------------------------------------------------

#
# Build script that runs code coverage.
#

# Define paths to binaries.
$openCover = ".\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe";
$vsTest = "vstest.console.exe";

# Use Appveyor logger by default. Specify "local" as an argument to ignore this when running locally.
$logger = If ($args[0] -eq "local") { "/logger:Appveyor" } Else { "" };

# Searches the repository for test binaries.
$testBinaries = "";
Get-ChildItem -Path . -Filter Dangr.*.Test.dll -Recurse `
| Where-Object {
    [System.IO.Path]::GetFullPath($_.Directory) -match '.*\\bin\\Debug' 
}  `
| %{$testBinaries = $testBinaries + ' "' + $_.FullName + '"'};

# Define the code coverage filters.
$filter = "+[Dangr.*]*";          # Include Dangr.* modules.
$filter += " -[Dangr.*.Test]*";   # Exclude test modules
$filter += " -[*]*.NamespaceDoc"; # Exclude NamespaceDoc classes
$filter += " -[*]*Exception";     # Exclude Exception classes

# Specify the coverage results output file.
$outputFileName = ".\DangrLib_coverage.xml";

# Execute code coverage.
& $openCover `
    -register:user `
    -target:"$vsTest" `
    -targetargs:"$logger $testBinaries"`
    -filter:"$filter"`
    -output:"$outputFileName";
