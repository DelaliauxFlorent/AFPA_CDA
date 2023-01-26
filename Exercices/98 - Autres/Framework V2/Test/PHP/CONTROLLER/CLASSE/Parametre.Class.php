
<?php
class Parametre
{
    ////////////////////////////////////
    // Attributs

    private static $_host;
    private static $_port;
    private static $_base;
    private static $_user;
    private static $_password;

    /////////////////////////////////////
    // Getters/Setters
    
    static function getHost()
    {
        return self::$_host;
    }

    static function getPort()
    {
        return self::$_port;
    }

    static function getBase()
    {
        return self::$_base;
    }

    static function getUser()
    {
        return self::$_user;
    }

    static function getPassword()
    {
        return self::$_password;
    }

    ////////////////////////////

    public static function init()
    {
        if (file_exists("config.json")) {
            $infoconnect = json_decode(file_get_contents("config.json"));
            self::$_host = $infoconnect->host;
            self::$_port = $infoconnect->port;
            self::$_base = $infoconnect->base;
            self::$_user = $infoconnect->user;
            if (strlen($infoconnect->password) == 0) {
                self::$_password = $infoconnect->password;
            } else {
                self::$_password = $infoconnect->password;
            }
        }
    }

}
