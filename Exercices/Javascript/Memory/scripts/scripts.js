cartes = [1, 2, 3, 4, 5, 6, 7, 8];
back = "plage";
deck = cartes.concat(cartes);
plateau = document.querySelector("div");
timeout = 1;
carteSelected = [];
nbreClick=0;
comptCartes = 0;
nbreJoueur = 0;
ptsJoueur=[];



//////////////////////////////////////////
// Afficher cartes
deckMelange = shuffle(deck);
deckMelange.forEach(carte => {
    let newImg = document.createElement("img");
    newImg.classList.add("carte");
    newImg.src = "./img/" + back + ".jpg";
    newImg.setAttribute("data-image", carte);
    newImg.addEventListener('click', retournerCarte);
    plateau.appendChild(newImg);
    comptCartes++;
});
partie();

//////////////////////////////////////////
// Fisher-Yates (aka Knuth) Shuffle
// Used to shuffle the deck
//
// Mélanger les cartes
function shuffle(array) {
    let currentIndex = array.length, randomIndex;

    // While there remain elements to shuffle.
    while (currentIndex != 0) {

        // Pick a remaining element.
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;

        // And swap it with the current element.
        [array[currentIndex], array[randomIndex]] = [
            array[randomIndex], array[currentIndex]];
    }

    return array;
}


function masquerCartes(params, timer) {
    params.forEach(carteARetourner => {
        setTimeout(() => {
            masquer(carteARetourner);
        }, timer * 1000);

    });
}
/**
 * fonction "cachant" à nouveau la carte passé en paramètre
 * @param {Node} params 
 */
function masquer(params) {
    params.src = "./img/" + back + ".jpg";
    console.info(params);
}

/**
 * 
 * @param {event} event
 */
function retournerCarte(event) {
    carte = event.target;
    carte.src = "./img/" + carte.getAttribute("data-image") + ".jpg";
    carteSelected[nbreClick] = carte;
    nbreClick++;
}

function verifPair() {
    if (carteSelected[0].getAttribute("data-image") != carteSelected[1].getAttribute("data-image")) {
        masquerCartes(carteSelected, timeout);
        cmptTour++;
        alert("Joueur suivant.");
        return false;
    }
    else {
        comptCartes -= 2;
        ptsJoueur[joueurActu]++;
        carteSelected.forEach(carteSel => {
            carteSel.removeEventListener("click", retournerCarte);
        });
        alert("Joueur "+(joueurActu+1)+" peut jouer à nouveau.");
        return true;
    }
}

function tour() {
    nbreClick = 0;
    peutJouer = true;
    while (peutJouer) {
        if (nbreClick == 2) {
            if (comptCartes != 0) {
                peutJouer = verifPair();
                nbreClick = 0;
            } 
            ///////////////////////
            // Maybe redondant?
            else {
                peutJouer = false;
            }
            //////////////////////
        }
    }
    joueurActu++;
    if (joueurActu > nbreJoueur) {
        joueurActu = 0;
    }
}

function partie() {
    nbreJoueur = getNbreJoueur();
    joueurActu = 0;
    while (comptCartes != 0) {
        tour();
    }
    afficherResult();

}

function getNbreJoueur() {
    while (isNaN(nbreJoueur) || nbreJoueur < 2 || nbreJoueur > 4) {
        nbreJoueur = prompt("Combien de joueurs?");
    }
}

function afficherResult() {
    plusDePts=Math.max(ptsJoueur);
    listeMaxPts=[];
    for (let index = 0; index < ptsJoueur.length; index++) {
        if(ptsJoueur[index]==plusDePts){
            listeMaxPts.push(index);
        }
    }
    if (listeMaxPts.length==1) {
        alert("Le joueur "+(listeMaxPts[0]+1)+" a gagné avec un total de "+plusDePts+" points.");
    }
    else{
        message="Les joueurs ";
        listeMaxPts.forEach(joueurG => {
            message+=joueurG+", ";
        });
        message.slice(0,-2);
        message+=" sont à égalité avec un score de "+plusDePts+" points.";
        alert(message);
    }
}