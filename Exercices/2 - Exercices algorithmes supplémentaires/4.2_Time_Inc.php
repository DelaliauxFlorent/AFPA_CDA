<?php

$regex='/^[0-9]{1,2}$/';

do{
    $hour=readline("Veuillez indiquer la valeur des heures: ");
    if(!preg_match($regex,$hour)){
        echo "Erreur, entrée invalide!\n";
    }    
}while(!preg_match($regex,$hour));
do{
    $min=readline("Veuillez indiquer la valeur des minutes: ");
    if(!preg_match($regex,$min)){
        echo "Erreur, entrée invalide!\n";
    }    
}while(!preg_match($regex,$min));

echo "Dans une minute, il sera ";

if($min!=59){
    echo $hour." heure(s) ".$min+1;
    echo ".";
}elseif($hour!=23){
    echo $hour+1;
    echo " heure(s) 00.";
}else{
    echo "minuit.";
}