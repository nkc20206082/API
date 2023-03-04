using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageData : MonoBehaviour
{
    public IEnumerator Load(StageData stagedata)
    {
        gameObject.name = stagedata.name;//ゲームオブジェクトの名前の変更
        string url = "http://hiroshi05.php.xdomain.jp/Resources/" + stagedata.image+".jpg";  //取得したい画像の url を書く
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        gameObject.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        gameObject.GetComponent<RawImage>().SetNativeSize();

        //Debug.Log(stagedata.id + "," + gameObject.name); 
    }
}
