document.querySelector("#Voter").addEventListener('click', Voter);

function Voter() {
    var code = document.querySelector("#CodeVotant").value;
    document.querySelector("#CodeVotant").value="";
    var requ = new XMLHttpRequest();
    requ.open('GET', 'http://10.115.41.51:5000/api/CodesValides', true);
    requ.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    requ.send();
    requ.onreadystatechange = function (event) {
        if (this.readyState === XMLHttpRequest.DONE) {
            if (this.status === 200) {
                reponse = JSON.parse(this.responseText);
                let index = 0;
                let pv = false;
                while (reponse[index] != null && pv == false) {
                    if (reponse[index].codeValide == code && reponse[index].utilise == false) {
                        pv = true;
                        var requ3 = new XMLHttpRequest();
                        requ3.open('POST', 'http://10.115.41.51:5000/api/Votes/', true);
                        requ3.setRequestHeader("Content-Type", "application/json");
                        listRadio = document.querySelectorAll('[name="Vote"]');
                        listRadio.forEach(element => {
                            if (element.checked) {
                                vote = element.value;
                                element.checked=false;
                            }
                        });
                        args3 = '{"choixVote":"' + vote + '", "idCodeValide":' + reponse[index].idCodeValide + '}';
                        requ3.send(args3);
                        if (this.readyState === XMLHttpRequest.DONE) {
                            if (this.status === 200) {

                                var requ2 = new XMLHttpRequest();
                                requ2.open('PUT', 'http://10.115.41.51:5000/api/CodesValides/' + reponse[index].idCodeValide, true);
                                requ2.setRequestHeader("Content-Type", "application/json");
                                args = '{"idCodeValide":"' + reponse[index].idCodeValide + '", "codeValide":"' + reponse[index].codeValide + '", "utilise":true}';
                                requ2.send(args);
                            }
                        }
                    }
                    index++;
                }
            }
        }
        else if (this.status !== 200)
            console.log("Erreur" + this.status + this.responseText);
    }

}
