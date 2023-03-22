using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; //ÀÌ¹ÌÁö Àý¹Ý µü¸ÂÃã

public class move1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] public RectTransform rect_Background;
    [SerializeField] public RectTransform rect_Joystick;
    private float radius;
    [SerializeField] public Rigidbody go_Player;
    [SerializeField] public float moveSpeed = 5;
    private bool isTouch = false;
    float y = 0;
    float x = 0;
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
            go_Player.AddForce(Vector3.forward * y);
            go_Player.AddForce(Vector3.up * y);
            go_Player.AddForce(Vector3.right * x);
        }
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