using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public float Gold;
    public List<CardDeck> CardDecks;    // player�� 5���� ī�嵦�� ������.
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
