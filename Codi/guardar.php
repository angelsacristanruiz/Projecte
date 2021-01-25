<?php
    $nombre = $_POST["nombre"];
    $hacer = $_POST["hacer"];
    $dia = $_POST["dia"];
    $mes = $_POST["mes"];
    $ano = $_POST["ano"];
    $horas = $_POST["horas"];
    $minutos = $_POST["minutos"];
    $segundos = $_POST["segundos"];
    $comentari = $_POST["comentari"];

    if($dia<10){
        $dia = "0".$dia;
    }
    if($mes<10){
        $mes = "0".$mes;
    }
    if($ano<10){
        $ano = "0".$ano;
    }
    if($horas<10){
        $horas = "0".$horas;
    }
    if($minutos<10){
        $minutos = "0".$minutos;
    }
    if($segundos<10){
        $segundos = "0".$segundos;
    }

    $file = fopen("/home2/esdionli/fichar/".$nombre.".txt", "a");
    fwrite($file, " " . PHP_EOL);
    fwrite($file, "--------------------------------------------------------" . PHP_EOL);
    fwrite($file, $hacer . PHP_EOL);
    fwrite($file, $horas.":".$minutos.":".$segundos." - ".$dia."/".$mes."/".$ano . PHP_EOL);

    if (!empty($_SERVER['HTTP_CLIENT_IP'])) {
        $ip = $_SERVER['HTTP_CLIENT_IP'];
    } elseif (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) {
        $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
    } else {
        $ip = $_SERVER['REMOTE_ADDR'];
    }

    fwrite($file, "IP: ".$ip . PHP_EOL);
    fwrite($file, $comentari . PHP_EOL);
    fwrite($file, "--------------------------------------------------------" . PHP_EOL);
    fclose($file);


    $file = fopen("/home2/esdionli/fichar/".$nombre.".txt", "r");

    while(!feof($file)) {
        echo fgets($file). "<br />";
    }
    fclose($file);

?>