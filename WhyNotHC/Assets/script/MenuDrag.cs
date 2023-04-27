using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class MenuDrag : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public float threshold = 5f;
    public float DownPosition;
    public float UpPosition;
    bool isMoveUp = false;
    public bool IsMoveUp
    {
        get { return isMoveUp; }

        set
        {
            isMoveUp = value;

            AutoMove(isMoveUp);
        }
    }
    bool trg = true;
    bool isUp = false;
    bool isNotTouch = false;
    private Sequence seq;
    private RectTransform rectTransform;
    public RectTransform makeUpUis;
    public float UpUIs;
    public float DownUIs;
    public void OnDrag(PointerEventData eventData)
    {
        isNotTouch = false;

        if (trg)
        {
            rectTransform.position = new Vector3(rectTransform.position.x, Input.mousePosition.y - 158, rectTransform.position.z);

            if (rectTransform.position.y > UpPosition)
            {
                rectTransform.position = new Vector3(rectTransform.position.x, UpPosition, rectTransform.position.z);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isNotTouch = true;

        AutoMove(isMoveUp);//애니 안할떄만
    }

    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        DOTween.SetTweensCapacity(5000, 2500);
    }

    private void Update()
    {
        if (!isNotTouch)
        {
            if (!isUp && rectTransform.position.y > threshold && trg)
            {
                IsMoveUp = true;
            }
            else if (isUp && rectTransform.position.y <= threshold && trg)
            {
                IsMoveUp = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            seq.TogglePause();
        }
    }

    private void AutoMove(bool isMoveUp)
    {
        seq = DOTween.Sequence();

        trg = false;
        seq.Append(rectTransform.DOAnchorPosY(isMoveUp ? UpPosition : DownPosition, 1f).SetEase(Ease.OutCirc))
            .Join(makeUpUis.DOAnchorPosY(isMoveUp ? UpUIs : DownUIs, 1f).SetEase(Ease.OutCirc))
            .OnComplete(() =>
            {
                isUp = isMoveUp;
                trg = true;
                isNotTouch = false;
            })
            .AppendCallback(() =>
            {
                seq.Kill();
            });
    }
}
