using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_move : MonoBehaviour
{

    public float speed = 10;

    
    float yMove;
    bool up_state = true; // 표적이 위로 올라가는 상태면 true.


    /*
    up_state 변수를 쓰는 이유:
    속력이 빨라 타겟이 지정 좌표를 많이 넘어선 경우(여기서는 위로 넘어간 경우를 예시로 들겠다.),
    좌표 상으로 벗어난 상태이기 때문에 방향이 아래로 바뀔 것이다.
    그러나 범위를 '많이' 넘어선 상태여서 다음 프레임에서도 좌표가 벗어나 있다면,
    또 다시 방향이 바뀌어 위로 이동하게 될 것이다.
    여기서 만약 타겟의 이동 방향을 저장해놓은 변수가 있다면
    타겟의 이동 범위를 벗어났지만 아래로 내려오고 있으니 다시 방향을 바꿀 필요가 없다고 판단할 수 있게 된다.
    */


    // Start is called before the first frame update
    void Awake()
    {   
        
        
    }

    void Start() {
        if(Random.Range(0, 10) <= 4) {
            yMove = -speed;
            up_state = false;
        } else {
            yMove = speed;
            up_state = true; 
        }
    }


    void Update()
    {
        if (this.GetComponent<RectTransform>().anchoredPosition.y >= 680.0f &&
            up_state == true) {
            yMove = -speed;
            up_state = false;
        }
        
        if (this.GetComponent<RectTransform>().anchoredPosition.y <= 100.0f &&
            up_state == false) {
            yMove = speed;
            up_state = true;
        }
        
        transform.Translate(new Vector3(0, yMove, 0) * Time.deltaTime);
    }


    public void Stop()
    {
        speed = 0;
    }
}
