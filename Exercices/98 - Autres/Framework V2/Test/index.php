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

DbConnect::close();
