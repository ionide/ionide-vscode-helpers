# Ionide-Helpers

[![](https://ci.appveyor.com/api/projects/status/6kcn1ewp5bf8687e?svg=true)](https://ci.appveyor.com/project/Ionide/ionide-vscode-helpers)

Helper library containing some common functionalities used by other ionide plugins for [Visual Studio Code](https://github.com/Microsoft/vscode).

## Contributing and copyright

The project is hosted on [GitHub](https://github.com/ionide/ionide-helpers) where you can [report issues](https://github.com/ionide/ionide-helpers/issues), fork
the project and submit pull requests.

The library is available under [MIT license](https://github.com/ionide/ionide-helpers/blob/master/LICENSE.md), which allows modification and
redistribution for both commercial and non-commercial purposes.

Please note that this project is released with a [Contributor Code of Conduct](CODE_OF_CONDUCT.md). By participating in this project you agree to abide by its terms.

## Building

Building this project require a few things :

* A .Net 4 environment (Microsoft version on windows, Mono on mac/linux)
* [.Net 5](https://www.microsoft.com/net/core)
* [Node.js](https://nodejs.org/en/download/)
* [Yarn berry](https://yarnpkg.com/en/docs/install)

With that installed the project should build using `build.sh` / `build.cmd` or when Ctrl+Shift+B is used in VSCode.
