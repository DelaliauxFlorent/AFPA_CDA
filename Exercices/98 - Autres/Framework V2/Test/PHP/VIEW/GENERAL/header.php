<?php
echo '<header><h1>Framework</h1></header>';
if (isset($_GET['afficher'])) {
    if (isset($_GET["table"]) && (in_array($_GET["table"], $tableExiste))) {
        echo '<h2 class="centered">Liste des ' . $_GET["table"] . '</h2>';
    }
}
