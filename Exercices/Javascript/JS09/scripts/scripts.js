lesFleches = document.querySelectorAll(".arr");
lesFleches.forEach(arrow => {
    arrow.addEventListener("click", choixJoueur)
});

///////////////////////////////////////////////////
// Pour qu'il arrete de prendre une valeur différente toutes les 5 minutes!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

largeurEnDur = 24;
hauteurEnDur = 32;

character = document.getElementById("character");
stepSizeW = largeurEnDur / 2;
stepSizeH = hauteurEnDur / 2;
fieldWidth = character.parentNode.scrollWidth;
fieldHeight = character.parentNode.scrollHeight;

isDown = false;         // gestion onMouseDown
var mousePosition;      // erreur "undefinied" si on met pas le "var"
offset = [0,0];

///////////////////////////////////////////////////
// Gestion "Graphique"
function choixJoueur(event) {
    arrowCliked = event.target;                             // Get which arrow was clicked
    direction = arrowCliked.classList[0];                   // Get the first class => direction as a string
    moveCharacter(direction);

}

///////////////////////////////////////////////////
// Mouvement du personnage
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

///////////////////////////////////////////////////
// Gestion "Clavier"
document.onkeydown = function gestionTouches(event) {
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

///////////////////////////////////////////////////
// Gestion "Souris"
character.addEventListener("mousedown", function (e) {
    isDown = true;

    //empèche le déclenchement du comportement par défaut de l'event
    //si absent=> besoin de "mouseDown=>mousemove=>mouseup" pour bouger personnage puis un click pour le lacher
    e.preventDefault();
    
    //Get position on the sprite (so we don't default to top left)
    offset = [
        character.offsetLeft - e.clientX,
        character.offsetTop - e.clientY
    ];
});

document.addEventListener('mouseup', function () {
    isDown = false;
});

document.addEventListener('mousemove', function (event) {
    event.preventDefault();
    if (isDown) {
        // get mouse position
        mousePosition = {
            x: event.clientX,
            y: event.clientY
        };

        //edit sprite position as to be "current mouse position" relative to "specific position on sprite"
        character.style.left = (mousePosition.x + offset[0]) + 'px';
        character.style.top = (mousePosition.y + offset[1]) + 'px';
    }
});