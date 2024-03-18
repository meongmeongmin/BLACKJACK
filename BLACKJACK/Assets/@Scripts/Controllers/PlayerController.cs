using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

[Serializable]
public class PlayerInfo
{
    public float Gold;
    public float TotalBet;  // ������ �� �ݾ�
    public List<CardDeck> CardDecks;    // player�� 5���� ī�嵦�� ������.
}

[Serializable]
public class DealerInfo
{
    public List<Card> Cards;
    public int Score;
}

public class PlayerController
{
    public PlayerInfo PlayerInfo = new PlayerInfo();
    public DealerInfo DealerInfo;
    private int _currentCardDeckIdx;

    public void Init()
    {
        PlayerInfo.Gold = 100000;
        PlayerInfo.CardDecks = new List<CardDeck>();
        PlayerInfo.CardDecks.Add(new CardDeck());
        PlayerInfo.CardDecks.Add(new CardDeck());
        PlayerInfo.CardDecks.Add(new CardDeck());
        PlayerInfo.CardDecks.Add(new CardDeck());
        PlayerInfo.CardDecks.Add(new CardDeck());

        DealerInfo.Cards = new List<Card>();
    }

    public void SelectCardDeck(int cardDeckIdx)
    {
        _currentCardDeckIdx = cardDeckIdx;
    }

    public void Bet(Chip chip)
    {
        if (chip == Chip.None)
        {
            Debug.Log("Clear");
            PlayerInfo.Gold += PlayerInfo.CardDecks[_currentCardDeckIdx].Bet * 1000;
            PlayerInfo.TotalBet -= PlayerInfo.CardDecks[_currentCardDeckIdx].Bet;
            PlayerInfo.CardDecks[_currentCardDeckIdx].Bet = 0;
            return;
        }

        if (PlayerInfo.Gold >= (int)chip)
        {
            Debug.Log("Bet");
            PlayerInfo.Gold -= (int)chip;
            PlayerInfo.TotalBet += (int)chip / 1000;
            PlayerInfo.CardDecks[_currentCardDeckIdx].Bet += (int)chip / 1000;
        }
    }

    public void Play()
    {
        Managers.Card.Init();
        // ���� ī�� �й�
        DealerInfo.Cards.Add(Managers.Card.CallCard());
        DealerInfo.Cards.Add(Managers.Card.CallCard());

        // �÷��̾� ī�� �й�
        foreach (var deck in PlayerInfo.CardDecks) 
        {
            if (deck.Bet > 0)
            {
                deck.Cards.Add(Managers.Card.CallCard());
                deck.Cards.Add(Managers.Card.CallCard());
            }
        }
    }

    public void Hit()
    {
        
    }

    public void Stand()
    {
        
    }

    public void DoubleDown()
    {
        
    }

    public void Split()
    {
        
    }

    public void Surrender()
    {

    }
}
