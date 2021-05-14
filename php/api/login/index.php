<?php
	session_start();

	include('session.php');
	if(!Session::isSession()){
		header("location:login_view.php");
		exit();
	}
?>

<!DOCTYPE html>
<html>
<head>
	<title>Administrace</title>
	<link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
	<div class="login-header">
		<h1>Administrace API</h1>
		<a href="logout.php">Logout</a>
	</div>
</body>
</html>

