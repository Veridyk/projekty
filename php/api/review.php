<?php
	require_once('Database.php');
	//header('Content-type: Application/JSON');
	header("Access-Control-Allow-Origin: *");
	$query = "SELECT * FROM review ORDER BY id ASC";
	$stmt = $conn->prepare($query);
  	$stmt->execute();

  	$result = $stmt->fetchAll(PDO::FETCH_ASSOC);
  	echo json_encode($result, JSON_PRETTY_PRINT);
?>