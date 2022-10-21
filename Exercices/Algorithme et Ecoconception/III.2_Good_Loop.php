<?php
$nbre_art=0;
$total_art=0;
do{
    $prix_art=readline("Entrez le prix d'un article (ou 0 pour terminer): ");
    ////////////////////////////////////////
    ///  A changer
    if(is_numeric($prix_art)){//} && !preg_match('/\.,/',$prix_art)){
        $nbre_art++;
        $total_art+=(int)$prix_art;
    }else{
        echo "Erreur, le prix doit être un entier!\n";
    }
    //*/
}while($prix_art!=0);

echo "\nVous avez entré ".$nbre_art." article(s) pour un total de ".$total_art." euros.\n\n";

do{
    $payment=readline("Encaissement de: ");
    if($payment<$total_art){
        echo "Erreur, cette somme n'est pas suffisante!\n";
    }elseif(!is_int($payment)){
        echo "Erreur, cette somme n'est pas valide! Donnez une valeur entière.";
    }
}while(!is_numeric($payment) || (int)$payment<$total_art);

$monnaie=$payment-$total_art;
if($monnaie!=0){
    echo "Voici votre monnaie:\n";
    while($monnaie>=10){
        echo "10 Euros\n";
        $monnaie-=10;
    }
    if($monnaie>=5){
        echo "5 Euros\n";
        $monnaie-=5;
    }
    while($monnaie>0){
        echo "1 Euro\n";
        $monnaie-=1;
    }
}
