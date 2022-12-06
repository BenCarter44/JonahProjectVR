using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeworkScript : MonoBehaviour
{
    public TMP_Text question;
    public TMP_Text btnA;
    public TMP_Text btnB;
    public TMP_Text btnC;
    public TMP_Text btnD;

    private float answer;
    private float numA;
    private float numB;
    private float numC;
    private float numD;

    public TMP_Text numCorrect;
    public TMP_Text numWrong;
    public TMP_Text numTotal;
    public TMP_Text perCorrect;

    private float nC;
    private float nW;
    private float nT;
    private float pC;

    // Start is called before the first frame update
    void Start()
    {
        generateQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateQuestion()
    {
        System.Random rnd = new System.Random();

        // solve for x
        // y = m * x + b
        // x = (y - b) / m
        answer = (float)rnd.Next(1, 10);
        float m = (float) rnd.Next(1, 10);
        float b = (float) rnd.Next(1, 10);
        float y = (float)m * answer + b;

        question.text = y.ToString() + " = " + m.ToString() + " * x " + " + " + b.ToString();

        if (answer % 4 == 0)        /// A is correct
        {
            numA = answer;
            do
            {
                numB = rnd.Next(1, 10);
                numC = rnd.Next(1, 10);
                numD = rnd.Next(1, 10);
            } while (checkButtons());
        }
        else if (answer % 4 == 1)   // B is correct
        {
            numB = answer;
            do
            {
                numA = rnd.Next(1, 10);
                numC = rnd.Next(1, 10);
                numD = rnd.Next(1, 10);
            } while (checkButtons());
        }
        else if (answer % 4 == 2)   // C is correct
        {
            numC = answer;
            do
            {
                numB = rnd.Next(1, 10);
                numA = rnd.Next(1, 10);
                numD = rnd.Next(1, 10);
            } while (checkButtons());
        }
        else                        // D is correct
        {
            numD = answer;
            do
            {
                numB = rnd.Next(1, 10);
                numC = rnd.Next(1, 10);
                numA = rnd.Next(1, 10);
            } while (checkButtons());
        }

        btnA.text = "A: " + numA.ToString();
        btnB.text = "B: " + numB.ToString();
        btnC.text = "C: " + numC.ToString();
        btnD.text = "D: " + numD.ToString();

    }

    bool checkButtons()
    {
        return !((numA == numB) | (numA == numC) | (numA == numD) | (numB == numC) | (numB == numD) | (numC == numD));
    }

    void checkCorrect(float num)
    {
        if (num == answer)
        {
            nC++;
            nT++;
            pC = nC / nT;
        }
        else
        {
            nW++;
            nT++;
            pC = nC / nT;
        }

        numCorrect.text = nC.ToString();
        numWrong.text = nW.ToString();
        numTotal.text = nT.ToString();
        pC = pC * 100;
        perCorrect.text = pC.ToString("0.00");

        generateQuestion();
    }

    public void ButtonA()
    {
        checkCorrect(numA);
    }

    public void ButtonB()
    {
        checkCorrect(numB);
    }

    public void ButtonC()
    {
        checkCorrect(numC);
    }

    public void ButtonD()
    {
        checkCorrect(numD);
    }
}
