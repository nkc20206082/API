using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StageDataCount : MonoBehaviour
{
    [SerializeField] InstantiateImage instantiateImage;
    [SerializeField] StageDataLoad stageDataLoad;
    string ServerAddress = "http://hiroshi05.php.xdomain.jp/Nyanshima/CountData.php";  //CountData.phpを指定　

    //SendSignalボタンを押した時に実行されるメソッド

    public void CountStageData()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();

        StartCoroutine(Post(ServerAddress, dic)); //サーバーへ接続
    }

    private IEnumerator Post(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return StartCoroutine(CheckTimeOut(www, 3f)); //TimeOutSecond = 3s;

        if (www.error != null)
        {
            Debug.Log("HttpPost NG: " + www.error);
            //そもそも接続ができていないとき

        }
        else if (www.isDone)
        {
            int countData = int.Parse(www.downloadHandler.text);
            instantiateImage.InstImage(countData);//データの個数分RawImageを生成
            for(int i = 1; i <=countData; i++)//データの個数分データを読み取るよう命令
            {
                stageDataLoad.LoadStageData(i);
            }
        }
    }

    private IEnumerator CheckTimeOut(UnityWebRequest www, float timeout)
    {
        float requestTime = Time.time;

        while (!www.isDone)
        {
            if (Time.time - requestTime < timeout)
                yield return www.SendWebRequest();
            else
            {
                Debug.Log("TimeOut");  //タイムアウト
                //タイムアウト処理
                //
                break;
            }
        }
        yield return null;
    }
}
