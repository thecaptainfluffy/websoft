/**
 * General routes.
 */
"use strict";

const express = require("express");
const router  = express.Router();

// Add a route for the path /
router.get("/", (req, res) => {
    res.send("Hello World2");
});
router.get("/me", (req, res) => {
    res.redirect("/me.html");
});

// Add a route for the path /about
router.get("/about", (req, res) => {
    res.send("About something2");
});

module.exports = router;
