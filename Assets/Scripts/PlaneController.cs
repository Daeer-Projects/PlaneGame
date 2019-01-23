// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlaneController.cs" company="DaeerGames">
//   The controller for the plane.
// </copyright>
// <summary>
//   Defines the PlaneController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

/// <summary>
/// The plane controller.
/// </summary>
public class PlaneController : MonoBehaviour
{
    /// <summary>
    /// The speed used for the movement.
    /// </summary>
    public float Speed;

    /// <summary>
    /// The movement of the plane as it travels to the right of the screen.
    /// </summary>
    public float Movement;

    /// <summary>
    /// The force that take the plane down to the ground.
    /// </summary>
    public float Gravity;

    /// <summary>
    /// The plane rigid body used for collisions.
    /// </summary>
    private Rigidbody2D planeBody;

    /// <summary>
    /// Has the plane landed on the runway?
    /// </summary>
    private bool hasLanded;

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    public void Start()
    {
        this.planeBody = this.GetComponent<Rigidbody2D>();
        this.hasLanded = false;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void FixedUpdate()
    {
        if (!this.hasLanded)
        {
            var movement = new Vector2(this.Movement, this.Gravity);
            this.planeBody.AddForce(movement * this.Speed);
        }
        else
        {

            var currentVelocity = this.planeBody.velocity;
            var breaks = new Vector2(currentVelocity.x - 0.1f, 0.0f);
            this.planeBody.velocity = breaks;
            this.planeBody.angularVelocity = 0.0f;

            if (currentVelocity.x <= 0.0f)
            {
                this.planeBody.velocity = Vector2.zero;
                this.planeBody.angularVelocity = 0.0f;
            }
        }
    }

    /// <summary>
    /// Detects if the plane has hit the wall, building, or landed.
    /// </summary>
    /// <param name="other">The other objects that the plane could hit.</param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            var currentYPosition = this.planeBody.position.y;
            var newPosition = new Vector2(-3.7f, currentYPosition);
            this.planeBody.MovePosition(newPosition);
        }
        else if (other.gameObject.CompareTag("Road"))
        {
            this.hasLanded = true;
        }
    }
}