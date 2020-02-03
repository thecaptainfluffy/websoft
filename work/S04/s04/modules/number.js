/**
 * A module for game Guess the number I'm thinking of.
 */
"use strict";

class Number {
    /**
     * @constructor
     */
    constructor() {
        this.number = null;
    }

    /**
     * Roll the dice and remember tha value of the rolled dice.
     *
     * @param {integer} max The number of faces of the dice, defaults to 6.
     *
     * @returns {integer} The value of the rolled dice min=1 and max=faces.
     */
    roll(max=34) {
        this.number = Math.floor(Math.random() * max + 1);
        return this.number;
    }

    /**
     * Get the value of the last rolled dice.
     *
     * @returns {integer} The value of the last rolled dice.
     */
    lastRoll() {
        return this.number;
    }

    /**
     * When someone is printing this object, what should it look like?
     *
     * @returns {string} The value of the last rolled dice.
     */
    toString() {
        return this.number;
    }
}

module.exports = Number;