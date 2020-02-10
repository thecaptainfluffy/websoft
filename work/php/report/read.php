<?php
$crud = $_GET["crud"] ?? null;
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="Cache-control" content="no-cache">
    <title>About this site</title>
    <link rel="stylesheet" href="css/style.css">
    <link rel="icon" href="favicon.ico">
</head>

<body>
<?php include 'view/header.php' ?>    

<h2>CRUD</h2>
<a href="?crud=create">Create</a>
<a href="?crud=update">Update</a>
<a href="?crud=delete">Delete</a>

<?php if (!is_null($crud)) { ?>
<?php include 'view/' . $crud . '.php' ?>
<?php } ?>

<?php include 'view/read.php' ?>

<?php include "view/footer.php" ?>

<script type="text/javascript" src="js/car.js"></script>
</body>
</html>
