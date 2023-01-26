<?php
$listeDossiers=["CSS", "HTML", "IMG", "JS", "SQL","PHP", "PHP/CONTROLLER", "PHP/CONTROLLER/ACTION", "PHP/CONTROLLER/CLASSE", "PHP/MODEL", "PHP/MODEL/API", "PHP/MODEL/MANAGER", "PHP/VIEW", "PHP/VIEW/FORM", "PHP/VIEW/GENERAL", "PHP/VIEW/LISTE"];

foreach ($listeDossiers as $dossier) {
    if(!is_dir($dossier)){
        mkdir("test/{$dossier}",0777, true);
        $fichier = fopen("test/{$dossier}/index.php", "w");
        fwrite($fichier, "<?php echo <h1>Sécurité</h1>;");
        fclose($fichier);
    }
}
