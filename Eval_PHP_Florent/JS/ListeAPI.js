grid = document.querySelector(".listArticles");
window.addEventListener("load", listing);



function listing() {
    var requ = new XMLHttpRequest();
    requ.open('POST', 'index.php?page=AppelAPI', true);
    requ.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    requ.send();

    requ.onreadystatechange = function (event) {
        if (this.readyState === XMLHttpRequest.DONE) {
            if (this.status === 200) {
                reponse = JSON.parse(this.responseText);
                temp = document.getElementById("tplArticle");
                reponse.forEach(element => {
                    contenu = temp.content.cloneNode(true);
                    var requ2 = new XMLHttpRequest();
                    requ2.open('GET', '//sta6400874/?key=59011-14-06&ref=' + element.refArticle, true);
                    requ2.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                    requ2.send();
                    grid.appendChild(contenu);
                    grid.innerHTML = grid.innerHTML.replaceAll("ValeurIdArticle", element.idArticle);
                    grid.innerHTML = grid.innerHTML.replaceAll("ValeurLibelle", element.libelleArticle);
                    grid.innerHTML = grid.innerHTML.replaceAll("ValeurRef", element.refArticle);
                    grid.innerHTML = grid.innerHTML.replaceAll("ValeurPrix", element.prix + "€");

                    requ2.onreadystatechange = function (event) {
                        if (this.readyState === XMLHttpRequest.DONE) {
                            if (this.status === 200) {
                                if (this.responseText != "Erreur de référence") {
                                    reponse2 = JSON.parse(this.responseText);
                                    grid.querySelectorAll('[name="qte"][data-refart="'+reponse2.refProduit+'"]')[0].innerHTML=reponse2.quantite;
                                    grid.querySelectorAll('[name="delai"][data-refart="'+reponse2.refProduit+'"]')[0].innerHTML=reponse2.delai;
                                }
                            }
                        }
                    }

                });
            }
        }
    }
}

