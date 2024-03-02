using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        Get<TMP_Text>((int)Texts.GoldText).text = "Test";

        // 커맨드 연결
        var chip10Command = new ChipCommand(_player, Chip.Chip10);
        var chip50Command = new ChipCommand(_player, Chip.Chip50);
        var chip100Command = new ChipCommand(_player, Chip.Chip100);
        var chip500Command = new ChipCommand(_player, Chip.Chip500);
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
