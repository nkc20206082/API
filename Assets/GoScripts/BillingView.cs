using UnityEngine;
using UnityEngine.UI;

public class BillingView : MonoBehaviour
{
    [SerializeField] GameObject InstanceObj;
    [SerializeField] GameObject Canvas;

    private int x = 0;
    private int y = 0;
    private int addy = -300;

    public void Load(BillingData Data)
    {
        GameObject newObj= Instantiate(InstanceObj, new Vector3(x,y,0), Quaternion.identity);
        newObj.transform.SetParent(Canvas.transform,false);
        newObj.transform.GetChild(1).GetComponent<Text>().text = Data.Name;
        newObj.transform.GetChild(2).GetComponent<Text>().text = Data.Price.ToString();
        newObj.GetComponent<Item>().ID = Data.ID.ToString();

        y += addy;
    }

}
