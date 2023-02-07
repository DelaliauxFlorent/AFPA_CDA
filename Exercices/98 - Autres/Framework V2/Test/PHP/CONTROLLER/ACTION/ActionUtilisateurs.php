<?php

    if (isset($_POST["Mode"])) {
        switch ($_POST["Mode"]) {
            case "Ajouter":
                $newUtilisateurs = new Utilisateurs($_POST);
                UtilisateursManager::Add($newUtilisateurs);
                break;
            case "Modifier":
                if ((isset($_POST['idUtilisateur'])) && (is_numeric($_POST['idUtilisateur']))) {
                    $modUtilisateurs = new Utilisateurs($_POST);
                    UtilisateursManager::Update($modUtilisateurs);
                }
                break;
            case "Supprimer":
                if ((isset($_POST['idUtilisateur'])) && (is_numeric($_POST['idUtilisateur']))) {
                    $delUtilisateurs = new Utilisateurs($_POST);
                    UtilisateursManager::Delete($delUtilisateurs);
                }
                break;
            default:
                # code...
                break;
        }
        header("Location:?afficher=ListeUtilisateurs");
    }