using UnityEngine;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEngine.UI;
using UnityEditor;
#endif

public class ClickObject : MonoBehaviour, IPointerDownHandler
{
    [Header("Скорость в процентах высоты экрана в секунду")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private ClickVFX clickEffect;
    
    private RectTransform rt;
    
    private void Awake()
    {
        rt = transform as RectTransform;
    }

    private void Update()
    {
        rt.anchoredPosition += Vector2.up * (PreAdScreen.Instance.CanvasSize.y * (moveSpeed / 100) * Time.unscaledDeltaTime);
    }

    #if UNITY_EDITOR
    private void OnValidate()
    {
        if(clickEffect == null || !TryGetComponent(out Image image))
            return;
        
        Sprite changedSprite = image.sprite;
        
        if(changedSprite == clickEffect.MainParticleSystemSprite)
            return;
    
        clickEffect.MainParticleSystemSprite = changedSprite;
        
        Debug.LogWarning($"Sprite on <b>{clickEffect.gameObject.name}</b> got changed!\n" +
                         $"You don't have to do anything, just hit Ctrl+S again for good measure");
        
        EditorUtility.SetDirty(clickEffect);
    }
    #endif

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject vfx = null;
        
        if (clickEffect != null)
            vfx = Instantiate(clickEffect.gameObject, transform.position, transform.rotation, transform.parent);

        PreAdClicker.ObjectClicked.Invoke(vfx);

        Destroy(gameObject);
    }
}
