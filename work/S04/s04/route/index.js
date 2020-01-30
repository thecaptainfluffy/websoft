/**
 * General routes.
 */
//"use strict";

const express = require("express");
const path = require('path');
const router  = express.Router();

let lotto = require("../modules/lotto.js");

// Add a route for the path /
router.get("/", (req, res) => {
    res.send("Hello")
});
router.get("/report", (req, res) => {
    res.send("What?")
});
router.get("/lotto", (req, res) => {
    if(req.param("row") != null) {
        var numbers = [];
        for(var i = 1; i <= 35; i++) {
            numbers.push(i)
        }
        let row = req.param("row")
        let result = lotto.getNumbers();
        

        res.send(numbers)
    } else {
        res.send(lotto.getNumbers())
    }
});
router.get("/lotto-json", (req, res) => {
    if(req.param("row") != null) {
        let row = req.param("row");
        let result = lotto.getNumbers();

        var jsonRow = stringToJSON(row);
        var jsonResult = stringToJSON(result)

        var nrCorAns = correctLotto(jsonRow, jsonResult)

        var jsonObject = {"row": jsonRow, "nrCorAns": nrCorAns.length};
        res.json(jsonObject);
    } else {
    res.json(lotto.getNumbers())
    }
});

function stringToJSON(input) {
    var text = input.split(",");
    var jsonArray = JSON.stringify(text)
    return JSON.parse(jsonArray)
}

function correctLotto(input, result) {
    var found = input.filter(val => result.includes(val))
    console.log(found)
    return found
}

module.exports = router;
