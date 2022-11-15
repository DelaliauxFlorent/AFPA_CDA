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
$poid-=$accid;
if ($accid<=2 && $poid>=0){
    
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
    }
}else{
    echo "Refusé";
}

/* Correction
$age = readLine('Age : ');
$permis = readLine('Années de permis : ');
$accident = readLine('Nombre d\'accidents : ');
$gold = readLine('Client depuis plus d\'un an ? : ');

$score = 0;

$couleur = ['rouge', 'orange', 'verte', 'bleue'];

if($accident<3){

    if($age>25){
        $score ++;
    }

    if($permis>2){
        $score ++;
    }

    $score -= $accident;

    if($gold && $score >= 0){
        $score ++;
    }

    if($score >= 0){
        echo 'Vous avez droit à l\'assurance de couleur '.$couleur[$score];
    }
    else{
        echo 'Vous ne pouvez pas souscrire à une assurance';
    }
}
else{
    echo 'Vous ne pouvez pas souscrire à une assurance';
}
*/