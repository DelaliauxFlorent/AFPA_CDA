<?php
class Parametre{
    ////////////////////////////////////
    // Attributs

    public static $_host;
    public static $_base;
    public static $_user;
    public static $_password;

    public static function readConfig()
    {
        $json = file_get_contents("PHP/config.json");
        $infoconnect = json_decode($json);
        $_host=outils::decode($infoconnect[0]);
        $_base=outils::decode($infoconnect[1]);
        $_user=outils::decode($infoconnect[2]);
        $_password = outils::decode($infoconnect[3]);
    }
}