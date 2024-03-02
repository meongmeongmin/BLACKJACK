using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UI_GameplayScene : UI_Scene
{
    #region enum
    enum GameObjects
    {
        SetBetting,
    }

    enum Buttons
    {
        HomeButton,
        MenuButton,
        Chip10Button,
        Chip50Button,
        Chip100Button,
        Chip500Button,
        ClearChipButton,
        PlayButton,
        CardDeckButton_1,
        CardDeckButton_2,
        CardDeckButton_3,
        CardDeckButton_4,
        CardDeckButton_5,
    }

    enum Texts
    {
        GoldText,
    }
    #endregion

    private PlayerControllers _player;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        _player = new PlayerControllers();

        Bind<GameObject>(typeof(GameObjects));
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        BindEvent(Get<Button>((int)Buttons.HomeButton).gameObject, OnHomeButtonClick, null, UIEvent.Click);
    }

    public void UpdateGoldText(float text)
    {
        // GoldText.text = text.ToString();
    }

    public void OnHomeButtonClick()
    {
        Managers.Scene.LoadScene(Scene.HomeScene);
    }
}
