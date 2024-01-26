using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{

    public abstract void EnterState(GameObject go);
    public abstract void UpdateState(GameObject go);

}
