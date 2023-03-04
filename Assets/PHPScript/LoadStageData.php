<?php
require_once('Access.php');
$pdo = connectDB();

$id = $_POST["id"];
try 
{
    $stmt=$pdo->query("SELECT *  FROM `StageData` where id=$id");

        foreach($stmt as $row){
        $userData[]=array(
        'id'=>$row['id'],
        'name'=>$row['StageName'],
        'image'=>$row['Image'],
        'masta'=>$row['StageMasta']
        );
        }
}
catch (PDOException $e) {
    var_dump($e->getMessage());
}
$pdo = null;    //DB切断

header('Content-type: application/json');
echo json_encode($userData, JSON_UNESCAPED_UNICODE);
  //unity に結果を返す
?>