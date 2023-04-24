using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class MenuDrag : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public float threshold = 5f;
    public Vector3 DownPosition;
    public Vector3 UpPosition;
    bool trg = true;
    bool isUp = false;
    bool isTouch = false;
    public void OnDrag(PointerEventData eventData)
    {
        if (trg == true)
        {
            transform.position = new Vector3(transform.position.x, Input.mousePosition.y, transform.position.z);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = true;
    }

    private void Update()
    {
        if (transform.position.y > threshold && (isUp == false || isTouch == true))
        {
            transform.DOMove(UpPosition, 1.5f).SetEase(Ease.OutCirc);
            trg = false;
            if(Vector3.Distance(transform.position, UpPosition) <= 1)
            {
                DOTween.KillAll();
                isUp = true;
                trg = true;
                isTouch = false;
            }
        }
        if((isTouch == true || isUp == true) && transform.position.y <= threshold)
        {
            transform.DOMove(DownPosition, 1.5f).SetEase(Ease.OutCirc);
            trg = false;
            if (Vector3.Distance(transform.position, DownPosition) <= 1)
            {
                DOTween.KillAll();
                isUp = false;
                trg = true;
                isTouch = false;
            }
        }
    }

}
