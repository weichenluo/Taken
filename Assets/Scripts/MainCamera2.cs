using UnityEngine;

public class MainCamera2 : MonoBehaviour {
    public Transform player;
    private Vector3 offset = new Vector3(1f, 1f, 1f);
    private float speed = 1f;

    public float distance = 10.0f;
    public float height = 5.0f;
    public float viewHeightRatio = 0.5f;      

    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    public bool followVelocity = true;
    public float velocityDamping = 5.0f;

    private Vector3 smoothLastPos = Vector3.zero;
    private Vector3 smoothVelocity = Vector3.zero;
    private float smoothTargetAngle = 0.0f;
    private Vector3 updatedVelocity;
    private float time;
    private float f_lastTime;

    void start(){
        f_lastTime = Time.realtimeSinceStartup;
    }


    private void Update()

    {
        float f_deltaTime = Time.realtimeSinceStartup - f_lastTime;
        f_lastTime = Time.realtimeSinceStartup;
        time = f_deltaTime;
        // Vector3 temp = player.position - offset;
        // Vector3 temp2 = Vector3.Lerp(transform.position, temp, speed);
        // if(Time.deltaTime == 0){
        //     updatedVelocity = (player.position + offset - smoothLastPos) / (Time.deltaTime+0.1f);
        // }else{
        //     Debug.Log(player.position);
            updatedVelocity = (player.position + offset - smoothLastPos) / time;
        // // }
        
        smoothLastPos = player.position + offset;

        updatedVelocity.y = 0.0f;

        if(updatedVelocity.magnitude > 1.0f){
            smoothVelocity = Vector3.Lerp(smoothVelocity,updatedVelocity,velocityDamping*time);
            smoothTargetAngle = Mathf.Atan2(smoothVelocity.x,smoothVelocity.z)*Mathf.Rad2Deg;
        }

        if(!followVelocity){
            smoothTargetAngle = player.eulerAngles.y;
        }

        float wantedHeight = player.position.y + offset.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, smoothTargetAngle, rotationDamping*time);
        currentHeight = Mathf.Lerp(currentHeight,wantedHeight, speed);

        Quaternion currentRotation = Quaternion.Euler(0,currentRotationAngle,0);

        transform.position = player.position + offset;
        transform.position -= currentRotation * Vector3.forward * distance;

        Vector3 t = transform.position;
        t.y = currentHeight;
        transform.position = t;
        

        // transform.position = temp2;

        transform.LookAt(player.position+offset+Vector3.up*height*viewHeightRatio);

    }
}
