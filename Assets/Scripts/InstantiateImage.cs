using UnityEngine;
using UnityEngine.UI;

public class InstantiateImage : MonoBehaviour
{
    [SerializeField] RawImage img;//増やすイメージの元
    [SerializeField] GameObject parent;//キャンバス

    float y = 0;
    float addy = 300;//生成間隔

    public void InstImage(int num)
    {
        for (int i = 1; i < num; i++)
        {
            y -= addy;
            RawImage ui = Instantiate(img, new Vector3(0, y, 0), Quaternion.identity);
            ui.transform.SetParent(this.parent.transform, false);
        }
    }
}
