<?php
echo '<!DOCTYPE html>
<html><head>';

//Si le titre est indiqué, on l\'affiche entre les balises <title>';
echo (!empty($titre)) ? '<title>' . $titre . '</title>' : '<title> Titre de la page </title>';
echo '<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<link rel="icon" href="IMG/favicon.ico" />
<link rel="stylesheet" href="CSS/root.css">
<link rel="stylesheet" href="CSS/style.css">
<link rel="stylesheet" href="CSS/icon.css">
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;700&display=swap" rel="stylesheet">
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Comfortaa:wght@500;700&display=swap" rel="stylesheet">';
echo '  <link rel="stylesheet" href="CSS/grids.css">
            <link rel="stylesheet" href="CSS/form.css">';
    echo '</head>';
//  <script src="https://kit.fontawesome.com/ce4feb7268.js" crossorigin="anonymous"></script>