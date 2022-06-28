using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAction
{
    /// <summary>
    /// These should be modifiers that affect 
    /// various things during the growth phase.
    /// </summary>
    /// <returns></returns>
    public virtual bool ApplyModifiers()
    {
        Debug.Log("ApplyModifiers");

        return true;
    }

}
