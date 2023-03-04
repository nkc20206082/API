<?php
   function connectDB()
   {
    $url = 'mysql1.php.xdomain.ne.jp'; //mysqlサーバー名
    $user = 'hiroshi05_nekosk'; //ユーザーID
    $pass = 'nekonekomuu3'; //パスワード
    $db = 'hiroshi05_nyanshima'; //データベース名


    try 
    {
        $mysqli = new mysqli($url, $user, $pass, $db);
        
    } 
    catch (PDOException $e) 
    {
        exit('' . $e->getMessage());
    }
    return $mysqli;
   }
    ?>