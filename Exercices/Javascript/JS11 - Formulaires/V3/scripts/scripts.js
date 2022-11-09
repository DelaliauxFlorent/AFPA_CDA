/////////////////////////////////////////
// Fait la liste de tous les inputs sauf le bouton "submit"
// => ajout d'un eventListener sur chaque pour vérifier les saisies
listInputs = document.querySelectorAll('[data-type]');
listInputs.forEach(element => {
    element.addEventListener("input", verifInput);
    element.addEventListener("blur", verifSubmit);
});
erreur = [];
entreeRequises=document.querySelectorAll("[required]");
console.info(entreeRequises);
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
        vidageMessageErreur = document.querySelector('[data-message="' + typeElem + '"]');
        vidageMessageErreur.innerHTML = "";
        // resetInputClass = document.querySelector('[data-type="' + typeElem + '"]');
        // resetInputClass.classList.remove("erreur");
    }
}

function gestionErreur(elemActu, typeInput) {
    messageFlash = document.querySelector('[data-message="' + typeInput + '"]');
    //inputFlash = document.querySelector('[data-type="' + typeInput + '"]');

    // En fonction du type de donnée sur laquelle l'erreur a été faite
    // on affiche le message correspondant en dessous de l'input conserné
    messageFlash.innerHTML = element.getAttribute("title");
    switch (typeInput) {
        case "nom":
            messageFlash.innerHTML = element.getAttribute("title");
            break;
        case "telephone":
            messageFlash.innerHTML = "Un numéro de téléphone doit être une suite de chiffres de la forme 0X&nbsp;XX&nbsp;XX&nbsp;XX&nbsp;XX ou +33X&nbsp;XX&nbsp;XX&nbsp;XX&nbsp;XX (les espaces pouvant être remplacés par des points ou même enlevés).";
            break;
        case "cdPost":
            messageFlash.innerHTML = "Un code postal doit être une suite de 5 chiffres.";
            break;
        case "mail":
            messageFlash.innerHTML = "Une adresse mail est formé d'une suite de caractères (séparé ou non par un point), d'un arobase puis d'une autre suite de caractère et se termine par un '.xxx' (où xxx est une suite de 2 à 5 caractères).";
            break;
        case "mdp":
            messageFlash.innerHTML = "Un mot de passe doit mesurer au moins 8 caractères et comporter au moins une lettre minuscule, une lettre majuscule, un chiffre et un caractère spécial (+-*/%...).";
            break;
        default:
            break;
    }

    // et on change l'apparence de l'input en question pour attirer l'oeil de l'utilisateur
    //inputFlash.classList.add("erreur");
}

function verifSubmit() {
    peutEnvoyer = true;
    entreeRequises.forEach(element => {
        peutEnvoyer &= element.value != "";
    });
    messageGen="Vous avez des erreurs dans le(s) champ(s) ";
    msgErreurGen=document.querySelector(".span5");
    if(erreur.isArray && erreur.lenght>0){
        erreur.forEach(elementErreur => {
            messageGen+=elementErreur.labels[0].innerHTML+", ";
            console.info(elementErreur);
        });
        messageGen=messageGen.slice(0, -2)+".";
        msgErreurGen.innerHTML=messageGen;
    }

    console.info(erreur);

    // si tous les champs sont rempli (possibilité de check seulement ceux avec attribut "required")
    // et qu'aucune erreur n'est détecter lors des saisies

    if (peutEnvoyer && !erreur.lenght>0) {
        document.getElementById("envoyer").disabled = false;        // on réactive le bouton submit
    }
    else {
        document.getElementById("envoyer").disabled = true;
    }
}

function infoBulle() {
    infoBulle=document.querySelectorAll(".info");
    infoBulle.forEach(element => {
        element.setAttribute("title",element.previousElementSibling.previousElementSibling.getAttribute("title"));
    });
}