using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateAnimation(Vector2 input)
    {
        bool isMoving = input.sqrMagnitude > 0.01f;
        animator.SetBool("IsMoving", isMoving);

        // �¿� ���� �Ǵ� (x�ุ ���)
        if (isMoving && Mathf.Abs(input.x) > 0.01f)
        {
            spriteRenderer.flipX = input.x < 0f;
        }
    }
}
