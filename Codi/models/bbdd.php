<?php
    $con = mysqli_connect("http://esdi-online.com/","angel","esdiangel");
    if (!$con)
    {
        die('Could not connect: ' . mysqli_error());
    }

    mysqli_select_db("mysql_database_name", $con);

    $query = "SELECT * FROM TableName";
    $result = mysqli_query($query);
?>