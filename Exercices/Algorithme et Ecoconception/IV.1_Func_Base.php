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
    $regex= '/^(-|\+)?[0-9]+$/';
    do{
        do{
            $val=readline("Entrez une valeur entière: ");
            if(!preg_match($regex,$val)){
                echo "Erreur, entrez un entier!\n";
            }
        }while(!preg_match($regex,$val));
        $retour2[]=(int)$val;
    }while($val!=0);
    array_pop($retour2);
    return $retour2;
}

//3.	Trier un tableau 

function TrierTableau($tableau){
    sort($tableau, SORT_NATURAL | SORT_FLAG_CASE); // Retourne booléen et le tableau classé par ordre alpha/croissant et réassignement keys
    return $tableau;
}

//4.	Afficher un tableau

function Afficher_Tab($tableau){
    foreach($tableau as $value){
        echo " | ".$value;
    }
    echo " |";
}

// 5.	Saisir un tableau à 2 dimensions de X valeurs par Y (X et Y passer en paramètre)

function SaisieTableau2D($largeur, $hauteur){
    for($i=0; $i<$hauteur;$i++){
        $lignes[$i]= SaisieTabUn($largeur, "Veuillez entrer un nombre entier: ");
    }
    return $lignes;
}

//6.	Afficher un tableau à 2 dimensions sous forme de plateau de jeu ; c’est-à-dire avec les traits de ligne et colonnes, les entêtes de colonnes seront des lettres, chiffres pour les lignes

function AfficherTab2D($tableau2D){
    $hauteur=count($tableau2D);
    $largeur=count($tableau2D[0]);
    $tirret="-----------------";

    echo "\t \t";
    for($i=0;$i<$largeur;$i++){
        echo "|\t".mb_chr(65+$i)."\t";
        $tirret.="----------------";
    }
    echo "|";
    
    foreach($tableau2D as $ligne=>$array){
        echo "\n".$tirret;
        echo "\n|\t".($ligne+1)."\t";
        foreach($array as $value){
            echo "|\t".$value."\t";
        }
        echo "|";
    }
    echo "\n".$tirret;
}

//7.	Rechercher une valeur dans un tableau

function rechercheTab($value, $tableau){
    $found=false;
    $i=0;
    do{
        if($tableau[$i]==$value){
            $found=true;
        }
        $i++;
    }while($i<count($tableau) && $found==false);
    return $found;
}

// Génération d'un tableau de taille voullu rempli de valeurs aléatoire pour test

function tableauRandom($taille){
    for($i=0; $i<$taille; $i++){
        $tableau[$i]=random_int(0,100);
    }
    return $tableau;
}

/////////////////////////////////////////
// Test des fonctions

$testFonction=readline("Quelle fonction tester? ");
switch($testFonction){
    case 1:
        $test1_1=SaisieTabUn(5, "Entrez une valeur: ");
        print_r($test1_1);
        $test1_2=SaisieTabUn(3, "Entrez un prix: ");
        print_r($test1_2);
        break;
    case 2:
        $test2=SaisieTabDyna();
        print_r($test2);
        break;
    case 3:
        $test3=SaisieTabDyna();
        $test3=TrierTableau($test3);
        print_r($test3);
        break;
    case 4:
        $test4=SaisieTabDyna();
        Afficher_Tab($test4);
        break;
    case 5:
        $test5=SaisieTableau2D(5,3);
        print_r($test5);
        break;
    case 6:
        $test6=[[0,2,4,6,8],[10,12,14,16,18],[20,22,24,26,28]];
        AfficherTab2D($test6);
        break;
    case 7:
        $test7=tableauRandom(10);
        print_r($test7);
        $needle=readline("Recherche: ");
        if(rechercheTab($needle, $test7)){
            echo "Trouvé!";
        }else{
            echo "Absent!";
        }
        break;
    default:
        break;
}