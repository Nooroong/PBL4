using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 블록 1칸의 면적: 128 px^2
// 각 블록들의 콜라이더 사이즈 == 각 변의 길이에서 - 4

public class VerticalMoving : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Rigidbody2D rigidBody;
    private bool isdrag = false;
    private Vector2 y_move;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=lightene&logNo=220903657039
        // rigidBody.constraints: 블록끼리 충돌 시 선택하지 않은 블록이 밀리는 것을 방지

        if(isdrag) {
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX |
                                    RigidbodyConstraints2D.FreezeRotation;

            y_move = new Vector2(0f, Input.GetAxis("Mouse Y"));

            // https://cpp11.tistory.com/70 (모바일 환경 처리)
            if(Input.touchCount > 0) {
                y_move.y = Input.touches[0].deltaPosition.y;
            }

            rigidBody.velocity = y_move;
        } else {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        // 마우스 버튼을 누르기 시작한 시점
        isdrag = true;
    }


    public void OnDrag(PointerEventData eventData) {
        // 드래그를 하지 않으면(포인터가 이동하지 않으면) 함수가 실행되지 않는다.
        // 그래서 드래그를 멈춰도 rigidbody의 속력이 0이 되지 않는다.
        // (드래그를 멈추기 직전의 속력이 계속 적용되는듯?)
        // 이를 해결하기 위해 이 부분의 코드는 update 함수에서 처리한다.
        
    }


    public void OnEndDrag(PointerEventData eventData) {
        // 마우스 버튼을 때면
        isdrag = false;
        rigidBody.velocity = Vector2.zero;
    }
}

