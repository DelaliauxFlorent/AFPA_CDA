<?php

$cand1=readline("Score du 1er candidat: ");
$cand2=readline("Score du 2eme candidat: ");
$cand3=readline("Score du 3eme candidat: ");
$cand4=readline("Score du 4eme candidat: ");


//if ($cand1+$cand2+$cand3+$cand4<=100){
    if($cand1>50){
        echo "Élu";
    }elseif($cand1<12.5||$cand2>50||$cand3>50||$cand4>50){
        echo "Battu";
    }elseif(($cand1>$cand2) && ($cand1>$cand3) && ($cand1>$cand4)){ //utiliser un array pour les scores et utiliser un 'sort' pour vérifier si valeur égale au 1er? prob en cas de score identique
        echo "Ballotage favorable";
    }else{
        echo "Ballotage défavorable";
    }/*
}else{
    echo "Tricherie";
}*/