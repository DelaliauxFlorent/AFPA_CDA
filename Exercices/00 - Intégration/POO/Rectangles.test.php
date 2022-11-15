<?php
require "Rectangles.class.php";

$taille1=array("longueur"=>20, "Largeur"=>30);
$taille2=array("longueur"=>25, "Largeur"=>25);

$rect1=new Rectangles($taille1);
$rect2=new Rectangles($taille2);

$rect1->afficherRectangle();
echo "\n";
$rect2->afficherRectangle();