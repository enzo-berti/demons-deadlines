using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class FastTyping : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI previewTMP;
    [SerializeField] private TMP_InputField inputTMP;

    [SerializeField] private string[] texts;

    private int indexWord = 0;
    private string nextWord = string.Empty;
    private string[] words;
    private string correctInput = string.Empty;

    private int score = 0;

    private void Awake()
    {
        NewText();
    }

    public void UpdateFastTyping()
    {
        if (CleanText(inputTMP.text) == CleanText(nextWord))
        {
            indexWord++;
            if (indexWord == words.Length)
            {
                score++;
                NewText();
                return;
            }
            nextWord += " " + words[indexWord];
            previewTMP.text += " " + words[indexWord];
        }
    }

    private void NewText()
    {
        int randIndex = Random.Range(0, texts.Length);

        indexWord = 0;
        correctInput = texts[randIndex];
        words = correctInput.Split();
        nextWord = words[indexWord];

        previewTMP.text = nextWord;
        inputTMP.text = "";
    }

    public void AddInput(string textInput)
    {
        inputTMP.text += textInput;
    }

    public void RemoveInput()
    {
        if (inputTMP.text.Length == 0)
        {
            return;
        }

        inputTMP.text.Remove(inputTMP.text.Length - 1);
    }

    static private string CleanText(string input)
    {
        if (input == null)
        {
            return string.Empty;
        }

        // Supprime les caractères invisibles : \u200B (zero width space), \uFEFF (BOM), etc.
        string cleaned = Regex.Replace(input, @"[\u200B-\u200D\uFEFF]", "");

        // Supprime les espaces multiples, retours à la ligne superflus, etc.
        cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();

        return cleaned;
    }
}
