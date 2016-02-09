using UnityEngine;

public class StereoCamera : MonoBehaviour {

    
    public Transform leftCam;
    public Transform rightCam;
    public Transform aimPoint;
    public float rayLenght = 100;
    public float eyeDistance = 1;

    private RaycastHit hit;

    void Start ()
    {
        Vector3 eyeOffset = new Vector3(eyeDistance / 2, 0, 0);
        leftCam.transform.localPosition = eyeOffset;
        rightCam.transform.localPosition = -eyeOffset;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, rayLenght))
        {
            aimPoint.position = Vector3.Lerp(aimPoint.position, hit.point, Time.deltaTime * 10);            
        }
        else
        {
            aimPoint.localPosition = Vector3.Lerp(aimPoint.localPosition, Vector3.forward * rayLenght, Time.deltaTime * 10);
        }

        leftCam.LookAt(aimPoint);
        rightCam.LookAt(aimPoint);

        //Debug
        Debug.DrawRay(ray.origin, ray.direction * rayLenght);
        Debug.DrawRay(leftCam.transform.position, leftCam.transform.forward * rayLenght,Color.red);
        Debug.DrawRay(rightCam.transform.position, rightCam.transform.forward * rayLenght, Color.green);
    }
}
