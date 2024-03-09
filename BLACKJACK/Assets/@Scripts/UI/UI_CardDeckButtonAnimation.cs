using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UI_CardDeckButtonAnimation : UI_Base
{
    private Transform SelectCardDeckIcon = null;

    void Start()
    {
        FindSelectCardDeckIcon();
        BindEvent(gameObject, ButtonOnPointerClickAnimation);
    }

    private void FindSelectCardDeckIcon()
    {
        foreach (Transform transform in gameObject.GetComponentsInChildren<Transform>(true))
        {
            if (transform.name.Contains("SelectCardDeckIconImage"))
            {
                SelectCardDeckIcon = transform;
                break;
            }
        }
    }

    public void ButtonOnPointerClickAnimation()
    {
        if (SelectCardDeckIcon == null)
            return;

        SelectCardDeckIcon.gameObject.SetActive(true);
        // 애니메이션 활성화
        // 수정 필요, 다른 카드덱을 클릭하면 이전 SelectCardDeckIconImage의 크기를 원상태로 되돌리고 SetActive를 false 해야함.
    }
}
