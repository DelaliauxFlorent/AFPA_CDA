
listInputs = document.querySelectorAll('[data-type]');
listInputs.forEach(element => {
    element.addEventListener("blur", verifInput);
});

function verifInput(event) {
    element = event.target;
    typeElem = element.getAttribute("data-type");
    erreur = false;

    regexNom = /^[\p{L}\s\-]{1,}$/u;
    regexPhone = /^[0|+33]\d((\.| )?\d{2}){4}$/;
    regexMail = /^\w+([\.-_]?\w+)*@\w+([\.-_]?\w+)*\.\w{2,5}$/;
    regexCdPost = /^\d{5}$/;
    regexPassW = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{8,}$/;

    ///////////////////////

    switch (typeElem) {
        case "nom":
            if (!element.value.match(regexNom)) {
                element.value = "";
                gestionErreur(element);
                erreur = true;
            }
            else {
                erreur = false;
            }
            break;
        case "telephone":
            if (!element.value.match(regexPhone)) {
                element.value = "";
                gestionErreur(element);
                erreur = true;
            }
            else {
                erreur = false;
            }
            break;
        case "mail":
            if (!element.value.match(regexMail)) {
                element.value = "";
                gestionErreur(element);
                erreur = true;
            }
            else {
                erreur = false;
            }
            break;
        case "cdPost":
            if (!element.value.match(regexCdPost)) {
                element.value = "";
                gestionErreur(element);
                erreur = true;
            }
            else {
                erreur = false;
            }
            break;
        case "mdp":
            if (!element.value.match(regexPassW)) {
                element.value = "";
                gestionErreur(element);
                erreur = true;
            }
            else {
                erreur = false;
            }
            break;
        default:
            break;
    }
    verifSubmit();
}

function gestionErreur(params) {
    alert("Erreur de saisie!");
    ///////////////////////////////////////////////////
    // Look up how to make it work
    console.info(params);
    params.focus();
}

function verifSubmit(event) {
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