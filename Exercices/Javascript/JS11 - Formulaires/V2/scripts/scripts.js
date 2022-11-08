
listInputs = document.querySelectorAll('[data-type]');
listInputs.forEach(element => {
    element.addEventListener("blur", verifInput);
});

function verifInput(event) {
    element = event.target;
    typeElem = element.getAttribute("data-type");
    erreur = false;

    if (typeElem == "cdPost") {
        regexString = "\\d{5}";
    }
    else {
        regexString = element.getAttribute("pattern")
    }
    regexActu = new RegExp(`\^${regexString}\$`, "u");

    console.info(regexActu);

    if (!element.value.match(regexActu)) {
        element.value = "";
        gestionErreur(element, typeElem);
        erreur = true;
    }
    else {
        erreur = false;
    }

    verifSubmit();
}

function gestionErreur(params, typeInput) {
    messageErreur = "Erreur de saisie!\n"

    switch (typeInput) {
        case "nom":
            messageErreur += "Un nom peut avoir des espaces ou des tirets mais ne dois sinon comporter que des lettres.";
            break;
        case "telephone":
            messageErreur += "Un numéro de téléphone doit être une suite de chiffres de la forme 0X XX XX XX XX ou +33X XX XX XX XX (les espaces pouvant être remplacés par des points ou même enlevés).";
            break;
        case "cdPostal":
            messageErreur += "Un code postal doit être une suite de 5 chiffres.";
            break;
        case "mail":
            messageErreur += "Un code postal doit être une suite de 5 chiffres.";
            break;
        default:
            break;
    }
    alert(messageErreur);

    ///////////////////////////////////////////////////
    // Look up how to make it work
    console.info(params);
    params.focus();
}

function verifSubmit() {
    peutEnvoyer = true;
    listInputs.forEach(element => {
        peutEnvoyer &= element.value != "";
    });
    if (peutEnvoyer && !erreur) {
        document.getElementById("envoyer").disabled = false;
    }
    else {
        document.getElementById("envoyer").disabled = true;
    }
}