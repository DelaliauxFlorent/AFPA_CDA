function deplace(dleft, dtop) {
    // permet de deplacer le calque selon 2 directions left et top
    //on recupere le carré rouge
    var calque = document.getElementById('carre');
    //on recupere son style (tout le CSS)
    var styleCalque = window.getComputedStyle(calque, null);
    //on recupere les positions left et top actuelles
    var topActuel = styleCalque.top;
    var leftActuel = styleCalque.left;
    //on modifie les positions let et top actuelles
    calque.style.top = parseInt(topActuel) + dtop + 'px';
    calque.style.left = parseInt(leftActuel) + dleft + 'px';
}

document.addEventListener("keydown",function(event) {
    var event = event || window.event, // pour la compatibilite avec tous les navigateurs
        keyCode = event.keyCode;
    // On détecte l'événement puis selon la fleche, on appelle deplace
    switch (keyCode) {
        case 38:
            deplace(0, -5);
            break;
        case 40:
            deplace(0, 5);
            break;
        case 37:
            deplace(-5, 0);
            break;
        case 39:
            deplace(5, 0);
            break;
    }
});