using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerMovement2D : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private Rigidbody2D rb;
        private Vector2 moveInput;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            user_move();
        }
        void user_move()
        {
            // GetAxisRaw�� -1, 0, 1�� ���� �� ��ȯ �� �ﰢ ����
            float moveX = Input.GetAxisRaw("Horizontal"); // A, D
            float moveY = Input.GetAxisRaw("Vertical");   // W, S

            moveInput = new Vector2(moveX, moveY).normalized;
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
    }
