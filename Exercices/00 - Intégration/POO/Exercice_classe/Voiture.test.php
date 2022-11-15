<?php

require "Voiture.class.php";

$voiture1 = new Voiture("noire", "Citroën", "C4", 10000, "diesel");
$voiture2 = new Voiture("rouge", "renault", "Kadjar", 30, "essence");

$voiture1->description();
echo "\n";
$voiture2->description();

$kmRoule=readline("\n\nRoulé: ");
echo "Avant : ".$voiture1->get_nbKm()."\n";
$voiture1->rouler($kmRoule);
echo "Après : ".$voiture1->get_nbKm()."\n";