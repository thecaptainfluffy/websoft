<?php
require_once "db/database.php";
// Get incoming values
$id  = $_POST["id"] ?? null;
$delete = $_POST["delete"] ?? null;
//var_dump($_POST);

if ($delete) {
    $servername = "localhost";
    $username = "test";
    $password = "abcd1234";
    // Connect to the database
    $conn = connect($servername, $username, $password);
    // Prepare and execute the SQL statement
    $sql = "DELETE FROM websoft.characters WHERE id = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("i", $id);
    $stmt->execute();
    $conn->close();
}
?>

<form method="post">
    <input type="text" name="id" placeholder="Enter ID you want to delete">
    <input type="submit" name="delete" value="Delete">
</form>