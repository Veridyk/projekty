<?php

require("../classes/db.php");
require("../classes/item.php");

abstract class CLASS_KIND{
    const WARRIOR = 0;
    const WALKER = 1;
    const ARCHER = 2;
    const MAGE = 3;
    const PRIEST = 4;
    const EVOCATOR = 5;
    const COUNT = 6;
}

abstract class COUNTRY_KIND{
    const VALORIAN = 0;
    const DERION = 1;
    const GOR = 2;
    const COUNT = 3;
}



class Character{

    public $dwCharID;
    private $dwUserID;
    public $szNAME;
    public $bClass;
    private $bRace;
    public $bCountry;
    private $bRealSex;
    private $bSex;
    private $bHair;
    private $bFace;
    public $bLevel;
    public $dwHP;
    public $dwMP;
    public $szClass;
    public $szCountry;
    public $szFace;

    public $items = array();

    public function __construct(){
        $this->szClass = $this->GetClassText();
        $this->szCountry = $this->GetCountryText();
        $this->szFace = $this->GetFace();
    }

    public function GetFace(){
        return strval($this->bRace) . strval($this->bSex) . strval($this->bHair) . strval($this->bFace);
    }

    public function GetCountryText(){
        switch($this->bCountry){
            case COUNTRY_KIND::VALORIAN : return "Valorian"; break;
            case COUNTRY_KIND::DERION : return "Derion"; break;
            case COUNTRY_KIND::GOR : return "Broa"; break;
            default: return "Broa"; break;
        }
    }

    public function GetClassText(){
        switch($this->bClass){
            case CLASS_KIND::WARRIOR : return "Warrior"; break;
            case CLASS_KIND::ARCHER : return "Archer"; break;
            case CLASS_KIND::WALKER : return "Night Walker"; break;
            case CLASS_KIND::MAGE : return "Mage"; break;
            case CLASS_KIND::PRIEST : return "Priest"; break;
            case CLASS_KIND::EVOCATOR : return "Evocator"; break;
        }
    }

    public function GetEquip(){

        $cmd = Database::GetConnection()->prepare("SELECT t.bStorageType, t.dwStorageID, t.dwOwnerID, t.bItemID, t.wItemID, t.bLevel, t.bGLevel, t.dwDuraMax, t.dwDuraCur, t.bRefineCur, t.bGradeEffect, "
                                                    . "t.bMagic1, t.bMagic2, t.bMagic3, t.bMagic4, t.bMagic5, t.bMagic6, t.wValue1, t.wValue2, t.wValue3, t.wValue4, t.wValue5, t.wValue6, "
                                                    . "c.szNAME, c.bRefineMax FROM TITEMTABLE AS t JOIN TITEMCHART AS c ON (t.wItemID = c.wItemID) WHERE t.dwOwnerID = :owner AND dwStorageID=254 AND bStorageType=0");
        $cmd->execute(array("owner" => $this->dwCharID));

        $this->items = $cmd->fetchAll(PDO::FETCH_CLASS, "Item");
    }
}

?>