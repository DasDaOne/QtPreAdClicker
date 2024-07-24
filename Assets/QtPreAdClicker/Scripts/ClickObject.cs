using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour, IPointerDownHandler
{
    [Header("Скорость в процентах высоты экрана в секунду")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject clickEffect;
    
    private RectTransform rt;
    
    private void Awake()
    {
        rt = transform as RectTransform;
    }

    private void Update()
    {
        rt.anchoredPosition += Vector2.up * (PreAdScreen.Instance.CanvasSize.y * (moveSpeed / 100) * Time.unscaledDeltaTime);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject vfx = null;
        
        if (clickEffect != null)
            vfx = Instantiate(clickEffect, transform.position, transform.rotation, transform.parent);

        PreAdClicker.ObjectClicked.Invoke(vfx);

        Destroy(gameObject);
    }
}
