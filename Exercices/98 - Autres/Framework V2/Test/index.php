<?php 
include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");
Parametre::init();
DbConnect::init();

$stmtListeTables=DbConnect::getDb()->prepare("SHOW TABLES;");
$stmtListeTables->execute();
$resultListeTables = $stmtListeTables->fetchAll(PDO::FETCH_ASSOC);
var_dump($resultListeTables);
foreach ($resultListeTables as $table) {
    $tableName=$table["Tables_in_modelevoitures"];
    var_dump($tableName);
    CreateClasse($tableName);
}