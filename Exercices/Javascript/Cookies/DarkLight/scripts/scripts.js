/////////////////////////////////////////////////////////////////
// Check navigateur (some still use old separation in Cookies)
/////////////////////////////////////////////////////////////////

function QuelNavigateur() {
    var ua = navigator.userAgent;
    console.log(ua);
    var x = ua.indexOf("MSIE");
    var navig = "MSIE";
    if (x == -1) {
        x = ua.indexOf("Firefox");
        navig = "Firefox";
        if (x == -1) {
            x = ua.indexOf("OPR");
            navig = "Opéra";
            if (x == -1) {
                x = ua.indexOf("EDG");
                navig = "Edge";
                if (x == -1) {
                    x = ua.indexOf("Chrome");
                    navig = "Chrome";
                    if (x == -1) {
                        x = ua.indexOf("Safari");
                        navig = "Safari"
                    }
                }
            }
        }
        return navig;
    }
}

/////////////////////////////////////////////////////////////////
// Create a Cookie
/////////////////////////////////////////////////////////////////

function createCookie(name, value, days) {
    // permet de créer un cookie
    if (days) {
        // si le nombre de jour est renseigné, on le transforme en millieme de seconde
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "expires=" + date.toGMTString();
    } else var expires = "";
    //le cookie doit contenir  clé=valeur;expires=temps;path=nomDomaine
    document.cookie = name + "=" + value + separateur + expires + separateur + " path=/";
}

/////////////////////////////////////////////////////////////////
// Look for a specific Cookie
/////////////////////////////////////////////////////////////////

function readCookie(name) {
    // on récupère tous les cookies du site en une fois, séparé par ;
    // on range dans un tableau chaque cookie
    var listeCookies = document.cookie.split(separateur);
    for (let i = 0; i < listeCookies.length; i++) {
        // pour chaque cookie, on sépare en tableau la clé et la valeur 
        var unCookie = listeCookies[i].split("=");
        // si la clé correspond au cookie cherché, on renvoi la valeur 
        if (unCookie[0] == name) return unCookie[1];
    }
    return null;
}

/////////////////////////////////////////////////////////////////
// Erase a specific Cookie
/////////////////////////////////////////////////////////////////

function eraseCookie(name) {
    // pour supprimer un cookie, on le périme
    createCookie(name, "", -1);
}

/////////////////////////////////////////////////////////////////
// Reinitialise the Cookie
/////////////////////////////////////////////////////////////////

function reInitCookie(name) {
    eraseCookie(name);
    gestionCookie(name);
}

/////////////////////////////////////////////////////////////////
// Applique le css du thème voulu
/////////////////////////////////////////////////////////////////

function switchTheme(name) {
    cookieValue = readCookie(name);
    if (cookieValue == "light") {
        newVal = "dark";
    }
    else {
        newVal = "light";
    }
    createCookie(name, newVal, 1);
    setTheme("LightOrDark");
}

function setTheme(name) {

    cookieValue = readCookie(name);

    if(cookieValue==null){
        createCookie(name, "light", 1);
    }

    fond = document.querySelector("body");
    darkTheme = (cookieValue == "dark");
    fond.classList.toggle("dark", darkTheme);
    fond.classList.toggle("light", !darkTheme);
    console.log(fond.classList.contains(darkTheme));

    listeParagraphes = document.querySelectorAll("p");
    listeParagraphes.forEach(paragraphe => {
        paragraphe.classList.toggle("dark", darkTheme);
        paragraphe.classList.toggle("light", !darkTheme);
    });
}
/////////////////////////////////////////////////////////////////
// Functions' calls, setting eventListener, etc...
/////////////////////////////////////////////////////////////////

separateur = QuelNavigateur() == "firefox" ? "," : ";";

setTheme("LightOrDark");
boutonSwitch = document.querySelector("#switch");
boutonSwitch.addEventListener("click", () => { switchTheme("LightOrDark"); });