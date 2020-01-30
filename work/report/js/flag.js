//Create flag object
var flagObject = {appendBody: appendBody, appendHeader: appendHeader}

var body = document.body,
    head = document.head,
    flag = document.createElement("div"),
    aSweden = document.createElement("a"),
    aDenmark = document.createElement("a"),
    aFinland = document.createElement("a");
    countryLink = document.createElement("link")

flag.id = "flag";
flag.onclick = onClick;

aSweden.href = "flag.html?country=sweden";
aSweden.innerText = "Sweden";
aDenmark.href = "flag.html?country=denmark";
aDenmark.innerText = "Denmark";
aFinland.href = "flag.html?country=finland";
aFinland.innerText = "Finland";

countryLink.id = "countryStyle";
countryLink.rel = "stylesheet";

//Append header so onClick knows where to find the style sheet
flagObject.appendHeader();

//onClick function when clicking on the div
function onClick() {
    var flag = document.getElementById("flag")
    flag.style.transition  = "0.5s";
    flag.style.opacity = "0";
    setInterval(function () {
        flag.style.display = "none";
    }, 500)}
    var link = document.getElementById("countryStyle");
    switch (window.location.search.substring(9, window.location.search.length)) {
    case "sweden":
        link.href = "css/sweden.css";
        break;
    case "denmark":
        link.href = "css/denmark.css";
        break;
    case "finland":
        link.href = "css/finland.css";
        break;
}
//Append to header
function appendHeader() {
    head.append(countryLink);
}
//Append to body
function appendBody() {
    
    body.append(aSweden);
    body.append(" | ");
    body.append(aDenmark);
    body.append(" | ");
    body.append(aFinland);
    body.append(flag);
}


flagObject.appendBody()



