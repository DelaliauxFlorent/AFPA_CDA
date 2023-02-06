<?php
if (isset($_GET['afficher'])) {
    
    if (strpos($_GET['afficher'],"Liste") !== false) {
        echo '<div class="ligne">
        <div><a href="." class="buttonDash Retour">Retour</a></div>
        <div class="flex5"></div>
    </div>';
    } 
    // elseif (strpos($_GET['afficher'],"Form") !== false) {
    //     $go_back = htmlspecialchars($_SERVER['HTTP_REFERER']);
    //     echo '<div class="ligne">
    //     <div><a href='.$go_back.' class="buttonDash Retour">Retour</a></div>
    //     <div class="flex5"></div>
    // </div>';
    // }
}
