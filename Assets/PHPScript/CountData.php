<?php

require_once('Access.php');
$pdo = connectDB();

try 
{
    $sql = "SELECT * FROM StageData";
    $res = mysqli_query($pdo, $sql);
    $num_rows = mysqli_num_rows($res);
}
catch (PDOException $e) {
    var_dump($e->getMessage());
}
$pdo = null;    //DB切断

echo $num_rows;
  //unity に結果を返す
?>