/*var changeQte1=document.getElementById("Qte1");
var changeQte2=document.getElementById("Qte2");
var changePrixUnit1=document.getElementById("PrixUnit1");
var changePrixUnit2=document.getElementById("PrixUnit2");

function Check(param1, param2) {
    var QteActu="Qte".param2;
   if(!isNaN(param1.value))
   {

   }
}*/

function modifTotal(event){
    sortieInput=event.target;
    if(!isNaN(sortieInput.value)){
        valeurActuelle=sortieInput.value;
        if(sortieInput.getAttribute("data-input")=="Qte1"||sortieInput.getAttribute("data-input")=="PrixUnit1"){
            valeurActuelle=
        }
    }else{
        sortieInput.value=0;
    }
}

lesInputs = document.querySelectorAll("[data-input]");
lesInputs.forEach(element => {
    element.addEventListener("blur", modifTotal);
});