using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour   //Player�� ���¸� �������� ����
{
    private Touch tempTouch;

    public bool BP_Mode;//UI����
    public bool IA_Mode;//UI����
    public bool Menu_Mode;//UI����

    public float speed = 0.5f;
    float rotateSpeed = 3;
    float mouseX = 0;
    float mouseY = 0;
    int Gcount = 0;

    public bool CanRotate;

    CharacterController cc;

    // Start is called before the first frame update
    //void Start()
    //{
    //    BP_Mode = false;
    //    IA_Mode = false;
    //    cc = GetComponent<CharacterController>();
    //    CanRotate = true;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    move();
    //    //���콺
    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        Gcount++;
    //    }
    //    if (Gcount % 2 == 0)
    //    {
    //        rotate();
    //    }
    //    //���콺

    //    //��ġ
    //    //if (CanRotate)
    //    //{
    //    //    rotate();
    //    //}
    //    //��ġ

    //    //if (Input.touchCount > 0)
    //    //{
    //    //    tempTouch = Input.GetTouch(0);
    //    //    if (tempTouch.phase == TouchPhase.Began)
    //    //    {
    //    //        Debug.Log("Touch began");
    //    //    }
    //    //}
    //}
    //void move()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float y = Input.GetAxis("Vertical");

    //    Vector3 move = new Vector3(x, 0, y);

    //    cc.Move(transform.TransformDirection(move) * Time.deltaTime * speed);
    //}
    //void rotate()
    //{
    //    mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
    //    mouseY += Input.GetAxis("Mouse Y") * rotateSpeed;

    //    mouseY = Mathf.Clamp(mouseY, -70f, 70f);

    //    transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    //}
}
