<?php

$genre=readline("Genre? ");
$age=readline("Age? ");


if(($genre=="h" && $age>=20) || ($genre=="f" && ($age>=18 && $age<=35))){
    $impot=true;
}else{
    $impot=false;
}

/*
switch($genre){
    case "h":
        if($age>=20){
            $impot=true;
        };
        break;
    case "f":
        if($age>=18 && $age<=35){
            $impot=true;
        };
        break;
    default: 
        break;
}*/

echo "Vous êtes ";
if (!$impot){
    echo "non-";
}
echo "imposable.";