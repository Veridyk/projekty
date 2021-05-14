<?php

class Database{
    private static $connection = null;

    public static function GetConnection(){
        if(self::$connection != null)
            return self::$connection;

        self::$connection = new PDO('odbc:Driver={SQL Server};Server=DESKTOP-92DCTMG\SERVER;Database=TGAME_GSP; Uid=sa;Pwd=46dVxM');
        self::$connection->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
        self::$connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

        return self::$connection;
    }
}

?>