using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Canvas : MonoBehaviour
{
    public GameObject player;//�÷��̾�
    public GameObject RoomMenu;//���� UI
    public GameObject myMenu;
    public GameObject Menu;
    public GameObject parentBP;//�θ��� BluePrint
    public GameObject Open_Button;
    public GameObject BackToSelect_button;
    public Vector3 IA_Scale;//ũ�⺯��
    public float IA_RotY;//ȸ������
    //public bool IA_Mode;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
        IA_Scale = gameObject.transform.parent.GetComponent<IA_Test>().scaleVec;//������ ������ ũ�⺤��
        IA_RotY = gameObject.transform.parent.GetComponent<IA_Test>().IA_RotY;//������ ������ ȸ����
        parentBP = gameObject.transform.parent.GetComponent<IA_Test>().BP;//�θ��� BP�� ������
        player = GameObject.Find("Player");
        myMenu = GameObject.Find("Canvas");
        RoomMenu = myMenu.transform.GetChild(0).gameObject;
        myMenu = RoomMenu.transform.GetChild(3).gameObject;
        Open_Button = RoomMenu.transform.GetChild(6).gameObject;
        BackToSelect_button = RoomMenu.transform.GetChild(7).gameObject;


        myMenu.SetActive(false);
        //IA_Mode = GameObject.Find("Player").GetComponent<Move>().IA_Mode;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EditButton()
    {
        GameObject.Find("Player").GetComponent<Move>().IA_Mode = false;
        BackToSelect_button.SetActive(false);
        Instantiate(parentBP,
            gameObject.transform.parent.gameObject.transform.position,
            gameObject.transform.parent.gameObject.transform.rotation);
        //Debug.Log("BP �ν��Ͻ�ȭ " + Time.time);
        //StartCoroutine(WaitForDestroy());
        //if (check)
        //{
            Destroy(transform.parent.gameObject);
            //Debug.Log("���� ���� " + Time.time);
        //}
    }
    public void DeleteButton()
    {
        //������� ����
        RoomMenu.SetActive(true);
        myMenu.SetActive(false);
        Open_Button.SetActive(true);
        BackToSelect_button.SetActive(true);
        player.GetComponent<Move>().IA_Mode = false;
        player.GetComponent<Move>().Menu_Mode = false;
        gameObject.transform.parent.GetComponent<IA_Test>().player.GetComponent<Move>().CanRotate = true;
        Destroy(transform.parent.gameObject);
    }
    public void CancleButton()
    {
        //������� ����
        RoomMenu.SetActive(true);
        myMenu.SetActive(false);
        Open_Button.SetActive(true);
        BackToSelect_button.SetActive(true);
        player.GetComponent<Move>().IA_Mode = false;
        player.GetComponent<Move>().Menu_Mode = false;
        gameObject.transform.parent.GetComponent<IA_Test>().player.GetComponent<Move>().CanRotate = true;
        gameObject.SetActive(false);
        Menu.SetActive(true);
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        check = true;
    }
}
