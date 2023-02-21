<?php
include "./PHP/CONTROLLER/Outils.php";

spl_autoload_register("ChargerClasse");
Parametre::init();
DbConnect::init();

$routes = [
	"Accueil" => ["PHP/VIEW/GENERAL/", "Accueil", "Accueil", false],

	"Liste"=>["PHP/VIEW/LISTE/", "ListeArticles", "Liste des Articles", false],
	"FormArticle"=>["PHP/VIEW/FORM/", "FormArticle", "Formulaire des Articles", false],
	"ActionArticle"=>["PHP/CONTROLLER/ACTION/", "ActionArticle", "Action des Articles", false],
	"AppelAPI"=>["PHP/MODEL/API/", "AppelAPI", "Appel API des Articles", true]

];

if (isset($_GET["page"])) {

	$page = $_GET["page"];

	if (isset($routes[$page])) {
		AfficherPage($routes[$page]);
	} else {
		AfficherPage($routes["Accueil"]);
	}
} else {
	AfficherPage($routes["Accueil"]);
}