<?php
/////////////////////////////////////////////////////////////////////////
// Setting CONSTANTs to facilitate dealing with non-associative arrays
/////////////////////////////////////////////////////////////////////////

// For the array dealing with all the fields for each INPUT
const LABEL = 0;
const ID = 1;
const VALUE = 2;
const TYPE = 3;
const PATTERN = 4;
const REQUIRED = 5;
const HIDDEN = 6;
const DISABLED = 7;

// For the patterns and corrresponding message
const REGEX = 0;
const MESSAGE = 1;

/////////////////////////////////////////////////////////////////////////
// Setting an associative array where each KEY correspond to a pair
// "Regex pattern" => corresponding message
/////////////////////////////////////////////////////////////////////////

$patterns = [
    "Alpha" => ["^[a-zA-Z]{2,}$", "Entrer deux lettres minimum"],
    "AlphaMin" => ["[a-z]", "Entrer une lettre minuscule"],
    "AlphaMaj" => ["[A-Z]", "Entrer une lettre majuscule"],
    "Num" => ["[0-9]", "Entrer un chiffre"],
    "Spec" => ["[\W_]", "Entrer un caractère spécial (+-*/%...)"],
    "Telephone" => ["^[0]\d(\.| )?\d{2}(\.| )?\d{2}(\.| )?\d{2}(\.| )?\d{2}$", "10 chiffres, espaces et points autorisés."],
    "Mail" => ["^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,5})+$", "Une adresse de la forme 'Abc@example.com'."],
    "Min1Min" => ["(?=.*[a-z])", "1 minuscule"],
    "Min1Maj" => ["(?=.*[A-Z])", "1 majuscule"],
    "Min1Chi" => ["(?=.*[0-9])", "1 chiffre"],
    "Min1Spe" => ["(?=.*[\W_])", "1 caractère spécial (+-*/%...)"],
    "Min8Car" => [".{8,}", "8 caractères minimum"]
    // "PassW"=> ["(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{8,}",]
];

/////////////////////////////////////////////////////////////////////////
// Setting the particular case of the password
/////////////////////////////////////////////////////////////////////////

$patternPW = [$patterns["Min1Min"], $patterns["Min1Maj"], $patterns["Min1Chi"], $patterns["Min1Spe"], $patterns["Min8Car"]];

/////////////////////////////////////////////////////////////////////////
// Creating the array with all the inputs we want in the form
/////////////////////////////////////////////////////////////////////////

// For each element, the fields correspond to => "label", "id", "value", "type", "pattern", "required", "hidden", "disabled"
// ("value" is always empty here but the field would be needed if we took the infos from a DB)
// pattern => either a predefinied regex or, in case of type="number", a string with the "min" and "max" values separated by a ","
$listeDonneesFormulaire = [
    "nom" =>        ["Nom",                 "nom",          "",     "text",         $patterns["Alpha"],     true,       false,      false],
    "prenom" =>     ["Prénom",              "prenom",       "",     "text",         $patterns["Alpha"],     false,      false,      false],
    "age" =>        ["Âge",                 "age",          "",     "number",       "0,100",                false,      false,      false],
    "telephone" =>  ["Numéro de téléphone", "telephone",    "",     "text",         $patterns["Telephone"], false,      false,      false],
    "cdPostal" =>   ["Code Postal",         "cdPostal",     "",     "number",       "1000,99999",           false,      false,      false],
    "mail" =>       ["Mail",                "mail",         "",     "email",        $patterns["Mail"],      true,       false,      false],
    "password" =>   ["Mot de passe",        "mdp",          "",     "password",     $patternPW,             true,       false,      false],
    "confirmer" =>  ["Confirmation",        "confirmPW",    "",     "password",     $patternPW,             true,       false,      true]
];
//Repeat for clarity:"label",               "id",           "value","type",         "pattern",              "required", "hidden",   "disabled

/////////////////////////////////////////////////////////////////////////
// Start of the HTML page (<head>, Title and opening the <form>)
/////////////////////////////////////////////////////////////////////////

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
    <title>Génération de formulaires</title>
</head>

<body>
    <h1>Génération de formulaires</h1>
        <form action="#" method="post">';

/////////////////////////////////////////////////////////////////////////
// Loop for each of the desired INPUTs
/////////////////////////////////////////////////////////////////////////

foreach ($listeDonneesFormulaire as $ligne => $champ) {
    // each input on its own line, start with the <label>, then the <input> with every fields that will be the same no matter what 
    echo '
            <div class="ligne">
                <label for="' . $champ[ID] . '">' . $champ[LABEL] . '</label>
                <input class="checkValidity" type="' . $champ[TYPE] . '" id="' . $champ[ID] . '" name="' . $champ[ID] . '" value="'.$champ[VALUE].'" ' . (($champ[REQUIRED]) ? 'required ' : '') . (($champ[HIDDEN]) ? 'hidden ' : '') . (($champ[DISABLED]) ? 'disabled ' : '');

                // Depending on the "type", the "pattern" and "title" fields will be differents
                if ($champ[TYPE] == "number") {
                    $minMax = explode(",", $champ[PATTERN]);                                                // if a number, get min and max value
                    $titleNum = "Un nombre compris entre $minMax[0] et $minMax[1]";                         // generate the title and
                    echo ' min=' . $minMax[0] . ' max=' . $minMax[1] . ' title="' . $titleNum . '" />';     // add those 3 fields to the current input
                } elseif ($champ[TYPE] == "password") {
                    // if a password, initialize a pattern and title variable
                    $patPW = "";
                    $titlePW = "";
                    foreach ($champ[PATTERN] as $value) {
                        // fill those with each of the given elements
                        $patPW .= $value[REGEX];
                        $titlePW .= $value[MESSAGE].", ";
                    }
                    $titlePW=substr($titlePW, 0, -2);
                    // and add the fields with the correct values
                    echo ' pattern="' . $patPW . '" title="' . $titlePW . '" />';
                } else {
                    // in any other case, fill those fields directly
                    echo ' pattern="' . $champ[PATTERN][REGEX] . '" title="' . $champ[PATTERN][1] . '" />';
                }
                // We are done with the <input>, now the various messages specific to this particular one

        if ($champ[TYPE] == "password") {
            // If we are dealing with a password, we add the possibility for the user to clearly display
            // the field for a short while (done in JavaScript) => Eye icon to the right of the input
            // Then we add a way to remind the user, again, what the requirement are for the validity of the field
            echo '
                    <div class="mini info">
                        <div class="oeil">
                            <i class="fas fa-eye"></i>
                        </div>
                    </div>
                    <div class="info picto">
                        <i class="far fa-question-circle fa-2x infobulle"></i>
                        <div class="texteInfoBulle">' . $titlePW . '</div>';
            if ($champ[ID] != "confirmPW") {
                // In the case of the 1st itération of the password, add a tool to show what conditions
                // the current value of the input fulfil
                echo '
                            <div class="aideMdp">
                            <div>Liste des critères à respecter</div>';
                    foreach ($champ[PATTERN] as $value) {
                        echo'
                            <div>
                                <div class="mini"><i class="far fa-times-circle rouge"></i>
                                </div>
                                <div class="gauche">'.$value[MESSAGE].'</div>
                            </div>';
                    }
                echo '
                    </div>';   
            }
            // Add a green check or a red cross displaying the validity of the input
            // as well as the text indicating the same
        echo '
                </div>
                <div class="check picto">
                    <i class="far fa-check-circle fa-2x vert"></i>
                </div>
                <div class="message"></div>';
    } else {
        // We do the equivalent for all other cases
        echo '
                <div class="mini"></div>
                <div class="info picto">
                    <i class="far fa-question-circle fa-2x infobulle"></i>
                    <div class="texteInfoBulle">' .(($champ[TYPE] == "number")?$titleNum:$champ[PATTERN][MESSAGE]). '</div>
                </div>
                <div class="check picto">
                    <i class="far fa-check-circle fa-2x vert"></i>
                </div>
                <div class="message"></div>';
    }
    echo '
    
    </div>';
}

/////////////////////////////////////////////////////////////////////////
// End of the HTML page (adding the submit button, closing the <form>,
// linking the script and closing everything else)
/////////////////////////////////////////////////////////////////////////

echo '
        <div class="ligne"><input type="submit"></div>
    </form>
    <script src="./scripts/scripts.js"></script>
</body>

</html>';
