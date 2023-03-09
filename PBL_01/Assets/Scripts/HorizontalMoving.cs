using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 블록 1칸의 면적: 128 px^2
// 각 블록들의 콜라이더 사이즈 == 각 변의 길이에서 - 4

public class HorizontalMoving : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Rigidbody2D rigidBody;
    private bool isdrag = false;
    private Vector2 x_move;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=lightene&logNo=220903657039
        // 블록끼리 충돌 시 선택하지 않은 블록이 밀리는 것을 방지

        if(isdrag) {
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY |
                                    RigidbodyConstraints2D.FreezeRotation;
            
            x_move = new Vector2(Input.GetAxis("Mouse X"), 0f);

            // https://cpp11.tistory.com/70
            if(Input.touchCount > 0) {
                x_move.x = Input.touches[0].deltaPosition.x;
            }

            rigidBody.velocity = x_move;
            // rigidBody.velocity = x_move / Time.deltaTime / 5;
        } else {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        isdrag = true;
    }


    public void OnDrag(PointerEventData eventData) {
        

        
    }


    public void OnEndDrag(PointerEventData eventData) {
        isdrag = false;
        rigidBody.velocity = Vector2.zero;
    }

}
