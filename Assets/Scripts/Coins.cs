using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable
{
    public override void score(int ItemScore)
    {
        ItemScore = 100;
    }
}
