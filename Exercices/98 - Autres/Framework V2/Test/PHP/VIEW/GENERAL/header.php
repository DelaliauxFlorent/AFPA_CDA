<?php

if (isset($_GET["afficher"])) {

    $fichier = $ListeRoutes[$_GET["afficher"]]['chemin'];
    if (file_exists($fichier)) {
        echo '<h1>'.$ListeRoutes[$_GET["afficher"]]['titre'].'</h1>';
    }
}
else{
    echo '<h1>Framework</h1>';
}
