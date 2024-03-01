using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string Type;
    public int Score;
}

public class CardDeck
{
    public List<Card> Cards;
    public int Bet;
    public string CardDeckID;
}

public class CardManager
{
    public List<Card> AllCard = new List<Card>();

    public void Init()
    {
        GenerateAllCard();
    }

    public void GenerateAllCard()
    {
        // 카드 생성
        string[] types = new string[] { "Spade", "Heart", "Diamond", "Clover" };
        List<Card> cards = new List<Card>();
        foreach (string type in types)
        {
            for (int i = 1; i < 14; i++)
            {
                cards[i - 1].Type = type;
                cards[i].Score = i;
            }
        }

        AllCard = SuffleAllCard(cards);
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
        Card card = AllCard[0];
        AllCard.RemoveAt(0);

        return card;
    }
}
