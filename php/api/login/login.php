<?php
	session_start();
	require_once('../Database.php');
	include('session.php');

	if(Session::isSession()){
		header("location:index.php");
		exit();
	}

	if(isset($_POST["login"]) && isset($_POST["password"])){
		$login = $_POST["login"];
		$password = md5($_POST["password"]);

		$login = new Login($login, $password, $conn);
		if($login->isValid()){
			$login->onLogin();
		}
	}


	class Login
	{
		private $login;
		private $password;
		private $con;
		private $id;

		function __construct($login, $password, $con)
		{
			$this->login = $login;
			$this->password = $password;
			$this->con = $con;
		}

		public function isValid(){

			$params = array(':login' => $this->login, ':password' => $this->password);
			$obj = $this->con->prepare('SELECT * FROM users WHERE username = :login AND password = :password');
			$obj->execute($params);
  			$result = $obj->fetch();

  			if($obj->rowCount() == 1){
  				$this->id = $result["id"];
  				return true;
  			}

  			return false;
		}

		public function onLogin(){
			$_SESSION["id"] = $this->id;
			$_SESSION["username"] = $this->login;
			header("location:index.php");
		}
	}
?>