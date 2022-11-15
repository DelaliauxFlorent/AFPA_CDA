<?php

$regex='/^[0-9]{1,2}$/';

//////////////////
// V1
/*

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
do{
    $sec=readline("Veuillez indiquer la valeur des secondes: ");
    if(!preg_match($regex,$sec)){
        echo "Erreur, entrée invalide!\n";
    }    
}while(!preg_match($regex,$sec));

echo "Dans une seconde, il sera ";

if($sec!=59){
    echo $hour." heure(s), ".$min." minute(s) et ".$sec+1;
    echo "seconde(s).";
}elseif($min!=59){
    echo $hour." heure(s), ".$min+1;
    echo " minute(s) et 0 seconde.";
}elseif($hour!=23){
    echo $hour+1;
    echo " heure(s), 0 minute et 0 seconde";
}else{
    echo "minuit pile";
}

*/

////////////////////
// V2

$time = ['heures' => null, 'minutes' => null, 'secondes' => null];

foreach($time as $key => $value){
    do{
        $time[$key]=readline("Veuillez indiquer la valeur des ".$key.": ");
        if(!preg_match($regex,$time[$key])){
            echo "Erreur, entrée invalide!\n";
        }
    }while(!preg_match($regex,$time[$key]));
}

/*
if($time['secondes']!=59){
    $time['secondes']++;
}elseif($time['minutes']!=59){
    $time['secondes']=0;
    $time['minutes']++;
}elseif($time['heures']!=23){
    $time['secondes']=0;
    $time['minutes']=0;
    $time['heures']++;
}else{
    $time['secondes']=0;
    $time['minutes']=0;
    $time['heures']=0;
}*/

$time['secondes']++;
if($time['secondes']==60){
    $time['secondes']=0;
    $time['minutes']++;
    if($time['minutes']==60){
        $time['minutes']=0;
        $time['heures']++;
        if($time['heures']==24){
            $time['heures']=0;
        }
    }
}

echo "Dans une seconde, il sera ".$time['heures']." heure(s), ".$time['minutes']." minute(s) et ".$time['secondes']." seconde(s)";