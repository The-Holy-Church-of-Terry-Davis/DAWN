# Building from source (``Backend/``)

The `Backend/` directory contains all the
files that make DAWN, well... work.

Dotnet 7.0 is required.

#### To test DAWN:
```sh
$ cd ./DAWN/Backend
$ dotnet restore
$ dotnet run
# The test application will run on http://localhost:8080
# The application website files are located at `./TestApp`
```

#### To build from source:
```sh
$ cd ./DAWN/Backend
$ dotnet restore
$ dotnet build
```