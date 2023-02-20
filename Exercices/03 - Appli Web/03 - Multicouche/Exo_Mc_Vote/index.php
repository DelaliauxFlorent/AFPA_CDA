<?php

include "./PHP/CONTROLLER/Outils.php";

spl_autoload_register("ChargerClasse");

session_start();

$routes = [
	"Accueil" => ["PHP/VIEW/GENERAL/", "Accueil", "Accueil", 0, false],

	"Vote"=>["PHP/VIEW/FORM/", "FormVote", "Vote", 0, false],
	
	"ActionVote" => ["PHP/CONTROLLER/ACTION/", "ActionVote", "Action Vote", 0, false]

];

if (isset($_GET["page"])) {

	$page = $_GET["page"];

	if (isset($routes[$page])) {
		AfficherPage($routes[$page]);
	} else {
		AfficherPage($routes["Vote"]);
	}
} else {
	AfficherPage($routes["Vote"]);
}
