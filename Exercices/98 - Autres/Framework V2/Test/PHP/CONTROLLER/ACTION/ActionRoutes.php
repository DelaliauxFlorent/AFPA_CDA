<?php

if (isset($_POST['Mode'])) {
    switch ($_POST['Mode']) {
        case "Ajouter":
            $newRoute = new Routes($_POST);
            RoutesManager::Add($newRoute);
            break;
        case "Modifier":
            if ((isset($_POST['idRoute'])) && (is_numeric($_POST['idRoute']))) {
                $modRoute = new Routes($_POST);
                RoutesManager::Update($modRoute);
            }
            break;
        case "Supprimer":
            if ((isset($_POST['idRoute'])) && (is_numeric($_POST['idRoute']))) {
                $delRoute = new Routes($_POST);
                RoutesManager::Delete($delRoute);
            }
            break;
        default:
            # code...
            break;
    }
    header("Location:?afficher=ListeRoutes");
}
