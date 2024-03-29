<?php

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
        echo CreateInput($type, $colonne,$default);
    } elseif ($infosTable[$colonne]['Cle'] == "Primaire") {
        echo '<input type=hidden id=' . $colonne . '" name="' . $colonne . '" </imput>';
    } else {
        echo '<label for="' . $colonne . '">Entrez la valeur de "' . ucfirst($colonne) . '": </label><div class="flexMini"></div>';
        echo CreateComboBox(getGet($elt, [$colonne]), $listeCleSecondaires[$colonne]['table'], [ucfirst($listeCleSecondaires[$colonne]['table']::getChamps()[1])], null, null, null, null);

    }
    echo '</div>';
}
echo '
    <div class="ligne">
        <div>&nbsp;</div>
        <input id="btnCancel" class="cancel" type="button" value="Annuler">
        <div>&nbsp;</div>
        <input type="submit" value="Valider" />
        
        <div>&nbsp;</div>
    </div>
</form>';
