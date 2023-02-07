<?php
echo '<div class="ligne">';
if ((isset($_GET['afficher'])) && (strpos($_GET['afficher'], "Liste") !== false)) {
    echo '<div><a href="." class="buttonDash Retour">Retour</a></div>';
}else{
    echo '<div></div>';
}
echo '<div class="flex5"></div>';
echo '<a href=".?afficher=FormConnect">Connexion</a>';
echo '</div>';
