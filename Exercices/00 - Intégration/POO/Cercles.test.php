<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$cercle= new Cercles(["diametre"=>10]);
$cercle->AfficherCercle();