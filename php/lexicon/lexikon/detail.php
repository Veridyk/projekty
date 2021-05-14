<?php
    require("../classes/character.php");

    header("Access-Control-Allow-Origin: *");
    header("Access-Control-Allow-Methods: POST");
    header("Content-type: application/json; charset=UTF-8");

    if(isset($_GET['id'])){
        $id = intval($_GET['id']);

        $cmd = Database::GetConnection()->prepare("SELECT dwCharID, dwUserID, szNAME, bClass, bRace, bCountry, bRealSex, bHair, bFace, bLevel, dwHP, dwMP "
                                                    . "FROM TCHARTABLE WHERE dwCharID = :id", array(PDO::ATTR_CURSOR => PDO::CURSOR_FWDONLY));
        $cmd->execute(array('id' => $id));

        $characters = $cmd->fetchAll(PDO::FETCH_CLASS, "Character");

        foreach($characters as $char)
            $char->GetEquip();

        echo json_encode($characters, JSON_PRETTY_PRINT);
    }
?>