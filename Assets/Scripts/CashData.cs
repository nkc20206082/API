using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CashData : MonoBehaviour
{
    [SerializeField] InstantiateImage instantiateImage;
    [SerializeField] GameObject parent;//�L�����o�X

    static List<Cash> cashes=new List<Cash>();

    public IEnumerator CashStageData(StageData data)
    {
        string url = "http://hiroshi05.php.xdomain.jp/Resources/" + data.image + ".jpg";  //�擾�������摜�� url ������
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

        cashes.Add(new Cash(data.id,data.name,texture,data.masta));

        Debug.Log(cashes[cashes.Count-1].tex);
    }

    public void CashLoad()
    {
        instantiateImage.InstImage(cashes.Count);//�f�[�^�̌���RawImage�𐶐�
        for (int i = 0; i < cashes.Count; i++)//�f�[�^�̌����f�[�^��ǂݎ��悤����
        {
            parent.transform.GetChild(i).gameObject.name = cashes[i].name;//�Q�[���I�u�W�F�N�g�̖��O�̕ύX

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
