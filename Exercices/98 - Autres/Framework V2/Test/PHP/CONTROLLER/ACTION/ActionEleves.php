<?php
var_dump($_POST);
if(ISSET($_POST['Mode'])&&($_POST['Mode']=="Ajouter")){    
    $newObj= new Eleves($_POST);
    ElevesManager::Add($newObj);
    //header("Location:?afficher=ListeEleves");
}