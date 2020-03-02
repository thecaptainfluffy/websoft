<?php
require_once "db/database.php";

// Get incoming values
$id    = $_POST["id"] ?? null;
$first_name  = $_POST["first_name"] ?? null;
$last_name   = $_POST["last_name"] ?? null;
$race   = $_POST["race"] ?? null;
$class   = $_POST["class"] ?? null;
$save  = $_POST["save"] ?? null;
$update  = $_POST["update"] ?? null;
// var_dump($_GET);
// var_dump($_POST);

$servername = "localhost";
$username = "test";
$password = "abcd1234";
// Connect to the database
$conn = connect($servername, $username, $password);

$sql = "SELECT * FROM websoft.characters";
$stmt = $conn->prepare($sql);
$stmt->execute();
$res1 = $stmt->get_result();
//var_dump($res1);

if ($save) {
    $sql = "UPDATE websoft.characters SET first_name = ?, last_name = ?, race = ?, class = ? WHERE id = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("ssssi", $first_name, $last_name, $race, $class, $id);
    $stmt->execute();
}
if ($update) {
    $sql = "SELECT * FROM websoft.characters WHERE id = ?";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("i", $id);
    $stmt->execute();
    $res2 = $stmt->get_result();
}

?>
<form method="post">
    <input type="text" name="id" placeholder="Enter ID you want to update">
    <input type="submit" name="update" value="Update">
</form>

<?php if (!empty($res2)) { ?>
<form method="post">
    <fieldset>
        <legend>Update</legend>
        <?php foreach($res2 as $row) : ?>
            <input type="text" readonly="readonly" name="id" value="<?= $row["id"] ?>">
            <input type="text" name="first_name" value="<?= $row["first_name"] ?>">
            <input type="text" name="last_name" value="<?= $row["last_name"] ?>">
            <input type="text" name="race" value="<?= $row["race"] ?>">
            <input type="text" name="class" value="<?= $row["class"] ?>">
            <input type="submit" name="save" value="Save">
        <?php endforeach; ?>
    </fieldset>
</form>
<?php } ?>
