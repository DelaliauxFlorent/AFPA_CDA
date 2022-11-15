<?php
//1.	Déclarer un tableau associatif avec les chiffres en lettres comme clé et les chiffres correspondants en valeur
$tableauAssoc=array("zero"=>0, "un"=>1, "deux"=>2, "trois"=> 3, "quatre"=>4, "cinq"=>5);

    // Test
    print_r($tableauAssoc);

//2.	Rechercher une valeur dans un tableau associatif

$needle=readline("Rechercher :");
if(in_array($needle, $tableauAssoc)){
    echo "Trouvé!";
}
else{
    echo "Absent!";
}



//Eco?
/*
$tabBase=array_values($tableauAssoc);
$i=0;
do{
    if($tablBase[$i]==$value){
        $found=true;
    }
    $i++;
}while($i<count($tableauAssoc) && $found==false);
*/

/*
    Values=>    
        - in_array (présence)
        - array_search (présence et return key si true)
    Key=>
        - array_keys (return array of keys)
        - array_key_exists (check if key exist in array)


*/

//3.	Quel tri peut-on appliquer à un tel tableau ?

/*
    - ksort/krsort => tri par ordre croi/décroi des keys [https://www.php.net/manual/fr/function.ksort.php]
    - uksort => tri selon règle défini par user [https://www.php.net/manual/fr/function.uksort.php]
*/