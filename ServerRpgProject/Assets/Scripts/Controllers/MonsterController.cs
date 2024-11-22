using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using static Define;

public class MonsterController : CreatureController
{

    protected override void Init()
    {
        base.Init();

    }
    protected override void UpdateController()
    {
        theRB.linearVelocity = new Vector2(1, 0);
        base.UpdateController();
    }
}
