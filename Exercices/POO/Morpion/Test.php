<?php

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$plateau=new Plateaux(["dimX"=>3, "dimY"=>3]);
$reponsePosition=Affichages::demandePosition($plateau);
print_r($reponsePosition);