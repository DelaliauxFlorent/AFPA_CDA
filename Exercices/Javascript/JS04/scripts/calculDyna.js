function modifTotal(event){
    sortieInput=event.target;
    if(isNaN(sortieInput.value)){
        if(sortieInput.getAttribute("data-input").match("Qte")){
            sortieInput.value=1;
        }else{
            sortieInput.value=0;
        }
    }
    var ligne=sortieInput.getAttribute("data-input")[sortieInput.getAttribute("data-input").length-1];
    qte="[data-input=Qte"+ligne+"]";
    prixUnit="[data-input=PrixUnit"+ligne+"]";
    prixTotal="[data-input=PrixTotal"+ligne+"]";
    document.querySelector(prixTotal).value=document.querySelector(qte).value*document.querySelector(prixUnit).value;
    /*
    if(sortieInput.getAttribute("data-input").match("1")){
        document.querySelector("[data-input=PrixTotal1]").value=document.querySelector("[data-input=Qte1]").value*document.querySelector("[data-input=PrixUnit1]").value;
    }else{
        document.querySelector("[data-input=PrixTotal2]").value=document.querySelector("[data-input=Qte2]").value*document.querySelector("[data-input=PrixUnit2]").value;
    }*/
    document.querySelector("[data-input=Total]").value=parseFloat(document.querySelector("[data-input=PrixTotal1]").value)+parseFloat(document.querySelector("[data-input=PrixTotal2]").value);
}

lesInputs = document.querySelectorAll("[data-input]");
lesInputs.forEach(element => {
    element.addEventListener("blur", modifTotal);
});