using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private StageDataCount stageDataCount;
    [SerializeField] private CashData CashData;
    static bool flg = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!flg)
        {
            stageDataCount.CountStageData();
            flg = true;
        }
        else
        {
            CashData.CashLoad();
            Debug.Log("OK");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene(0);
    }
}


//Linuxクラウド系統のコマンド、AWSクラウド系統