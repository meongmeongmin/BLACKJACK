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
        // �ִϸ��̼� Ȱ��ȭ
        // ���� �ʿ�, �ٸ� ī�嵦�� Ŭ���ϸ� ���� SelectCardDeckIconImage�� ũ�⸦ �����·� �ǵ����� SetActive�� false �ؾ���.
    }
}
