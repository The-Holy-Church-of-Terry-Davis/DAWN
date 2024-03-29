# Config (`appconfig.json`)

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