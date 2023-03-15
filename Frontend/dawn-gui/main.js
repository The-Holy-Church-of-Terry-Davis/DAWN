// main.js

// Modules to control application life and create native browser window
const { app, BrowserWindow, ipcMain } = require('electron')
const path = require('path')
const fs = require("fs")
var util = require("util")
const http = require('http');



let mainWindow;

const createWindow = () => {
  // Create the browser window.
  mainWindow = new BrowserWindow({
    width: 500,
    height: 500,
    frame: true,
    minimizable: true,
    maximizable: false,
    resizable: false,
    closable: true,
    icon: __dirname + "./logo.ico",
    webPreferences: {
      nodeIntegration: false, // is default value after Electron v5
      contextIsolation: true, // protect against prototype pollution
      enableRemoteModule: false, // turn off remote
      preload: path.join(__dirname, 'preload.js')
    }
  })

  // and load the index.html of the app.
  mainWindow.removeMenu();
  mainWindow.loadFile('index.html');

  // Open the DevTools.
  //mainWindow.webContents.openDevTools();
}

function logToFile(msg) {
  console.log(msg);
  fs.appendFileSync("./dawngui.log", `${msg}\n`, function (err) {
    if (err) {
      return console.log(err);
    }
  });
}

function clearLog() {
  fs.writeFileSync("./dawngui.log", ``, function (err) {
    if (err) {
      return console.log(err);
    }
  });
}

function downloadExe(rootDir, projName) {
  const file = fs.createWriteStream(`${rootDir}/dawn.exe`);
  const request = http.get(
    "http://github.com/The-Holy-Church-of-Terry-Davis/DAWN/releases/download/2023-3-11.4/DAWN.exe",
    function (response) {
      response.pipe(file);

      // after download completed close filestream
      file.on("finish", () => {
        file.close();
        logToFile("[✔] Retrieved DAWN executable");
        setupBasics(rootDir, projName);
      });
    }
  );
  return;
}

function getExecutable(rootDir, projName, OS) {
  // if it exists
  if (fs.existsSync(rootDir)) {
    logToFile(`[!] Project, \"${projName}\" already exists!`);
    return;
  }

  fs.mkdirSync(rootDir);

  if (OS == "Windows") {
    logToFile("[-] Retrieving DAWN exe");
    downloadExe(rootDir, projName);
  } else {
    logToFile(
      "[X] *NIX is not available as of now, skipping backend download. Build from source instead"
    );
    setupBasics(rootDir, projName);
  }
  return;
}

function handleSendJson(data) {
  // make the log file blank
  clearLog();

  console.log(`Recieved data from preload/rederer! ${data}`);
  let projObj = JSON.parse(data);

  let projName = projObj.projName;
  let OS = projObj.OS;

  console.log(projName);
  console.log(OS);

  let rootDir = `./${projName}`;

  logToFile(`[-] Creating DAWN project, "${projName}"`);
  getExecutable(rootDir, projName, OS);
  return;
}

////////////////////////////////////////////

function setupBasics(rootDir, projName) {
  logToFile("[-] Making JSON appconfig file");

  appConfigContent = {
    Prefixes: ["http://localhost:8080/"],
    RootDir: `./${projName}/`,
    Mappings: [
      {
        request_path: "/",
        filename: `./${projName}/index.html`,
      },
      {
        request_path: "",
        filename: `./${projName}/index.html`,
      },
      {
        request_path: "/index",
        filename: `./${projName}/index.html`,
      },
      {
        request_path: "/home",
        filename: `./${projName}/index.html`,
      },
    ],
  };

  // make appconfig

  fs.writeFileSync(
    `${rootDir}/appconfig.json`,
    JSON.stringify(appConfigContent, null, 4),
    function (err) {
      if (err) {
        return logToFile(`[X] ${err}`);
      }
    }
  );

  logToFile("[✔] Made JSON config file");
  logToFile("[-] Retrieving and making basic files");

  fs.mkdirSync(`${rootDir}/${projName}`);

  const file = fs.createWriteStream(`${rootDir}/${projName}/logo.png`);
  const request = http.get(
    "http://raw.githubusercontent.com/The-Holy-Church-of-Terry-Davis/DAWN/main/Docs/logo.png",
    function (response) {
      response.pipe(file);

      // after download completed close filestream
      file.on("finish", () => {
        file.close();

        let htmlContent =
          '<html><head> <title>Welcome to DAWN</title> <link rel="icon" type="image/png" href="logo.png"></head><body> <style>:root{--blue: #377497; --purple: #442261; --red: #ff2300; --yellow: #ffc200;}body{background-color: rgb(20, 20, 20); margin: 0; border: 0; color: white; font-family: Arial;}#container{position: absolute; top: 50%; left: 50%; -webkit-transform: translate(-50%, 50%); -ms-transform: translate(-50%, 50%); transform: translate(-50%, -50%); text-align: center;}#D{color: var(--yellow);}#A{color: var(--red);}#W{color: var(--blue);}#N{color: var(--purple);}span{text-decoration: underline;}a{color: var(--blue); text-decoration: underline; text-decoration-color: transparent; transition: all .25s ease; -webkit-text-decoration-color: transparent; -moz-text-decoration-color: transparent;}a:hover{text-decoration-color: var(--blue); -webkit-text-decoration-color: var(--blue); -moz-text-decoration-color: var(--blue);}h4{color: rgb(200, 200, 200);}h1{line-height: .2em;}#logo{width: 40%; transition: all .4s cubic-bezier(0.6, -0.28, 0.735, 0.045); padding-bottom: .5rem;}#logo:hover{transform: scale(1.1);}</style> <div id="container"> <img id="logo" src="logo.png" alt="logo"/> <h1>Welcome to <span id="D">D</span><span id="A">A</span><span id="W">W</span><span id="N">N</span>!</h1> <h4>GitHub repository is located <a href="https://github.com/The-Holy-Church-of-Terry-Davis/DAWN">here</a></h4> </div></body></html>';

        fs.writeFileSync(
          `${rootDir}/${projName}/index.html`,
          htmlContent,
          function (err) {
            return logToFile(`[X] ${err}`);
          }
        );

        logToFile("[✔] Retrieved and made basic files");
        logToFile(`[✔] Your DAWN project, \"${projName}\" is all setup :)`);
      });
    }
  );

  return;
}



app.whenReady().then(() => {
  // make the file blank
  fs.writeFileSync("./dawngui.log", ``, function (err) {
    if (err) {
      return console.log(err);
    }
  });
  createWindow()
});


ipcMain.on("toMain", (event, args) => {
  fs.watchFile(path.join(__dirname, 'dawngui.log'), (error, data) => {
    // Do something with file contents
    data = fs.readFile(path.join(__dirname, 'dawngui.log'), (error, data) => {
      // Send result back to renderer process
      mainWindow.webContents.send("fromMain", data.toString('utf8'));
    })
  });
});

ipcMain.on('sendJson', (event, args) => {
  handleSendJson(args);
});



/*
ipcMain.on("fromMain", (event, args) => {
  fs.readFile("./dawngui.log", (error, data) => {
    // Do something with file contents
    console.log(data);
  });
});

ipcMain.on("setJson", (event, data, args) => {
  console.log("data recieved from preload/renderer");
  console.log(data);
});
*/

