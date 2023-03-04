using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Test : MonoBehaviour
{
    // メンバ変数
    Process proc;

    // アプリ起動時に呼ばれる
    void Start()
    {
        // 別アプリ(プロセス)起動
        proc = new Process();
        proc.StartInfo.FileName = "file:C:/Users/user/Desktop/Other/Assets/Test/Test.exe";   // 起動させる別アプリ名をここに入れて下さい(フルパス指定でも可) 
        proc.Start();
    }

    // アプリ終了時に呼ばれる
    private void OnApplicationQuit()
    {
        // 別アプリ終了処理

        if (!proc.HasExited)
        {
            // 別アプリが起動中の場合のみ終了させる
            proc.CloseMainWindow();
        }

        proc.Close();
        proc = null;
    }
}
