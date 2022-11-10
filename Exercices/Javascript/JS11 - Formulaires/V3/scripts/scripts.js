/////////////////////////////////////////
// Fait la liste de tous les inputs sauf le bouton "submit"
// => ajout d'un eventListener sur chaque pour vérifier les saisies
listInputs = document.querySelectorAll('[data-type]');
listInputs.forEach(element => {
    element.addEventListener("input", verifInput);
    element.addEventListener("blur", verifSubmit);
});
entreeRequises = document.querySelectorAll("[required]");
oeilPassword = document.querySelector(".afficherMDP");
oeilPassword.addEventListener("mouseover", switchTypeMDP);
oeilPassword.addEventListener("mouseleave", switchTypeMDP);
var erreur = new Array;
affErreurMDP = false;

infoBulle();


/**
 * Fonction vérifiant que ce qui est entré dans les Inputs correspond bien aux patterns définis
 * @param {*} event 
 */
function verifInput(event) {
    element = event.target;
    typeElem = element.getAttribute("data-type");       // Récupère le type d'Input    

    if (!element.checkValidity()) {                     // si l'entrée n'est pas valide

        gestionErreur(element, typeElem);                        // et on affiche le message d'erreur correspondant

        if (!erreur.includes(element)) {
            erreur.push(element);
        }

    }
    else {
        // si l'entrée est bonne, on ne fait que supprimer le message d'erreur correspondant au cas où il existe
        if (erreur.indexOf(element) != "-1") {
            erreur.splice(erreur.indexOf(element), 1)
        }
        if(typeElem=="mdp"){
            affErreurMDP=false;
        }
        vidageMessageErreur = document.querySelector('[data-message="' + typeElem + '"]');
        vidageMessageErreur.innerHTML = "";
        // resetInputClass = document.querySelector('[data-type="' + typeElem + '"]');
        // resetInputClass.classList.remove("erreur");
    }
}

function gestionErreur(elemActu, typeInput) {
    messageFlash = document.querySelector('[data-message="' + typeInput + '"]');

    // En fonction du type de donnée sur laquelle l'erreur a été faite
    // on affiche le message correspondant en dessous de l'input conserné
    
    if (typeInput == "mdp") {
        patternMin = new RegExp("[a-z]");
        patternMaj = new RegExp("[A-Z]");
        patternChi = new RegExp("[0-9]");
        patternSpe = new RegExp("[\\W_]");
        patternNbr = new RegExp(".{8,}");

        console.log("Caractères spéciaux => "+patternSpe.test(elemActu.value));
        console.log(elemActu.value);


        presence = [patternMin.test(elemActu.value), patternMaj.test(elemActu.value), patternChi.test(elemActu.value), patternSpe.test(elemActu.value), patternNbr.test(elemActu.value)];
        presenceNom = ["- 1 minuscule", "- 1 Majuscule", "- 1 Chiffre", "- 1 Caractère spéciale (+-*/%@...)", "- Au moins 8 caractères"];
        if (!affErreurMDP) {
            for (let index = 0; index < presence.length; index++) {
                const presenceActu = presence[index];
                newDiv = document.createElement("div");
                newDiv.innerHTML = presenceNom[index];
                if(presenceActu){
                    newDiv.classList.add("okMDP");
                }
                messageFlash.appendChild(newDiv);
            }
            affErreurMDP=true;
        }else{
            listeDivMDP=messageFlash.querySelectorAll("div");
            let indexListeDiv=0;console.info(listeDivMDP);
            listeDivMDP.forEach(element => {
                element.classList.toggle("okMDP", presence[indexListeDiv]);
                indexListeDiv++;
            });
        }
    } else {
        messageFlash.innerHTML = elemActu.getAttribute("title");
    }

}

function verifSubmit() {
    peutEnvoyer = true;
    entreeRequises.forEach(element => {
        peutEnvoyer &= element.value != "";
    });
    messageGen = "Vous avez des erreurs dans le(s) champ(s) ";
    msgErreurGen = document.querySelector(".span5");

    if (Array.isArray(erreur) && erreur.length > 0) {
        erreur.forEach(elementErreur => {
            messageGen += elementErreur.labels[0].innerHTML + ", ";
            //console.info(elementErreur);
        });
        messageGen = messageGen.slice(0, -2) + ".";
        msgErreurGen.innerHTML = messageGen;
    } else {
        msgErreurGen.innerHTML = "";
    }

    // si tous les champs sont rempli (possibilité de check seulement ceux avec attribut "required")
    // et qu'aucune erreur n'est détecter lors des saisies
    if (peutEnvoyer && Array.isArray(erreur) && (erreur.length < 1)) {
        document.getElementById("envoyer").disabled = false;        // on réactive le bouton submit
    }
    else {
        document.getElementById("envoyer").disabled = true;
    }
}

function infoBulle() {
    infoBulle = document.querySelectorAll(".info");
    infoBulle.forEach(element => {
        element.setAttribute("title", element.previousElementSibling.previousElementSibling.getAttribute("title"));
    });
}

function switchTypeMDP() {
    inputMDP = document.querySelector("[data-type='mdp']");
    console.info(inputMDP);
    if (inputMDP.getAttribute("type") == "text") {
        inputMDP.setAttribute("type", "password");
    } else {
        inputMDP.setAttribute("type", "text");
    }
}