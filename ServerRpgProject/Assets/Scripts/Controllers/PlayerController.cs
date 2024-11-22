using UnityEngine;
using UnityEngine.InputSystem;
using static Define;
public class PlayerController : CreatureController
{
    public InputActionReference moveInput;
    public InputActionReference attackInput;
    public float delayTime = 0.5f; // 평타 딜레이
    private float delayCounter;

    protected override void Init()
    {
        base.Init();

        DontDestroyOnLoad(this.gameObject);
    }

    protected override void UpdateController()
    {
        if (delayCounter > 0)
        {
            delayCounter -= Time.deltaTime;
            theRB.linearVelocity = Vector2.zero;
        }
        else
        {
            // 벗어날때 IDLE 상태로
            state = CreatureState.Idle;

            // InputSystem 활용하여 입력처리 + normalized로 대각속도도 일정하게 설정
            theRB.linearVelocity = moveInput.action.ReadValue<Vector2>().normalized * moveSpeed;

            if (attackInput.action.WasPressedThisFrame())
            {
                state = CreatureState.Skill;
                delayCounter = delayTime;
            }
            base.UpdateController();
        }


    }
}
