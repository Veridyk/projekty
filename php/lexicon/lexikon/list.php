<?php
    require("../classes/character.php");

    header('Access-Control-Allow-Origin: *');
    header("Access-Control-Allow-Methods: GET");
    header("Content-type: application/json; charset=UTF-8");

    if(isset($_GET['name'])){
        $name = $_GET['name'];

        $limit = 10;
        $records = Database::GetConnection()->prepare("SELECT count(*) FROM TCHARTABLE WHERE szNAME like :name", array(PDO::ATTR_CURSOR => PDO::CURSOR_FWDONLY));
        $records->execute(array('name' => "%" . $name . "%"));
        $total_results = $records->fetchColumn();
        $total_pages = ceil($total_results/$limit);

        if (!isset($_GET['page'])) {
            $page = 1;
        } else{
            $page = $_GET['page'];
        }

        $starting_limit = ($page-1)*$limit;

        $cmd = Database::GetConnection()->prepare("SELECT dwCharID, dwUserID, szNAME, bClass, bRace, bCountry, bRealSex, bSex, bHair, bFace, bLevel, dwHP, dwMP "
                                                    . "FROM TCHARTABLE WHERE szNAME like :name ORDER BY dwCharID "
                                                    . "OFFSET CAST(:offset AS INT) ROWS FETCH NEXT CAST(:limit AS INT) ROWS ONLY", array(PDO::ATTR_CURSOR => PDO::CURSOR_FWDONLY));
        
        $cmd->execute(array(":name" => "%" . $name . "%", ':limit' => $limit, ':offset' => $starting_limit));

        $characters = $cmd->fetchAll(PDO::FETCH_CLASS, "Character");

        echo json_encode(array(array("currentPage" => $page, "totalPages" => $total_pages),$characters), JSON_PRETTY_PRINT);
    }
    else{

        $cmd = Database::GetConnection()->prepare("SELECT TOP 10 dwCharID, dwUserID, szNAME, bClass, bRace, bCountry, bRealSex, bSex, bHair, bFace, bLevel, dwHP, dwMP "
                                                    . "FROM TCHARTABLE order by bLevel DESC", array(PDO::ATTR_CURSOR => PDO::CURSOR_FWDONLY));
        $cmd->execute();

        $characters = $cmd->fetchAll(PDO::FETCH_CLASS, "Character");
        
        echo json_encode($characters, JSON_PRETTY_PRINT);
    }
?>