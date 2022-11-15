<?php

$regex='/^[0-9]+$/';

do{
    $copies=readline("Veuillez indiquer le nombre de photocopies: ");
    if(!preg_match($regex,$copies)){
        echo "Erreur, entrée invalide!\n";
    }    
}while(!preg_match($regex,$copies));

$facture=0.0;

if($copies<=10){
    $facture=$copies*0.1;
}elseif($copies<=30){
    $facture=1+($copies-10)*0.09;
}else{
    $facture=2.8+($copies-30)*0.08;
}

echo "Pour une série de ".$copies." photocopie(s), il vous en coûtera ".number_format($facture, 2,'€').".";