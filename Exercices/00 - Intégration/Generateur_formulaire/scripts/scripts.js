//Contient tous les champs à vérifier  identifiés par la class "checkValidity"
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

// affichage de l'aide à la saisie du mot de passe 
// c'est la 2eme fois que l'on pose un listener sur input de mot de passe, les 2 fonctions vont s'executer l'une derrière l'autre 
mdp.addEventListener("input", function (event) {
    let aideMdp = document.getElementsByClassName("aideMdp")[0];
    aideMdp.classList.add("displayFlex");
    aideMdp.classList.remove("noDisplay");
    let lesImages = aideMdp.getElementsByTagName("i");
    let lesCheck = ["(?=.*[a-z])", "(?=.*[A-Z])", "(?=.*[0-9])", "(?=.*[\\W_])", "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\\W_]).{8,}"];
    for (let i = 0; i < lesCheck.length; i++) {
        if (RegExp(lesCheck[i]).test(mdp.value)) {
            //la condition est vérifiée, on met la coche verte correspondente
            lesImages[i].classList = "far fa-check-circle vert";
        } else {
            lesImages[i].classList = "far fa-times-circle rouge";
        }
    }
})

//suppression de l'aide mot de passe quand on quitte le champ
mdp.addEventListener("blur", function (event) {
    let aideMdp = document.getElementsByClassName("aideMdp")[0];
    aideMdp.classList.remove("displayFlex");
    aideMdp.classList.add("noDisplay");
})

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

//gestion de l'oeil dans le mot de passe
var yeux=document.querySelectorAll(".oeil");
yeux.forEach(oeil => {
    // on affiche un petit oeil qui permet de voir de mot de passe 
    oeil.addEventListener("mousedown", function (event) {
        affichePassWord(true,event.target.parentNode.parentNode.previousElementSibling.id);
    });
    oeil.addEventListener("mouseup", function (event) {
        affichePassWord(false,event.target.parentNode.parentNode.previousElementSibling.id);
    });
});

/**
 * Gestion des infobulles
 * On récupère l'information dans le title de l'input et on l'affiche au dessus de l'interface
 */
infobulles = document.getElementsByClassName("infobulle");
for (let i = 0; i < infobulles.length; i++) {
    infobulles[i].addEventListener("mouseover", function (e) {
        var parent = e.target.parentNode.parentNode;
        var texteInfoBulle = parent.getElementsByClassName("texteInfoBulle")[0];

        // Géré par le PHP ici

        // var texte = (parent.getElementsByTagName("input")[0]).title;
        // texteInfoBulle.textContent = texte;

        texteInfoBulle.classList.remove("noDisplay");
        texteInfoBulle.classList.add("displayFlex");
    });
    infobulles[i].addEventListener("mouseout", function (e) {
        (e.target.parentNode.getElementsByClassName("texteInfoBulle")[0]).classList.remove("displayFlex");
        (e.target.parentNode.getElementsByClassName("texteInfoBulle")[0]).classList.add("noDisplay");
    });
}


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

    var message = input.parentNode.getElementsByClassName("message")[0];
    message.classList.add("visible");
    if (input.type == "password") {
        // Si password, index 0 correspond à l'oeil
        image = input.parentNode.getElementsByTagName("i")[1];
    } else {
        image = input.parentNode.getElementsByTagName("i")[0];
    }

    image.parentNode.classList.toggle("check", isValid != 0);
    input.classList.toggle("basVert", isValid);
    input.classList.toggle("basRouge", !isValid);

    switch (isValid) {
        case true:
            message.innerHTML = "Champ valide.";
            image.classList = "far fa-check-circle fa-2x vert";

            image.classList.add("displayBlock");
            image.classList.remove("noDisplay");

            image.parentNode.classList.toggle("check", !isValid);

            // si l'on vient de trouver que le mot de passe est bon,
            // on réactive l'input pour sa confirmation
            if (input.id == "mdp") {
                confirmation.disabled = false;
            }
            break;
        case 0:
            message.innerHTML = "Champ requis!";
            image.classList.remove("displayBlock");
            image.classList.add("noDisplay");
            break;
        case false:
            if (input.id == "confirmPW") {
                // si on est sur la confirmation du mot de passe
                // la seule erreur possible ici est qu'il n'est pas identique
                message.innerHTML = "Non identique!";
            } else {
                message.innerHTML = "Format invalide!";
            }
            image.classList = "far fa-times-circle fa-2x rouge";

            image.classList.add("displayBlock");
            image.classList.remove("noDisplay");

            image.parentNode.classList.toggle("check", isValid);

            // si l'on vient de trouver que le mot de passe n'est pas bon,
            // on désactive et réinitialise l'input de confirmation
            // et les messages associé

            if (input.id == "mdp") {
                confirmation.disabled = true;
                confirmation.value="";
                confirmation.classList.remove("basVert");
                confirmation.parentNode.querySelectorAll("i")[1].classList="far fa-question-circle fa-2x infobulle";
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
        submit.style.color = "white";
        submit.style.borderBottom = "4px solid white";
    } else {
        submit.disabled = true;
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