/**
 * A simple test program importing a class Dice.
 *
 * @author Simon Westerdahl
 */
"use strict";

let Number = require("./number.js");

// Prepare a dice hand to hold the dices (its an array)
let numbers = [];

// Add the dices to the dice hand and roll them once
var sameNumber = false;
var compareNr;
for (let i=0; i<7; i++) {
    numbers[i] = new Number();
    do {
        sameNumber = false;
        numbers[i] = numbers[i].roll();
        for(let j=0; j<numbers.length-1; j++) {
            if(compareNr == numbers[j]) {
                sameNumber = true;
            }
        }
    } while (sameNumber); 
}

// Print out the whole datastructure
//console.info(numbers);

// Join the elements and print out as a string.
// This construct is using the builtin class method toString.
function getNumbers() {
    return numbers.join();
}

function correctLotto(input, result) {
    var found = input.filter(val => result.includes(val))
    return found.length
}

module.exports = {
    "getNumbers": getNumbers,
    "correctLotto": correctLotto
};