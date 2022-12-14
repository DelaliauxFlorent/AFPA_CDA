
/******************* V2 ajout de ligne dynamiquement*************** */
// créer un template dans le html
function ajoutLigne(ind){
    grille = document.getElementById("grille"); // on récupère la grille pour ajouter une ligne
    temp = document.getElementsByTagName("template")[0]; // on récupère le template
    const element = temp.content.cloneNode(true); // on clone le template
    grille.appendChild(element);    // on ajoute la ligne à la grille
    //console.log(document.querySelectorAll(".qte")[ind+1].value);

    document.querySelectorAll(".qte")[ind+1].addEventListener("input",calcul);
    document.querySelectorAll(".pu")[ind+1].addEventListener("input",calcul);
    lesQuantites = document.querySelectorAll(".qte");
    lesUnitaires = document.querySelectorAll(".pu");
    lesPrix = document.querySelectorAll(".prix");
}

/****************** fin V2 ************************************* */
lesQuantites = document.querySelectorAll(".qte");
//lesQuantites = document.getElementsByClassName("qte");
lesQuantites.forEach(element => {
    element.addEventListener("input",calcul);
});
lesUnitaires = document.querySelectorAll(".pu");
lesUnitaires.forEach(element => {
    element.addEventListener("input",calcul);
});

lesPrix = document.querySelectorAll(".prix");

function calcul(event)
{
    inp= event.target;
    // recherche de l'index dans le tableau pour trouver les 2 inputs correspondants dans les autres tableaux
    if( inp.classList.contains("qte"))
    // Array.from(lesUnitaires) permet de transformer le NodeList en Array pour utiliser la fonction indexOf
    {
        index = Array.from(lesQuantites).indexOf(inp);        
    }
    else{
        index = Array.from(lesUnitaires).indexOf(inp);
        if(index==Array.from(lesUnitaires).length-1){
            ajoutLigne(index);
        }
    }
    // on ne fait le calcul que si les 2 inputs sont remplis
    if ( lesQuantites[index].value!="" && lesUnitaires[index].value!="")
    {
        lesPrix[index].value=  lesQuantites[index].value*lesUnitaires[index].value;
    }
    calculTotal();
}

function calculTotal()
{
    somme = 0
    lesPrix.forEach(elt=>{
        somme += elt.value*1; // *1 pour caster en int
    })
    document.getElementsByClassName("total")[0].value = somme;
}

