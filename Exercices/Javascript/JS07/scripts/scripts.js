bouton=document.getElementsByTagName("button")[0];
bouton.addEventListener("click", ajouterDessert);

function ajouterDessert(){
    newDessert = prompt("Quel dessert ajouter?");
    listeDesserts=document.getElementById("listeDesserts");
    temp = document.getElementsByTagName("template")[0];
    const element = temp.content.cloneNode(true);
    listeDesserts.appendChild(element);
    eltListe=document.querySelectorAll("li");
    listeLength=eltListe.length-1;
    eltListe[listeLength].insertAdjacentText('afterbegin',newDessert);
    eltListe[listeLength].addEventListener("click", effacerElement);
}

listeLI=document.querySelectorAll("li");
listeLI.forEach(element => {
    element.addEventListener("click", effacerElement)
});

function effacerElement(event) {
    item=event.target;JS07/scripts/scripts.js
    listeDesserts=document.getElementById("listeDesserts");
    listeDesserts.removeChild(item);
}

