/**
 * General routes.
 */
//"use strict";

const express = require("express");
const router  = express.Router();

let lotto = require("../modules/lotto.js");

// Add a route for the path /
router.get("/lotto", (req, res) => {
    let data = [];
    var numbers = [];
        for (var i = 0; i < 35; i++) 
        numbers.push(i+1);

    if(req.param("row") != null) {
        var row = req.param("row").split(",");
        var result = lotto.getNumbers().split(",");
        var nrCorAns = lotto.correctLotto(row, result);

        data.numbers = numbers;
        data.nrCorAns = nrCorAns;
        data.row = row;
        data.result = result;
        res.render("lotto", data)
    } else {
        data.numbers = numbers;
        data.nrCorAns = 0;
        data.row = [];
        data.result = lotto.getNumbers().split(",");
        console.log(data.result);
        
        res.render("lotto", data)
    }
});
router.get("/lotto-json", (req, res) => {
    let data = [];
    if(req.param("row") != null) {
        let row = req.param("row");
        let result = lotto.getNumbers();

        var jsonRow = stringToJSON(row);
        var jsonResult = stringToJSON(result)

        var nrCorAns = lotto.correctLotto(jsonRow, jsonResult)

        var jsonObject = {"row": jsonRow, "nrCorAns": nrCorAns.length};
        res.json(jsonObject);
    } else {
        res.json(lotto.getNumbers());
    }
});

function stringToJSON(input) {
    var text = input.split(",");
    var jsonArray = JSON.stringify(text)
    return JSON.parse(jsonArray)
}

module.exports = router;
