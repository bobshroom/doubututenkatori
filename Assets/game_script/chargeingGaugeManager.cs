using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeingGaugeManager : MonoBehaviour
{
    public float gauge;
    [SerializeField] private Vector2 vector;
    private Vector2 startVector;
    [SerializeField] float barRange;
    [SerializeField] GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        startVector = bar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bar.transform.position = new Vector2(startVector.x + (gauge * barRange * vector.x), startVector.y + (gauge * barRange * vector.y));
    }
}
