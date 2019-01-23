using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Plane;

    private PlaneController planeController;

    public GameObject Bomb;

    private BombController bombController;


    // Use this for initialization
    private void Start()
    {
        //this.Plane = GameObject.FindGameObjectWithTag("Player");
        //this.Bomb = GameObject.FindGameObjectWithTag("Bomb");

        this.Plane.SetActive(true);
        this.planeController = this.Plane.GetComponent<PlaneController>();
        this.planeController.Start();
        //this.Bomb.SetActive(true);

        //this.bombController = this.Bomb.GetComponent<BombController>();
        //this.bombController.InitialPosition = new Vector2(-1000, -1000);
        //this.bombController.InitialVelocity = new Vector2(0, 0);
        //this.bombController.Destroy();

        //
        //var planeBody = this.Plane.GetComponent<Rigidbody2D>();

        //var newBombPosition = new Vector2(planeBody.position.x + 5, planeBody.position.y - 10);
        //var newBombVelocity = planeBody.velocity;

        //this.bombController.ReStartBomb(newBombPosition, newBombVelocity);
        //this.bombController.InitialPosition = newBombPosition;
        //this.bombController.InitialVelocity = newBombVelocity;
        //this.bombController.Start();
    }

    // Update is called once per frame
    private void Update()
    {

    }
}