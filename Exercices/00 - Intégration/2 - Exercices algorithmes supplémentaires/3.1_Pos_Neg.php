<?php

/*
    $regex='/^(-?|\+?)[0-9]\d*((,|\.)\d+)?$/';

    do{
        $nbre=readline("Veuillez entrer le nombre voulu: ");
        if(!preg_match($regex,$nbre)){
            echo "Erreur, entrée invalide!\n";
        }    
    }while(!preg_match($regex,$nbre));

    if($nbre[0]=="-"){
        echo "Ce nombre est négatif!";
    }else{
        echo "Ce nombre est positif!";
    }
    */
/////////////////////
// Non-regex version

do{
    $nbre=readline("Veuillez entrer le nombre voulu: ");
    if(!is_numeric($nbre)){
        echo "Erreur, entrée invalide!\n";
    }elseif(!ctype_digit($nbre)){
        echo "Erreur, entrez un entier!\n";
    }
}while(!is_numeric($nbre)||!ctype_digit($nbre));

// is_numeric correctly recognize int and float even when in a string int val =>

/*
if($nbre[0]=="-"){
    echo "Ce nombre est négatif!";
}else{
    echo "Ce nombre est positif!";
}*/