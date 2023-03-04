using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BillingClient : MonoBehaviour
{
    [SerializeField] private bool IN134;
    private string baseURL = "http://localhost";
    private int MaxData=0;
    [SerializeField] BillingView Billngview;
    private void Start()
    {
        //if (IN134)
        //{
        //    baseURL = baseURL + "169.254.67.119";

        //}
        //else
        //{
        //    baseURL = baseURL + "172.18.103.71";

        //}

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(CountData());
        }
    }

    IEnumerator CountData()
    {
        string url = baseURL + "/countData";
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
                MaxData = int.Parse(request.downloadHandler.text);

            }
        }
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        for (int i = 1; i <= MaxData; i++)
        {
            string url = baseURL + "/getData/"+i;
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
                    BillingData billingdata = JsonUtility.FromJson<BillingData>(rawData); 

                    Billngview.Load(billingdata);
                }
            }
        }
    }

    public IEnumerator Buyrequest(string ID)
    {
        string url = baseURL + "/Buy/" + ID;
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
                float disPrice = float.Parse(request.downloadHandler.text);

                Debug.Log(disPrice);
            }
        }
    }
}
