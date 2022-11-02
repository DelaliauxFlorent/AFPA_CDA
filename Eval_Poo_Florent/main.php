<?php

$client=new Clients("nom"=>"Dupont", "prenom"=>"Paul", "compte"=> new Comptes("numero"=>"50236R", "montant"=>120), "livret"=>new livrets("numero"=>"45"))