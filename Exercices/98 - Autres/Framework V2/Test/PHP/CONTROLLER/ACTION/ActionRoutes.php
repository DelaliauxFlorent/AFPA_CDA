<?php

if(ISSET($_POST['Mode'])&&($_POST['Mode']=="Ajouter")){    
    $newRoute= new Routes($_POST);
    RoutesManager::Add($newRoute);
    header("Location:?afficher=ListeRoutes");
}