<?php
require_once "db/database.php";

// Get incoming values
$result = array();

$servername = "localhost";
$username = "test";
$password = "abcd1234";

$conn = connect($servername, $username, $password);

$sql = "SELECT * FROM websoft.characters";
        $stmt = $conn->prepare($sql);
        $stmt->execute();
        $result = $stmt->get_result();
        $conn->close();

?>
<?php if(!empty($result)) { ?>
<table id="table">
    <tr>
        <th>ID</th>
        <th>First name</th>
        <th>Last name</th>
        <th>Race</th>
        <th>Class</th>
    </tr>
    <?php foreach($result as $row) : ?>
    <tr>
        <td><?= $row["id"] ?></td>
        <td><?= $row["first_name"] ?></td>
        <td><?= $row["last_name"] ?></td>
        <td><?= $row["race"] ?></td>
        <td><?= $row["class"] ?></td>
    </tr>
    <?php endforeach; ?>
</table>
<?php } else { ?>
<p>No results found</p>
<?php } ?>