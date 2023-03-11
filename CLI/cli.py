import urllib.request
from pathlib import Path
import argparse
from platform import system

"""
Author(s): Yendy, QAEZZ
PYPI Packages: None
Description:
    Simple config file...
"""


class color:
   PURPLE = '\033[1;35;48m'
   CYAN = '\033[1;36;48m'
   BOLD = '\033[1;37;48m'
   BLUE = '\033[1;34;48m'
   GREEN = '\033[1;32;48m'
   YELLOW = '\033[1;33;48m'
   RED = '\033[1;31;48m'
   END = '\033[0m'


DAWN = f"{color.BOLD}{color.YELLOW}D{color.RED}A{color.BLUE}W{color.PURPLE}N{color.END}"


def Create(val: str):
    dir = str("./" + val)
    try:
        Path(dir).mkdir()
    except FileExistsError:
        print(f"{color.BOLD}{color.RED}[!] Project, \"{val}\" already exists!{color.END}")
        return

    if system().lower() == "windows":
        print(f"{color.CYAN}[-] Retrieving {DAWN}{color.CYAN}.exe{color.END}")
        urllib.request.urlretrieve("https://github.com/The-Holy-Church-of-Terry-Davis/DAWN/releases/download/2023-3-9/Backend-Windows.exe", f"{dir}/DAWN.exe")
        print(f"{color.GREEN}[✔] Retrieved {DAWN}{color.GREEN}.exe{color.END}")
    else:
        print(f"\n{color.BOLD}{color.RED}[!] *NIX is not available as of now, skipping backend download{color.END}\n")

    print(f"{color.CYAN}[-] Retrieving JSON config file]{color.END}")
    urllib.request.urlretrieve("https://raw.githubusercontent.com/The-Holy-Church-of-Terry-Davis/DAWN/main/Backend/appconfig.json", f"{dir}/appconfig.json")
    print(f"{color.GREEN}[✔] Retrieved JSON config file{color.END}\n{color.CYAN}[-] Retrieving and making basic files{color.END}")


    Path(f"{dir}/{val}").mkdir()

    urllib.request.urlretrieve("https://raw.githubusercontent.com/The-Holy-Church-of-Terry-Davis/DAWN/main/Docs/logo.png", f"{dir}/{val}/logo.png")

    f = open(f"./{dir}/{val}/index.html", "w")
    f.write('<html><head> <title>Welcome to DAWN</title> <link rel="icon" type="image/png" href="logo.png"></head><body> <style>:root{--blue: #377497; --purple: #442261; --red: #ff2300; --yellow: #ffc200;}body{background-color: rgb(20, 20, 20); margin: 0; border: 0; color: white; font-family: Arial;}#container{position: absolute; top: 50%; left: 50%; -webkit-transform: translate(-50%, 50%); -ms-transform: translate(-50%, 50%); transform: translate(-50%, -50%); text-align: center;}#D{color: var(--yellow);}#A{color: var(--red);}#W{color: var(--blue);}#N{color: var(--purple);}span{text-decoration: underline;}a{color: var(--blue); text-decoration: underline; text-decoration-color: transparent; transition: all .25s ease; -webkit-text-decoration-color: transparent; -moz-text-decoration-color: transparent;}a:hover{text-decoration-color: var(--blue); -webkit-text-decoration-color: var(--blue); -moz-text-decoration-color: var(--blue);}h4{color: rgb(200, 200, 200);}h1{line-height: .2em;}#logo{width: 40%; transition: all .4s cubic-bezier(0.6, -0.28, 0.735, 0.045); padding-bottom: .5rem;}#logo:hover{transform: scale(1.1);}</style> <div id="container"> <img id="logo" src="logo.png" alt="logo"/> <h1>Welcome to <span id="D">D</span><span id="A">A</span><span id="W">W</span><span id="N">N</span>!</h1> <h4>GitHub repository is located <a href="https://github.com/The-Holy-Church-of-Terry-Davis/DAWN">here</a></h4> </div></body></html>')
    print(f"{color.GREEN}[✔] Retrieved and made basic files\n\n[✔] Your {DAWN}{color.GREEN} project, \"{val}\" is all setup :){color.END}")


parser = argparse.ArgumentParser()
parser.add_argument("create", help="Creates a DAWN app")
args = parser.parse_args()

if args.create:
    print(f"{color.CYAN}[-] Creating {DAWN}{color.CYAN} project, \"{args.create}\"{color.END}")
    Create(args.create)