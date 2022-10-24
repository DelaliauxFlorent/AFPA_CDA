<?php
//1.	Déclarer un tableau associatif avec les chiffres en lettres comme clé et les chiffres correspondants en valeur
$tableauAssoc=array("zero"=>0, "un"=>1, "deux"=>2, "trois"=> 3, "quatre"=>4, "cinq"=>5);

    // Test
    print_r($tableauAssoc);

//2.	Rechercher une valeur dans un tableau associatif

$found=false;
do{
    $needle=readline("Rechercher :");
}while($needle)


//Eco?
$tabBase=array_values($tableauAssoc);
$i=0;
do{
    if($tablBase[$i]==$value){
        $found=true;
    }
    $i++;
}while($i<count($tableauAssoc) && $found==false);