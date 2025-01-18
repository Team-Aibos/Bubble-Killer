using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeManager : MonoBehaviour
{
    public float SetRandomNum(int x, int y)
    {
        float randomNum = Random.Range(x, y);
        return randomNum;
    }
}
