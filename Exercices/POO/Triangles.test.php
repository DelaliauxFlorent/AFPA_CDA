<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$tri1 = new Triangles(["base"=>5, "hauteur"=>10]);
$tri1->afficherTriangle();