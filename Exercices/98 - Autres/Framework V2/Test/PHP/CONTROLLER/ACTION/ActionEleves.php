<?php

    if (isset($_POST["Mode"])) {
        switch ($_POST["Mode"]) {
            case "Ajouter":
                $newEleves = new Eleves($_POST);
                ElevesManager::Add($newEleves);
                break;
            case "Modifier":
                if ((isset($_POST['idEleve'])) && (is_numeric($_POST['idEleve']))) {
                    $modEleves = new Eleves($_POST);
                    ElevesManager::Update($modEleves);
                }
                break;
            case "Supprimer":
                if ((isset($_POST['idEleve'])) && (is_numeric($_POST['idEleve']))) {
                    $delEleves = new Eleves($_POST);
                    ElevesManager::Delete($delEleves);
                }
                break;
            default:
                # code...
                break;
        }
        header("Location:?afficher=ListeEleves");
    }