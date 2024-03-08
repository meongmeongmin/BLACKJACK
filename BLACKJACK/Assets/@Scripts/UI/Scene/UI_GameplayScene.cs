using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        BetText_1,
        BetText_2,
        BetText_3,
        BetText_4,
        BetText_5,
    }

    enum Images
    {
        SelectCardDeckIconImage_1,
        SelectCardDeckIconImage_2,
        SelectCardDeckIconImage_3,
        SelectCardDeckIconImage_4,
        SelectCardDeckIconImage_5,
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
        _player.Init();

        #region 바인딩
        BindObejct(typeof(GameObjects));
        BindButton(typeof(Buttons));
        BindText(typeof(Texts));
        BindImage(typeof(Images));

        BindEvent(Get<Button>((int)Buttons.HomeButton).gameObject, OnHomeButtonClick);
        BindEvent(Get<Button>((int)Buttons.MenuButton).gameObject, OnMenuButtonClick);
        // SetBetting의 버튼
        BindEvent(Get<Button>((int)Buttons.Chip10Button).gameObject, () => { OnChipButtonClick(Chip.Chip10); } );
        BindEvent(Get<Button>((int)Buttons.Chip50Button).gameObject, () => { OnChipButtonClick(Chip.Chip50); } );
        BindEvent(Get<Button>((int)Buttons.Chip100Button).gameObject, () => { OnChipButtonClick(Chip.Chip100); } );
        BindEvent(Get<Button>((int)Buttons.Chip500Button).gameObject, () => { OnChipButtonClick(Chip.Chip500); } );
        BindEvent(Get<Button>((int)Buttons.ClearChipButton).gameObject, () => { OnChipButtonClick(Chip.None); });
        BindEvent(Get<Button>((int)Buttons.PlayButton).gameObject, OnPlayButtonClick);
        // 카드덱 버튼
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_1).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_1); });
        GetButton((int)Buttons.CardDeckButton_1).GetOrAddComponent<UI_CardDeckButtonAnimation>();
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_2).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_2); });
        GetButton((int)Buttons.CardDeckButton_2).GetOrAddComponent<UI_CardDeckButtonAnimation>();
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_3).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_3); });
        GetButton((int)Buttons.CardDeckButton_3).GetOrAddComponent<UI_CardDeckButtonAnimation>();
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_4).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_4); });
        GetButton((int)Buttons.CardDeckButton_4).GetOrAddComponent<UI_CardDeckButtonAnimation>();
        BindEvent(Get<Button>((int)Buttons.CardDeckButton_5).gameObject, () => { OnCardDeckButtonClick(Buttons.CardDeckButton_5); });
        GetButton((int)Buttons.CardDeckButton_5).GetOrAddComponent<UI_CardDeckButtonAnimation>();
        #endregion

        _player.SelectCardDeck(0);
        
        // 테스트용 수정이 필요함
        GetImage((int)Images.SelectCardDeckIconImage_1).gameObject.SetActive(true);
        GetImage((int)Images.SelectCardDeckIconImage_2).gameObject.SetActive(false);
        GetImage((int)Images.SelectCardDeckIconImage_3).gameObject.SetActive(false);
        GetImage((int)Images.SelectCardDeckIconImage_4).gameObject.SetActive(false);
        GetImage((int)Images.SelectCardDeckIconImage_5).gameObject.SetActive(false);

        Refresh();
    }

    private void Refresh()
    {
        GetText((int)Texts.GoldText).text = _player.PlayerInfo.Gold.ToString();
        GetText((int)Texts.BetText_1).text = _player.PlayerInfo.CardDecks[0].Bet.ToString();
        GetText((int)Texts.BetText_2).text = _player.PlayerInfo.CardDecks[1].Bet.ToString();
        GetText((int)Texts.BetText_3).text = _player.PlayerInfo.CardDecks[2].Bet.ToString();
        GetText((int)Texts.BetText_4).text = _player.PlayerInfo.CardDecks[3].Bet.ToString();
        GetText((int)Texts.BetText_5).text = _player.PlayerInfo.CardDecks[4].Bet.ToString();
    }

    #region 버튼 클릭 이벤트
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

        Refresh();
    }

    private void OnPlayButtonClick()
    {
        GetObejct((int)GameObjects.SetBetting).SetActive(false);
    }

    private void OnCardDeckButtonClick(Buttons button)
    {
        switch (button)
        {
            case Buttons.CardDeckButton_1:
                _player.SelectCardDeck(0);
                break;
            case Buttons.CardDeckButton_2:
                _player.SelectCardDeck(1);
                break;
            case Buttons.CardDeckButton_3:
                _player.SelectCardDeck(2);
                break;
            case Buttons.CardDeckButton_4:
                _player.SelectCardDeck(3);
                break;
            case Buttons.CardDeckButton_5:
                _player.SelectCardDeck(4);
                break;
        }
    }
    #endregion
}
