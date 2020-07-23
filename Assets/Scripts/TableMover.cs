using UnityEngine;

public class TableMover : MonoBehaviour
{

    private Level2 Level2;
    private ResponseTime ResponseTime;
    private Variables Variables;
    public float DistanceZ = 0.0f; //This variable tells the stimulus how much to move.
    public float Stimpos = 0.0f; // This variable holds the PI number. You can change this in the inspector after adding it as a component for each stimulus.
    public float angle;
    public float Shoulder;
    public float DistanceY;
    public float TableDistance;
    Vector3 tempPos; // Needed for moving the stimulus.


    void Awake()
    {
        Variables = GameObject.FindGameObjectWithTag("UI").GetComponent<Variables>(); //This pulls the variables from the variables script. It's a handy way to call variables from objects without manualy telling unity where to look for the corisponding script every time a new scene loads. 
    }

    private void Start()
    {
        Shoulder = Variables.shoulder;
        DistanceZ = Stimpos * Variables.arm;
        TableDistance = 1;//How far the table is from 0.

    }

    void Update()
    {

        tempPos = transform.position;
        tempPos.z = transform.localScale.z /2 + TableDistance; //This should set the table in front of the user. 
        tempPos.y = Shoulder + (DistanceZ * (Mathf.Tan(angle)) / 2) - 0.9f; //places  the table just below the ball.
        Debug.Log(tempPos.y);
        transform.position = tempPos; // This does the actual stimulus moving.

    } 
}