using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameplayScene : UI_Base
{
    // 버튼
    public Button HomeButton;
    public Button MenuButton;
    public Button Chip10Button;
    public Button Chip50Button;
    public Button Chip100Button;
    public Button Chip500Button;
    public Button ClearChipButton;
    public Button PlayButton;
    public List<Button> CardDeckButton;
    // 텍스트
    public TextMeshPro GoldText;
    // 게임 오브젝트
    public GameObject SetBetting;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        
        // 너무 하드코딩해서 최적화하고 싶음.
        // 상단 메뉴
        HomeButton = GameObject.Find("HomeButton").GetComponent<Button>();
        MenuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        // CardDeck
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_1").GetComponentInChildren<Button>());
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_2").GetComponentInChildren<Button>());
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_3").GetComponentInChildren<Button>());
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_4").GetComponentInChildren<Button>());
        CardDeckButton.Add(GameObject.Find("PlayerCardDeck_5").GetComponentInChildren<Button>());
        // Gold
        GoldText = GameObject.Find("GoldText").GetComponent<TextMeshPro>();
        // Set Betting
        SetBetting = GameObject.Find("SetrBetting");   // 나중에 UIManager을 응용할 것.
        // Chip
        Chip10Button = GameObject.Find("Chip10Button").GetComponent<Button>();
        Chip50Button = GameObject.Find("Chip50Button").GetComponent<Button>();
        Chip100Button = GameObject.Find("Chip100Button").GetComponent<Button>();
        Chip500Button = GameObject.Find("Chip500Button").GetComponent<Button>();
        Chip500Button = GameObject.Find("Chip500Button").GetComponent<Button>();
        ClearChipButton = GameObject.Find("ClearChipButton").GetComponent<Button>();
        // Play
        PlayButton = GameObject.Find("PlayButton").GetComponent<Button>();

        HomeButton?.onClick.AddListener(OnHomeButtonClick);
    }

    public void UpdateGoldText(float text)
    {
        GoldText.text = text.ToString();
    }

    public void OnHomeButtonClick()
    {
        Managers.Scene.LoadScene(Define.Scene.HomeScene);
    }
}
