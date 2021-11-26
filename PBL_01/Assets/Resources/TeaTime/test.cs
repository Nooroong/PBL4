using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{


        void Update()
        {
            float moveY = 0f;
            float moveX = 0f;

            if (Input.GetKey(KeyCode.W))       
            {
                moveY += 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveY -= 1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveX -= 1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveX += 1f;
            }
            transform.Translate(new Vector3(moveX, moveY, 0f) * 0.5f);
        }
}

