# DangrLib ![DangrLib][logo] 
[![GitHub release][GithubReleaseShield]][GithubRelease] 
[![Build Status][BuildStatusShield]][AppVeyorProject]
[![Code Factor][CodeFactorShield]][CodeFactorRepository]
[![codecov][CodeCovShield]][CodeCovRepository]

---

**DangrLib** is a collection of classes, interfaces, and values that provide useful utilities across various segments of application programming. 

It started as separate personal projects and libraries, that I soon realized had a lot of common code. So I began merging and refactoring the code into
a common code base.

## Collecting feedbacks and proposals for DocFX

Let's make DangrLib better together!

**Vote** for the proposals you like, and **add** yours:
[![Feature Requests][FeatHubShield]][FeatHubPage]

## Getting Started

To install **DangrLib**, clone this repository and reference the packages from your _.csproj_

```
git clone https://github.com/Dangerdan9631/DangrLib.git
```

*Or*

Run the following command in the [Visual Studio] Package Manager Console for each of the packages you want.

```
Install-Package Dangr.Annotation
Install-Package Dangr.Async
Install-Package Dangr.Command
Install-Package Dangr.Configuration
Install-Package Dangr.Diagnostics
Install-Package Dangr.Entity
Install-Package Dangr.Event
Install-Package Dangr.Inject
Install-Package Dangr.Logging
Install-Package Dangr.Logging.Loggers
Install-Package Dangr.Logging.Wcf
Install-Package Dangr.Math
Install-Package Dangr.ObjectPool
Install-Package Dangr.Registry
Install-Package Dangr.Simulation
Install-Package Dangr.Test
Install-Package Dangr.Util
```

### Prerequisites

[Visual Studio]

### Optional tools used

[Resharper] - Code analysis and refactoring.

[GhostDoc] - Generating XML doc comments.

[Sandcastle Help File Builder (SHFB)][SHFB] - Building help files.

### Installing

The **DangrLib** libraries can be built out of the box using [Visual Studio].

## Running the tests

Unit tests can be run using **MSTest** in the [Visual Studio] Test Explorer.

Each package has it's own MSTest project.

Coding style should follow the guidelines in the [Visual Studio] and [Resharper] code analysis rules included in the Solution.

## Packages
| Package | Version | Description |
| --- | :---: | --- | 
| **Dangr.Annotation** | [![nuget][NugetV1.0Shield]][Dangr.Annotation] | A collection of attributes useful for adding annotations and documentation to your code. |
| **Dangr.Async** | [![nuget][NugetV1.0Shield]][Dangr.Async] | Asynchronous code execution utilities for use with DangrLib. |
| **Dangr.Command** | [![nuget][NugetV1.0Shield]][Dangr.Command] | Utilities for parsing and executing commands from a command line. |
| **Dangr.Configuration** | [![nuget][NugetV1.0Shield]][Dangr.Configuration] | Utilities for loading and accessing configuration data in a scoped manner. |
| **Dangr.Diagnostics** | [![nuget][NugetV1.0Shield]][Dangr.Diagnostics] | Diagnostic utilities for use with DangrLib. |
| **Dangr.Entity** | [![nuget][NugetV1.0Shield]][Dangr.Entity] | Utilities for creating and tracking entities with unique ids. |
| **Dangr.Event** | [![nuget][NugetV1.0Shield]][Dangr.Event] | Utilities for publishing and subscribing to event channels. |
| **Dangr.Inject** | [![nuget][NugetV1.0Shield]][Dangr.Inject] | Dependency Injection utilities for use with DangrLib. |
| **Dangr.Logging** | [![nuget][NugetV1.0Shield]][Dangr.Logging] | Logging framework for use with DangrLib. |
| **Dangr.Logging.Loggers** | [![nuget][NugetV1.0Shield]][Dangr.Logging.Loggers] | Default loggers that can be used with DangrLib's logging framework. |
| **Dangr.Logging.Wcf** | [![nuget][NugetV1.0Shield]][Dangr.Logging.Wcf] | WCF based logging utilities for use with DangrLib's logging framework. |
| **Dangr.Math** | [![nuget][NugetV1.0Shield]][Dangr.Math] | Math utilities for use with DangrLib. |
| **Dangr.ObjectPool** | [![nuget][NugetV1.0Shield]][Dangr.ObjectPool] | Provides generic object pool utilities. |
| **Dangr.Registry** | [![nuget][NugetV1.0Shield]][Dangr.Registry] | Utilities for accessing shared data in a scoped manner. |
| **Dangr.Simulation** | [![nuget][NugetV1.0Shield]][Dangr.Simulation] | A library used to simulate digital logic circuits. |
| **Dangr.Test** | [![nuget][NugetV1.0Shield]][Dangr.Test] | Test utilities for use with DangrLib. |
| **Dangr.Util** | [![nuget][NugetV1.0Shield]][Dangr.Util] | Miscellaneous utilities for use with DangrLib. |

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

* **Billie Thompson** - [PurpleBooth](https://github.com/PurpleBooth) - *[README.md](https://gist.github.com/PurpleBooth/109311bb0361f32d87a2) and [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) templates*

<!--
    Image links
-->
[logo]: https://github.com/Dangerdan9631/DangrLib/raw/master/Images/Logo/skulllogo64.png

<!--
    Shields
-->
[GithubReleaseShield]: https://img.shields.io/badge/release-v1.0-2D64F5.svg
[BuildStatusShield]: https://ci.appveyor.com/api/projects/status/43vxfn09qxuvdih5?svg=true
[CodeFactorShield]: https://www.codefactor.io/repository/github/dangerdan9631/dangrlib/badge
[NugetV1.0Shield]: https://img.shields.io/badge/nuget-v1.0-2D64F5.svg
[CodeCovShield]: https://codecov.io/gh/Dangerdan9631/DangrLib/branch/master/graph/badge.svg
[FeatHubShield]: http://feathub.com/Dangerdan9631/DangrLib?format=svg

<!--
    Links
-->
[GithubRelease]: https://github.com/Dangerdan9631/DangrLib/releases/tag/v1.0
[Visual Studio]: https://www.visualstudio.com/
[Resharper]: https://www.jetbrains.com/resharper/
[GhostDoc]: http://submain.com/products/ghostdoc.aspx
[SHFB]: https://github.com/EWSoftware/SHFB
[AppVeyorProject]: https://ci.appveyor.com/project/Dangerdan9631/dangrlib
[CodeFactorRepository]: https://www.codefactor.io/repository/github/dangerdan9631/dangrlib
[CodeCovRepository]: https://codecov.io/gh/Dangerdan9631/DangrLib
[FeatHubPage]: http://feathub.com/Dangerdan9631/DangrLib

[Dangr.Annotation]: https://www.nuget.org/packages/Dangr.Annotation/ "DangrLib"
[Dangr.Async]: https://www.nuget.org/packages/Dangr.Async/ "DangrLib"
[Dangr.Command]: https://www.nuget.org/packages/Dangr.Command/ "DangrLib"
[Dangr.Configuration]: https://www.nuget.org/packages/Dangr.Configuration/ "DangrLib"
[Dangr.Diagnostics]: https://www.nuget.org/packages/Dangr.Diagnostics/ "DangrLib"
[Dangr.Entity]: https://www.nuget.org/packages/Dangr.Entity/ "DangrLib"
[Dangr.Event]: https://www.nuget.org/packages/Dangr.Event/ "DangrLib"
[Dangr.Inject]: https://www.nuget.org/packages/Dangr.Inject/ "DangrLib"
[Dangr.Logging]: https://www.nuget.org/packages/Dangr.Logging/ "DangrLib"
[Dangr.Logging.Loggers]: https://www.nuget.org/packages/Dangr.Logging.Loggers/ "DangrLib"
[Dangr.Logging.Wcf]: https://www.nuget.org/packages/Dangr.Logging.Wcf/ "DangrLib"
[Dangr.Math]: https://www.nuget.org/packages/Dangr.Math/ "DangrLib"
[Dangr.ObjectPool]: https://www.nuget.org/packages/Dangr.ObjectPool/ "DangrLib"
[Dangr.Registry]: https://www.nuget.org/packages/Dangr.Registry/ "DangrLib"
[Dangr.Simulation]: https://www.nuget.org/packages/Dangr.Simulation/ "DangrLib"
[Dangr.Test]: https://www.nuget.org/packages/Dangr.Test/ "DangrLib"
[Dangr.Util]: https://www.nuget.org/packages/Dangr.Util/ "DangrLib"
