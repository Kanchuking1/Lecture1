using UnityEngine;
using System;
using System.Text;

public class Hangman : MonoBehaviour
{
    string[] listOfFilms = { "TANHAJI", "GOOD NEWWZ", "CHHAPAAK"};
    bool isRunning;
    int numberOfLives;
    string currentFilm;
    string currentGuessed;
    int letterCount;
   
    void Start()
    {
        isRunning = true;
        letterCount = 0;
        numberOfLives = 3;
        int arrayLength = listOfFilms.GetLength(0);
        currentFilm = listOfFilms[UnityEngine.Random.Range(0,arrayLength)];
        foreach(char i in currentFilm)
        {
            if (Char.IsLetter(i))
            {
                currentGuessed = currentGuessed + "_ ";
                letterCount++;
            }
            else
            {
                currentGuessed = currentGuessed + i;
            }
        }
        Debug.Log(currentGuessed + "\n Letter Count: " + letterCount + "\n");
    }

    void Update()
    {
        //while (isRunning)
        //{
        char c;
        if (Input.anyKey)
        {
            foreach (char ch in Input.inputString)
            {
                c = ch;
                Debug.Log(c);
                currentGuessed = currentGuessedBuilder(Char.ToUpper(c));
                Debug.Log(currentGuessed + "\n Letter Count: " + letterCount + "\n");
            }
        }
        //}
    }

    string currentGuessedBuilder(char c)
    {
        string newCurrentGuessed = null;
        int k = 0;
        foreach (char i in currentFilm)
        {
            if (Char.IsLetter(i) && i != c && !Char.IsLetter(currentGuessed[k]))
            {
                newCurrentGuessed = newCurrentGuessed + "_ ";
                Debug.Log(currentGuessed[k]);
                //letterCount++;
            }
            else
            {
                newCurrentGuessed = newCurrentGuessed + i + " ";
            }
            k+=2;
        }
        return newCurrentGuessed;
    }
}
