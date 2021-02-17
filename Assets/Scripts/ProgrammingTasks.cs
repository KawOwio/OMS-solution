using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingTasks : MonoBehaviour
{
    [SerializeField] private string targetString;
    [SerializeField] private string guessString;

    [SerializeField] List<int> binaryValues = new List<int>();

    private BinaryTree binaryTree;

    // Start is called before the first frame update
    void Start()
    {
        binaryTree = gameObject.AddComponent<BinaryTree>();

        for (int i = 0; i < binaryValues.Count; i++)
        {
            binaryTree.Add(binaryValues[i]);
        }
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

        // Score is precentage of the same characters on the same index of a string
        // F.e. target string is "AAAA" and guess string is "AAAB" the result will be 75%
        // if target string is "A" and guess string is "AA" the result will be 50%
        float result = (float)score / (float)longest * 100.0f;

        Debug.Log(result + "%");
        return result;
    }

    public void PreOrderTraversal()
    {
        Debug.Log("PreOrder Traversal:");
        binaryTree.TraversePreOrder(binaryTree.root);
    }

    public void InOrderTraversal()
    {
        Debug.Log("InOrder Traversal:");
        binaryTree.TraverseInOrder(binaryTree.root);
    }

    public void PostOrderTraversal()
    {
        Debug.Log("PostOrder Traversal:");
        binaryTree.TraversePostOrder(binaryTree.root);
    }
}
