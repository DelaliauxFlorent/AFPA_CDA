lesFleches = document.querySelectorAll(".arr");
lesFleches.forEach(arrow => {
    arrow.addEventListener("click", moveCharacter)
});
character = document.getElementById("character");
stepSizeW = character.width / 2;
stepSizeH = character.height / 2;
fieldWidth = character.parentNode.scrollWidth;
fieldHeight = character.parentNode.scrollHeight;

function moveCharacter(event) {   
    arrowCliked = event.target;                             // Get which arrow was clicked
    direction = arrowCliked.classList[0];                   // Get the first class => direction as a string

    switch (direction) {
        //////////////////////////////////////////
        // For each directions
        case "up":
            character.src = "./img/charact_up.png";         // change sprite
            stepUp = character.y - character.height;        // calcul new position
            if (character.y> stepSizeH) {
                character.style.top = stepUp + "px";        // set value for new position
            }
            break;
        case "down":
            character.src = "./img/charact_down.png";
            stepDown = character.y + stepSizeH;
            if (fieldHeight > (stepDown + character.height)) {
                character.style.top = stepDown + "px";
            }
            break;
        case "left":
            character.src = "./img/charact_left.png";
            stepLeft = character.x - (2 * stepSizeW);
            if (character.x > stepSizeW) {
                character.style.left = stepLeft + "px";
            }
            break;
        case "right":
            character.src = "./img/charact_right.png";
            stepRight = character.x + stepSizeW;
            if (fieldWidth > (stepRight + stepSizeW)) {
                character.style.left = stepRight + "px";
            }
            break;
        default:
            console.log("Erreur de direction!")
            break;
    }
}
