// main.js

// Modules to control application life and create native browser window
const { app, BrowserWindow, ipcMain } = require('electron')
const path = require('path')
const fs = require("fs")
var util = require("util")



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

function handleSendJson(data) {
  // make the log file blank
  fs.writeFileSync("./dawngui.log", ``, function (err) {
    if (err) {
      return console.log(err);
    }
  });

  console.log(`Recieved data from preload/rederer! ${data}`);
  let projObj = JSON.parse(data);

  projName = projObj.projName;
  OS = projObj.OS;

  console.log(projName);
  console.log(OS);

  rootDir = `./${projName}`;

  logToFile(`[-] Creating DAWN project, "${projName}"`);

  // if it exists
  if (fs.existsSync(rootDir)) {
    logToFile(`[!] Project, \"${projName}\" already exists!`);
    return;
  }

  if (OS == "Windows") {
    logToFile("[-] Retrieving DAWN exe");
    logToFile("[✔] Retrieved DAWN executable (Didn't download, not implemented)");
  } else {
    logToFile("[X] *NIX is not available as of now, skipping backend download. Build from source instead");
  }

  logToFile("[-] Making JSON appconfig file");

  appConfigContent = {
      "Prefixes": ["http://localhost:8080/"],
      "RootDir": `./${projName}/`,
      "Mappings": [
        {
          "request_path": "/",
          "filename": `./${projName}/index.html`
        },
        {
          "request_path": "",
          "filename": `./${projName}/index.html`
        },
        {
          "request_path": "/index",
          "filename": `./${projName}/index.html`
        },
        {
          "request_path": "/home",
          "filename": `./${projName}/index.html`
        }
      ]
    }

    //make appconfig

  };


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

