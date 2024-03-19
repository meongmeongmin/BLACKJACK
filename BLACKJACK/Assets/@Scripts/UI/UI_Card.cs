using UnityEngine;

public class UI_Card : UI_Base
{
    private Card _card;

    public override bool Init()
    {
        base.Init();
        return true;
    }

    public void SetInfo(Card card)
    {
        _card = card;
        Sprite spr = Managers.Resource.Load<Sprite>($"{_card.Suit}{_card.Number:D2}.sprite");
        GetComponent<SpriteRenderer>().sprite = spr;
    }
}
