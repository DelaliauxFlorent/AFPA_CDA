<?php
////////////////////////////////////////////////////////////
// Partie haute du HTML
echo '
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="./styles/styles.css">
    <link rel="icon" type="image/x-icon" href="./img/favicon.ico">
    <title>Générateur de Formulaires</title>
</head>

<body>';

// Fin de haute du HTML
////////////////////////////////////////////////////////////

// Gestion des différents patterns possible
$patterns = [
    "Alpha" => ["^[a-zA-Z]{2,}$", "Entrer deux lettres minimum"],
    "AlphaMin" => ["[a-z]", "Entrer une lettre minuscule"],
    "AlphaMaj" => ["[A-Z]", "Entrer une lettre majuscule"],
    "Num" => ["[0-9]", "Entrer un chiffre"],
    "Spec" => ["[\W_]", "Entrer un caractère spécial (+-*/%...)"],
    "Telephone" =>["^[0]\d(\.| )?\d{2}(\.| )?\d{2}(\.| )?\d{2}(\.| )?\d{2}$", "10 chiffres, espaces et points autorisés."],
    "Mail"=> ["^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,5})+$", "Une adresse de la forme 'Abc@example.com'."],
    "Min1Min" => ["(?=.*[a-z])", "Au moins une minuscule"],
    "Min1Maj" => ["(?=.*[A-Z])", "Au moins une majuscule"],
    "Min1Chi" => ["(?=.*[0-9])", "Au moins un chiffre"],
    "Min1Spe" => ["(?=.*[\W_])", "Au moins un caractère spécial (+-*/%...)"],
    "Min8Car" => [".{8,}", "Au moins 8 caractères au total"]
    // "PassW"=> ["(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{8,}",]
];

$patternPW=[$patterns["Min1Min"], $patterns["Min1Maj"], $patterns["Min1Chi"], $patterns["Min1Spe"], $patterns["Min8Car"]];
// Pour chaque élément, ordres => "label", "id", "value", "type", "pattern", "title", "required", "hidden", "disabled"
$listeDonneesFormulaire = [ "nom" => ["Votre nom : ", "nom", "", "text", $patterns["Alpha"],"", true, false, false],
                            "prenom" => ["Votre prenom : ", "prenom", "", "text", $patterns["Alpha"],"", false, false, false],
                            "age" => ["Votre âge : ", "age", "", "number", "0,100","", false, false, false],
                            "telephone" => ["Numéro de téléphone : ", "telephone", "", "text", $patterns["Telephone"],"", false, false, false],
                            "cdPostal" => ["votre Code Postal : ", "cdPostal", "", "number", "1000,99999","", false, false, false],
                            "mail" => ["Votre eMail : ", "mail", "", "email", $patterns["Alpha"],"", false, false, false],
                            "password" => ["Mot de passe : ", "mdp", "", "password", $patternsPW,"", true, false, false],
                            "confirmer" => ["Confirmatio : ", "prenom", "", "text", $patterns["Alpha"],"", false, false, false],
                            
];

////////////////////////////////////////////////////////////
// Partie basse du HTML
echo '
    <script src="./scripts/scripts.js"></script>
</body>

</html>';
