function registra() {
    var fecha = new Date();
    
    $.ajax({
        type: 'POST',
        url: 'models/checkUser.php',
        dataType: "json",
        data: 
        {   name: document.getElementById("usuari").value,
            password: document.getElementById("contrasenya").value,
            doIt: getRadioButtonSelectedValue(formulario.opcion),
            day: fecha.getDate(),
            month: fecha.getMonth()+1,
            year: fecha.getFullYear(),
            hour: fecha.getHours(),
            minutes: fecha.getMinutes(),
            seconds: fecha.getSeconds(),
            commentary: document.getElementById("comentari").value
        },
        
        success:function(data){
            alert(data.fitxat);
            if(data.status == 'false'){
                alert('Usuari incorrecte');
            }else{
               document.getElementById("quitar").style.display = "none";
               document.getElementById("poner").style.display = "block";
               alert(data.userName);
               document.getElementById("poner").innerHTML = "Hola " + data.userName;
            }
        }
    })
}

function getRadioButtonSelectedValue(ctrl){
    for(i=0;i<ctrl.length;i++)
    if(ctrl[i].checked) return ctrl[i].value;
}