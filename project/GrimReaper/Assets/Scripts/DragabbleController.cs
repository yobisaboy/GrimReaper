using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DraggableController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private Vector2 _offset;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _offset = eventData.position - _rectTransform.anchoredPosition;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 newPos = eventData.position - _offset;
        _rectTransform.anchoredPosition = ClampToCanvas(newPos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        SoundController.instance.Play("Consume");    
        GamePlayUIController.Instance.UpdateHealth(1.0f);
        GetComponent<Image>().sprite = null;
        GetComponent<Image>().color = new Color(255, 255, 255, 0);
        //disable the item
        this.gameObject.SetActive(false);

    }

    private Vector2 ClampToCanvas(Vector2 position)
    {
        Vector2 minPosition = _rectTransform.rect.min * _canvas.scaleFactor;
        Vector2 maxPosition = (_canvas.pixelRect.size - _rectTransform.rect.size) * _canvas.scaleFactor;
        return new Vector2(Mathf.Clamp(position.x, minPosition.x, maxPosition.x), Mathf.Clamp(position.y, minPosition.y, maxPosition.y));
    }
}
