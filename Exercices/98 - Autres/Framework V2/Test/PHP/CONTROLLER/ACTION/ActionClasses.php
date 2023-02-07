<?php

    if (isset($_POST["Mode"])) {
        switch ($_POST["Mode"]) {
            case "Ajouter":
                $newClasses = new Classes($_POST);
                ClassesManager::Add($newClasses);
                break;
            case "Modifier":
                if ((isset($_POST['idClasse'])) && (is_numeric($_POST['idClasse']))) {
                    $modClasses = new Classes($_POST);
                    ClassesManager::Update($modClasses);
                }
                break;
            case "Supprimer":
                if ((isset($_POST['idClasse'])) && (is_numeric($_POST['idClasse']))) {
                    $delClasses = new Classes($_POST);
                    ClassesManager::Delete($delClasses);
                }
                break;
            default:
                # code...
                break;
        }
        header("Location:?afficher=ListeClasses");
    }