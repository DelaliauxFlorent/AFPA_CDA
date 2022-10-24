<?php
$regex= '/^[0-9]+$/';
$nbre_art=0;
$total_art=-1;

//Prix

do{
    $prix_art=readline("Entrez le prix d'un article (ou 0 pour terminer): ");
    if(preg_match($regex,$prix_art)){
        $nbre_art++;
        $total_art+=(int)$prix_art;
    }else{
        echo "Erreur, le prix doit être un entier!\n";
    }
}while($prix_art!=0);

echo "\nVous avez entré ".$nbre_art." article(s) pour un total de ".$total_art." euros.\n\n";

//Somme Payé

do{
    $payment=readline("Encaissement de: ");
    if($payment<$total_art){
        echo "Erreur, cette somme n'est pas suffisante!\n";
    }elseif(!preg_match($regex,$payment)){
        echo "Erreur, entrée invalide! Donnez une valeur entière.";
    }
}while(!preg_match($regex,$payment) || (int)$payment<$total_art);

// Rendu

$monnaie=$payment-$total_art;
if($monnaie!=0){
    echo "Voici votre monnaie:\n";
    while($monnaie>=10){
        echo "\t10 Euros\n";
        $monnaie-=10;
    }
    if($monnaie>=5){
        echo "\t 5 Euros\n";
        $monnaie-=5;
    }
    while($monnaie>0){
        echo "\t 1 Euro\n";
        $monnaie-=1;
    }
}
