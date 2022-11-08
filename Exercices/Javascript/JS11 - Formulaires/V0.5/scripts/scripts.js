listInputs = document.querySelectorAll('[data-type]');
listInputs.forEach(element => {
    element.addEventListener("blur", verifInput);
});

function verifInput(event) {
    element = event.target;
    typeElem = element.getAttribute("data-type");
    erreur = false;

    ///////////////////////

    switch (typeElem) {
        case "telephone":

            tel = element.value.replaceAll(".", "");
            tel = tel.replaceAll(" ", "");

            if (isNaN(tel) || parseInt(tel) < 100000000 || parseInt(tel) > 999999999) {
                element.value = "";
                gestionErreur(element);
                erreur = true;
            }
            else {
                erreur = false;
            }
            break;
        case "mail":
            testArrob = element.value.split("@");
            //console.info(testArrob);
            if (testArrob.length == 2) {                        // Vérif la présence d'un et dd'unseul "@"
                testPointMail = testArrob[1].split(".");
                if (testPointMail.length >= 2) {                // Vérif la présence d'un moins un "."
                    erreur = false;
                } else {
                    element.value = "";
                    gestionErreur(element);
                    erreur = true;
                }

            } else {
                element.value = "";
                gestionErreur(element);
                erreur = true;
            }
            break;
        case "cdPost":
            console.log(isNaN(element.value));
            if (isNaN(element.value) || parseInt(element.value) < 0 || parseInt(element.value) > 99999) {
                element.value = "";
                gestionErreur(element);
                erreur = true;
            }
            else {
                erreur = false;
            }
            break;
        // case "mdp":
        //     if (!element.value.match(regexPassW)) {
        //         element.value = "";
        //         erreur=true;
        //     }
        //     else{
        //         erreur=false;
        //     }
        //     break;
        default:
            break;
    }
    verifSubmit();
}

function gestionErreur(params) {
    alert("Erreur de saisie!");
    ///////////////////////////////////////////////////
    // Look up how to make it work
    //console.info(params);
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