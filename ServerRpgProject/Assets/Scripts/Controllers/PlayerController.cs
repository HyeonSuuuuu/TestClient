using UnityEngine;
using UnityEngine.InputSystem;
using static Define;
public class PlayerController : CreatureController
{
    public InputActionReference moveInput;
    public InputActionReference attackInput;
    public float delayTime = 0.5f; // ��Ÿ ������
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
            // ����� IDLE ���·�
            state = CreatureState.Idle;

            // InputSystem Ȱ���Ͽ� �Է�ó�� + normalized�� �밢�ӵ��� �����ϰ� ����
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
