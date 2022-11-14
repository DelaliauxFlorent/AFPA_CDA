<?php

function ChargerClasse($classe)
{
    require './classes/'.$classe . '.class.php';
}
spl_autoload_register('ChargerClasse');

include './formulaire.php';

echo '<!DOCTYPE html>';
echo '<html lang="en">';
echo '<head>';
echo '    <meta charset="UTF-8">';
echo '    <meta http-equiv="X-UA-Compatible" content="IE=edge">';
echo '    <meta name="viewport" content="width=device-width, initial-scale=1.0">';
echo '<link rel="stylesheet" href="style.css">';

echo '    <title>Document</title>';
echo '</head>';
echo '<body>';
echo '<form>';
foreach ($form as $key => $value) {
    echo '<div>';
    echo '  '.$form[$key];
    echo '</div>';
}
echo '</form>';
echo '<script src="./script.js"></script>';
echo '</body>';
echo '</html>';
