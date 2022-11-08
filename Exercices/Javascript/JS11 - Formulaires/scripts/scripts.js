listInputs = document.querySelectorAll('[data-type]');
listInputs.forEach(element => {
    element.addEventListener("blur", verifInput);
    element.addEventListener("input", verifSubmit);
});







function verifInput(event) {
    element = event.target;
    typeElem = element.getAttribute("data-type");

    regexPhone = /^\d{2}(\.|| )?\d{2}(\.|| )?\d{2}(\.|| )?\d{2}(\.|| )?\d{2}$/;
    regexMail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    regexCdPost=/^\d{5}$/;

    ///////////////////////

    switch (typeElem) {
        case "telephone":
            // console.log(element.value.match(regexPhone));    
            if (!element.value.match(regexPhone)) {
                element.value = "";
                gestionErreur(element);
            }
            break;
        case "mail":
            if (!element.value.match(regexMail)) {
                element.value = "";
                gestionErreur(element);
            }
            break;
        case "cdPost":
            if (!element.value.match(regexCdPost)||(element.value<0||element.value>99999)) {
                element.value = "";
                gestionErreur(element);
            }
            break;
        default:
            break;
    }
}

function gestionErreur(params) {
    alert("Erreur de saisie!");
    params.focus();
}

function verifSubmit(event) {
    peutEnvoyer=true;
    listInput.forEach(element => {
        peutEnvoyer&=element.value!="";
    });
    if(peutEnvoyer){
        document.getElementsByTagName
    }
}