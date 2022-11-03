function switchOnOFF(element){
    if(element.src.match("eteinte")){
        element.src="./img/Ampoule_allumee.jpg";
    }
    else{
        element.src="./img/Ampoule_eteinte.jpg";
    }
};

var element =document.getElementById("ampoule");
element.addEventListener("click", function() {
    if(element.src.match("eteinte")){
        element.src="./img/Ampoule_allumee.jpg";
    }
    else{
        element.src="./img/Ampoule_eteinte.jpg";
    }
});