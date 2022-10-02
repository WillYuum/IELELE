using UnityEngine;
using UnityEngine.UI;
using Utils.GenericSingletons;

public class MainCharacter : MonoBehaviourSingleton<MainCharacter>
{
    private float _startingHealth = 100;
    private float _currentHealth;


    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _currentHealth = _startingHealth;
        _slider.value = 1;

    }

    private void Update()
    {
        _slider.transform.LookAt(Camera.main.transform);


        Debug.DrawRay(transform.position, transform.forward * 4.2f, Color.red);
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

        _slider.value = _currentHealth / _startingHealth;

        if (_currentHealth <= 0)
        {
            GameManager.instance.LoseGame();
        }
    }

    public void ToggleAbilityItem(Items item)
    {
        switch (item)
        {
            case Items.Sword:
            case Items.Bow:
                //show range
                break;

            case Items.Basil:
            case Items.Beads:
            case Items.Flute:
            case Items.Garlic:
            case Items.WormWood:
            case Items.IE:
                //Hide range
                break;

            default:
                break;
        }
    }
}
