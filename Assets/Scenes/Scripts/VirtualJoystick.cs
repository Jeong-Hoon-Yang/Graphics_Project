using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있는 기능을 지원

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]  // 에디터의 Inspector 뷰에서 넣어주기 위해 설정
    private RectTransform lever;    // 레버의 RectTransform 컴포넌트를 갖는 변수
    private RectTransform rectTransform;    // 조이스틱의 RectTransform 컴포넌트를 갖는 변수

    [SerializeField, Range(10, 150)]
    private float leverRange;   // 레버가 조이스틱 밖까지 나가지 않도록 제한시키기 위한 변수

    private Vector2 inputDirection;
    private bool isInput;   // 조이스틱이 눌렸는지 확인하는 변수

    [SerializeField]
    public JoystickPlayerCtrl controller;

    public float sensitivity = 1f;  // 카메라 회전 민감도 조절
    // 열거형 변수 선언
    public enum JoystickType { Move, Rotate }
    public JoystickType joystickType;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) // 드래그 시작 시
    {
        ControlJoystickLever(eventData);
        isInput = true;
    }

    // 오브젝트를 클릭해서 드래그 하는 도중에 들어오는 이벤트
    // 하지만 클릭을 유지한 상태로 마우스를 멈추면 이벤트가 들어오지 않음
    public void OnDrag(PointerEventData eventData)  // 드래그 중
    {
        ControlJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)   // 드래그 끝냈을 때
    {
        // 조이스틱에서 손을 뗐을 때 레버가 조이스틱의 중심으로 다시 돌아오도록 하고, inInput을 false로 바꿔준다.
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        switch(joystickType)
        {
            case JoystickType.Move: // 드래그를 끝냈을 때 Move 함수의 이동벡터를 0으로 돌려놓는다.(멈춤)
                controller.Move(Vector2.zero);
                break;
            case JoystickType.Rotate:   // 드래그를 끝내면 카메라 회전을 멈춘다.
                break;
        }
    }

    private void ControlJoystickLever(PointerEventData eventData)
    {
        // eventData.position으로 터치한 위치를 갖고 온 뒤, 이 위치를 조이스틱 오브젝트의 위치와 빼서 레버의 위치 inputPos를 구한다.
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        // 삼항 연산 : (조건식) ? 참일때 : 거짓일때
        // inputPos의 길이가 leverRange보다 짧으면 inputPos값을 바로 레버로 주고, 그렇지 않으면 inputPos를 정규화 한 다음 leverRange를 곱하는 방식으로 inputPos의 거리를 제한하여 넣어준다.
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = 5 * (inputVector / leverRange);  // inputVector는 해상도를 기반으로 만들어진 값이라 이동속도로 쓰기에는 너무 큼      @@@이동속도 조절은 여기서@@@
    }

    // OnDrag함수는 클릭을 유지한 상태에서 마우스를 멈추면 이벤트가 들어오지 않기 때문에, 조이스틱을 계속해서 움직이지 않으면 캐릭터가 움직이지 않는다.
    // 따라서 이 함수는 isInput이 활성화된 상태일 때 Update함수에서 지속적으로 호출해준다.
    private void InputControlVector()   // 구한 입력벡터를 캐릭터에 전달하여 이동시키는 함수
    {
        switch(joystickType)
        {
            case JoystickType.Move: // Move 케이스에는 Move함수를 호출(캐릭터 이동 조작)
                controller.Move(inputDirection);
                break;
            case JoystickType.Rotate:   // Rotate 케이스에는 LookAround함수를 호출(카메라 회전 조작)
                controller.LookAround(inputDirection * sensitivity);
                break;
        }
        //Debug.Log(inputDirection.x + " / " + inputDirection.y);
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(isInput)
        {
            InputControlVector();
        }
    }
}
