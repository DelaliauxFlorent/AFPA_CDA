<?php

/* Trop compliqué
$a=readline("Age de l'enfant: ");
echo "Votre enfant est en catégorie ";
switch($a){
    case($a==6||$a==7):
        echo "Poussin";
        break;
    case($a==8||$a==9):
        echo "Pupille";
        break;
    case($a==10||$a==11):
        echo "Minime";
        break;
    case($a>=12):
        echo "Cadet";
        break;
    default:
        echo "erreur";
        break;
}*/
/*
$a=readline("Age de l'enfant: ");
if ($a>=6){
    if($a<8){
        echo "Poussin";
    }elseif($a<10){
        echo "Pupille";
    }elseif($a<12){
        echo "Minime";
    }else{
        echo "Cadet";
    }
}else{
    echo "erreur";
}
//Réponse*/
$a=readline("Age de l'enfant: ");
if ($a>12){
    echo "Cadet";
}elseif($a>10){
    echo "Minime";
}elseif($a>8){
    echo "Pupille";
}elseif($a>6){
    echo "Poussin";
}else{
    echo "erreur";
}