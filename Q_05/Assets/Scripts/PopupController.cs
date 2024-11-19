using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    private WaitForSeconds _wait;
    private Button _popupButton;

    [SerializeField] private GameObject _popup;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _wait = new WaitForSeconds(_deactiveTime);
        _popupButton = GetComponent<Button>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        StartCoroutine(DeactivateRoutine());
        Debug.Log("Activate");
        GameManager.Instance.Pause();
        _popup.gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        Debug.Log("Deactivate");
        GameManager.Instance.Resume();
        _popup.gameObject.SetActive(false);
    }

    private IEnumerator DeactivateRoutine()
    {
        Debug.Log($"ÄÚ·çÆ¾,{_wait},{_deactiveTime},{Time.timeScale}");
        // yield return _wait;
        yield return new WaitForSeconds(2);
        Deactivate();
    }
}
