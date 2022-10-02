using System;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private float _durationToFillOneBar = 1.0f;
    private int _currentResouceCount = 0;
    private int _maxResourceCount = 5;


    private float _timePassed = 0;
    private float _currentResourceValue = 0.0f;

    [SerializeField] private Slider[] _sliders;

    [SerializeField] private BattleCards[] _battleCards;
    private void Awake()
    {
        foreach (var slider in _sliders)
        {
            slider.value = 0.0f;
        }
        _currentResouceCount = 0;

        SetListenersToBattleCards();
    }


    private void SetListenersToBattleCards()
    {
        foreach (var card in _battleCards)
        {
            card.OnClickButton(OnClickBattleCard);
            card.SetHoverLogic(OnHoverBattleCard);
        }
    }


    private void OnClickBattleCard(int energyCost, Items item)
    {
        if (_currentResouceCount >= energyCost)
        {
            RemoveResourceCount(energyCost);

            void DoSomethingOn(Action actionOnKnight, Action actionOnIelele)
            {
                var knight = GameObject.FindGameObjectsWithTag("Enemy");
                var ielele = GameObject.FindGameObjectsWithTag("Enemy");

                if (knight != null)
                {
                    actionOnKnight.Invoke();
                }
                else
                {
                    actionOnIelele.Invoke();
                }
            };

            print("CLicked on " + item);
            switch (item)
            {
                case Items.Sword:
                    DoSomethingOn(() =>
                    {
                        var knight = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Knight>();
                        Vector3 distBtweenMainCharacterAndKnight = knight.transform.position - MainCharacter.instance.transform.position;

                        if (distBtweenMainCharacterAndKnight.magnitude < 4.2f)
                        {
                            knight.TakeDamage(40);
                        }
                    }, () =>
                    {
                        var ielele = GameObject.FindGameObjectWithTag("Enemy").GetComponent<IELELE>();
                        Vector3 distBtweenMainCharacterAndKnight = ielele.transform.position - MainCharacter.instance.transform.position;

                        if (distBtweenMainCharacterAndKnight.magnitude < 4.2f)
                        {
                            ielele.GetStunned();
                        }
                    });
                    break;

                case Items.Bow:
                    DoSomethingOn(() =>
                    {
                        var knight = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Knight>();
                        Vector3 distBtweenMainCharacterAndKnight = knight.transform.position - MainCharacter.instance.transform.position;

                        if (distBtweenMainCharacterAndKnight.magnitude < 4.2f * 1.85f)
                        {
                            knight.TakeDamage(50);
                        }
                    }, () =>
                    {
                        var ielele = GameObject.FindGameObjectWithTag("Enemy").GetComponent<IELELE>();
                        Vector3 distBtweenMainCharacterAndKnight = ielele.transform.position - MainCharacter.instance.transform.position;

                        if (distBtweenMainCharacterAndKnight.magnitude < 4.2f * 1.85f)
                        {
                            ielele.GetStunned();
                        }
                    });
                    //show range
                    break;

                case Items.Basil:
                case Items.Beads:
                case Items.Flute:
                case Items.Garlic:
                case Items.WormWood:
                case Items.IE:
                    DoSomethingOn(() =>
                     {
                         var knight = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Knight>();
                         Vector3 distBtweenMainCharacterAndKnight = knight.transform.position - MainCharacter.instance.transform.position;

                         knight.TakeDamage(0);
                         knight.GetAngry();

                     }, () =>
                     {
                         var ielele = GameObject.FindGameObjectWithTag("Enemy").GetComponent<IELELE>();
                         Vector3 distBtweenMainCharacterAndKnight = ielele.transform.position - MainCharacter.instance.transform.position;

                         ielele.GetStunned();
                     });



                    break;

                default:
                    break;
            }
        }
    }


    private void OnHoverBattleCard(Items item)
    {
        MainCharacter.instance.ToggleAbilityItem(item);
    }

    void Update()
    {
        IncreaseResourceCount();
    }

    private void IncreaseResourceCount()
    {
        if (_currentResouceCount >= _maxResourceCount) return;

        _currentResourceValue += Time.deltaTime;

        _currentResourceValue = Mathf.Clamp(_currentResourceValue, 0.0f, 1.0f);

        _sliders[_currentResouceCount].value = _currentResourceValue;

        if (_currentResourceValue >= 1)
        {
            _currentResouceCount += 1;
            _currentResourceValue = 0.0f;
        }


    }

    public void RemoveResourceCount(int amount)
    {
        float amountToRemove = Mathf.Clamp(amount, 0.0f, 1.0f);

        _timePassed -= amountToRemove;
        if (_timePassed <= 0) _timePassed = 0;

        Slider[] slidersToEmpty = new Slider[amount];

        for (int i = 0; i < amount; i++)
        {
            _currentResouceCount = Mathf.Clamp(_currentResouceCount, 0, _maxResourceCount - 1);
            slidersToEmpty[i] = _sliders[_currentResouceCount];
            _currentResouceCount--;
            _currentResouceCount = Mathf.Clamp(_currentResouceCount, 0, _maxResourceCount - 1);
        }


        float totalAmountRemoved = amount;
        foreach (var item in slidersToEmpty)
        {
            item.value -= totalAmountRemoved;
            totalAmountRemoved -= amountToRemove;
        }
    }
}
