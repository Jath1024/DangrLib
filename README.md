
<!--
    This file Is generated using T4 Text Templates. Do Not Modify. 
    Make changes to T4 files directly.
-->

<div style="text-align:center">

# DangrLib ![DangrLib](https://raw.githubusercontent.com/Dangerdan9631/DangrLib/master/Images/Logo/skulllogo64.png)

[![Release](https://img.shields.io/github/release/Dangerdan9631/DangrLib.svg)](https://github.com/Dangerdan9631/DangrLib/releases)
[![License](https://img.shields.io/github/license/Dangerdan9631/DangrLib.svg)](https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE)
[![Issues](https://img.shields.io/github/issues-raw/Dangerdan9631/DangrLib.svg)](https://github.com/Dangerdan9631/DangrLib/issues)

[![BuildStatus](https://img.shields.io/appveyor/ci/Dangerdan9631/DangrLib.svg)](https://ci.appveyor.com/project/Dangerdan9631/DangrLib)
[![CodeCoverage](https://img.shields.io/codecov/c/github/Dangerdan9631/DangrLib.svg)](https://codecov.io/gh/Dangerdan9631/DangrLib)
[![CodeAnalysis](https://www.codefactor.io/repository/github/Dangerdan9631/DangrLib/badge)](https://www.codefactor.io/repository/github/Dangerdan9631/DangrLib)

</div>

---

**DangrLib** is a collection of classes, interfaces, and values that provide useful utilities across various segments of application programming. 

It started as separate personal projects and libraries, that I soon realized had a lot of common code. So I began merging and refactoring the code into
a common code base.

## Feedback and proposals for DangrLib

**Vote** for the proposals you like, and **add** yours:

[![Feature Requests](http://feathub.com/Dangerdan9631/DangrLib?format=svg)](http://feathub.com/Dangerdan9631/DangrLib)

## API Reference

For library details and code samples and see the [API Reference](https://dangerdan9631.github.io/DangrLib/).

## Getting Started

To install **DangrLib**, clone this repository and reference the packages from your _.csproj_

```
git clone https://github.com/Dangerdan9631/DangrLib.git
```

*Or*

Run the following command in the [Visual Studio] Package Manager Console for each of the packages you want.

```
Install-Package Dangr.Async
Install-Package Dangr.Build
Install-Package Dangr.Command
Install-Package Dangr.Configuration
Install-Package Dangr.Diagnostics
Install-Package Dangr.Entity
Install-Package Dangr.Event
Install-Package Dangr.Logging
Install-Package Dangr.Logging.Interface
Install-Package Dangr.Logging.Loggers
Install-Package Dangr.Logging.Wcf
Install-Package Dangr.Math
Install-Package Dangr.ObjectPool
Install-Package Dangr.Registry
Install-Package Dangr.Test
Install-Package Dangr.Util
```

### Prerequisites

[Visual Studio]

### Optional tools used

[Resharper] - Code analysis and refactoring.

[GhostDoc] - Generating XML doc comments (Documentation files generated using [DocFx]).

### Installing

The **DangrLib** libraries can be built out of the box using [Visual Studio].

## Running the tests

Unit tests can be run using **MSTest** in the [Visual Studio] Test Explorer.

Each package has it's own MSTest project.

Coding style should follow the guidelines in the [Visual Studio] and [Resharper] code analysis rules included in the Solution.

## Packages
| Package | Version | Description |
| --- | :---: | --- | 
| **Dangr.Async** | [![nuget](https://img.shields.io/nuget/v/Dangr.Async.svg)](https://www.nuget.org/packages/Dangr.Async/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Async.svg)](https://www.nuget.org/packages/Dangr.Async/) | Asynchronous code execution utilities for use with DangrLib. |
| **Dangr.Build** | [![nuget](https://img.shields.io/nuget/v/Dangr.Build.svg)](https://www.nuget.org/packages/Dangr.Build/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Build.svg)](https://www.nuget.org/packages/Dangr.Build/) | Provides build tools to use in DangrLib packages. |
| **Dangr.Command** | [![nuget](https://img.shields.io/nuget/v/Dangr.Command.svg)](https://www.nuget.org/packages/Dangr.Command/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Command.svg)](https://www.nuget.org/packages/Dangr.Command/) | Utilities for parsing and executing commands from a command line. |
| **Dangr.Configuration** | [![nuget](https://img.shields.io/nuget/v/Dangr.Configuration.svg)](https://www.nuget.org/packages/Dangr.Configuration/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Configuration.svg)](https://www.nuget.org/packages/Dangr.Configuration/) | Utilities for loading and accessing configuration data in a scoped manner. |
| **Dangr.Diagnostics** | [![nuget](https://img.shields.io/nuget/v/Dangr.Diagnostics.svg)](https://www.nuget.org/packages/Dangr.Diagnostics/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Diagnostics.svg)](https://www.nuget.org/packages/Dangr.Diagnostics/) | Diagnostic utilities for use with DangrLib. |
| **Dangr.Entity** | [![nuget](https://img.shields.io/nuget/v/Dangr.Entity.svg)](https://www.nuget.org/packages/Dangr.Entity/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Entity.svg)](https://www.nuget.org/packages/Dangr.Entity/) | Utilities for creating and tracking entities with unique ids. |
| **Dangr.Event** | [![nuget](https://img.shields.io/nuget/v/Dangr.Event.svg)](https://www.nuget.org/packages/Dangr.Event/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Event.svg)](https://www.nuget.org/packages/Dangr.Event/) | Utilities for publishing and subscribing to event channels. |
| **Dangr.Logging** | [![nuget](https://img.shields.io/nuget/v/Dangr.Logging.svg)](https://www.nuget.org/packages/Dangr.Logging/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Logging.svg)](https://www.nuget.org/packages/Dangr.Logging/) | Logging framework for use with DangrLib. |
| **Dangr.Logging.Interface** | [![nuget](https://img.shields.io/nuget/v/Dangr.Logging.Interface.svg)](https://www.nuget.org/packages/Dangr.Logging.Interface/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Logging.Interface.svg)](https://www.nuget.org/packages/Dangr.Logging.Interface/) | Provides a generalized interface for interacting with a logging framework. |
| **Dangr.Logging.Loggers** | [![nuget](https://img.shields.io/nuget/v/Dangr.Logging.Loggers.svg)](https://www.nuget.org/packages/Dangr.Logging.Loggers/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Logging.Loggers.svg)](https://www.nuget.org/packages/Dangr.Logging.Loggers/) | Default loggers that can be used with DangrLib's logging framework. |
| **Dangr.Logging.Wcf** | [![nuget](https://img.shields.io/nuget/v/Dangr.Logging.Wcf.svg)](https://www.nuget.org/packages/Dangr.Logging.Wcf/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Logging.Wcf.svg)](https://www.nuget.org/packages/Dangr.Logging.Wcf/) | WCF based logging utilities for use with DangrLib's logging framework. |
| **Dangr.Math** | [![nuget](https://img.shields.io/nuget/v/Dangr.Math.svg)](https://www.nuget.org/packages/Dangr.Math/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Math.svg)](https://www.nuget.org/packages/Dangr.Math/) | Math utilities for use with DangrLib. |
| **Dangr.ObjectPool** | [![nuget](https://img.shields.io/nuget/v/Dangr.ObjectPool.svg)](https://www.nuget.org/packages/Dangr.ObjectPool/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.ObjectPool.svg)](https://www.nuget.org/packages/Dangr.ObjectPool/) | Provides generic object pool utilities. |
| **Dangr.Registry** | [![nuget](https://img.shields.io/nuget/v/Dangr.Registry.svg)](https://www.nuget.org/packages/Dangr.Registry/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Registry.svg)](https://www.nuget.org/packages/Dangr.Registry/) | Utilities for accessing shared data in a scoped manner. |
| **Dangr.Test** | [![nuget](https://img.shields.io/nuget/v/Dangr.Test.svg)](https://www.nuget.org/packages/Dangr.Test/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Test.svg)](https://www.nuget.org/packages/Dangr.Test/) | Test utilities for use with DangrLib. |
| **Dangr.Util** | [![nuget](https://img.shields.io/nuget/v/Dangr.Util.svg)](https://www.nuget.org/packages/Dangr.Util/)</br>[![nuget](https://img.shields.io/nuget/dt/Dangr.Util.svg)](https://www.nuget.org/packages/Dangr.Util/) | Miscellaneous utilities for use with DangrLib. |

## Contributing

Please read [CONTRIBUTING.md](https://github.com/Dangerdan9631/DangrLib/blob/master/.github/CONTRIBUTING.md) for details on the code of conduct, and the process for submitting pull requests.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/Dangerdan9631/DangrLib/tags). 

## Authors

* **Dan Garvey** - [DangerDan9631](https://github.com/Dangerdan9631) - *Initial work*

See also the list of [contributors](https://github.com/Dangerdan9631/DangrLib/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE) file for details

## Acknowledgments

* **Shields.io** - http://shields.io/ - Badges
* **Docfx** - https://github.com/dotnet/docfx - API Documentation and GH Pages generator.
* **Billie Thompson** - [PurpleBooth](https://github.com/PurpleBooth) - *[README.md](https://gist.github.com/PurpleBooth/109311bb0361f32d87a2) and [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) templates*

<!--
    Links
-->
[DocFx]: https://github.com/dotnet/docfx
[FeatHubPage]: http://feathub.com/Dangerdan9631/DangrLib
[GhostDoc]: http://submain.com/products/ghostdoc.aspx
[Resharper]: https://www.jetbrains.com/resharper/
[Visual Studio]: https://www.visualstudio.com/
