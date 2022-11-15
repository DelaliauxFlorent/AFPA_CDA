lesFleches = document.querySelectorAll(".arr");
lesFleches.forEach(arrow => {
    arrow.addEventListener("click", choixJoueur)
});

lesObstacles = document.querySelectorAll(".blocage");

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
offset = [0, 0];         //initialiser les offsets pour déplacement par mousemove

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

            // Call checkMove only once and get
            //  if something other than the top of the screen block the character
            //  if true, get the node to let the character go up only up to that object
            let tempUp = checkMove("up");
            isblockedUp = tempUp[0];
            blockedUpBy = tempUp[1];

            //      Generic case: not near the top nor is there an obstacle in the way
            if ((character.y > stepSizeH) && !isblockedUp) {
                character.style.top = stepUp + "px";        // set value for new position
            }//     if too near the top, set Y to -10px (so the top of the hat is flush with top of field)
            else if (character.y <= stepSizeH) {         // Remember "ELSE IF", not "ELSEIF" like in PHP
                character.style.top = "-10px";
            }//     if object in the way, get flush to it
            else if (isblockedUp) {
                // console.log("isblockedUp");
                character.style.top = (blockedUpBy.y + blockedUpBy.height - 10) + "px";
            }
            break;
        case "down":
            character.src = "./img/charact_down.png";
            stepDown = character.y + stepSizeH;

            let tempDown = checkMove("down");
            isblockedDown = tempDown[0];
            blockedDownBy = tempDown[1];

            if ((fieldHeight > (stepDown + hauteurEnDur)) && !isblockedDown) {
                character.style.top = stepDown + "px";
            } else if (fieldHeight <= (stepDown + hauteurEnDur)) {
                character.style.top = (fieldHeight - hauteurEnDur) + "px";
            } else if (isblockedDown) {
                // console.log("isblockedDown");
                character.style.top = (blockedDownBy.y - character.height - 8) + "px";
            }
            break;
        case "left":
            character.src = "./img/charact_left.png";
            stepLeft = character.x - largeurEnDur;

            let tempLeft = checkMove("left");
            isblockedLeft = tempLeft[0];
            blockedLeftBy = tempLeft[1];

            if ((character.x > stepSizeW) && !isblockedLeft) {
                character.style.left = stepLeft + "px";
            } else if (character.x <= stepSizeW) {
                character.style.left = "-10px";
            } else if (isblockedLeft) {
                // console.log("isblockedLeft");
                character.style.left = (blockedLeftBy.x + blockedLeftBy.width - 10) + "px";
            }
            break;
        case "right":
            character.src = "./img/charact_right.png";
            stepRight = character.x + stepSizeW;

            let tempRight = checkMove("right");
            isblockedRight = tempRight[0];
            blockedRightBy = tempRight[1];

            if ((fieldWidth > (stepRight + largeurEnDur)) && !isblockedRight) {
                character.style.left = stepRight + "px";
            } else if (fieldWidth <= (stepRight + largeurEnDur)) {
                character.style.left = (fieldWidth - largeurEnDur) + "px";
            } else if (isblockedRight) {
                // console.log("isblockedRight");
                character.style.left = (blockedRightBy.x - character.width - 7) + "px";
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

///////////////////////////////////////////////////////
// Check if block
/**
 * 
 * @param {string} sens 
 * @return array
 */
function checkMove(sens) {
    numberBlocks = 0;
    problemForMove = [];
    lesObstacles.forEach(block => {
        //////////////////////////////////////////
        // Mesures des valeurs pour block en cour
        blockX = block.x;
        blockY = block.y;
        blockH = block.height;
        blockW = block.width;

        // console.info(block);

        //////////////////////////////////////////
        // Mesures des valeurs pour le sprite
        spriteX = character.x;
        spriteY = character.y;
        spriteH = character.height;
        spriteW = character.width;

        switch (sens) {
            case "up":
                // console.log("*****************************");                 
                // console.log("spriteY < blockY + blockH + stepSizeH => "+(spriteY < blockY + blockH + stepSizeH));                 
                // console.log("spriteY = top of sprite = "+spriteY);                 
                // console.log("blockY + blockH + stepSizeH = bottom of block + size of step = "+(blockY + blockH + stepSizeH));                 
                // console.log("spriteY + spriteH > blockY =>"+(spriteY + spriteH > blockY));                 
                // console.log("spriteY + spriteH = bottom of sprite = "+(spriteY + spriteH));                 
                // console.log("blockY = top of block = "+blockY);  
                if (((spriteX + spriteW > blockX+2)                   //  si X(coin haut droit du sprite) est plus à droite que le côté gauche du block
                    && (spriteX < blockX + blockW-2))                //  ET X(coin haut gauche du sprite) est plus à gauche que le côté droit du block
                    //                                                      => ie sprite au moins en partie aligné verticalement avec le block
                    && (spriteY < blockY + blockH + stepSizeH)          //  ET le sprite rencontrera le block s'il fait un pas dans cette direction
                    && (spriteY + spriteH > blockY)) {
                    numberBlocks++;
                    problemForMove[1] = block;
                }
                break;
            case "down":
                // console.log("*****************************");                 
                // console.log("spriteY + spriteH + stepSizeH > blockY => "+(spriteY + spriteH + stepSizeH > blockY));                 
                // console.log("spriteY + spriteH + stepSizeH = bottom of sprite after step down = "+(spriteY + spriteH + stepSizeH));                 
                // console.log("blockY = top of block = "+blockY);                 
                // console.log("spriteY > blockY + blockH =>"+(spriteY > blockY + blockH));                 
                // console.log("spriteY = top of sprite = "+spriteY);                 
                // console.log("blockY + blockH = bottom of block = "+(blockY + blockH)); 
                if (((spriteX + spriteW > blockX+2)                   //  si X(coin haut droit du sprite) est plus à droite que le côté gauche du block
                    && (spriteX < blockX + blockW-2))                //  ET X(coin haut gauche du sprite) est plus à gauche que le côté droit du block
                    //                                                      => ie sprite au moins en partie aligné verticalement avec le block
                    && (spriteY + spriteH + stepSizeH > blockY)         //  ET le sprite rencontrera le block s'il fait un pas dans cette direction         
                    && (spriteY + 2 < blockY + blockH)) {               //  +2 to deal with transparent pixels     
                    numberBlocks++;
                    problemForMove[1] = block;
                }
                break;
            case "left":
                // console.log("*****************************");
                // console.log("*****************************");                           
                // console.log("spriteY + spriteH > blockY =>"+(spriteY + spriteH > blockY));                 
                // console.log("spriteY + spriteH = bottom of sprite = "+(spriteY + spriteH));                 
                // console.log("blockY = top of block = "+blockY);       
                // console.log("spriteY < blockY + blockH - 5 => "+(spriteY < blockY + blockH - 5));                 
                // console.log("spriteY = top of sprite = "+spriteY);                 
                // console.log("blockY + blockH - 5 = bottom of block = "+(blockY + blockH - 5));
                // ///////////////////////////////////////////////////////////////
                // console.log("*****************************");   
                // console.log("spriteX - stepSizeW < blockX + blockW => "+(spriteX - stepSizeW < blockX + blockW));                 
                // console.log("spriteX - stepSizeW = one step to the left of sprite = "+(spriteX - stepSizeW));                 
                // console.log("blockX + blockW = right of block = "+(blockX + blockW));                 
                // console.log("spriteX + spriteW > blockX =>"+(spriteX + spriteW > blockX));                 
                // console.log("spriteX + spriteW = right of sprite = "+(spriteX + spriteW));                 
                // console.log("blockX = left of block = "+blockX);
                // console.log("*****************************");   
                // console.log("*****************************");   
                if (((spriteY + spriteH > blockY)                       //  si le bas du sprite est plus bas que le haut du block
                    && (spriteY < blockY + blockH - 5))                 //  ET le haut du sprite est plus haut que le bas du block
                    //                                                      => ie sprite au moins en partie aligné horizontalement avec le block
                    && (spriteX - stepSizeW < blockX + blockW)          //  ET le sprite rencontrera le block s'il fait un pas dans cette direction
                    && (spriteX + spriteW -10 > blockX)) {
                    numberBlocks++;
                    problemForMove[1] = block;
                }
                break;
            case "right":
                // console.log("*****************************");                 
                // console.log("spriteY < blockY + blockH => "+(spriteY < blockY + blockH));                 
                // console.log("spriteY = top of sprite = "+spriteY);                 
                // console.log("blockY + blockH = bottom of block = "+(blockY + blockH));                 
                // console.log("spriteY + spriteH > blockY =>"+(spriteY + spriteH > blockY));                 
                // console.log("spriteY + spriteH = bottom of sprite = "+(spriteY + spriteH));                 
                // console.log("blockY = top of block = "+blockY);  
                if (((spriteY + spriteH > blockY)                       //  si le bas du sprite est plus bas que le haut du block
                    && (spriteY < blockY + blockH - 5))                 //  ET le haut du sprite est plus haut que le bas du block
                    //                                                      => ie sprite au moins en partie aligné horizontalement avec le block
                    && (spriteX + spriteW + stepSizeW > blockX)         //  ET le sprite rencontrera le block s'il fait un pas dans cette direction
                    && (spriteX + 2 < blockX + blockW)) {
                    numberBlocks++;
                    problemForMove[1] = block;
                }
                break;
            default:
                break;
        }
    });
    problemForMove[0] = (numberBlocks == 0 ? false : true);
    if (numberBlocks > 1) {
        console.log("multiple blocks");
    }
    return problemForMove;
}