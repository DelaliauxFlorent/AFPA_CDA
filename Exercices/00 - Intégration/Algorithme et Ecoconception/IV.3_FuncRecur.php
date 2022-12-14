<?php

//1. Ecrire un algorithme qui demande un nombre de départ, et qui calcule sa factorielle.

function factorial($value){
    //Ordre décroissant
    
    if($value!=1){
        echo $value." * ";
        return $value*factorial($value-1);
    }else{
        echo "1 = ";
        return 1;
    }

    //ordre croissant


}

//2.	Epeler - Ecrire une fonction qui épèle le mot passé en paramètre
/*
function epeler($mot, $pos){
    $array=str_split($mot);
    if($pos<count($array)){
        echo "'".$array[$pos]."'".($pos!=(count($array)-1)?", ":".");
        epeler($mot, $pos+1);
    }
}*/

function epeler($mot){
    //affiche le premier charactère de la chaine
    echo "'".$mot[0]."'";
    if(strlen($mot)>1){
        echo ", ";
        epeler(substr($mot,1));
    }
}

//Testes

$sousExo=readline("Tester la partie? ");
switch($sousExo){
    case 1:
        $value=readline("Valeur :");
        echo "Factorielle de ".$value." => \n\t";
        echo factorial($value);
        break;
    case 2:
        $mot=readline("Indiquer le mot à épeler: ");
        echo "\"".$mot."\" se décompose en => ";
        epeler($mot);
        break;
    default:
        echo "Erreur!";
        break;
}