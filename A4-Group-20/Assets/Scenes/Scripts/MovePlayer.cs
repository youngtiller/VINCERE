using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float horizontalInput;

    [SerializeField]
    private float movespeed = 5f;
    [SerializeField]
    private float gravity = 10f;
    [SerializeField]
    private float jumpSpeed = 4f;
    private CharacterController cc;

    private float directionY;

    public GameObject startLevel;
    private Vector3 startLevelPos;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        startLevelPos = startLevel.transform.position;
        transform.position = startLevelPos;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput *= -1;
        float verticalInput = Input.GetAxis("Vertical");
        verticalInput *= -1;
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        if(Input.GetButtonDown("Jump")){
            directionY = jumpSpeed;
        }
        directionY -= gravity * Time.deltaTime;
        direction.y = directionY;
        cc.transform.Rotate(Vector3.up * horizontalInput * (100f * Time.deltaTime));
        cc.Move(direction * movespeed * Time.deltaTime);

        
    }

    //private void FixedUpdate(){
       // cc.transform.Rotate(Vector3.up * horizontalInput * (100f * Time.deltaTime));
    //}
}
