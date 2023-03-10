import urllib.request
import os
import argparse

def Create(val: str):
    dir = str("./" + val)
    os.mkdir(dir)
    os.chdir(dir)
    
    urllib.request.urlretrieve("https://github.com/The-Holy-Church-of-Terry-Davis/DAWN/releases/download/2023-3-9.2/DAWN.exe", "DAWN.exe")
    urllib.request.urlretrieve("https://raw.githubusercontent.com/The-Holy-Church-of-Terry-Davis/DAWN/main/Backend/appconfig.json", "appconfig.json")
    
    os.mkdir(val)
    os.chdir(dir)

    f = open("./index.html", "w")
    f.write("<p>Hello World!</p>")

parser = argparse.ArgumentParser()
parser.add_argument("create", help="Creates a DAWN app")
args = parser.parse_args()

if args.create:
    print("Creating DAWN project " + args.create)
    Create(args.create)