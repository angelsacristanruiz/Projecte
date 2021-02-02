<?php
    $con = mysqli_connect("162.159.24.157","angel","esdiangel");
    if (!$con)
    {
        die('Could not connect: ' . mysqli_error());
    }

    mysqli_select_db("mysql_database_name", $con);

?>