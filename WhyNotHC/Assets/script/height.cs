using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; //ÀÌ¹ÌÁö Àý¹Ý µü¸ÂÃã

public class Height : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] public RectTransform rect_Background;
    [SerializeField] public RectTransform rect_Joystick;
    private float radius;
    [SerializeField] public Rigidbody go_Player;
    [SerializeField] public float moveSpeed = 5;
    private bool isTouch = false;
    public float y = 0;
    public Rigidbody wing;
    public Rigidbody wing2;
    public Image bar;
    void Start()
    {
        radius = rect_Background.rect.height * 0.5f;
    }

    void Update()
    {
        if (bar.fillAmount != 0)
        {
            go_Player.AddForce(Vector3.up * y);
            if (y > 0.1f)
            {
                wing.AddTorque(Vector3.up * y * 60);
                wing2.AddTorque(Vector3.right * y * 60);
            }
        }
        else
        {
            y = 0;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (bar.fillAmount != 0)
        {
            Vector2 value = (eventData.position - (Vector2)rect_Background.position) * 1;

            value = Vector2.ClampMagnitude(value, radius);
            rect_Joystick.localPosition = new Vector2(0, value.y);
            y = rect_Joystick.anchoredPosition.y * 10 * Time.deltaTime * moveSpeed;
        }
    }
}