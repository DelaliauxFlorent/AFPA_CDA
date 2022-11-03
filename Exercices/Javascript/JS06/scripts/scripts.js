listeCouleursParag = ['blue', 'black'];
listeCouleursTitre = ['yellow', 'green', 'black'];

lesParagraphes = document.querySelectorAll("p");

lesParagraphes.forEach(para => {
    para.addEventListener("click", changeColorP);
});
lesTitres = document.querySelectorAll("h1, h2, h3");
lesTitres.forEach(title => {
    title.addEventListener("click", changeColorT);
});

var iteration=1;

////////////////////////////////////////////////////////////
// Alternance couleur en changeant style
/*
function changeColorP(event) {
    paragraphe=event.target;
    if(paragraphe.style.color==listeCouleursParag[0]){
        paragraphe.style.color=listeCouleursParag[1];
    }else{
        paragraphe.style.color=listeCouleursParag[0];
    }
}

function changeColorT(event) {
    titre=event.target;
    tousTitreNiveau=document.querySelectorAll(titre.localName);
    tousTitreNiveau.forEach(title => {
        switch(title.style.color){
            case listeCouleursTitre[0]:
                title.style.color=listeCouleursTitre[1];
                break;
            case listeCouleursTitre[1]:
                title.style.color=listeCouleursTitre[2];
                break;
            default:
                title.style.color=listeCouleursTitre[0];
                break;
        }       
        
    });
}
*/

////////////////////////////////////////////////////////////
// Alternance couleur en changeant les classes

function changeColorP(event) {
    paragraphe = event.target;
    if (paragraphe.classList.contains("para2")) {
        paragraphe.classList.remove("para2");
    } else {
        paragraphe.classList.add("para2");
    }
}

function changeColorT(event) {
    titre=event.target;
    tousTitreNiveau=document.querySelectorAll(titre.localName);
    tousTitreNiveau.forEach(title => {
        title.classList.toggle("titleA", iteration%3==0);
        title.classList.toggle("titleB", iteration%3==1);
        title.classList.toggle("titleC", iteration%3==2);      
    });    
    iteration++;  
}