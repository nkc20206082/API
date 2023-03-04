using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class apiClient : MonoBehaviour
{
    [SerializeField] private InputField _InputField;
    [SerializeField] private Text _OutputText;
    [SerializeField] private bool IN134;
    private string baseURL = "http://";
    private void Start()
    {
        if (IN134)
        {
            baseURL = baseURL + "169.254.67.119";
        }
        else
        {
            baseURL = baseURL + "172.18.103.71";
        }
    }

    public void GetDataFromAPIServer()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        string url = baseURL + "/getData/" + int.Parse(_InputField.text);
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            if (request.responseCode == 200)
            {
                string rawData = request.downloadHandler.text;
                //CharaState charaState = JsonUtility.FromJson<CharaState>(rawData); charaState.IDÇ≈IDÇæÇØÇíäèoâ¬î\

                _OutputText.text = rawData;
            }
        }
    }
}
