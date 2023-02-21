<?php
$nomColonnes = Articles::getChamps();
echo json_encode(DAO::select($nomColonnes, "Articles", null, null, null, true));