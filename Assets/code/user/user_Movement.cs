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
            // GetAxisRaw는 -1, 0, 1의 정수 값 반환 → 즉각 반응
            float moveX = Input.GetAxisRaw("Horizontal"); // A, D
            float moveY = Input.GetAxisRaw("Vertical");   // W, S

            moveInput = new Vector2(moveX, moveY).normalized;
        }

        void FixedUpdate()
        {
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
    }
