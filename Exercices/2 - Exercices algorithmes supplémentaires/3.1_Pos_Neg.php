<?php
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
