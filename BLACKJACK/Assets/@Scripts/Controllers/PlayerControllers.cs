using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public float Gold;
    public List<CardDeck> CardDecks;    // player은 5개의 카드덱을 가진다.
}

public class PlayerControllers : MonoBehaviour
{
    public PlayerInfo playerInfo = new PlayerInfo();

    public void SelectCardDeck()
    {

    }

    public void Bet()
    {

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

    public void Surrender()
    {

    }
}
