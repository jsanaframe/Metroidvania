using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private Image manaBar;
    [SerializeField]
    private TextMeshProUGUI pocionesText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateLifeBar();
        UpdateManaBar();
        UpdatePocionesText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLifeBar()
    {
        lifeBar.fillAmount = GameManager.instance.gameData.Life/GameManager.instance.gameData.MaxLife;
    }

    public void UpdateManaBar()
    {
        manaBar.fillAmount = GameManager.instance.gameData.Mana/GameManager.instance.gameData.MaxMana;
    }

    public void UpdatePocionesText()
    {
        pocionesText.text = "X " + GameManager.instance.gameData.PotionsCount.ToString();
    }
}
