bouton=document.getElementsByTagName("button")[0];
bouton.addEventListener("click", ajouterDessert);

function ajouterDessert(){
    newDessert = prompt("Quel dessert ajouter?");
    listeDesserts=document.getElementById("listeDesserts");
    temp = document.getElementsByTagName("template")[0];
    const element = temp.content.cloneNode(true);
    element.textcontent=newDessert;
    //console.info(element);
    listeDesserts.appendChild(element);
}