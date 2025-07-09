using UnityEngine;
using UnityEngine.UI;

public class ScoreDigit : MonoBehaviour
{
    public Sprite[] numberSprites; // 0 a 9
    private Image img;

    void Awake()
    {
        img = GetComponent<Image>();
    }

    public void SetDigit(int digit)
    {
        if (digit >= 0 && digit < numberSprites.Length)
        {
            img.sprite = numberSprites[digit];
        }
    }
}