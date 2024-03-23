using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

[Serializable]
public class PlayerInfo
{
    public float Gold;
    public float TotalBet;  // 배팅한 총 금액
    public List<CardDeck> CardDecks;    // player는 5개의 카드덱을 가진다.
}

[Serializable]
public class DealerInfo
{
    public List<Card> Cards;
    public int Score
    {
        get
        {
            if (Cards == null)
            {
                Debug.Log("Dealer Cards null");
                return 0;
            }

            int score = 0;
            foreach (var card in Cards)
            {
                if (card != null)
                    score += card.Number;
            }

            return score;
        }
    }
}

public class PlayController
{
    public PlayerInfo PlayerInfo = new PlayerInfo();
    public DealerInfo DealerInfo = new DealerInfo();
    private CardManager _card = new CardManager();
    private int _currentCardDeckIdx;

    public void Init()
    {
        _card = Managers.Card;

        PlayerInfo.Gold = 100000;
        PlayerInfo.CardDecks = new List<CardDeck>()
        {
            new CardDeck(),
            new CardDeck(),
            new CardDeck(),
            new CardDeck(),
            new CardDeck(),
        };

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
        // 딜러 카드 분배
        DealerInfo.Cards.Add(_card.CallCard());
        DealerInfo.Cards.Add(_card.CallCard());

        // 플레이어 카드 분배
        foreach (var deck in PlayerInfo.CardDecks) 
        {
            if (deck.Bet > 0)
            {
                deck.Cards.Add(_card.CallCard());
                deck.Cards.Add(_card.CallCard());
            }
        }

        #region CardData Check
        foreach (var card in DealerInfo.Cards) 
        {
            if (card != null)
                Debug.Log($"Dealer : {card.Suit}{card.Number}");
            else
                break;
        }

        int idx = 0;
        foreach (var deck in PlayerInfo.CardDecks)
        {
            if (deck == null)
                continue;

            foreach (var card in PlayerInfo.CardDecks[idx].Cards)
            {
                if (card != null)
                    Debug.Log($"Player : {card.Suit}{card.Number}");
                else
                    break;
            }

            idx++;
        }
        #endregion
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
