using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageData : MonoBehaviour
{
    public IEnumerator Load(StageData stagedata)
    {
        gameObject.name = stagedata.name;//�Q�[���I�u�W�F�N�g�̖��O�̕ύX
        string url = "http://hiroshi05.php.xdomain.jp/Resources/" + stagedata.image+".jpg";  //�擾�������摜�� url ������
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        gameObject.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        gameObject.GetComponent<RawImage>().SetNativeSize();

        //Debug.Log(stagedata.id + "," + gameObject.name); 
    }
}
