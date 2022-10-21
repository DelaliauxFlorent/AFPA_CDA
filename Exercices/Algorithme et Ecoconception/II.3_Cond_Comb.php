<?php
do{
    $genre=readline("Genre? ");
    $genre=strtoupper(substr($genre,0,1));
}while($genre!="H" && $genre!="F");
$age=readline("Age? ");


if(($genre=="H" && $age>=20) || ($genre=="F" && ($age>=18 && $age<=35))){
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