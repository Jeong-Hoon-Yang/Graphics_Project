using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IA_Test : MonoBehaviour
{
    public GameObject BP;//�� ������ BP, �̸� �־����
    public GameObject myCanvas;//�� ������ UI, �̸� �־����
    public GameObject player;//���� �ִ� Player
    public GameObject RoomMenu;//���� UI
    public GameObject MenuPanel;//���� UI�� �ڽ� UI
    public GameObject Open_Button;//���� ��ư
    public GameObject BackToSelect_button;//�ڷΰ��� ��ư
    public GameObject furnitureMenu;//�����޴�
    public GameObject textureMenu;//�ؽ��ĸ޴�
    public int LayerMask;//���̾� ����ũ
    public Vector3 scaleVec;
    public bool BP_Mode;
    public bool IA_Mode;
    public bool touchMe;
    public bool UIToched;//UI�� ��ġ�Ǿ����� Ȯ���ϴ� ����
    public Touch tempTouch;
    RaycastHit hit;
    public Vector3 IA_eulerAngles;
    public Quaternion IA_Quaternian;
    public float IA_RotY;
    // Start is called before the first frame update
    void Start()
    {
        IA_eulerAngles = gameObject.transform.eulerAngles;
        IA_Quaternian = gameObject.transform.rotation;
        //Debug.Log("IA_eulerAngles = " + IA_eulerAngles);
        //Debug.Log("IA_Quaternian = " + IA_Quaternian);

        gameObject.layer = 9;//�������̾�
        player = GameObject.Find("Player");
        scaleVec = GameObject.Find("BP_Canvas").GetComponent<BP_Canvas>().BP_ScaleVec;//BP�� ScaleVec�� �޾ƿ�
        IA_RotY = GameObject.Find("BP_Canvas").GetComponent<BP_Canvas>().BP_RotY;//BP�� y�ప
        RoomMenu = GameObject.Find("Canvas");
        RoomMenu = RoomMenu.transform.GetChild(0).gameObject;
        MenuPanel = RoomMenu.transform.GetChild(3).gameObject;
        furnitureMenu = RoomMenu.transform.GetChild(4).gameObject;
        textureMenu = RoomMenu.transform.GetChild(5).gameObject;
        Open_Button = RoomMenu.transform.GetChild(6).gameObject;
        BackToSelect_button = RoomMenu.transform.GetChild(7).gameObject;
        //Debug.Log("IA_RotY = " + IA_RotY);

        IA_Mode = false;
        touchMe = false;
        gameObject.transform.localScale = scaleVec;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IA_Mode = player.GetComponent<Move>().IA_Mode;
        BP_Mode = player.GetComponent<Move>().BP_Mode;
        //��ġ ����
        if (furnitureMenu.activeSelf == false)
        {
            if (Input.touchCount > 0)//��ġ�� �ϳ� �̻��̸�
            {
                tempTouch = Input.GetTouch(0);//ù��° ��ġ�� ��ǲ���� �Ѵ�
                Ray ray = Camera.main.ScreenPointToRay(tempTouch.position);
                if (furnitureMenu.GetComponent<furnitureMenu>().furnitureChoosed == false)
                {
                    if (tempTouch.phase == TouchPhase.Began)
                    {
                        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))//���̾� 9�� ���̸� ��, ���̾�9�� Furniture��
                        {
                            if (hit.collider.gameObject == gameObject)//��ġ�Ȱ� ��(����)�� touchMe�� ������ �ٲ�
                            {
                                touchMe = true;
                            }
                        }
                    }
                }
                if (tempTouch.position.x > 2640 && tempTouch.position.x < 3120) //G7:2640,3120   IPad:1914,2388
                {
                    if (tempTouch.position.y < 472 && tempTouch.position.y > 0)//472,0     473,0
                    {
                        UIToched = true;
                    }
                    else
                    {
                        UIToched = false;
                    }
                }

                if (touchMe)
                {
                    if (!UIToched)
                    {
                        if (tempTouch.phase == TouchPhase.Ended)
                        {
                            if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))//���̾� 9�� ���̸� ��, ���̾�9�� Furniture��
                            {
                                if (MenuPanel.activeSelf == false && furnitureMenu.activeSelf == false && textureMenu.activeSelf == false)
                                {
                                    if (BP_Mode == false && IA_Mode == false)
                                    {
                                        player.GetComponent<Move>().CanRotate = false;//UI���鼭 �÷��̾� ȸ�� ����
                                        myCanvas.SetActive(true);
                                        Open_Button.SetActive(false);
                                        BackToSelect_button.SetActive(false);
                                        //IA_Mode = true;
                                        player.GetComponent<Move>().IA_Mode = true;
                                        touchMe = false;

                                    }
                                }
                            }
                        }
                    }
                }
                if (tempTouch.phase == TouchPhase.Ended)
                {
                    touchMe = false;
                    UIToched = false;
                }
            }
        }
        //��ġ ��
    }

    private void OnMouseEnter()
    {

    }
    //���콺
    //private void OnMouseOver()//������ Ŭ��,��ġ �ϸ� UI�� ���
    //{
    //    if (MenuPanel.activeSelf == false && furnitureMenu.activeSelf == false && textureMenu.activeSelf == false)
    //    {
    //        if (Input.GetMouseButtonUp(0) && BP_Mode == false && IA_Mode == false)//�ƹ� UI�� �ȶ���� ������
    //        {
    //            player.GetComponent<Move>().CanRotate = false;//UI���鼭 �÷��̾� ȸ�� ����
    //            player.GetComponent<Move>().IA_Mode = true;//UI��� ����
    //            myCanvas.SetActive(true);//��ȣ�ۿ� Canvas ����
    //            Open_Button.SetActive(false);//���¹�ư ��
    //            BackToSelect_button.SetActive(false);//�ڷΰ��� ��ư ��
    //        }
    //    }
    //}
    //���콺 ��
    private void OnMouseExit()
    {

    }
}
