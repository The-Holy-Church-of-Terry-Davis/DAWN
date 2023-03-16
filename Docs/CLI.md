# DAWN CLI

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