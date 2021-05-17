<?php

    $name = $_POST["nombre"];
    $password = $_POST["contrasenya"];
    $doIt = $_POST["hacer"];
    $day = $_POST["dia"];
    $month = $_POST["mes"];
    $year = $_POST["ano"];
    $hour = $_POST["horas"];
    $minutes = $_POST["minutos"];
    $seconds = $_POST["segundos"];
    $commentary = $_POST["comentari"];

    $sql = "select nom, contrasenya from Treballador";
    $result = $conn->query($sql);
    
    $validation = false;
    
    if ($result->num_rows > 0) {
        while($row = $result->fetch_assoc()) {
            if($row['nom'] == $name && $row['constrasenya'] == $password){
                
            }
            echo "test";
        }
    }
    
?>