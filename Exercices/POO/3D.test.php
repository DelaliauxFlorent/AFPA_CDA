<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$pav1= new Paves(["longueur"=>10, "largeur"=>5, "profondeur"=>2]);
$pav1->AfficherPave();