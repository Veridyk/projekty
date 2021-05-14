<?php

class Session{
	public static function isSession(){
		if(isset($_SESSION['id']))
    		return true;

		return false;
	}

	public static function exit(){
		header("location:index.php");
		exit();
	}
}
?>