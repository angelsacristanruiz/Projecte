<?php
    $dbhost = "localhost";
    $dbuser = "esdionli_angel";
    $dbpass = "surus";
    $db = "esdionli_backup";

    $conn = mysqli_connect($dbhost, $dbuser, $dbpass,$db) or die("Connect failed: ". $conn -> error);
    
?>