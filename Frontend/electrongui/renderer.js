
let submitButton = document.getElementById("projNameButton");
let projNameLabel = document.getElementById("projName");
let projNameTextInput = document.getElementById("projNameTextInput");
let runningOS = document.getElementById("runningOS");
let logArea = document.getElementById("logArea");

const osWindowsButton = document.getElementById("osWindowsButton");
const osLinuxButton = document.getElementById("osLinuxButton");

function getTextInput(element) { 
    val = element.value.replace(/[^a-zA-Z0-9]/g, "").replace(/\s/g, "");
    if (val == "") {
        val = "MyDawnProject";
    }
    return val;
}

function updateProjNameLabel() {
    projNameLabel.firstChild.data = getTextInput(projNameTextInput);
}

function runningOSSelect(operatingSystem) {
    if (operatingSystem == "Windows") {
        osWindowsButton.dataset.selected = true;
        osLinuxButton.dataset.selected = false;
    } else {
        osLinuxButton.dataset.selected = true;
        osWindowsButton.dataset.selected = false;
    }

    
    runningOS.firstChild.data = operatingSystem;

}

function createDawnApp() {
    projName = projNameLabel.firstChild.data;
    OS = runningOS.firstChild.data;

    jason = {
        "projName": projName,
        "OS": OS
    };
    console.log(projName);
    console.log(OS);
    console.log(`Sent data!\n${JSON.stringify(jason)}`);

    window.api.sendJson(JSON.stringify(jason));
    alert(`Creating DAWN App, "${projName}"`);
}

function run() {
    window.api.send("toMain", "some data");
    
    window.api.receive("fromMain", (data) => {
        console.log(data)
        logArea.setAttribute('data', './dawngui.log');
    });
}

run();