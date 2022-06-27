using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BP_Test : MonoBehaviour
{
    RaycastHit hit;
    public GameObject prefab;//��üȭ�� prefab, �̸� �־����
    public Material preMat;//��üȭ�� prefab�� Material, �̸� �־����
    public Touch tempTouch;//��ġ ����
    Material mat;//���׸��� ����
    MeshRenderer mesh;//�޽� ����
    public bool place;//�� �ڸ��� ���� �� �ִ��� üũ
    bool IsFurniture;//Ŭ���� ���� ������ üũ�ϴ� ����
    private Vector3 ScreenCenter;//ȭ�� �߾��� ����Ű�� ����
    public Vector3 BP_eulerAngles;//üũ��
    public Quaternion BP_Quaternian;//üũ��
    public bool UIToched;//UI�� ��ġ�Ǿ����� Ȯ���ϴ� ����
    public int LayerMask;//���̾� ����ũ

    // Start is called before the first frame update
    void Start()//���� ��ġ ����϶� �� �Լ��� �Ҹ���
    {
        BP_eulerAngles = gameObject.transform.eulerAngles;
        BP_Quaternian = gameObject.transform.rotation;
        //Debug.Log("BP_eulerAngles = " + BP_eulerAngles);
        //Debug.Log("BP_Quaternian = " + BP_Quaternian);

        gameObject.layer = 10;//BP���̾��
        mesh = GetComponent<MeshRenderer>();//�޽����� �ҷ���
        mat = preMat;

        place = true;
        IsFurniture = false;

        LayerMask = (1 << 0) + (1 << 1) + (1 << 2) + (1 << 3) + (1 << 6) + (1 << 9) ;//���̾� ����ũ : 0������, 1�Ž�, 2ȭ���, 6�ٴ�, 9����

        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);//ȭ�� �߾Ӱ�
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);//���� BP�������� ȭ�� �߰�
        if (transform.position == Vector3.zero)//���� �������� (0,0,0) �̸�
        {
            if (Physics.Raycast(ray, out hit, 50000.0f, LayerMask))//���̾� ����ũ�� ���̸� ���.
            {
                transform.position = hit.point;
            }
            //if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))//���̾� 9�� ���̸� ��, ���̾�9�� ����.
            //{
            //    transform.position = hit.point;
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        BP_eulerAngles = gameObject.transform.eulerAngles;
        if (Input.GetMouseButton(0))
        {
            Debug.Log(Input.mousePosition);
        }
        //��ġ ����
        if (Input.touchCount > 0)//��ġ�� �ϳ� �̻��̸�
        {
            tempTouch = Input.GetTouch(0);//ù��° ��ġ�� ��ǲ���� �Ѵ�
            Ray ray = Camera.main.ScreenPointToRay(tempTouch.position);
            if (tempTouch.position.x > 2640 && tempTouch.position.x < 3120) //G7:2648,3120   IPad:1914,2388
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

            if (tempTouch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))//���̾� 10�� ���̸� ��, ���̾�10�� BP��
                {
                    if (hit.collider.gameObject == gameObject)//��ġ�Ȱ� ��(����)�� IsFurniture�� ������ �ٲ�
                    {
                        IsFurniture = true;
                    }
                }
            }

            if (IsFurniture)
            {
                if (tempTouch.phase == TouchPhase.Moved)
                {
                    if (!UIToched)//��ġ�� ���� ������Ʈ���
                    {
                        if (Physics.Raycast(ray, out hit, 50000.0f, LayerMask))//��ġ�� ���� ��,�ٴ�,õ���̰ų�
                        {
                            transform.position = hit.point;
                        }
                        //if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))//�����̸�
                        //{
                        //    transform.position = hit.point;
                        //}
                    }
                }

            }
            if (tempTouch.phase == TouchPhase.Ended)
            {
                IsFurniture = false; 
                UIToched = false;
            }
        }
        //��ġ ��
    }

    private void OnTriggerEnter(Collider other)//�浹ó��
    {
        if (!other.CompareTag("Ground")) //Ground�� ������ �±׿� ������ ������
        {
            mat = mesh.material;
            mat.color = new Color(255, 0, 0);
            place = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Ground"))
        {
            mat = mesh.material;
            mat.color = new Color(255, 0, 0);
            place = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Ground"))//Ground�� ��� ������ ������� ���ƿ�
        {
            // mat.color = new Color(0, 255, 0);
            Material material = preMat;
            mesh.material = material;
            place = true;
        }
    }

    public void OnMouseDrag()
    {
        //���콺
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (EventSystem.current.IsPointerOverGameObject())//Ŭ���� ���� UI���
        //{
        //    Debug.Log("�����Ͱ� UI�� �ִ�");
        //}
        //else//Ŭ���� ���� ������Ʈ���
        //{
        //    Debug.Log("�����Ͱ� ������Ʈ�� �ִ�");
        //    if (Physics.Raycast(ray, out hit, 50000.0f, LayerMask))//���̾� 6�� ���̸� ��
        //    {
        //        //Debug.Log(hit.collider.transform.name);
        //        transform.position = hit.point;
        //    }
        //    if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 9)))//���̾� 9�� ���̸� ��, ���̾�9�� ����.
        //    {
        //        transform.position = hit.point;
        //    }
        //}
        //���콺 ��
    }
    public bool retPlace()
    {
        return place;
    }

}
