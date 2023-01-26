
<?php
/* Autoload permet de charger toutes les classes necessaires */
function ChargerClasse($champs)
{
    if (file_exists("PHP/CONTROLLER/CLASSE/" . $champs . ".Class.php")) {
        require "PHP/CONTROLLER/CLASSE/" . $champs . ".Class.php";
    }
    if (file_exists("PHP/MODEL/MANAGER/" . $champs . ".Class.php")) {
        require "PHP/MODEL/MANAGER/" . $champs . ".Class.php";
    }
}


function crypte($mot) //fonction qui crypte le mot de passe
{
    return md5(md5($mot) . strlen($mot));
}
// A coder pour décoder les informations base de données dans le json
function decode($texte)
{
    return $texte;
}

function decoder($string)
{
    $encoded = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
    $decoded = ['p', 'v', 'x', 's', 'z', 'd', 'f', 'g', 'u', 'h', 'j', 'k', 'l', 'b', 'i', 'o', 'm', 'e', 'q', 'r', 'y', 'c', 'n', 'w', 't', 'a', 'P', 'V', 'X', 'S', 'Z', 'D', 'F', 'G', 'U', 'H', 'J', 'K', 'L', 'B', 'I', 'O', 'M', 'E', 'Q', 'R', 'Y', 'C', 'N', 'W', 'T', 'A'];
    for ($i = 0; $i < strlen($string); $i++) {
        if (in_array($string[$i], $encoded)) {
            $index = array_search($string[$i], $encoded);
            $string[$i] = $decoded[$index];
        }
    }
    return $string;
}

/**
 * Vérifie si la chaîne contient un ";", indiquant la possibilité de tentative d'injection
 *
 * @param string 
 * @return boolean
 */
function DetectInject($string): bool
{
    if (strpos($string, ";") !== false) {
        return true;
    }
    return false;
}

function CreateClasse($table)
{
    $stmtListAttributs = DbConnect::getDb()->prepare("DESCRIBE ".$table);
    $stmtListAttributs->execute();
    $resultListeColonnes = $stmtListAttributs->fetchAll(PDO::FETCH_ASSOC);
    var_dump($resultListeColonnes);
    $codeClassse='
    <?php
        class {$table}
        {
            ////////////////////////////////////
            // Attributs

    ';
    foreach ($resultListeColonnes as $colonne) {
        $codeClassse.='
        private $_'.$colonne["Field"].';
        ';
    }
    var_dump($codeClassse);
}
