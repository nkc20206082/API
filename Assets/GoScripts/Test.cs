using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Test : MonoBehaviour
{
    // �����o�ϐ�
    Process proc;

    // �A�v���N�����ɌĂ΂��
    void Start()
    {
        // �ʃA�v��(�v���Z�X)�N��
        proc = new Process();
        proc.StartInfo.FileName = "file:C:/Users/user/Desktop/Other/Assets/Test/Test.exe";   // �N��������ʃA�v�����������ɓ���ĉ�����(�t���p�X�w��ł���) 
        proc.Start();
    }

    // �A�v���I�����ɌĂ΂��
    private void OnApplicationQuit()
    {
        // �ʃA�v���I������

        if (!proc.HasExited)
        {
            // �ʃA�v�����N�����̏ꍇ�̂ݏI��������
            proc.CloseMainWindow();
        }

        proc.Close();
        proc = null;
    }
}
