grille = document.querySelector(".grid");
zoneCompteur = document.getElementById("compteur");
zoneNbEssai = document.getElementById("nbEssai");
zoneMessage = document.getElementById("message");
nbImages = 8
// carteTest1 = document.querySelector("[data-image='1']")
// carteTest2 = document.querySelector("[data-image='2']")
// // decouvrirCarte(carteTest);
// // setTimeout(function(){retournerCarte(carteTest)},3000);
// console.log(estPair([carteTest1, carteTest2]));

nbClick = 0;
nbPair = 0;
nbEssai = 0;
initPartie();
cartesRetournees = []

function actionClick(event) {
    carte = event.target;
    nbClick++;
    if (nbClick <= 2) {
        decouvrirCarte(carte);
        if (cartesRetournees[0] != carte) { // évite les doubles click sur la même image
            cartesRetournees.push(carte);
            if (nbClick == 2) {
                if (estPair(cartesRetournees)) {
                    // on laisse les cartes affichées
                    // on enlève les listeners
                    cartesRetournees.forEach(elt => {
                        elt.removeEventListener("click", actionClick)
                    });
                    // on vide le tableau
                    cartesRetournees = [];
                    // on augmente le compteur et on s'en sert pour l'afficher
                    zoneCompteur.innerHTML = "nb paire : " + ++nbPair;
                    nbClick = 0;
                    if (nbPair == nbImages)
                        zoneMessage.innerHTML = "Gagné";
                }
                else { // les cartes sont différentes
                    cartesRetournees.forEach(elt => {
                        setTimeout(function () {
                            retournerCarte(elt);
                            nbClick = 0;
                        }, 3000)
                    });
                }
                // on augmente le compteur et on s'en sert pour l'afficher
                zoneNbEssai.innerHTML = "nb Essai : " + ++nbEssai;
            }
        }
    }
    //else 3eme click
}

function initPartie() {

    index = 0;
    tabCartes = [];
    for (let i = 1; i <= nbImages; i++) {
        tabCartes[index] = i;
        index++;
        tabCartes[index] = i;
        index++;
    }
    // on tri le tableau
    // la méthode sort accepte une fonction de comparaison
    // on précise ( oupas) 2 éléments du tableau et on donne une indication sur lequel passe devant l'autre
    // dans notre cas on veut un tri aléatoire. On utilise random
    // pour qu'il y ait autant de chance que a passe devant b, on le compare à 0.5 
    //  tabCartes.sort(() => Math.random() - 0.5)

    afficherCartes(tabCartes);

}

function estPair(cartes) {
    return (cartes[0].getAttribute("data-image") == cartes[1].getAttribute("data-image"))
}

function decouvrirCarte(carte) {
    carte.src = "./Images/" + carte.getAttribute("data-image") + ".jpg"
}

function retournerCarte(carte) {
    carte.src = "./Images/plage.jpg";
    // on retire la carte du tableau des cartes retournées
    cartesRetournees.shift();
}

function afficherCartes(tableau) {
    tableau.forEach(element => {
        img = document.createElement("img");
        img.src = "./Images/plage.jpg";
        img.setAttribute("data-image", element);
        // pour mettre un listener avec une fonction qui a besoin d'argument
        // on crée une fonction anonyme qui appelle notre fonction avec ses arguments
        img.addEventListener("click", actionClick);
        grille.appendChild(img);
    });


}