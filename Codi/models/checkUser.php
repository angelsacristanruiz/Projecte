<?php
    ini_set('display_errors', 1);
    ini_set('display_startup_errors', 1);
    error_reporting(E_ALL);

    require_once ("conectBBDD.php");
    $sql = "select usuari, contrasenya, nom, id_treballador from Treballador";
    $result = $conn->query($sql);
    
    
    $name = $_POST["name"];
    $password = $_POST["password"];
    $doIt = $_POST["doIt"];
    $day = $_POST["day"];
    $month = $_POST["month"];
    $year = $_POST["year"];
    $hour = $_POST["hour"];
    $minutes = $_POST["minutes"];
    $seconds = $_POST["seconds"];
    $commentary = $_POST["commentary"];

    $data = array();
    $data['status'] = 'false';
    
    
    if ($result->num_rows > 0) {
        while($row = $result->fetch_assoc()) {
            if($row['usuari'] == $name && $row['contrasenya'] == $password){
                $data['status'] = 'true';
                $data['userName'] = $row['nom'];
                $id_user = $row['id_treballador'];
            }
        }
    }
    
    if($data['status'] == 'true'){
        if($day<10){
            $day = '0'.$day;
        }
        if($month<10){
            $month = '0'.$month;
        }
        if($minutes<10){
            $minutes = '0'.$minutes;
        }
        if($hour<10){
            $hour = '0'.$hour;
        }
        if($seconds<10){
            $seconds = '0'.$seconds;
        }
           
        $day_complet = $day.'/'.$month.'/'.$year;    
        if($doIt == 'Entrada'){
            $entry = $hour.':'.$minutes.':'.$seconds;
            
            $sql = "UPDATE Horari
            SET sortida='no fitxat', hores='0', comentari_sortida='no fitxat'
            WHERE id_treballador=$id_user AND dia!='$day_complet' AND sortida=''";
            $conn->query($sql);
            
            
            $sql = "INSERT INTO Horari (dia, entrada, comentari_entrada, id_treballador)
            VALUES ('$day_complet', '$entry', '$commentary', '$id_user')";
            $conn->query($sql);

        }else{
            $data['fitxat'] = 'false';
            
            $exit = $hour.':'.$minutes.':'.$seconds;
            
            $sql = "select id_horari, dia, id_treballador from Horari where id_treballador='$id_user' AND dia='$day_complet' AND sortida=''";
            $result = $conn->query($sql);
            
            if ($result->num_rows > 0) {
                while($row = $result->fetch_assoc()) {
                    echo $row['id_horari'];
                    echo $row['dia'];
                    echo $row['id_treballador'];
                }
                
                
                $sql = "UPDATE Horari
                SET sortida='$exit', hores='0', comentari_sortida='$commentary'
                WHERE id_treballador=$id_user AND dia='$day_complet' AND sortida=''";
                $conn->query($sql);
                
                $data['fitxat'] = 'true';
            }
            
        }
        
    }

    echo json_encode($data);
    
    
?>