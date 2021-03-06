using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;

    [SerializeField] private Image _healthBarBackground;

    [SerializeField] private GameObject _gameObjectHealth;
    
    [SerializeField] private bool _isActiveInStart = false;

    [SerializeField] private Gradient _gradient;

    private IHealth _health;

    private void Awake() 
    {
        if((_health = _gameObjectHealth.GetComponent<IHealth>()) == null) 
            throw new ArgumentNullException($"{_gameObjectHealth.name} don't have Ihealth interface");
        
        EnemyHealth.OnTakeDamage += OnHealthChanged;
        
        _healthBarBackground.gameObject.SetActive(_isActiveInStart);
    }

    private void OnDisable() 
    {
        EnemyHealth.OnTakeDamage -= OnHealthChanged;
    }

    private void OnHealthChanged(Transform target, float damage, float healthPointsMax, float oldHeatPoints, float newHeatPoints) 
    {
        if(target.gameObject.GetComponent<IHealth>() != _health) return;

        ShowBar();
        
        var valueAsPercantage = newHeatPoints / healthPointsMax;

        _healthBarFilling.fillAmount  = valueAsPercantage;
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercantage);
        
        StartCoroutine(HideBar());
    }

    private IEnumerator HideBar() 
    {
        yield return new WaitForSeconds(2f);
        _healthBarBackground.gameObject.SetActive(false);
    }

    private void ShowBar() 
    {
        _healthBarBackground.gameObject.SetActive(true);
    }
}
