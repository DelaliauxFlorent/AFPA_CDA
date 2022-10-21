<?php

$regex1='/^[0-9]{1,2}$/';
$regex2='/^[0-9]+$/';

do{
    $day=readline("Veuillez indiquer le numéro du jour: ");
    if(!preg_match($regex1,$day)){
        echo "Erreur, entrée invalide!\n";
    }elseif($day>31){
        echo "Erreur, aucun mois ne contient plus de 31 jours!\n";
    }
}while(!preg_match($regex1,$day) || $day>31);
do{
    $month=readline("Veuillez indiquer le numéro du mois: ");
    if(!preg_match($regex1,$month)){
        echo "Erreur, entrée invalide!\n";
    }elseif($month>12){
        echo "Erreur, aucune année ne contient plus de 12 mois!\n";
    }
}while(!preg_match($regex1,$month) || $month>12);
do{
    $year=readline("Veuillez indiquer le numéro de l'année: ");
    if(!preg_match($regex2,$year)){
        echo "Erreur, entrée invalide!\n";
    }
}while(!preg_match($regex2,$year));

$lmonth=[1,3,5,7,8,10,12];

if(
    (!in_array($month, $lmonth) && $day==31)   // mois qui ne sont sencé avoir que 30 jours
    || ($day==29 && $month==2 && (
        ($year%4!=0) || (($year%100==0) && $year%400!=0)    // année non bissextile
    )) || ($day>29 && $month==2)
  )
{
    echo "Cette date est invalide!";
}else{
    echo "Cette date est valide!";
}