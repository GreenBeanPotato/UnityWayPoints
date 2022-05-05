using UnityEngine;

public class Move2 : MonoBehaviour {

    public Transform goal;
    public float speed= 2.0f, accuracy = 0.01f;

    void Start() {

     
    }

    void LateUpdate() {
        Vector3 direction = goal.position - this.transform.position;
        if (direction.magnitude > accuracy)
            this.transform.LookAt(goal.position);
        this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }
}
