<?php

$pattern = new Patterns();

$form = [
    new Params([
        "name" => "name",
        "classInput" => "",
        "pattern" => $pattern->findRegex("chaineCaractere"),
        "title" => $pattern->findMsgErrorRegex("chaineCaractere"),
        "text" => "Entrez le nom",
        "classLabel" => "",
        "classMessage" => "",
        "classPicto" => ""
    ]),
    new Params([
        "name" => "prenom",
        "classInput" => "",
        "pattern" => $pattern->findRegex("chaineCaractere"),
        "title" =>  $pattern->findMsgErrorRegex("chaineCaractere"),
        "text" => "Entrez le prénom",
        "classLabel" => "",
        "classMessage" => "",
        "classPicto" => ""
    ]),
    new Params([
        "name" => "num",
        "classInput" => "",
        "pattern" => $pattern->findRegex("num"),
        "title" => $pattern->findMsgErrorRegex("num"),
        "text" => "Entrez le numéro de téléphone",
        "classLabel" => "",
        "classMessage" => "",
        "classPicto" => ""
    ]),
    new Params([
        "name" => "code",
        "classInput" => "",
        "pattern" => $pattern->findRegex("code"),
        "title" => $pattern->findMsgErrorRegex("code"),
        "text" => "Entrez le code postal",
        "classLabel" => "",
        "classMessage" => "",
        "classPicto" => "",
    ]),
    new Params([
        "name" => "mail",
        "classInput" => "",
        "type" => "mail",
        "pattern" => $pattern->findRegex("mail"),
        "title" => $pattern->findMsgErrorRegex("mail"),
        "text" => "Entrez l'adresse email",
        "classLabel" => "",
        "classMessage" => "",
        "classPicto" => "",
    ]),
    new Params([
        "name" => "mdp",
        "classInput" => "",
        "type" => "password",
        "pattern" => $pattern->findRegex("mdp"),
        "title" => $pattern->findMsgErrorRegex("mdp"),
        "text" => "Entrez le mot de passe",
        "classLabel" => "",
        "classMessage" => "",
        "classPicto" => "",
    ]),
];