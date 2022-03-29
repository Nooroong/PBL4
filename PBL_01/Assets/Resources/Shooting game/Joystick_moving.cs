using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick_moving : MonoBehaviour
{
    public RectTransform innerPad; //���� ��
    public float speed;

    private Joystick joystick;

    void Awake()
    {
        joystick = GameObject.FindObjectOfType<Joystick>();
    }


    void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        { //�̵�
            MoveControl();
        }
    }

    private void MoveControl()
    {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical; //���Ϸ� �̵��ϴ� ����
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal; //�¿�� �̵��ϴ� ����
        float stickAngle = Mathf.Abs(Mathf.Atan2(innerPad.anchoredPosition.x, innerPad.anchoredPosition.y) * Mathf.Rad2Deg); //���̽�ƽ ����

        this.transform.position += upMovement;
        this.transform.position += rightMovement;
    }
}
