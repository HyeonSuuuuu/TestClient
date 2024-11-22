using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Define;

public class CreatureController : MonoBehaviour
{

    protected CreatureState state = CreatureState.Idle;
    protected Rigidbody2D theRB;
    public float moveSpeed;
    protected Animator anim;

    // 임시
    public Vector3Int CellPos { get; set; } = Vector3Int.zero;

    public CreatureState State
    {
        get { return state; }
        set
        {
            if (state == value)
                return;
            state = value;
        }
    }



    void Start()
    {
        Init();
    }
    void Update()
    {
        UpdateController();
    }

    protected virtual void Init()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
    }

    protected virtual void UpdateController()
    {
        UpdateState();
        
    }

    void UpdateState()
    {
        // x 속도값을 보고 x축 Flip
        if (theRB.linearVelocityX > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (theRB.linearVelocityX < 0f)
        {
            transform.localScale = Vector3.one;
        }

        // 속도총합으로 상태 체크

        if ((int)state < 2) // IDLE, MOVING 일때만
        {
            if (theRB.linearVelocity.magnitude > 0f)
                state = CreatureState.Moving;
            else
                state = CreatureState.Idle;
        }

        // 에니메이터에 인자 전달
        anim.SetInteger("State", (int)state);
    }


}