lesFleches = document.querySelectorAll(".arr");
lesFleches.forEach(arrow => {
    arrow.addEventListener("click", choixJoueur)
});

///////////////////////////////////////////////////
// Pour qu'il arrete de prendre une valeur différente toutes les 5 minutes!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

largeurEnDur=24;
hauteurEnDur=32;

character = document.getElementById("character");
stepSizeW = largeurEnDur / 2;
stepSizeH = hauteurEnDur / 2;
fieldWidth = character.parentNode.scrollWidth;
fieldHeight = character.parentNode.scrollHeight;

function choixJoueur(event) {
    arrowCliked = event.target;                             // Get which arrow was clicked
    direction = arrowCliked.classList[0];                   // Get the first class => direction as a string
    moveCharacter(direction);
    
}

function moveCharacter(directionChoisie) {
    switch (directionChoisie) {
        //////////////////////////////////////////
        // For each directions
        case "up":
            character.src = "./img/charact_up.png";         // change sprite
            stepUp = character.y - hauteurEnDur;        // calcul new position
            if (character.y > stepSizeH) {
                character.style.top = stepUp + "px";        // set value for new position
            }
            break;
        case "down":
            character.src = "./img/charact_down.png";
            stepDown = character.y + stepSizeH;
            if (fieldHeight > (stepDown + hauteurEnDur)) {
                character.style.top = stepDown + "px";
            }
            break;
        case "left":
            character.src = "./img/charact_left.png";
            stepLeft = character.x - largeurEnDur;
            if (character.x > stepSizeW) {
                character.style.left = stepLeft + "px";
            }
            break;
        case "right":
            character.src = "./img/charact_right.png";
            stepRight = character.x + stepSizeW;
            if (fieldWidth > (stepRight + largeurEnDur)) {
                character.style.left = stepRight + "px";
            }
            break;
        default:
            console.log("Erreur de direction!")
            break;
    }
}

document.onkeydown=function gestionTouches(event) {        
    switch (event.key) {
        case "ArrowUp":
            moveCharacter("up");
            break;
        case "ArrowDown":
            moveCharacter("down");
            break;
        case "ArrowLeft":
            moveCharacter("left");
            break;
        case "ArrowRight":
            moveCharacter("right");
            break;

        default:
            break;
    }
}