using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class StageDataLoad : MonoBehaviour
{

    string ServerAddress = "http://hiroshi05.php.xdomain.jp/Nyanshima/LoadStageData.php";
    [SerializeField] private ImageData imageData;
    [SerializeField] private CashData cashData;

    public void LoadStageData(int i)
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();

        dic.Add("id", i);

        StartCoroutine(Post(ServerAddress, dic));  
    }

    private IEnumerator Post(string url, Dictionary<string, int> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, int> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return StartCoroutine(CheckTimeOut(www, 3f)); //TimeOutSecond = 3s;

        if (www.error != null)
        {
            Debug.Log("HttpPost NG: " + www.error);
            //���������ڑ����ł��Ă��Ȃ��Ƃ�

        }
        else if (www.isDone)
        {
            string rawData = www.downloadHandler.text.Replace("[","").Replace("]","");
            StageData stageDatas = JsonUtility.FromJson<StageData>(rawData);//json���\���̂�
            cashData.StartCoroutine("CashStageData", stageDatas);
            transform.GetChild(stageDatas.id - 1).gameObject.GetComponent<ImageData>().StartCoroutine("Load",stageDatas);//�C���[�W�̔��f�̂��߂̃f�[�^���M
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
                Debug.Log("TimeOut");  //�^�C���A�E�g
                //�^�C���A�E�g����
                //
                //
                break;
            }
        }
        yield return null;
    }
}
