<?php
    $regex='/^(-?|\+?)[0-9]\d*((,|\.)\d+)?$/';

    do{
        $nbre1=readline("Veuillez entrer le 1er nombre: ");
        if(!preg_match($regex,$nbre1)){
            echo "Erreur, entrée invalide!\n";
        }    
    }while(!preg_match($regex,$nbre1));
    do{
        $nbre2=readline("Veuillez entrer le 2ème nombre: ");
        if(!preg_match($regex,$nbre2)){
            echo "Erreur, entrée invalide!\n";
        }    
    }while(!preg_match($regex,$nbre2));

    if($nbre1==0 || $nbre2==0){
        echo "Le produit de ces deux nombres est null!";
    }elseif(($nbre1[0]=="-") xor ($nbre2[0]=="-")){
        echo "Le produit de ces deux nombres est négatif!";
    }else{
        echo "Le produit de ces deux nombres est positif!";
    }