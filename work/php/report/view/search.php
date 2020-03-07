<?php
require "db/database.php";

// Get incoming values
$search = $_GET["search"] ?? null;
$like = "%$search%";
$result = array();

if ($search) {
$servername = "localhost";
$username = "test";
$password = "abcd1234";

$conn = connect($servername, $username, $password);

$sql = "SELECT * FROM websoft.characters WHERE id LIKE ? OR first_name LIKE ? OR last_name LIKE ? OR race LIKE ? OR class LIKE ?";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param("sssss", $like, $like, $like, $like, $like);
        $stmt->execute();
        $result = $stmt->get_result();
        $conn->close();
}
?>

<h2>SEARCH</h2>
<form>
    <input type="text" placeholder="Search.." name="search">
    <button type="submit">Submit</button>
</form>

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