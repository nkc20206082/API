using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CashData : MonoBehaviour
{
    [SerializeField] InstantiateImage instantiateImage;
    [SerializeField] GameObject parent;//キャンバス

    static List<Cash> cashes=new List<Cash>();

    public IEnumerator CashStageData(StageData data)
    {
        string url = "http://hiroshi05.php.xdomain.jp/Resources/" + data.image + ".jpg";  //取得したい画像の url を書く
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

        cashes.Add(new Cash(data.id,data.name,texture,data.masta));

        Debug.Log(cashes[cashes.Count-1].tex);
    }

    public void CashLoad()
    {
        instantiateImage.InstImage(cashes.Count);//データの個数分RawImageを生成
        for (int i = 0; i < cashes.Count; i++)//データの個数分データを読み取るよう命令
        {
            parent.transform.GetChild(i).gameObject.name = cashes[i].name;//ゲームオブジェクトの名前の変更

            parent.transform.GetChild(i).gameObject.GetComponent<RawImage>().texture = cashes[i].tex;
            parent.transform.GetChild(i).gameObject.GetComponent<RawImage>().SetNativeSize();
        }
    }
}

public class Cash
{
    public int id;
    public string name;
    public Texture tex;
    public int masta;

    public Cash(int id, string name, Texture tex, int masta)
    {
        this.id = id;
        this.name = name;
        this.tex = tex;
        this.masta = masta;
    }
}
