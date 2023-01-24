<?php

include "./PHP/CONTROLLER/Outils.php";
spl_autoload_register("ChargerClasse");

//on active la connexion à la base de données
Parametre::init();
DbConnect::init();
var_dump(PersonneManager::GetAllPersonnes());
echo "<br/><hr/><br/>";
DbConnect::close();
