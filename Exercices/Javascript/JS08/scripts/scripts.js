deck = ["Pine_Bright.png", "Pine_Ribbon.png", "Pine_Plain.png", "Pine_Plain.png"];    // List of all possible cards
deckMelange =shuffle(deck);  // Shuffle the Deck

////////////////////////////////////////////
// array used so setTimeout don't mix, otherwise clicking on another 
// card before the previous one is hidden again will "freeze" that one
// as "revealed" and the timeout for the one that was just clicked will 
// be with the time left from the first instead of the full value
carteNum=[];

////////////////////////////////////////////
// Timer (en secondes) pour retourner la carte
timeout = 0.5;

lesCartes = document.querySelectorAll("img");
lesCartes.forEach((carte, index) => {
    //carte.addEventListener("click", retourner);
    carte.addEventListener("click", function () {
        retourner(event, index);    // call of event depreciated but won't work without
    })
});


//////////////////////////////////////////
// Fisher-Yates (aka Knuth) Shuffle
// Used to shuffle the deck
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

/**
 * fonction "cachant" à nouveau la carte passé en paramètre
 * @param {Node} params 
 */
function masquer(params) {
    params.src = "./img/Back.png";
    console.info(params);
}

/**
 * 
 * @param {event} event 
 * @param {int} index 
 */
function retourner(event, index) {
    carteNum[index] = event.target;
    carteNum[index].src = "./img/" + deckMelange[index];
    setTimeout(() => {
        masquer(carteNum[index]);
    }, timeout * 1000);
}