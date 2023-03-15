// main.js

// Modules to control application life and create native browser window
const { app, BrowserWindow, ipcMain } = require('electron')
const path = require('path')
const fs = require("fs")



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
  mainWindow.removeMenu()
  mainWindow.loadFile('index.html')

  // Open the DevTools.
  // mainWindow.webContents.openDevTools()
}

app.on("ready", createWindow);


ipcMain.on("toMain", (event, args) => {
  fs.watchFile(path.join(__dirname, 'test.txt'), (error, data) => {
    // Do something with file contents
    data = fs.readFile(path.join(__dirname, 'test.txt'), (error, data) => {
      // Send result back to renderer process
      mainWindow.webContents.send("fromMain", data.toString('utf8'));
    })
  });
});

/*
ipcMain.on("fromMain", (event, args) => {
  fs.readFile("./test.txt", (error, data) => {
    // Do something with file contents
    console.log(data);
    responseObj = data;
    // Send result back to renderer process
    mainWindow.webContents.send("toMain", responseObj);
  });
});*/
