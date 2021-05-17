function registra() {
    var fecha = new Date();
    
    var param = {
        name: document.getElementById("usuari").value,
        password: document.getElementById("contrasenya").value,
        doIt: getRadioButtonSelectedValue(formulario.opcion),
        day: fecha.getDate(),
        month: fecha.getMonth()+1,
        year: fecha.getFullYear(),
        hour: fecha.getHours(),
        minutes: fecha.getMinutes(),
        seconds: fecha.getSeconds(),
        commentary: document.getElementById("comentari").value
    };
    
    //document.getElementById("quitar").style.display = "none";
    //document.getElementById("poner").style.display = "block";
}

function getRadioButtonSelectedValue(ctrl){
    for(i=0;i<ctrl.length;i++)
    if(ctrl[i].checked) return ctrl[i].value;
}