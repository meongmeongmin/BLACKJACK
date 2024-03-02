using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class ChipCommand : ICommand
{
    private Chip _chip;
    private PlayerControllers _player;

    public ChipCommand(PlayerControllers player, Chip chip)
    {
        _player = player;
        _chip = chip;
    }

    public void Execute()
    {
        _player.Bet(_chip);
    }
}
