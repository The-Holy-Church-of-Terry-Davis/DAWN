
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

const sleep = (ms) => new Promise((r) => setTimeout(r, ms));
function run() {
    window.api.send("toMain", "some data");
    
    window.api.receive("fromMain", (data) => {
        console.log(data)
        logArea.setAttribute('data', 'test.txt');
    });
}

run();