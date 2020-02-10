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
function generateNumbers() {
    for (let i=0; i<7; i++) {
        numbers[i] = new Number().roll();
    }
}
generateNumbers();
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
    "correctLotto": correctLotto,
    "generateNumbers": generateNumbers
};