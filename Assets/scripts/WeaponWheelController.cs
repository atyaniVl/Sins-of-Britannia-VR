using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class WeaponWheelController : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform menuTransform;
    [SerializeField] private InputActionReference toggleAction;

    [Header("Settings")]
    [SerializeField] private float duration = 0.25f;
    [SerializeField] private Vector3 targetScale = Vector3.one;
    private void Awake()
    {
        canvasGroup.alpha = 0;
        menuTransform.localScale = Vector3.zero;
        canvasGroup.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        toggleAction.action.started += ShowUI;
        toggleAction.action.canceled += HideUI;
    }

    private void OnDisable()
    {
        toggleAction.action.started -= ShowUI;
        toggleAction.action.canceled -= HideUI;
    }
    private void ShowUI(InputAction.CallbackContext context)

    { 
        canvasGroup.DOKill();
        menuTransform.DOKill();

        canvasGroup.DOFade(1f, duration);

        menuTransform.DOScale(targetScale, duration).SetEase(Ease.OutBack);
        Debug.Log("wheel menu show");
    }

    private void HideUI(InputAction.CallbackContext context)
    {
        canvasGroup.DOKill();
        menuTransform.DOKill();

        canvasGroup.DOFade(0f, duration);

        menuTransform.DOScale(Vector3.zero, duration)
            .SetEase(Ease.InBack)
            .OnComplete(() => Debug.Log("wheel menu hidden"));
    }

    public void ShowWeapon()
    {

    }
}
