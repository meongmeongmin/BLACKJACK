using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardDeckButtonAnimation : UI_Base
{
    void Start()
    {
        // 테스트용, 수정이 필요함.
        BindEvent(gameObject, () => { ButtonOnPointerClickAnimation(gameObject.transform.GetChild(0).gameObject); });
    }

    // 테스트용, 수정이 필요함.
    public void ButtonOnPointerClickAnimation(GameObject go)
    {
        if (go == null) 
            return;
        
        go.SetActive(true);
        Debug.Log("Test");
    }
}
