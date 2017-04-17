using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordChange : MonoBehaviour {


    public delegate void WordChanged();
    public static event WordChanged OnWordChanged;


    public string currentWord;
    public string nextWord;
    public float changeTime = 0.001f;

    private TextMesh textObj;
    private string[] alphabet;
    private IEnumerator co;
    private int currentWordIndex = 0;

    // Use this for initialization
    void Start() {
        textObj = this.GetComponent<TextMesh>();
        currentWord = textObj.text;
        alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        co = ChangeWord(nextWord);
        StartCoroutine(co);
    }

    IEnumerator ChangeWord(string newWord)
    {
        while (currentWordIndex < nextWord.Length)
        {
            int alphabetIndex = 0;  //set alpha bet index to 0 everytime we start new letter 
            string nextLetter = nextWord[currentWordIndex].ToString();  //get the next letter 
            string nextLetterUpperCase = nextLetter.ToUpper();  //get refference to next letter upcase so we dont kepp converting

            while (!string.Equals(nextLetterUpperCase, alphabet[alphabetIndex]))
            {
                ChangeLetter(nextLetter, nextLetterUpperCase, alphabetIndex);

                textObj.text = currentWord;  //update text
                alphabetIndex++;  //increament to next alphabet letter
                yield return new WaitForSeconds(changeTime); 
            }
            ChangeLetter(nextLetter, nextLetterUpperCase, alphabetIndex);
            currentWordIndex++;
            yield return null;
        }
        currentWord = nextWord;
        textObj.text = currentWord;  //update text
        OnWordChanged();
    }

    void ChangeLetter(string nextLetter, string nextLetterUpperCase,int alphabetIndex)
    {
        if (currentWordIndex < currentWord.Length)
        {
            currentWord = currentWord.Remove(currentWordIndex, 1);  //Remove the current letter as its not the right one
        }
        string insertedLetter = LetterToInsert(nextLetter, nextLetterUpperCase, alphabetIndex);  //figure out next inserted letter 
        currentWord = currentWord.Insert(currentWordIndex, insertedLetter);  //insert that letter
    }

    string LetterToInsert(string nextLetter, string nextLetterUpperCase, int alphabetIndex)
    {
        if (string.Equals(nextLetter, nextLetterUpperCase))
        {
           return alphabet[alphabetIndex];
        }
        else
        {
           return alphabet[alphabetIndex].ToLower();
        }
    }

    }
