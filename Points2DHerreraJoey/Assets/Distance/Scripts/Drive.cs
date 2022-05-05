using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public GameObject fule;

    void Start()
    {

    }

    void CalculateDistance()
    {
        Vector3 tankPos = this.transform.position;
        Vector3 fulePos = fule.transform.position;

        float distance = Mathf.Sqrt(Mathf.Pow(tankPos.x - fulePos.x, 2) + Mathf.Pow(tankPos.y - fulePos.y, 2) + Mathf.Pow(tankPos.z - fulePos.z, 2));
        float unityDistance = Vector3.Distance(tankPos, fulePos);
            Debug.Log("Distance: " + distance);
            Debug.Log("Unity Distance: " + unityDistance);
    }
    void CalculateAngle()
    {
        Vector3 tF = this.transform.up;
        Vector3 fD = fule.transform.position - this.transform.position;

        float dot = tF.x * fD.x + tF.y * fD.y,
            angle = Mathf.Acos(dot/(tF.magnitude * fD.magnitude));

        Debug.Log("Angle: " + angle * Mathf.Rad2Deg);
        Debug.Log("Unity Angle: " + Vector3.Angle(tF, fD));

        Debug.DrawRay(this.transform.position, tF * 1000, Color.green, 2);
        Debug.DrawRay(this.transform.position, fD, Color.red, 2);
    }

    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, translation, 0);

        // Rotate around our y-axis
        transform.Rotate(0, 0, -rotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateDistance();
            CalculateAngle();
        }

    }
}