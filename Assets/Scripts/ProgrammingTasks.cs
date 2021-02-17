using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingTasks : MonoBehaviour
{
    [SerializeField] private string targetString;
    [SerializeField] private string guessString;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FizzBuzz()
    {
        for (int i = 1; i <= 100; i++)
        {
            // If dividable by both 3 and 5
            if (i % 3 == 0 && i % 5 == 0)
            { 
                Debug.Log("FizzBuzz");
            }
            // If dividable by 3
            else if (i % 3 == 0)
            {
                Debug.Log("Fizz");
            }
            // If dividable by 5
            else if (i % 5 == 0)
            {
                Debug.Log("Buzz");
            }
            // If not dividable by 3 or 5
            else
            {
                Debug.Log(i);
            }
        }
    }

    public void CallCompareStrings()
    {
        CompareStrings(targetString, guessString);
    }

    public float CompareStrings(string target, string guess)
    {
        int score = 0;

        int length; // To go through in for loop and not get an exception error
        int longest; // To calculate result (score divided by longest length)

        if (target.Length <= guess.Length)
        {
            length = target.Length;
            longest = guess.Length;
        }
        else
        {
            length = guess.Length;
            longest = target.Length;
        }

        for (int i = 0; i < length; i++)
        {
            if (target[i].Equals(guess[i]))
            {
                score++;
            }
        }

        float result = (float)score / (float)longest * 100.0f;

        Debug.Log(result);
        return result;
    }
}
