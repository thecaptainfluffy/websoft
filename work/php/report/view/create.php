<?php
require_once "db/database.php";
// Get incoming values
$first_name  = $_POST["first_name"] ?? null;
$last_name   = $_POST["last_name"] ?? null;
$race   = $_POST["race"] ?? null;
$class   = $_POST["class"] ?? null;
$create = $_POST["create"] ?? null;
//var_dump($_POST);

if ($create) {
    $servername = "localhost";
    $username = "test";
    $password = "abcd1234";
    // Connect to the database
    $conn = connect($servername, $username, $password);
    // Prepare and execute the SQL statement
    $sql = "INSERT INTO websoft.characters (first_name, last_name, race, class) VALUES (?, ?, ?, ?)";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("ssss", $first_name, $last_name, $race, $class);
    $stmt->execute();
    $conn->close();
}
?>

<form method="post">
    <input type="text" name="first_name" placeholder="Enter first name">
    <input type="text" name="last_name" placeholder="Enter last name">
    <input type="text" name="race" placeholder="Enter race">
    <input type="text" name="class" placeholder="Enter class">
    <input type="submit" name="create" value="Create">
</form>