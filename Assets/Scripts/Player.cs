using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    
    public float thrustForce = 100f;
    public float rotatioSpeed = 120f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;

    public static int SCORE = 0;
    public static float xBorderLimit, yBorderLimit;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();

        yBorderLimit = Camera.main.orthographicSize+1;
        xBorderLimit = (Camera.main.orthographicSize+1) * Screen.width / Screen.height;
    }
    private void UpdateSOS(){
        float rotation = Input.GetAxis("Horizontal")*Time.deltaTime;;
        float thrust= Input.GetAxis("Vertical")*Time.deltaTime;
        Vector3 thrustDirection= transform.right;
     transform.Rotate(Vector3.forward,-rotation*rotatioSpeed);
        _rigid.AddForce(thrustDirection*thrust*thrustForce);
}
    // Update is called once per frame
    void Update()
    {
        if(!Pausa.estaPausado)
        {

       var newPos = transform.position;
        if(newPos.x> xBorderLimit)
        newPos.x=-xBorderLimit+1;
        else if(newPos.x<-xBorderLimit)
        newPos.x=xBorderLimit-1;
        else if(newPos.y> yBorderLimit) 
        newPos.y=-yBorderLimit+1;
        else if(newPos.y<-yBorderLimit) 
        newPos.y=yBorderLimit;
        transform.position=newPos;
        UpdateSOS();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;

            // Ignorar la colisión entre el jugador y la bala
            Collider bulletCollider = bullet.GetComponent<Collider>();
            Collider playerCollider = GetComponent<Collider>();
            Physics.IgnoreCollision(bulletCollider, playerCollider);
        
        }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.tag == "Enemy")
        {
            SCORE = 0;
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Destroy(collision.gameObject);
            Debug.Log("He colisionado con otra cosa...");
        }

    }
}
