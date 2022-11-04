function ajoutLigne(ind){
    tableau = document.getElementById("Tableau"); // on récupère le tableau pour ajouter une ligne
    temp = document.getElementsByTagName("template")[0]; // on récupère le template
    const element = temp.content.cloneNode(true); // on clone le template
    tableau.appendChild(element);    // on ajoute la ligne au tableau

    newLine=parseInt(ind)+1;    //set value of new line
    
    // add eventListener to both new inputs
    document.querySelectorAll("[data-quantite]")[newLine].addEventListener("input",modifTotal);
    document.querySelectorAll("[data-prixUnit]")[newLine].addEventListener("input",modifTotal);

    // Set datas to new value to reflect on which line they are
    document.querySelectorAll("[data-quantite]")[newLine].setAttribute("data-quantite", newLine);
    document.querySelectorAll("[data-prixUnit]")[newLine].setAttribute("data-prixUnit", newLine);
    document.querySelectorAll("[data-prixTotal]")[newLine].setAttribute("data-prixTotal", newLine);
    
    // Update the lists 
    lesQtes = document.querySelectorAll("[data-quantite]");
    lesPrixUnit = document.querySelectorAll("[data-prixUnit]");
    lesTotaux = document.querySelectorAll("[data-prixTotal]");
}

function modifTotal(event) {
    sortieInput = event.target;
    if (!isNaN(sortieInput.value)) {
        //Get line
        if (sortieInput.getAttribute("data-quantite")) {            
            ligne = sortieInput.getAttribute("data-quantite");
        } else {
            ligne = sortieInput.getAttribute("data-prixUnit");
            // if the user just modified the "Prix Unitaire" for the current last line => we add a new (empty) line to the list
            if(ligne==Array.from(lesPrixUnit).length-1){
                ajoutLigne(ligne);
            }
        }
        document.querySelector("[data-prixTotal=\""+ligne+"\"]").value = document.querySelector("[data-quantite=\"" + ligne + "\"]").value * document.querySelector("[data-prixUnit=\"" + ligne + "\"]").value;
        calculTotal();
    }
}

function calculTotal(){
    lesTotaux = document.querySelectorAll("[data-prixTotal]");
        totalFin = 0;
        lesTotaux.forEach(element => {
            totalFin += parseFloat(element.value);
        });
        document.getElementById("Total").value = totalFin;
}

lesQtes = document.querySelectorAll("[data-quantite]");
lesQtes.forEach(element => {
    element.addEventListener("input", modifTotal);
});

lesPrixUnit = document.querySelectorAll("[data-prixUnit]");
lesPrixUnit.forEach(element => {
    element.addEventListener("input", modifTotal);
});

//////////////////////////////////////////
// querySelectorAll("[data-quantite], [data-prixUnit]") possible