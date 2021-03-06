using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PazzlePiece : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Canvas _mainCanvas;
    private CanvasGroup _canvasGroup;
    private CanvasMousePosition _canvasMousePosition;

    private PazzleList _pazzleList;
    public int pazzleId;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
        _pazzleList = GetComponentInParent<PazzleList>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasMousePosition = GetComponentInParent<CanvasMousePosition>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = _canvasMousePosition.GetMousePositionInCanvas();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _pazzleList.SetCurrentId(pazzleId);
        _rectTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
    }
}
