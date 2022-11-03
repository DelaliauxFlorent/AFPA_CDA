listeCouleursParag=['blue', 'red'];
listeCouleursTitre=['yellow', 'green', 'black'];

lesParagraphes=document.querySelectorAll("p");

lesParagraphes.forEach(para => {
    para.addEventListener("click", changeColorP);
});
lesTitres=document.querySelectorAll("h1, h2, h3");
lesTitres.forEach(title => {
    title.addEventListener("click", changeColorT);
});

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