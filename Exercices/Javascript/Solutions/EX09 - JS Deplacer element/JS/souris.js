 var enfonce = false;//repere si la souris est relaché ou enfonce

 function souris_enfonce() {
     enfonce = true;
 }

 function souris_lache() {
     enfonce = false;
 }

 function souris_bouge(e) {
     if (enfonce) {
         document.getElementById("square").style.left = e.clientX + 'px';
         document.getElementById("square").style.top = e.clientY + 'px';
     }
 }

 document.getElementById("square").addEventListener("mousedown", souris_enfonce);
 document.addEventListener("mouseup", souris_lache);
 document.addEventListener("mousemove", souris_bouge);