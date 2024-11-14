using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableOrb : ItemCollectableBase
{

    protected override void Collect()
    {
        base.OnCollect();
        ItemManager.Instance.AddOrbs();
    }

}
