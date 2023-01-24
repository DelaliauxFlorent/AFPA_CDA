<?php
class DbConnect
{

    private static $_db;

    public static function connect()
    {
        try {
            $_db = new PDO('mysql:host=' . Parametre::$_host . ';dbname=' . Parametre::$_base, Parametre::$_user, Parametre::$_password);
        } catch (PDOException $e) {
            print "Error!: " . $e->getMessage() . "<br/>";
            die();
        }
    }

    public static function disconnect()
    {
        $_db = null;
    }
}
