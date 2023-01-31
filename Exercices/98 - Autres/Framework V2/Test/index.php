<?php
include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");
Parametre::init();
DbConnect::init();

$stmtListeTables = DbConnect::getDb()->prepare("SHOW TABLES;");
$stmtListeTables->execute();
$resultListeTables = $stmtListeTables->fetchAll(PDO::FETCH_ASSOC);
$varTableIn = "Tables_in_" . Parametre::getBase();

foreach ($resultListeTables as $table) {
    $tableName = $table[$varTableIn];
    CreateClasse($tableName);
    CreateManager($tableName);
}
echo '<!DOCTYPE html>
<html lang="en">

    <head>
        <meta charset="UTF-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" type="text/css" href="./css/styles.css">
        <link rel="icon" type="image/x-icon" href="./img/favicon.ico">
        <title></title>
    </head>

    <body><h1>Test</h1>';

// echo '<div class="centered">';
// AfficherTable(DAO::Select(null, "Eleves", null, null, null, false, false));
// echo '</div>';

//echo CreateComboBox(null, "Eleves", ["nom", "prenom"], null,null, null, "--Veuillez choisir un eleve--");

//var_dump(FormCreation::ListerFK("eleves"));
$eleveTest=DAO::Select(null, "eleves", ["idEleve"=>'2'], null, null, false, false);

FormCreation::CreateForm($eleveTest);

DbConnect::close();
echo '<script src="./scripts/scripts.js"></script>
</body>

</html>';
