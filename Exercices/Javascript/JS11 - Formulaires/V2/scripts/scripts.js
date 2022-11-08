/////////////////////////////////////////
// Fait la liste de tous les inputs sauf le bouton "submit"
// => ajout d'un eventListener sur chaque pour vérifier les saisies
listInputs = document.querySelectorAll('[data-type]');
listInputs.forEach(element => {
    element.addEventListener("blur", verifInput);
});


/**
 * Fonction vérifiant que ce qui est entré dans les Inputs correspond bien aux patterns définis
 * @param {*} event 
 */
function verifInput(event) {
    element = event.target;
    typeElem = element.getAttribute("data-type");       // Récupère le type d'Input
    erreur = false;

    if (typeElem == "cdPost") {                         // codage du pattern pour le code postal en dur du fait de l'absence d'un attribut pattern pour les inputs de type "number"
        regexString = "\\d{5}";
    }
    else {
        regexString = element.getAttribute("pattern")   // dans les autres cas, on utilise le pattern déjà fournit
    }
    regexActu = new RegExp(`\^${regexString}\$`, "u");  // on crée le regex à partir des patterns

    //console.info(regexActu);

    if (!element.value.match(regexActu)) {              // s'il n'y a pas de correspondance
        element.value = "";                             // on réinitialise l'input
        gestionErreur(typeElem);                        // et on affiche le message d'erreur correspondant
        erreur = true;
    }
    else {
        // si l'entrée est bonne, on ne fait que supprimer le message d'erreur correspondant au cas où il existe
        erreur = false;
        vidageMessageErreur = document.querySelector('[data-message="'+typeElem+'"]');
        vidageMessageErreur.innerHTML="";        
        resetInputClass=document.querySelector('[data-type="'+typeElem+'"]');
        resetInputClass.classList.remove("erreur");
    }

    verifSubmit(erreur);
}

function gestionErreur(typeInput) {
    messageFlash=document.querySelector('[data-message="'+typeInput+'"]');
    inputFlash=document.querySelector('[data-type="'+typeInput+'"]');

    // En fonction du type de donnée sur laquelle l'erreur a été faite
    // on affiche le message correspondant en dessous de l'input conserné

    switch (typeInput) {
        case "nom":
            messageFlash.innerHTML= "Un nom peut avoir des espaces ou des tirets mais ne dois sinon comporter que des lettres.";
            break;
        case "telephone":
            messageFlash.innerHTML= "Un numéro de téléphone doit être une suite de chiffres de la forme 0X&nbsp;XX&nbsp;XX&nbsp;XX&nbsp;XX ou +33X&nbsp;XX&nbsp;XX&nbsp;XX&nbsp;XX (les espaces pouvant être remplacés par des points ou même enlevés).";
            break;
        case "cdPost":
            messageFlash.innerHTML= "Un code postal doit être une suite de 5 chiffres.";
            break;
        case "mail":
            messageFlash.innerHTML= "Une adresse mail est formé d'une suite de caractères (séparé ou non par un point), d'un arobase puis d'une autre suite de caractère et se termine par un '.xxx' (où xxx est une suite de 2 à 5 caractères).";
            break;
        case "mdp":
            messageFlash.innerHTML= "Un mot de passe doit mesurer au moins 8 caractères et comporter au moins une lettre minuscule, une lettre majuscule, un chiffre et un caractère spécial (+-*/%...).";
            break;
        default:
            break;
    }
    
    // et on change l'apparence de l'input en question pour attirer l'oeil de l'utilisateur
    inputFlash.classList.add("erreur");
}

function verifSubmit(erreurExt) {
    peutEnvoyer = true;
    listInputs.forEach(element => {
        peutEnvoyer &= element.value != "";
    });

    // si tous les champs sont rempli (possibilité de check seulement ceux avec attribut "required")
    // et qu'aucune erreur n'est détecter lors des saisies

    if (peutEnvoyer && !erreurExt) {
        document.getElementById("envoyer").disabled = false;        // on réactive le bouton submit
    }
    else {
        document.getElementById("envoyer").disabled = true;
    }
}