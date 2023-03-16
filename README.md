<img style="width:25%;" src="./Docs/logo.png" />

# DAWN (Dotnet and JS/PY Web Network)

This is a webserver project written in JS/PY and C#. The
webserver itself is written entirely in C#, however, the
frontend of the webserver is written in JS/PY. JS/PY also
will help take care of deploying new DAWN applications.

DAWN must be ran as administrator on Windows.
DAWN does not require `sudo` on Linux.

**NOTICE:** ``DAWN.exe`` in the release is not the latest, this notice will go away when it is updated.

## Simple, Quick Usage

```sh
# Nightly
$ cd ./DAWN/Backend
# The website files are located in `./TestApp`
$ dotnet restore
$ dotnet run # elevated privileges are needed

# Stable
$ cd ./DAWN/CLI
$ python3 ./dawn.py MyProject
$ cd ./MyProject
$ ./DAWN.exe # if on windows, if you are on linux, you need to build from source in `./DAWN/Backend`
```

## Documentation

<details>
<summary>CLI</summary>
<br />

# [DAWN CLI](./Docs/CLI.md)

DAWN utilizes CLI in order to take
instructions from users. You can use
this CLI to build, deploy, and modify
DAWN applicaitons.

```sh
$ cd ./DAWN/CLI
$ ./dawn.py --help
```


# Create

The ``create`` command in DAWN lets you
create a new DAWN application. It takes
one argument which is the name of the project.

```sh
$ cd ./DAWN/CLI
$ ./dawn.py MyProject
# alternatively, for a GUI,
$ cd ./DAWN/Frontend/dawn-gui # (for create)
# you can either install the npm packages (electron, electron-forge/cli) and call npm start
# or unzip the executables in dist/ and run those
```

# Deploy

The ``deploy`` command in DAWN lets you
deploy a DAWN application via docker. It
takes one argument which is the name of
the project.

```sh
$ cd ./DAWN/CLI
$ ./dawn.py deploy MyProj
```

<hr />
</details> 

<details>
<summary>Config</summary>
<br />

# [Config](./Docs/Config.md) 

The config consists of a few key value pairs
that are imported by the webserver. The first
of these is the prefix array. This is an array
of prefixes that the webserver will use when
accepting incoming connections.

```json
{ 
    "Prefixes" : [ "http://localhost:8080/" ]
}
```

The next key value pair in the config is the root
directory value. The root directory is the directory
where your HTML is.

```json
{ 
    "RootDir" : "./TestApp/"
}
```

The last value is the Mappings array. This is to
declare what urls lead to what files.

```json
{
    "Mappings" : [ 
        {
            "request_path" : "/",
            "filename" : "./TestApp/index.html"
        },
        {
            "request_path" : "",
            "filename" : "./TestApp/index.html"
        }
    ]
}
```

The `RootDir` and `Mappings` are automatically tailored to the name of your DAWN project.

<hr />
</details>

<details>
<summary>Building from source</summary>
<br />

# [Building From Source](./Docs/BuildingFromSource.md)

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

<hr />
</details>

## Screenshots
Includes logging, app info, etc.
<details>
<summary>Click to view Backend screenshots</summary>
<br />
<img src="https://media.discordapp.net/attachments/1084018888825634857/1085746833504088075/image.png" />
<br />
<img src="https://cdn.discordapp.com/attachments/1084018888825634857/1085746942086234222/image.png" />
<br />
<img src="https://cdn.discordapp.com/attachments/1084018888825634857/1085747030036598794/image.png" />
<br />
<img style="width:40%;" src="https://cdn.discordapp.com/attachments/1084018888825634857/1085747128518844508/image.png" />
<hr />
</details>

<br />

<details>
<summary>Click to view CLI screenshots</summary>
<br />
<img src="https://media.discordapp.net/attachments/1084018888825634857/1085749149703606273/90a1b735-e266-4747-adeb-6f3a0f79fa1e.png" />
<br />
<img src="https://media.discordapp.net/attachments/1084018888825634857/1085749365773176983/image.png" />
<br />
<img src="https://cdn.discordapp.com/attachments/1084018888825634857/1085749613056757812/image.png" />
<br />
<img style="width:40%;" src="https://cdn.discordapp.com/attachments/1084018888825634857/1085749908188971049/4796e621-ffd3-4aab-be50-998e22373c75.png" />
<hr />
</details>

<br />

<details>
<summary>Click to view GUI screenshots</summary>
<br />
<img src="https://cdn.discordapp.com/attachments/1084018888825634857/1085751805419466832/showcase1.gif" />
<br />
<img src="https://cdn.discordapp.com/attachments/1084018888825634857/1085752580430385202/showcase2.gif" />
<br />
<img src="https://cdn.discordapp.com/attachments/1084018888825634857/1085752877236113498/image.png" />
<hr />
</details>

## Contributing
Contributions to this project are welcome. If you encounter a bug or have a feature request, please open an issue.

## License
This project is licensed under the terms of the AGPL-3.0 license. See ``LICENSE`` for more information.