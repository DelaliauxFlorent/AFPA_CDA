<?php

const LABEL = 0;
const ID = 1;
const VALUE = 2;
const TYPE = 3;
const PATTERN = 4;
const REQUIRED = 5;
const HIDDEN = 6;
const DISABLED = 7;

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
    <script src="https://kit.fontawesome.com/ce4feb7268.js" crossorigin="anonymous"></script>
    <title>Générateur de Formulaires</title>
</head>

<body>
    <h1>Formulaire</h1>
        <form action="#" method="post">';

// Fin de haute du HTML
////////////////////////////////////////////////////////////

// Gestion des différents patterns possible
$patterns = [
    "Alpha" => ["^[a-zA-Z]{2,}$", "Entrer deux lettres minimum"],
    "AlphaMin" => ["[a-z]", "Entrer une lettre minuscule"],
    "AlphaMaj" => ["[A-Z]", "Entrer une lettre majuscule"],
    "Num" => ["[0-9]", "Entrer un chiffre"],
    "Spec" => ["[\W_]", "Entrer un caractère spécial (+-*/%...)"],
    "Telephone" => ["^[0]\d(\.| )?\d{2}(\.| )?\d{2}(\.| )?\d{2}(\.| )?\d{2}$", "10 chiffres, espaces et points autorisés."],
    "Mail" => ["^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,5})+$", "Une adresse de la forme 'Abc@example.com'."],
    "Min1Min" => ["(?=.*[a-z])", "Au moins 1 minuscule, "],
    "Min1Maj" => ["(?=.*[A-Z])", "1 majuscule, "],
    "Min1Chi" => ["(?=.*[0-9])", "1 chiffre, "],
    "Min1Spe" => ["(?=.*[\W_])", "1 caractère spécial (+-*/%...) et "],
    "Min8Car" => [".{8,}", "au moins 8 caractères au total"]
    // "PassW"=> ["(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{8,}",]
];

$patternPW = [$patterns["Min1Min"], $patterns["Min1Maj"], $patterns["Min1Chi"], $patterns["Min1Spe"], $patterns["Min8Car"]];
// Pour chaque élément, ordres => "label", "id", "value", "type", "pattern", "required", "hidden", "disabled"
$listeDonneesFormulaire = [
    "nom" => ["Votre nom : ", "nom", "", "text", $patterns["Alpha"], true, false, false],
    "prenom" => ["Votre prenom : ", "prenom", "", "text", $patterns["Alpha"], false, false, false],
    "age" => ["Votre âge : ", "age", "", "number", "0,100", false, false, false],
    "telephone" => ["Numéro de téléphone : ", "telephone", "", "text", $patterns["Telephone"], false, false, false],
    "cdPostal" => ["votre Code Postal : ", "cdPostal", "", "number", "1000,99999", false, false, false],
    "mail" => ["Votre eMail : ", "mail", "", "email", $patterns["Alpha"], true, false, false],
    "password" => ["Mot de passe : ", "mdp", "", "password", $patternPW, true, false, false],
    "confirmer" => ["Confirmation : ", "confirmPW", "", "password", $patternPW, true, false, true]
];

////////////////////////////////////////////////////////////
// Boucle de création du formulaire

foreach ($listeDonneesFormulaire as $ligne => $champ) {
    echo '
    <div class="ligne">
        <label for="' . $champ[ID] . '">' . $champ[LABEL] . '</label>
        <input class="checkValidity" type="' . $champ[TYPE] . '" id="' . $champ[ID] . '" name="' . $champ[ID] . '" ' . (($champ[REQUIRED]) ? 'required ' : '') . (($champ[HIDDEN]) ? 'hidden ' : '') . (($champ[DISABLED]) ? 'disabled ' : '');
    if ($champ[TYPE] == "number") {
        $minMax = explode(",", $champ[PATTERN]);
        $titleNum="Un nombre compris entre $minMax[0] et $minMax[1]";
        echo ' min=' . $minMax[0] . ' max=' . $minMax[1] . ' title="'.$titleNum.'" />';
    } elseif ($champ[TYPE] == "password") {
        $patPW = "";
        $titlePW = "";
        foreach ($champ[PATTERN] as $value) {
            $patPW .= $value[0];
            $titlePW .= $value[1];
        }
        echo ' pattern="'.$patPW.'" title="'.$titlePW.'" />';
    } else {
        echo ' pattern="'.$champ[PATTERN][0].'" title="'.$champ[PATTERN][1].'" />';
    }
    
    if($champ[TYPE] == "number"){
                echo '
                <div class="mini"></div>
                <div class="info picto">
                    <i class="far fa-question-circle fa-2x infobulle"></i>
                    <div class="texteInfoBulle">'.$titleNum.'</div>
                </div>
                <div class="check picto">
                    <i class="far fa-check-circle fa-2x vert"></i>
                </div>
                <div class="message"></div>';
            }elseif($champ[TYPE] == "password"){
                echo '
                <div class="mini info">
                    <div class="oeil">
                        <i class="fas fa-eye"></i>
                    </div>
                </div>
                <div class="info picto">
                    <i class="far fa-question-circle fa-2x infobulle"></i>
                    <div class="texteInfoBulle">'.$titlePW.'</div>
                    <div class="aideMdp">
                        <div>Liste des critères à respecter</div>
                        <div>
                            <div class="mini"><i class="far fa-times-circle rouge"></i>
                            </div>
                            <div class="gauche">8 caractères minimum</div>
                        </div>
                        <div>
                            <div class="mini"><i class="far fa-times-circle rouge"></i>
                            </div>
                            <div class="gauche">majuscule(s)</div>
                        </div>
                        <div>
                            <div class="mini"><i class="far fa-times-circle rouge"></i>
                            </div>
                            <div class="gauche">minuscule(s)</div>
                        </div>
                        <div>
                            <div class="mini"><i class="far fa-times-circle rouge"></i>
                            </div>
                            <div class="gauche">nombre(s)</div>
                        </div>
                        <div>
                            <div class="mini"><i class="far fa-times-circle rouge"></i>
                            </div>
                            <div class="gauche">caractères spéciaux</div>
                        </div>
                    </div>
                </div>
                <div class="check picto">
                    <i class="far fa-check-circle fa-2x vert"></i>
                </div>
                <div class="message"></div>';
            }else{
                echo '
                <div class="mini"></div>
                <div class="info picto">
                    <i class="far fa-question-circle fa-2x infobulle"></i>
                    <div class="texteInfoBulle">'.$champ[PATTERN][1].'</div>
                </div>
                <div class="check picto">
                    <i class="far fa-check-circle fa-2x vert"></i>
                </div>
                <div class="message"></div>';
            }
    echo '
    
    </div>';
}

////////////////////////////////////////////////////////////
// Partie basse du HTML
echo '
        <div class="ligne"><input type="submit"></div>
    </form>
    <script src="./scripts/scripts.js"></script>
</body>

</html>';
