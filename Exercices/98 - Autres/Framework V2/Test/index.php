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
    if (!file_exists("PHP/CONTROLLER/CLASSE/" . ucfirst($tableName) . ".Class.php")) {
        CreateClasse($tableName);
    }
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

echo '<div class="centered">';
AfficherTable(DAO::select(null, "Eleves", null, null, null, false, false));
echo '</div>';

echo CreateComboBox(null, "Eleves", ["nom", "prenom"], null,null, null, "--Veuillez choisir un eleve--");

var_dump(FormCreation::ListerFK("eleves"));
FormCreation::CreateForm("eleves");

DbConnect::close();
echo '<script src="./scripts/scripts.js"></script>
</body>

</html>';
