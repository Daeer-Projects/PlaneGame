// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BombController.cs" company="DaeerGames">
//   The controller for the bomb.
// </copyright>
// <summary>
//   Defines the BombController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

/// <summary>
/// The bomb controller.
/// </summary>
public class BombController : MonoBehaviour
{
    /// <summary>
    /// The initial position of the bomb when we activate the bomb.
    /// </summary>
    public Vector2 InitialPosition;

    /// <summary>
    /// The initial velocity taken from the plane when we first drop the bomb.
    /// </summary>
    public Vector2 InitialVelocity;

    /// <summary>
    /// The bomb rigid body so we control it.
    /// </summary>
    private Rigidbody2D bombBody;

    /// <summary>
    /// Is the bomb active?  I.e. has it been launched and dropping, or not?
    /// </summary>
    public bool IsActive;

    /// <summary>
    /// The max rotation of the bomb, so it drops nose first and stops there.
    /// </summary>
    private float maxRotation;

    /// <summary>
    /// The default rotation of the bomb.
    /// </summary>
    private float defaultRotation;

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    public void Start()
    {
        this.maxRotation = -90.0f;
        this.defaultRotation = 0.0f;
        this.bombBody = this.GetComponent<Rigidbody2D>();

        this.bombBody.position = new Vector2(this.InitialPosition.x, this.InitialPosition.y);

        var originalCentre = this.bombBody.centerOfMass;
        this.bombBody.centerOfMass = new Vector2(originalCentre.x + 0.3f, originalCentre.y);
        this.bombBody.AddTorque(-0.1f);
        this.bombBody.velocity = this.InitialVelocity;
        this.bombBody.freezeRotation = false;
        //this.IsActive = true;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void FixedUpdate()
    {
        if (this.IsActive)
        {
            if (this.bombBody.rotation < this.maxRotation)
            {
                this.bombBody.rotation = this.maxRotation;
                this.bombBody.freezeRotation = true;
            }
        }
    }

    public bool Destroy()
    {
        this.IsActive = false;

        this.bombBody.position = new Vector2(-50, -50);
        this.bombBody.velocity = new Vector2(0, 0);

        this.bombBody.rotation = this.defaultRotation;
        this.bombBody.freezeRotation = true;

        return true;
    }

    public bool ReStartBomb(Vector2 newPosition, Vector2 newVelocity)
    {
        this.bombBody.position = newPosition;
        this.bombBody.velocity = newVelocity;
        this.bombBody.freezeRotation = false;

        this.IsActive = true;

        return this.IsActive;
    }
}