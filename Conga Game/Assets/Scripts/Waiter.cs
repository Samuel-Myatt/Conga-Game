using UnityEngine;

/// <summary>
/// Handles the movement and collision of an asteroid.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Waiter : MonoBehaviour
{
    /// <summary>
    /// An array of sprites of which one is randomly assigned to the asteroid.
    /// </summary>
    [Tooltip("An array of sprites of which one is randomly assigned to the asteroid.")]
    public Sprite[] sprites;

    /// <summary>
    /// The current assigned size of the asteroid.
    /// </summary>
    [HideInInspector]
    public float size = 1.0f;

    /// <summary>
    /// The minimum size that can be assigned to the asteroid.
    /// </summary>
    [Tooltip("The minimum size that can be assigned to the asteroid.")]
    public float minSize = 0.35f;

    /// <summary>
    /// The maximum size that can be assigned to the asteroid.
    /// </summary>
    [Tooltip("The maximum size that can be assigned to the asteroid.")]
    public float maxSize = 1.65f;

    /// <summary>
    /// How quickly the asteroid moves along its trajectory.
    /// </summary>
    [Tooltip("How quickly the asteroid moves along its trajectory.")]
    public float movementSpeed = 50.0f;

    /// <summary>
    /// The maximum amount of time the asteroid can stay alive after which it is
    /// destroyed.
    /// </summary>
    [Tooltip("The maximum amount of time the asteroid can stay alive after which it is destroyed.")]
    public float maxLifetime = 30.0f;

    /// <summary>
    /// The sprite renderer component attached to the asteroid.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// The rigidbody component attached to the asteroid.
    /// </summary>
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        // Store references to the asteroid's components
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Assign a random sprite to the asteroid
        _spriteRenderer.sprite = this.sprites[Random.Range(0, this.sprites.Length)];

        // Assign a random rotation to the asteroid
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

        // Set the scale and mass of the asteroid based on the assigned size
        this.transform.localScale = Vector3.one * this.size;
        _rigidbody.mass = this.size;

        // Destroy the asteroid after it reaches its max lifetime
        Destroy(this.gameObject, this.maxLifetime);
    }

    public void SetTrajectory(Vector2 direction)
    {
        // Move the asteroid along the trajectory factoring in its speed
        _rigidbody.AddForce(direction * this.movementSpeed);
    }





}