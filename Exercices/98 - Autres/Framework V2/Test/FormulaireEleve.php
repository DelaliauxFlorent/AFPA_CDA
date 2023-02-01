<?php
include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");
Parametre::init();
DbConnect::init();

echo '<!DOCTYPE html>
<html>

    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" type="text/css" href="./css/styles.css">
        <link rel="icon" type="image/x-icon" href="./img/favicon.ico">
        <title></title>
    </head>

    <body><h1>Test</h1>';

$table = "Eleves";
$infosTable = RecupInfos($table);
$listeCleSecondaires = ListerFK($table);

//////////////////////////////
// Présent dans le générateur

$id = (ISSET($_GET["id"])?$_GET["id"]:"");
$elt = ElevesManager::FindById($id);

echo '
<form methode="get" action="./PHP/CONTROLLER/ACTION/ActionEleves.php">
';
foreach ($infosTable as $colonne => $infoColonne) {
    echo '<div class="ligne">';
    if ($id != null) {
        $default = ' value="' . getGet($elt, [$colonne]) . '"';
    } else  {
        $default = ' value="' . $infosTable[$colonne]['Defaut'] . '"';
    } 
    $required = (!$infosTable[$colonne]['Null']) ? ' required' : '';
    $type=TypeToInput($infosTable[$colonne]['Type']);
    if ($infosTable[$colonne]['Cle'] == null) {

        if ($infosTable[$colonne]['Type'] != 'bool') {
            echo '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label><div class="flexMini"></div>';
            echo '<input type="' . $type . '" id="' . $colonne . '" name="' . $colonne . '"' . $default . $required . '>';
        }
    } elseif ($infosTable[$colonne]['Cle'] == "Primaire") {
        echo '<input type=hidden id=' . $colonne . '" name="' . $colonne . '" </imput>';
    } else {
        echo '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label><div class="flexMini"></div>';
        echo CreateComboBox(getGet($elt, [$colonne]), $listeCleSecondaires[$colonne]['table'], ["libelle"], null, null, null, null);
    }
    echo '</div>';
}
echo '
    <div class="ligne">
        <div>&nbsp;</div>
        <input id="btnCancel" class="cancel" type="button" value="Annuler">
        <div>&nbsp;</div>
        <input id="btnValid" class="valid" type="button" value="Valider">
        <div>&nbsp;</div>
    </div>
</form>';


echo '<script src="./scripts/scripts.js"></script>
</body>

</html>';
