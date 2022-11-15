lesInputs = document.querySelectorAll("input");

lesInputs.forEach(element => {
    element.addEventListener("input", check);
});

function check(e){
    target = e.target;

    if(target.checkValidity()){
        target.classList.remove("pasValide");
        target.classList.toggle("valide", true);
    }
    else{
        target.classList.remove("valide");
        target.classList.toggle("pasValide", true);
    }
}