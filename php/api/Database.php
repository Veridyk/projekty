<?php

$conn = Database::getInstance()->getCon();

class Database
{
	static $instance = null;
	private $con;
	private $servername = "localhost";
	private $username = "root";
	private $password = "";

	private function __construct()
	{
		$this->con = new PDO("mysql:host=$this->servername;charset=utf8;dbname=api", $this->username, $this->password);
		$this->con->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    }

	public static function getInstance(){
		if(self::$instance == null)
			self::$instance = new Database();
			
		return self::$instance;
	}

	public function getCon(){
		return $this->con;
	}
}
?>