using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameplayScene : UI_Base
{
    public Button HomeButton;
    public Button MenuButton;

    public TextMeshPro GoldText;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        HomeButton = GameObject.Find("HomeButton").GetComponent<Button>();
        MenuButton = GameObject.Find("MenuButton").GetComponent<Button>();

        GoldText = GameObject.Find("GoldText").GetComponent<TextMeshPro>();

        HomeButton?.onClick.AddListener(OnHomeButtonClick);
    }

    public void OnHomeButtonClick()
    {
        Managers.Scene.LoadScene(Define.Scene.HomeScene);
    }
}
