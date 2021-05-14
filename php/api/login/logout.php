<?php
		unset($_SESSION["id"]);
		unset($_SESSION["username"]);
		header("location:login_view.php");
?>