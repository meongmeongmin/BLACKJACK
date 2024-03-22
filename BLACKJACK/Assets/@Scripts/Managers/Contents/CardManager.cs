using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Card
{
    public string Suit;
    public int Number;
}

public class CardDeck
{
    public List<Card> Cards = new List<Card>();
    public float Bet;
    public int Score
    {
        get
        {
            if (Cards == null)
            {
                Debug.Log("Cards null");
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

public class CardManager
{
    public List<Card> AllCard = new List<Card>();
    private bool _init = false;

    public void Init()
    {
        _init = true;
        AllCard = SuffleAllCard(GenerateAllCard());
    }

    public List<Card> GenerateAllCard()
    {
        // 카드 생성
        string[] suits = Enum.GetNames(typeof(Define.CardSuit));
        List<Card> cards = new List<Card>();
        foreach (string suit in suits)
        {
            for (int i = 1; i < 14; i++)
            {
                Card card = new Card();
                card.Suit = suit;
                card.Number = i;
                cards.Add(card);
            }
        }

        return cards;
    }

    public List<Card> SuffleAllCard(List<Card> cards)
    {
        System.Random rand = new System.Random();
        int i = cards.Count;
        // Fisher-Yates shuffle
        while (i > 1) 
        {
            int j = rand.Next(i--);
            Card tmp = cards[i];
            cards[i] = cards[j];
            cards[j] = tmp;
        }

        return cards;
    }

    public Card CallCard()
    {
        if (_init) 
        {
            Card card = AllCard[0];
            AllCard.RemoveAt(0);

            return card;
        }
        
        return null;
    }
}
