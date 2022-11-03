function modifTotal(event) {
    sortieInput = event.target;
    if (!isNaN(sortieInput.value)) {
        //Get line
        if (sortieInput.getAttribute("data-quantite")) {
            ligne = sortieInput.getAttribute("data-quantite");
        } else {
            ligne = sortieInput.getAttribute("data-prixUnit");
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
    element.addEventListener("blur", modifTotal);
});

lesPrixUnit = document.querySelectorAll("[data-prixUnit]");
lesPrixUnit.forEach(element => {
    element.addEventListener("blur", modifTotal);
});