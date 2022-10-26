<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$pav1= new Paves(["longueur"=>10, "largeur"=>5, "profondeur"=>2]);
echo "Pavé =>\n\t";
echo $pav1;

$prisme1= new Prismes(["base"=>10, "hauteur"=>5, "profondeur"=>3]);
echo "Prisme =>\n\t";
echo $prisme1;

$sphere1=new Spheres(["diametre"=>5]);
echo "Sphère =>\n\t";
echo $sphere1;
