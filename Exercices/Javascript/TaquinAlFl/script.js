grille = document.querySelector(".grid3");
cpt = document.querySelector(".compteur");
nbCol = 3;
compteur = 0;
resultat = [];

for (let index = 1; index < 9; index++) {
  resultat[index - 1] = index;
}
resultat[8] = "";

creerTaquin();

function creerTaquin() {
  compteur = 0;
  taquin = [].concat(resultat);
  taquin.sort(() => Math.random() - 0.5);
  taquin.forEach((element) => {
    newCase = document.createElement("div");
    newCase.innerHTML = element;

    newCase.classList.add("cellule");
    if (element != "") {
      newCase.addEventListener("click", deplaceCase);
      //   console.log(element);
    }
    else{
      newCase.classList.add("vide");
    }

    grille.appendChild(newCase);
  });
}

function deplaceCase(e) {
  celluleChoisie = e.target;
  // console.info(celluleChoisie);
  // console.log(procheVide(celluleChoisie));
  if (procheVide(celluleChoisie)) {
    indCelluleVide = taquin.indexOf(""); // Index de la cellule vide
    ancCelVide = grille.querySelectorAll(".cellule")[indCelluleVide]; // Sélection de la celulle vide via son index
    indCelClick = taquin.indexOf(parseInt(celluleChoisie.innerHTML)); // Index de la cellule cliquée
    // console.info(indCelluleVide);
    // console.log(indCelClick);

    // Inversion des valeurs dans le tableau
    taquin[indCelluleVide] = parseInt(celluleChoisie.innerHTML);
    taquin[indCelClick] = "";
    // console.log(taquin);

    // Inversion des valeurs à l'affichage
    ancCelVide.innerHTML = parseInt(celluleChoisie.innerHTML);
    ancCelVide.classList.remove("vide");
    celluleChoisie.innerHTML = "";
    celluleChoisie.classList.add("vide");

    // Ajout/retrait des EventListener
    celluleChoisie.removeEventListener("click", deplaceCase);
    ancCelVide.addEventListener("click", deplaceCase);

    // Mise à jour du compteur de coups
    compteur++;
    cpt.innerHTML = compteur;
  }
  if (estGagne()) {
    // Si partie gagnée
    finPartie();
  }
}

// Retourne true si le déplacement de la cellule est possible
function procheVide(cellule) {
  indexCel = taquin.indexOf(parseInt(cellule.innerHTML));

  moveUp = indexCel - nbCol;
  moveDown = indexCel + nbCol;
  moveLeft = indexCel - 1;
  moveRight = indexCel + 1;

  return (
    (taquin[moveDown] == "" && indexCel < taquin.length - nbCol && moveDown >= 0 && moveDown < taquin.length) ||
    (taquin[moveUp] == "" && indexCel >= nbCol && moveUp >= 0 && moveUp < taquin.length) ||
    (taquin[moveLeft] == "" && indexCel % nbCol != 0 && moveLeft >= 0 && moveLeft < taquin.length) ||
    (taquin[moveRight] == "" && indexCel % nbCol != 2 && moveRight >= 0 && moveRight < taquin.length)
  );
}

function estGagne() {
  if (taquin.length == resultat.length) {
    return taquin.every((value, index) => value === resultat[index]);
  }
  return false;
}

function finPartie() {
  listeCel = grille.querySelectorAll(".cellule"); // Sélection de toutes les cellules

  // Retrait des EventListener pour chaque cellule
  listeCel.forEach((element) => {
    element.removeEventListener("click", deplaceCase);
  });
}
