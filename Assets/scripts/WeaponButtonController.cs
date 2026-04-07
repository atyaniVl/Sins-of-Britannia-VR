using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponButtonController : MonoBehaviour
{
    public int ID;
    public string weaponName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    public Sprite icon;

    private bool isSelected = false;
    private Animator _animator;
    private Color normalColor;
    void Start()
    {
        _animator = GetComponent<Animator>();
        normalColor = selectedItem.color;
    }

    void Update()
    {
        if (isSelected)
        {
            selectedItem.sprite = icon;
            selectedItem.color = new Color(selectedItem.color.r,
                selectedItem.color.g,
                selectedItem.color.b,
                1);
            itemText.text = weaponName;
        }

    }
    public void SelectionState(bool _state)
    {
        isSelected = _state;
        if (!_state)
        {
            selectedItem.color = new Color(0,0,0,0);
            selectedItem.sprite = null;
            itemText.text = "Choose your sacred weapon";
        }

        if (_state)
        {
            selectedItem.color = new Color(1, 1, 1, 1);
        }
    }
    public void HoveringState(bool _state)
    {
        _animator.SetBool("Hover", _state);
        itemText.text = _state ? weaponName : "";
    }
}
