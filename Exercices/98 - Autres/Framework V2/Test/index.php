<?php
include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");
Parametre::init();
DbConnect::init();

$stmtListeTables = DbConnect::getDb()->prepare("SHOW TABLES;");
$stmtListeTables->execute();
$resultListeTables = $stmtListeTables->fetchAll(PDO::FETCH_ASSOC);
$varTableIn = "Tables_in_" . Parametre::getBase();
$tableExiste;
foreach ($resultListeTables as $table) {
    $tableName = $table[$varTableIn];
    $tableExiste[] = $tableName;
    CreateClasse($tableName);
    CreateManager($tableName);
    CreateForm($tableName);
}
include "./PHP/VIEW/GENERAL/head.php";
include "./PHP/VIEW/GENERAL/header.php";
include "./PHP/VIEW/GENERAL/nav.php";

if (isset($_GET["afficher"])) {
    switch ($_GET["afficher"]) {
        case 'liste':
            if (isset($_GET["table"]) && (in_array($_GET["table"], $tableExiste))) {
                $fichier = "PHP/VIEW/LISTE/Liste" . ucfirst($_GET["table"]) . '.php';
                if (file_exists($fichier)) {
                    include $fichier;
                } else {
                    echo '<div><h2 class=centered">Page inconnue</h2></div><br /><br />';
                }
            }
            break;
        case 'formulaire':
            if (isset($_GET["table"]) && (in_array(lcfirst($_GET["table"]), $tableExiste))) {
                $fichier = "PHP/VIEW/FORM/Formulaire" . ucfirst($_GET["table"]) . '.php';
                if (file_exists($fichier)) {
                    include $fichier;
                } else {
                    echo '<div><h2 class=centered">Page inconnue</h2></div><br /><br />';
                }
            }
            break;

        default:
            # code...
            break;
    }
} else {
    echo '<div><h2 class=centered">Page d\'accueil</h2></div><br /><br />';
    foreach ($resultListeTables as $Listes) {
        echo '<div class="ligne"><div></div><div class="centered"><a href="?afficher=liste&table=' . $Listes[$varTableIn] . '" id="btnListe' . $Listes[$varTableIn] . '" class="buttonDash">Liste des ' . $Listes[$varTableIn] . '</a></div><div></div></div>';
    }
}

// echo '<div class="centered">';
// AfficherTable(DAO::Select(null, "Eleves", null, null, null, false, false));
// echo '</div>';

//echo CreateComboBox(null, "Eleves", ["nom", "prenom"], null,null, null, "--Veuillez choisir un eleve--");

//var_dump(FormCreation::ListerFK("eleves"));


//CreateForm("Eleves");
//include "./PHP/VIEW/FORM/FormulaireEleves.php";
echo '<div>&nbsp;</div>';
//echo FormCreation::CreateForm($ClassTest);

DbConnect::close();
