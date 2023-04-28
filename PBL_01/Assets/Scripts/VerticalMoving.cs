using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 블록 1칸의 면적: 128 px^2
// 각 블록들의 콜라이더 사이즈 == 각 변의 길이에서 - 4
// Rigidbody의 MovePositon()은 중간에 존재하는 다른 Rigidbody를 밀어낸다.
// 오브젝트의 크기를 알고 싶으면 콜라이더를 씌우고 콜라이더의 크기를 스크립트로 불러오면 된다.
// 벽 뚫기 방지: rigidbody로 오브젝트 이동시키기 + Collision Detection을 Continuous로 설정.

public class VerticalMoving : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float blockSpeed = 0.7f;
    // public LayerMask checkLayer;

    private Vector3 mousePosition = Vector3.zero;
    private Vector3 blockPosition = Vector3.zero;

    private Rigidbody2D rigidBody;
    private bool isdrag = false; // 드래그 중인지
    
    // private bool contactUpperWall = false; // 위쪽벽과 닿았는지
    // private bool contactLowerWall = false; // 아래쪽벽과 닿았는지
    // private float obj_size = 0.0f; // 콜라이더 세로 길이의 1/2
    // private RaycastHit2D hitUp; // 충돌 정보
    // private RaycastHit2D hitDown;
    


    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        // obj_size = this.GetComponent<BoxCollider2D>().bounds.extents.y/2;
    }


    private void Update() {
        // Debug.DrawRay(new Vector2(this.gameObject.transform.position.x,
        //                           this.gameObject.transform.position.y + obj_size),
        //               Vector2.up * 0.05f, Color.red);
        // Debug.DrawRay(new Vector2(this.gameObject.transform.position.x,
        //                           this.gameObject.transform.position.y - obj_size),
        //               Vector2.down * 0.05f, Color.red);

        // hitUp = Physics2D.Raycast(new Vector3(this.gameObject.transform.position.x,
        //                           this.gameObject.transform.position.y + obj_size,
        //                           this.gameObject.transform.position.z),
        //                          Vector2.up, 0.05f, checkLayer);
        // hitDown = Physics2D.Raycast(new Vector3(this.gameObject.transform.position.x,
        //                           this.gameObject.transform.position.y - obj_size,
        //                           this.gameObject.transform.position.z),
        //                          Vector2.down, 0.05f, checkLayer);
        
    }


    private void FixedUpdate() {
        // https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=lightene&logNo=220903657039
        // rigidBody.constraints: 블록끼리 충돌 시 선택하지 않은 블록이 밀리는 것을 방지

        if(isdrag) {
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX |
                                    RigidbodyConstraints2D.FreezeRotation;

            
            // https://www.youtube.com/watch?v=Ehk9fKBwS3Y
            mousePosition = new Vector3(transform.position.x,
                                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                        transform.position.z);
            blockPosition = Vector2.Lerp(transform.position, mousePosition, blockSpeed);
            rigidBody.MovePosition(blockPosition);



            // 블록이 움직이면 안되는 조건: (위쪽 벽에 붙음 && 마우스가 위로 올라감) || (아래쪽 벽에 붙음 && 마우스가 아래로 내려감)
            // if((!contactUpperWall || Input.GetAxis("Mouse Y") < 0.0f) &&
            //    (!contactLowerWall || Input.GetAxis("Mouse Y") > 0.0f)) {
                
            // }
        } else {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }


        
        // contactUpperWall = (hitUp.collider)? true : false;
        // contactLowerWall = (hitDown.collider)? true : false;
    }



    public void OnBeginDrag(PointerEventData eventData) {
        // 마우스 버튼을 누르기 시작한 시점
        isdrag = true;
    }


    public void OnDrag(PointerEventData eventData) {
        // OnDrag함수는 드래그를 하지 않으면(포인터가 이동하지 않으면) 실행되지 않는다.
    }


    public void OnEndDrag(PointerEventData eventData) {
        // 마우스 버튼을 때면
        isdrag = false;
        rigidBody.velocity = Vector2.zero;
    }
}

