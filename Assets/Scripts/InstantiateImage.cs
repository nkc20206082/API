using UnityEngine;
using UnityEngine.UI;

public class InstantiateImage : MonoBehaviour
{
    [SerializeField] RawImage img;//���₷�C���[�W�̌�
    [SerializeField] GameObject parent;//�L�����o�X

    float y = 0;
    float addy = 300;//�����Ԋu

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
