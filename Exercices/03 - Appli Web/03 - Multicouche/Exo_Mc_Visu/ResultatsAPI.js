divRes = document.querySelector("#Resultat");
var requ = new XMLHttpRequest();
requ.open('GET', 'http://10.115.41.51:5000/api/Syntheses', true);
requ.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
requ.send();
requ.onreadystatechange = function (event) {
    if (this.readyState === XMLHttpRequest.DONE) {
        if (this.status === 200) {
            reponse = JSON.parse(this.responseText);
            let totalVotes=0;
            let prct=0;
            reponse.forEach(elt => {
                totalVotes+=elt.nombre;
            });
            let colors = ["lightblue", "lightgreen", "lightyellow", "lightcoral", "lightseagreen"];
            let num=0;
            reponse.forEach(elt => {
                divRes.innerHTML+='<div></div><div class="right">'+elt.reponse+' :</div><div class="left">'+elt.nombre+'</div><div></div>';
                prct=((elt.nombre/totalVotes)*100).toFixed(2);
                divRes.innerHTML+='<div class="grid-columns-span-4"><div class="pie" style="--p:'+prct+'; --c:'+colors[num]+'">'+prct+'%</div></div>';
                num++;
            });
        }
    }
}