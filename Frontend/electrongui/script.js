
let submitButton = document.getElementById("projNameButton");
let projNameLabel = document.getElementById("projName");
let projNameTextInput = document.getElementById("projNameTextInput");

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
