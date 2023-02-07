<?php
if (isset($_GET['Mode'])) {
    switch ($_GET['Mode']) {
        case 'Connect':
            $visiteur = UtilisateursManager::FindByPseudo($_POST['pseudoUtilisateur']);
            if ($visiteur != null) {
                if ($visiteur->getPassword() == md5($_POST['password'])) {
                    $_SESSION['Utilisateur'] = $visiteur;
                    header("Location:.");
                } else {
                    header("Location:.?afficher=FormConnect&Erreur=2");
                }
            } else {
                header("Location:.?afficher=FormConnect&Erreur=1");
            }
            break;

        case 'Deconnect':
            session_destroy();
            header("Location:.");
            break;

        default:
            # code...
            break;
    }
}
