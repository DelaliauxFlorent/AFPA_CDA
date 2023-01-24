<?php

function ChargerClasse($classe)
{
    if ($classe == "DbConnect") {
        $path = './PHP/MODEL/MANAGER/';
    }else {
        $path= './PHP/CONTROLER/CLASSE/';
    }
    require $path.$classe.'.Class.php';
}
spl_autoload_register("ChargerClasse");

Parametre::readConfig();
DbConnect::connect();
echo Parametre::$_base;
