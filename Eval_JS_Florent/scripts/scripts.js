//Contient tous les champs à vérifier identifiés par la class "checkValidity"
inputs = document.getElementsByClassName("checkValidity");

//Récupération du submit, du mot de passe et de la confirmation
var submit = document.querySelector("[type=submit]");
var mdp = document.getElementById("mdp");
var confirmation = document.getElementById("confirmPW");

//Ajoute la vérification de validité au changement de chaque champ
for (let i = 0; i < inputs.length; i++) {
    inputs[i].addEventListener("input", function (event) {
        updateValidity(event.target);
    });
}

//gestion particulière de la confirmation de mot de passe
confirmation.addEventListener("input", function (event) {
    if (confirmation.value == mdp.value) {
        impactValidity(confirmation, true);
    } else {
        impactValidity(confirmation, false);
    }
})

//empecher le copier dans la zone mdp et confirm
mdp.addEventListener("contextmenu", annule);
confirmation.addEventListener("contextmenu", annule);
//empecher le coller dans la confirmation
confirmation.addEventListener("paste", annule);


/**
 * Vérifie la validité de la saisie dans un input et change le style en conséquence
 * @param {élément de type input} input 
 */
function updateValidity(input) {
    isValid = validateInput(input);
    impactValidity(input, isValid);
    checkAllValidity();
}


/**
 * Vérifie la validité de la saisie dans un input
 * Renvoi vrai si la saisie est valide, faux si elle n'est pas valide, 0 si le champ n'est pas rempli
 * @param {élément de type input} input 
 */
function validateInput(input) {
    isValid = input.checkValidity();
    if (!isValid && input.value == "" && input.required) {
        isValid = 0;
    }
    return isValid;
}

/**
 * Affiche le message d'erreur, change les couleurs et affiche les coches
 * @param {élément de type input} input 
 * @param {*} isValid 
 */
function impactValidity(input, isValid) {

    var message = input.parentNode.querySelector(".message");
    message.classList.add("visible");
    
    input.classList.toggle("gaucheVert", isValid);
    input.classList.toggle("gaucheRouge", !isValid);

    switch (isValid) {
        case true:
            message.innerHTML = "Champ valide.";
            

            // si l'on vient de trouver que le mot de passe est bon,
            // on réactive l'input pour sa confirmation
            if (input.id == "mdp") {
                confirmation.disabled = false;
            }
            break;
        case 0:
            message.innerHTML = "Champ requis!";
            break;
        case false:
            if (input.id == "confirmPW") {
                // si on est sur la confirmation du mot de passe
                // la seule erreur possible ici est qu'il n'est pas identique
                message.innerHTML = "Non identique!";
            } else {
                message.innerHTML = "Format invalide!<br />"+input.title;
            }

            // si l'on vient de trouver que le mot de passe n'est pas bon,
            // on désactive et réinitialise l'input de confirmation
            // et les messages associé

            if (input.id == "mdp") {
                confirmation.disabled = true;
                confirmation.value="";
                confirmation.classList.remove("gaucheVert");
                
                confirmation.parentNode.querySelector(".message").classList.remove("visible");
            }

            break;
        default:
            break;
    }
}

/**
 * Activation du bouton de formulaire
 * Vérification de tous les champs
 */
function checkAllValidity() {
    var pasErreur = true;
    i = 0;
    // on vérifie les inputs un à un
    while (pasErreur && i < inputs.length) {
        pasErreur = validateInput(inputs[i])
        i++;
    }
    if (pasErreur) {
        submit.disabled = false;
        submit.value="Valider";
        submit.style.color = "white";
        submit.style.borderBottom = "4px solid white";
    } else {
        submit.disabled = true;
        submit.value="En attente de formulaire complet";
        submit.style.color = "#666666";
        submit.style.borderBottom = "4px solid #666666";
    }
}

/**
 * Change le type de l'input mot de passe
 * que l'utilisateur veut vérifier
 * @param {boolean} flag 
 */
function affichePassWord(flag, id) {
    afficheMDP=document.getElementById(id);
    if (flag) afficheMDP.type = "text";
    else afficheMDP.type = "password";
}

/**
 * Annule l'action associé à la touche ou au clic
 * @param {*} event 
 */
function annule(event) {
    event.preventDefault(); //annule la fonction standard associée à la frappe ou au clic
    return false;
}