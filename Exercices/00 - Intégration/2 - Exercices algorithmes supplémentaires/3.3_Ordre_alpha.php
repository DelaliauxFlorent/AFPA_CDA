<?php

$regex='/^[A-Za-z]+$/';

for($i=0; $i<3; $i++){
    do{
        $tab_nom[$i]=readline("Veuillez entrer un nom: ");
        if(!preg_match($regex,$tab_nom[$i])){
            echo "Erreur, entrée invalide!\n";
        }    
    }while(!preg_match($regex,$tab_nom[$i]));
}

$tab_ori = $tab_nom;
sort($tab_nom, SORT_NATURAL | SORT_FLAG_CASE);
// natcasesort($tab_nom);                           Garde les clès d'origine
$already=true;

///////////
// Non eco
/*

foreach($tab_nom as $key=>$nom){
    if($nom!=$tab_ori[$key]){
        $already=false;
    }
}


*/

/////////////
// Eco?

$i=0;
do{
    if($tab_nom[$i]!=$tab_ori[$i]){
        $already=false;
    }
    $i++;
}while($already && $i<3);


//////////////////////////////////
// Affichage resultat

if($already){
    echo "Ces noms sont déjà classés par ordre alphabétique.";
}else{
    echo "Ces noms ne sont pas classés par ordre alphabétique.";
}