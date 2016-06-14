using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using UnityEngine;

public class BubbleTimer : MonoBehaviour
{

    public GameObject A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z;
    public GameObject place;

    public Vector3 position1, position2, position3, position4, position5, position6, position7, position8,
                   position9, position10, position11, position12;

    public float time;

    // Update is called once per frame
    void Update()
    {
        //create a timer for random bubbles
        time += Time.deltaTime;

        if (time >= 3)
        {
            time -= 3;
            //Removes all unused bubble clones
            DeleteAll();
            //places new bubbles
            randomBubbles();
        }
        //sets the positions for future bubbles
        setPositions();

}
    //Get position from sphere place holder and give that
    //position to the bubbles
void setPositions()
{

        //Get position from place holders.
        //place holder 1
        GameObject sphere1 = GameObject.Find("placeHolder1");

        Transform sphereTransform1 = sphere1.transform;

        position1 = sphereTransform1.position;

        //place holder 2
        GameObject sphere2 = GameObject.Find("placeHolder2");

        Transform sphereTransform2 = sphere2.transform;

        position2 = sphereTransform2.position;

        //place holder 3
        GameObject sphere3 = GameObject.Find("placeHolder3");

        Transform sphereTransform3 = sphere3.transform;

        position3 = sphereTransform3.position;

        //place holder 4
        GameObject sphere4 = GameObject.Find("placeHolder4");

        Transform sphereTransform4 = sphere4.transform;

        position4 = sphereTransform4.position;
        //place holder 5
        GameObject sphere5 = GameObject.Find("placeHolder5");

        Transform sphereTransform5 = sphere5.transform;

        position5 = sphereTransform5.position;

        //place holder 6
        GameObject sphere6 = GameObject.Find("placeHolder6");

        Transform sphereTransform6 = sphere6.transform;

        position6 = sphereTransform6.position;

        //place holder 7
        GameObject sphere7 = GameObject.Find("placeHolder7");

        Transform sphereTransform7 = sphere7.transform;

        position7 = sphereTransform7.position;

        //place holder 8
        GameObject sphere8 = GameObject.Find("placeHolder8");

        Transform sphereTransform8 = sphere8.transform;

        position8 = sphereTransform8.position;

        //place holder 1
        GameObject sphere9 = GameObject.Find("placeHolder9");

        Transform sphereTransform9 = sphere9.transform;

        position9 = sphereTransform9.position;

        //place holder 10
        GameObject sphere10 = GameObject.Find("placeHolder10");

        Transform sphereTransform10 = sphere10.transform;

        position10 = sphereTransform10.position;

        //place holder 11
        GameObject sphere11 = GameObject.Find("placeHolder11");

        Transform sphereTransform11 = sphere11.transform;

        position11 = sphereTransform11.position;

        //place holder 12
        GameObject sphere12 = GameObject.Find("placeHolder12");

        Transform sphereTransform12 = sphere12.transform;

        position12 = sphereTransform12.position;

    }

    //Create random bubbles
    void randomBubbles()
    {
        //get 12 random numbers and enter them into an array as gameobjects of the letters
        int random = 0;
        //create gameobject array to enter the gameobject
        GameObject[] randomNumbers = new GameObject[12];
        //Create int array to enter the random numbers
        int[] numbersUsed = new int[12];
        for (int i = 0; i < 12; i++)
        {
            //generate random number
            bool alreadyUsed = false;
            random = UnityEngine.Random.Range(1, 26);
            //Check if the number array has any dupilcate numbers
            if (i > 0)
            {
                foreach (int number in numbersUsed)
                {
                    if (random == number)
                    {
                        alreadyUsed = true;
                    }
                }
            }
            //if there are duplicate numbers in the array then create another random
            if (alreadyUsed)
            {
                while (alreadyUsed)
                {
                    random = UnityEngine.Random.Range(1, 26);
                    alreadyUsed = false;

                    foreach (int number in numbersUsed)
                    {
                        if (random == number)
                        {
                            alreadyUsed = true;
                        }
                    }
                }
            }
            //If ints are not duplicates then convert the random to a random gameobject
            switch (random)
            {
                case 1:
                    place = A;
                    break;
                case 2:
                    place = B;
                    break;
                case 3:
                    place = C;
                    break;
                case 4:
                    place = D;
                    break;
                case 5:
                    place = E;
                    break;
                case 6:
                    place = F;
                    break;
                case 7:
                    place = G;
                    break;
                case 8:
                    place = H;
                    break;
                case 9:
                    place = I;
                    break;
                case 10:
                    place = J;
                    break;
                case 11:
                    place = K;
                    break;
                case 12:
                    place = L;
                    break;
                case 13:
                    place = M;
                    break;
                case 14:
                    place = N;
                    break;
                case 15:
                    place = O;
                    break;
                case 16:
                    place = P;
                    break;
                case 17:
                    place = Q;
                    break;
                case 18:
                    place = R;
                    break;
                case 19:
                    place = S;
                    break;
                case 20:
                    place = T;
                    break;
                case 21:
                    place = U;
                    break;
                case 22:
                    place = V;
                    break;
                case 23:
                    place = W;
                    break;
                case 24:
                    place = X;
                    break;
                case 25:
                    place = Y;
                    break;
                case 26:
                    place = Z;
                    break;
            }
            //place the now converted random gameobject into place variable
            randomNumbers[i] = place;
            numbersUsed[i] = random;
        }

        //place the new randomly generated letters into the positions
        Instantiate(randomNumbers[0], position1, Quaternion.identity);
        Instantiate(randomNumbers[1], position2, Quaternion.identity);
        Instantiate(randomNumbers[2], position3, Quaternion.identity);
        Instantiate(randomNumbers[3], position4, Quaternion.identity);
        Instantiate(randomNumbers[4], position5, Quaternion.identity);
        Instantiate(randomNumbers[5], position6, Quaternion.identity);
        Instantiate(randomNumbers[6], position7, Quaternion.identity);
        Instantiate(randomNumbers[7], position8, Quaternion.identity);
        Instantiate(randomNumbers[8], position9, Quaternion.identity);
        Instantiate(randomNumbers[9], position10, Quaternion.identity);
        Instantiate(randomNumbers[10], position11, Quaternion.identity);
        Instantiate(randomNumbers[11], position12, Quaternion.identity);
    }

    public void DeleteAll()
    {
        //creates gameobject bubbles array from gameobjects with tags allbubbles which were all given to letter prefabs
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("allBubbles");
        //Loop through the array and destroy each bubble
        foreach (GameObject bubble in bubbles)
            Destroy(bubble);

    }
}
