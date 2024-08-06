function restrictToAlphabets(event) {
    if (event.charCode != 8 && event.charCode != 0 && !((event.charCode >= 65 && event.charCode <= 90) || (event.charCode >= 97 && event.charCode <= 122))) {
        event.preventDefault();
    }
}

document.getElementById("onlyAlphabetsInput").addEventListener("keypress", restrictToAlphabets);
