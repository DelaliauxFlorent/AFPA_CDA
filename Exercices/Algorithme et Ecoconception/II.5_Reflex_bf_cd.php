<?php

/*
Poids age:
    -25ans=> 0
    +25ans=> 1
Poids ancienneté permis:
    -2ans=>0
    +2ans=>1
Poids accidents => retrait d'une valeur égal au nombre
Relation Total<=>Tarifs:
    - de 1   => Refus
    0        => Rouge
    1        => Orange
    2        => Vert
    3        => Bleu
*/
$poid=0;
$age=readline("Quel âge avez-vous? ");
$permis=readline("Depuis combien d'années avez vous votre permis? ");
$accid=readline("De combien d'accidents avez-vous été responsable? ");

if($age>=25){
    $poid++;
}
if($permis>=2){
    $poid++;
}
if ($accid<=2){
    $poid-=$accid;
    $ancien=readline("Depuis combien d'année êtes-vous chez nous? ");
    if($ancien>=1){
        $poid++;
    }

    switch($poid){
        case 3:
            echo "Tarif Bleu";
            break;
        case 2:
            echo "Tarif Vert";
            break;
        case 1:
            echo "Tarif Orange";
            break;
        case 0:
            echo "Tarif Rouge";
            break;
        default:
            echo "Refusé";
            break;
    }
}else{
    echo "Refusé";
}