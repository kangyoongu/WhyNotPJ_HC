using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; //이미지 절반 딱맞춤

public class Move1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] public RectTransform rect_Background;
    [SerializeField] public RectTransform rect_Joystick;
    private float radius;
    [SerializeField] public Rigidbody go_Player;
    [SerializeField] public float moveSpeed = 5;
    private bool isTouch = false;
    float y = 0;
    float x = 0;
    public Transform wing;
    public Transform wing2;
    float wingspeed = 0;
    public Image oil;
    void Start()
    {
        radius = rect_Background.rect.width * 0.5f;
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, Screen.height * -0.25f);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height * 0.5f);
    }

    void Update()
    {
        if (isTouch)
        {
            if (oil.fillAmount > 0)//연료가 있으면 비행
            {
                wingspeed += Time.deltaTime * 2;
                go_Player.AddForce(Vector3.forward * y);
                go_Player.AddForce(Vector3.up * Time.deltaTime * 500);
                go_Player.AddForce(Vector3.right * x);
                oil.fillAmount -= Time.deltaTime * 0.14f;
            }
            else
            {
                isTouch = false;
            }
        }
        else
        {
            if (wingspeed <= 0)
            {
                wingspeed = 0;
            }
            else
            {
                wingspeed -= Time.deltaTime * 2.5f;
            }
        }
        wing.Rotate(Vector3.forward * wingspeed);
        wing2.Rotate(Vector3.right * wingspeed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetTouch(Input.touchCount - 1).position.x <= 1480)
        {
            rect_Background.anchoredPosition = Input.GetTouch(Input.touchCount - 1).position;
            isTouch = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_Joystick.localPosition = Vector3.zero;
        rect_Background.anchoredPosition = new Vector2(-1000, 0);
        y = 0;
        x = 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = (eventData.position - (Vector2)rect_Background.position) * 1;

        value = Vector2.ClampMagnitude(value, radius);
        rect_Joystick.localPosition = value;

        float distance = Vector2.Distance(rect_Background.position, rect_Joystick.position) / radius;
        value = value.normalized;
        y = value.y * moveSpeed * distance * Time.deltaTime;
        x = value.x * moveSpeed * distance * Time.deltaTime;
    }
}