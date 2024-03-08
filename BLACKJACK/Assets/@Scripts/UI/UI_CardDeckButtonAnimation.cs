using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardDeckButtonAnimation : UI_Base
{
    void Start()
    {
        // �׽�Ʈ��, ������ �ʿ���.
        BindEvent(gameObject, () => { ButtonOnPointerClickAnimation(gameObject.transform.GetChild(0).gameObject); });
    }

    // �׽�Ʈ��, ������ �ʿ���.
    public void ButtonOnPointerClickAnimation(GameObject go)
    {
        if (go == null) 
            return;
        
        go.SetActive(true);
        Debug.Log("Test");
    }
}
