<?php
	require_once('Database.php');
	//header('Content-type: Application/JSON');
	header("Access-Control-Allow-Origin: *");
	$query = "SELECT GC.id, GI.id, GI.category, GC.title, GI.path FROM gallery_category AS GC JOIN gallery_image AS GI ON (GC.id = GI.category)";
	$stmt = $conn->prepare($query);
  	$stmt->execute();

  	$result = $stmt->fetchAll(PDO::FETCH_ASSOC);
  	echo json_encode($result, JSON_PRETTY_PRINT);
?>