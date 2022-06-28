using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction
{
    public virtual bool Perform()
    {
        Debug.Log("Perform");

        return true;
    }

}
