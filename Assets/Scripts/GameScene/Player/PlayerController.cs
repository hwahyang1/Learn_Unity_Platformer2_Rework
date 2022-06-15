using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220531_Platform2Rework.GameScene.UI;

/*
 * [Class] PlayerController
 * 플레이어의 이동을 관리합니다.
 * 
 * 코드의 원본은 Cainos.PixelArtTopDown_Basic.TopDownCharacterController에서 찾을 수 있습니다.
 */
public class PlayerController : MonoBehaviour
{
    public float speed;

    private Animator animator;

    private ShowScript script;

    private void Start()
    {
        animator = GetComponent<Animator>();

        ShowScript[] objs = Resources.FindObjectsOfTypeAll<ShowScript>();
        script = objs[0];
    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;

        if (script.isEnd)
        {
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}
