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

    enum Images
    {
        SelectCardDeckIconImage,
    }
    #endregion

    private PlayerControllers _player;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        _player = new PlayerControllers();

        #region ���ε�
        BindObejct(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

        BindEvent(Get<Button>((int)Buttons.HomeButton).gameObject, OnHomeButtonClick);
        BindEvent(Get<Button>((int)Buttons.MenuButton).gameObject, OnMenuButtonClick);
        BindEvent(Get<Button>((int)Buttons.Chip10Button).gameObject, () => { OnChipButtonClick(Chip.Chip10); } );
        BindEvent(Get<Button>((int)Buttons.Chip50Button).gameObject, () => { OnChipButtonClick(Chip.Chip50); } );
        BindEvent(Get<Button>((int)Buttons.Chip100Button).gameObject, () => { OnChipButtonClick(Chip.Chip100); } );
        BindEvent(Get<Button>((int)Buttons.Chip500Button).gameObject, () => { OnChipButtonClick(Chip.Chip500); } );
        BindEvent(Get<Button>((int)Buttons.ClearChipButton).gameObject, () => { OnChipButtonClick(Chip.None); });
        BindEvent(Get<Button>((int)Buttons.PlayButton).gameObject, OnPlayButtonClick);
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_1).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_1); });
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_2).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_2); });
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_3).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_3); });
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_4).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_4); });
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_5).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_5); });
        #endregion
    }

    private void OnHomeButtonClick()
    {
        Managers.Scene.LoadScene(Scene.HomeScene);
    }

    private void OnMenuButtonClick()
    {
        Managers.UI.ShowPopupUI<UI_MenuPopup>();
    }

    private void OnChipButtonClick(Chip chip)
    {
        switch (chip)
        {
            case Chip.None:
                _player.Bet(chip);
                break;
            case Chip.Chip10:
                _player.Bet(chip);
                break;
            case Chip.Chip50:
                _player.Bet(chip);
                break;
            case Chip.Chip100:
                _player.Bet(chip);
                break;
            case Chip.Chip500:
                _player.Bet(chip);
                break;
        }

        GetText((int)Texts.GoldText).text = _player.playerInfo.Gold.ToString();
    }

    private void OnPlayButtonClick()
    {
        GetObejct((int)GameObjects.SetBetting).SetActive(false);
    }

    private void OnCardDeckButtonClick(Buttons button)
    {
        switch (button)
        {

        }
    }
}
