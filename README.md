# DAWN (Dart and C# Web Network)

This is a webserver project written in Dart and C#. The
webserver itself is written entirely in C#, however, the
frontend of the webserver is written in Dart. Dart also
will help take care of deploying new DAWN applications.


**Screenshot**
Includes logging, app info, etc.
<img src="https://cdn.discordapp.com/attachments/1084018888825634857/1084410168256774175/image.png"/>

## TODO 
- [x] CLI file does work properly when actually creating the files, however, the config file is static and therefore doesn't conform to user input... meaning if i do ./cli.py test then it wont be able to find the HTML because it won't put it in test/TestApp but instead test/test. We may have to use some JSON libs in python to edit the mappings and rootdir... or we could set those to be static at "TestApp". But I think it would be better just to edit them programmatically, its more intuitive.

- [ ] Addition of logs for the webserver

- [ ] Start looking into HTTPS support for DAWN (I don't know too much about HTTPS but I know SSL is a pain in the ass) I'm thinking of maybe just not doing this though; my reasoning being that we could encourage using a reverse proxy like ingress to drop SSL certs in front of DAWN applications which makes more sense anyways. But that also discourages people who just want to set up a simple website from using DAWN

- [ ] ~~Add stormy to the repo so he can help us do our skid shit~~ (Doesn't want to join and then bitches about wanting to join but then says doesnt want to join)