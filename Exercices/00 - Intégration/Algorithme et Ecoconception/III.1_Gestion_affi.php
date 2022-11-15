<?php

$nbre=readline("Donnez un nombre: ");
$total=0;
echo "La somme des entiers jusqu'a ce nombre est:\n";
$aff="";
if($nbre>0){
    for($i=1; $i<=$nbre; $i++){

        $total+=$i;
        $aff.=$i." + ";

    }
    $aff=substr($aff, 0, -3);
    echo $aff." = ";
}

echo $total;