using UnityEngine;

public class Item : MonoBehaviour
{

    private BillingClient billingClient;
    [System.NonSerialized]public string ID;

    private void Start()
    {
        billingClient = GameObject.Find("Client").GetComponent<BillingClient>();
    }
    public void PushButton()
    {
        StartCoroutine(billingClient.Buyrequest(ID));
    }
}
