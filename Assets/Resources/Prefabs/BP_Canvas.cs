using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BP_Canvas : MonoBehaviour
{
    public GameObject myMenu;
    public GameObject player;//���� �ִ� player
    public GameObject Menu;//ĵ������ �޴�
    public GameObject parentPrefab;//BP�� ������, ������ ����
    public GameObject RoomMenu;
    public GameObject Open_Button;//�����ư
    public GameObject BackToSelect_button;//�ڷΰ����ư
    public GameObject parentCode;
    public GameObject Joystick;//���̽�ƽ
    public GameObject rotater;//ȸ�������ִ°�
    
    public Slider RotationSlider;//ȸ�������̴�
    public Slider ScaleSlider;//ũ�⽽���̴�
    public bool place;        //������ ���� �� �ִ��� üũ�ϴ� ����
    public bool furnitureChoosed;//�޴����� ������ ���õǾ��� �� true
    public Vector3 BP_ScaleVec;//BP�� ũ�⺤��
    //public Vector3 BP_RotaionVec;
    public Vector3 tempVec;//�ӽð�
    public Vector3 IA_Scale;//������ ������ ũ�⺤��
    //public Vector3 IA_Rotation;
    public Vector3 OriginScale;//������ ����ũ��
    public float OriginRotY;//������ ���� ȸ��ũ��
    public float BP_RotY;//BP�� ȸ����
    public float IA_RotY;//������ ������ ȸ����
    //public bool BP_On;
    int ScaleCount;
    int ScaleUpLimit;
    int ScaleDownLimit;
    // Start is called before the first frame update
    void Start()
    {
        //BP_On = true;//��ġ��� On
        //playerã��
        player = GameObject.Find("Player");//���� Player�� ã�´�
        player.GetComponent<Move>().BP_Mode = true;//BP_Mode�� true�� �ٲ� -> ȸ��,�̵� �Ұ���
        myMenu = GameObject.Find("Canvas");
        RoomMenu = myMenu.transform.GetChild(0).gameObject;
        myMenu = RoomMenu.transform.GetChild(3).gameObject;
        rotater = RoomMenu.transform.GetChild(1).gameObject;
        Joystick = RoomMenu.transform.GetChild(2).gameObject;
        Open_Button = RoomMenu.transform.GetChild(6).gameObject;
        BackToSelect_button = RoomMenu.transform.GetChild(7).gameObject;
        furnitureChoosed = RoomMenu.transform.GetChild(4).gameObject.GetComponent<furnitureMenu>().furnitureChoosed;
        Open_Button.SetActive(false);
        BackToSelect_button.SetActive(false);
        rotater.SetActive(false);
        Joystick.SetActive(false);
        //
        //Debug.Log("BP_Canvas start "+Time.time);
        //ScaleCount = 0;//��ư�� ����
        //ScaleUpLimit = 5;
        //ScaleDownLimit = -5;

        if (null != gameObject.transform.parent.GetComponent<BP_Test>())
        {
            parentPrefab = gameObject.transform.parent.GetComponent<BP_Test>().prefab;
            place = gameObject.transform.parent.GetComponent<BP_Test>().place;
        }
        else if (null != gameObject.transform.parent.GetComponent<BP_Deco_script>())
        {
            parentPrefab = gameObject.transform.parent.GetComponent<BP_Deco_script>().prefab;
            place = gameObject.transform.parent.GetComponent<BP_Deco_script>().place;
        }
        //parentPrefab = gameObject.transform.parent.GetComponent<BP_Test>().prefab;//�θ�BP�� ������

        OriginScale = parentPrefab.transform.localScale;//�θ�BP�� ���� ũ��..
        OriginRotY = 180.0f;//�θ�BP�� ���� Y�ప

        BP_ScaleVec = transform.parent.gameObject.transform.localScale;
        BP_RotY = transform.parent.gameObject.transform.eulerAngles.y;

        //Debug.Log(GameObject.Find("IA_Canvas"));
        if (null != GameObject.Find("IA_Canvas"))//������ ������ ������ ��
        {
            IA_Scale = GameObject.Find("IA_Canvas").GetComponent<IA_Canvas>().IA_Scale;//������ ������ �����Ϻ���
            BP_ScaleVec = IA_Scale;

            IA_RotY = GameObject.Find("IA_Canvas").GetComponent<IA_Canvas>().IA_RotY;
            BP_RotY = IA_RotY;
            //Debug.Log("BP_RotY = " + BP_RotY);
        }

        //Debug.Log(tempVec);        
        tempVec = BP_ScaleVec;//�ӽð��� ����
        if (tempVec.x != OriginScale.x)//���� ũ��� �ٸ���
        {
            //Debug.Log(tempVec.x);
            //Debug.Log(OriginScale.x);
            float tempX = tempVec.x / OriginScale.x;
            float tempY = tempVec.y / OriginScale.y;
            float tempZ = tempVec.z / OriginScale.z;            
            BP_ScaleVec.x /= tempX;
            BP_ScaleVec.y /= tempY;
            BP_ScaleVec.z /= tempZ;
            tempX = (tempX - 1) * 10;
            tempY = (tempY - 1) * 10;
            tempZ = (tempZ - 1) * 10;
            ScaleSlider.value += tempX;
            //Debug.Log(ScaleSlider.value);
            //Debug.Log(BP_ScaleVec);
        }

        if (BP_RotY != OriginRotY)//���� ������ �ٸ���
        {
            float tempY = BP_RotY - OriginRotY;
            //Debug.Log("tempY = " + tempY);
            BP_RotY -= tempY;
            //Debug.Log("BP_RotY = " + BP_RotY);
            tempY = tempY / 15;
            RotationSlider.value += tempY;
            //Debug.Log("RotSlider.value = " + RotationSlider.value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (null != gameObject.transform.parent.GetComponent<BP_Test>())//�浹 ó���� ���� �θ��� place ������ ��� �޾ƿ�
        {
            place = gameObject.transform.parent.GetComponent<BP_Test>().place;
        }
        else if (null != gameObject.transform.parent.GetComponent<BP_Deco_script>())
        {
            place = gameObject.transform.parent.GetComponent<BP_Deco_script>().place;
        }
        tempVec = BP_ScaleVec;
        transform.parent.gameObject.transform.eulerAngles = new Vector3(-90, 0, RotationSlider.value*15 );//�����̴��� �����̸� ȸ����
        BP_RotY = RotationSlider.value * 15;
        tempVec.x *= (ScaleSlider.value / 10);
        tempVec.y *= (ScaleSlider.value / 10);
        tempVec.z *= (ScaleSlider.value / 10);
        transform.parent.gameObject.transform.localScale = tempVec;//�����̴��� �����̸� ũ�Ⱑ ����
    }

    public void ApplyButton()//��ġ�ϱ� ��ư
    {
        if (place == true)
        {
            BP_ScaleVec = tempVec;
            Instantiate(parentPrefab,
                gameObject.transform.parent.gameObject.transform.position,
                gameObject.transform.parent.gameObject.transform.rotation);//���� ������ ũ��,ȸ������ ���� �θ��� prefab�� �ν��Ͻ�ȭ �Ѵ�
            //��ġ��� off
            RoomMenu.transform.GetChild(4).gameObject.GetComponent<furnitureMenu>().furnitureChoosed = false;
            RoomMenu.SetActive(true);
            myMenu.SetActive(false);
            Open_Button.SetActive(true);
            BackToSelect_button.SetActive(true);
            rotater.SetActive(true);
            Joystick.SetActive(true);
            player.GetComponent<Move>().BP_Mode = false;//�÷��̾��� ��ġ��带 false�� �ٲ�
            player.GetComponent<Move>().Menu_Mode = false;
            Destroy(transform.parent.gameObject);
        }
    }
    public void CancleButton()//�����ϱ� ��ư
    {
        //��ġ��� off
        RoomMenu.transform.GetChild(4).gameObject.GetComponent<furnitureMenu>().furnitureChoosed = false;
        RoomMenu.SetActive(true);
        myMenu.SetActive(false);
        Open_Button.SetActive(true);
        BackToSelect_button.SetActive(true);
        rotater.SetActive(true);
        Joystick.SetActive(true);
        player.GetComponent<Move>().BP_Mode = false;
        player.GetComponent<Move>().Menu_Mode = false;
        Destroy(transform.parent.gameObject);
    }
}
