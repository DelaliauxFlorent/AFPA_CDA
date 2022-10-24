<?php

$regex= '/^(-?|\+?)[0-9]+$/';

//1.	Saisir un tableau de X valeurs entières avec invite variable et contrôle de type

function SaisieTabUn($sizeArray, $invite){
    $regex= '/^(-?|\+?)[0-9]+$/';
    $retour[0]=null;
    for($i=0; $i<$sizeArray; $i++){
        do{
            $val=readline($invite);
            if(!preg_match($regex,$val)){
                echo "Erreur, entrez un entier!\n";
            }
        }while(!preg_match($regex,$val));
        $retour[$i]=(int)$val;
    }
    return $retour;
}

// 2.	Saisir les valeurs d’un tableau jusqu’à ce que l’utilisateur saisisse 0.

function SaisieTabDyna(){
    $regex= '/^(-?|\+?)[0-9]+$/';
    $retour2[0]=null;
    do{
        do{
            $val=readline("Entrez une valeur entière: ");
            if(!preg_match($regex,$val)){
                echo "Erreur, entrez un entier!\n";
            }
        }while(!preg_match($regex,$val));
        $retour2[]=(int)$val;
    }while((int)$val!=0);
    array_pop($retour2);
    return $retour2;
}

//3.	Trier un tableau 

function TrierTableau($tableau){
    return sort($tableau, SORT_NATURAL | SORT_FLAG_CASE); // Retourne tableau classé par ordre alpha/croissant
    /* Ret

}

/////////////////////////////////////////
// Test des fonctions

$testFonction=readline("Quelle fonction tester? ");
switch($testFonction){
    case 1:
        $test1=SaisieTabUn(5, "Entrez une valeur: ");
        $test2=SaisieTabUn(3, "Entrez un prix: ");
        break;
    case 2:
        $test3=SaisieTabDyna();
        print_r($test3);
        break;
    case 3:
    case 4:
    case 5:
    case 6:
    case 7:
    default:
        break