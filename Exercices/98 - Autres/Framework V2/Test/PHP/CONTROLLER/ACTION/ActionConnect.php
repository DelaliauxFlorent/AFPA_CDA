<?php
$visiteur= UtilisateursManager::FindByPseudo($_POST['pseudoUtilisateur']);
if($visiteur!=null){
    var_dump($visiteur);
   // $visiteur->getPassword

}else{
    header("Location:.?afficher=FormConnect");
}