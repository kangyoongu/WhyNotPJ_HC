using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; //ÀÌ¹ÌÁö Àý¹Ý µü¸ÂÃã

public class height : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] public RectTransform rect_Background;
    [SerializeField] public RectTransform rect_Joystick;
    private float radius;
    [SerializeField] public Rigidbody go_Player;
    [SerializeField] public float moveSpeed = 5;
    private bool isTouch = false;
    float y = 0;
    void Start()
    {
        radius = rect_Background.rect.height * 0.5f;
    }

    void Update()
    {
        go_Player.AddForce(Vector3.up * y);
        Debug.Log(y);
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
        Vector2 value = (eventData.position - (Vector2)rect_Background.position) * 1;
        
        value = Vector2.ClampMagnitude(value, radius);
        rect_Joystick.localPosition = new Vector2(0, value.y);
        y = rect_Joystick.anchoredPosition.y * 10 * Time.deltaTime * moveSpeed;
    }
}