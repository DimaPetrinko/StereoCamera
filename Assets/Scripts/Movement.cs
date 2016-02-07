using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Transform cam;
    public float movementSpeed;
    public float rotaionSpeed;

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Movement
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * movementSpeed * Time.deltaTime);
        cam.Rotate(Vector3.right * -Input.GetAxis("Mouse Y") * rotaionSpeed * Time.deltaTime);
        transform.Rotate(transform.up * Input.GetAxis("Mouse X") * rotaionSpeed * Time.deltaTime);
        Debug.DrawRay(transform.position, transform.right);
        //transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.AngleAxis(Input.GetAxis("Mouse Y"), Vector3.right), Time.deltaTime * 10);
        
    }
}
