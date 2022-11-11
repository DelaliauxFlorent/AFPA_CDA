/////////////////////////////////////////////////////////////////
// Check navigateur (some still use old separation in Cookies)
/////////////////////////////////////////////////////////////////

function QuelNavigateur() {
    var ua = navigator.userAgent;
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
// Set "compteur" to either 1 (if no Cookie) or 
// if the cookie already existe, its increamented value
// then update/create the cookie
/////////////////////////////////////////////////////////////////

function gestionCookie(name) {
    compteur = document.querySelector("b");
    cookieValue = readCookie(name);
    if (cookieValue != null) {
        newVal = parseInt(cookieValue);
        newVal++;
    }
    else {
        newVal = 1;
    }
    createCookie(name, newVal, 1);
    compteur.innerHTML = newVal;
}

/////////////////////////////////////////////////////////////////
// Reinitialise the Cookie
/////////////////////////////////////////////////////////////////

function reInitCookie(name) {
    eraseCookie(name);
    gestionCookie(name);
}

/////////////////////////////////////////////////////////////////
// Functions' calls, setting eventListener, etc...
/////////////////////////////////////////////////////////////////

separateur = QuelNavigateur()=="firefox"?",":";";
gestionCookie("compteurVisite");

boutonReset=document.querySelector("button");
boutonReset.addEventListener("click",()=>{reInitCookie("compteurVisite");});