
let submitButton = document.getElementById("projNameButton");
let projNameLabel = document.getElementById("projName");
let projNameTextInput = document.getElementById("projNameTextInput");

function resolveTextInput(element) {
    return element.value;
}

function updateProjNameLabel() {
    projNameLabel.value = resolveTextInput(projNameTextInput);
    console.log("updated projName");
}