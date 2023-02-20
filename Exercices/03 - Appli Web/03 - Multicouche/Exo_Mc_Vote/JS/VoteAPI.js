document.querySelector("#Voter").addEventListener('click', CheckCode);

function CheckCode(e) {
    let code = e.target.value;
    //console.log(code);
    var requ = new XMLHttpRequest();
    requ.open('GET', 'http://10.115.41.51:5000/api/CodesValides', true);
    requ.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    requ.send();
    requ.onreadystatechange = function (event) {
        if (this.readyState === XMLHttpRequest.DONE) {
            if (this.status === 200) {
                console.log("Réponse reçue: %s", this.responseText);
                reponse = JSON.parse(this.responseText);
                console.log(reponse);
                let index = 0;
                let pv = false;
                while (reponse[index] != null) {
                    console.log(reponse[index]);
                    if (reponse[index].codeValide == code && reponse[index].utilise == false) {
                        pv = true;
                    }
                    index++;
                }
            }
        }
        else if (this.status !== 200)
            console.log("Erreur" + this.status + this.responseText);
    }

}
