using UnityEngine;

public class HumanoidAi : MonoBehaviour {

    public Transform Player;
    private Rigidbody rb;

    
    public float distanceLimit = 0.6f;
    public float period = 150f;
    public float forceValue = 80f;

    private Vector3 dy = new Vector3(0.0f, 3f);
    private float t = 0.0f;
    private System.Random random;
    private Transform cachedTransform;
    private AiState aiState = AiState.Respawned;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        random = new System.Random();
        cachedTransform = gameObject.transform;
    }

    void Update()
    {
        switch (aiState)
        {
            case AiState.Respawned:
            {
                JumpUp();
                aiState = AiState.FollowingPlayer;
                break;
            }
            case AiState.FollowingPlayer:
            {
                var directionToPlayer = GetDirectionToPlayer();
                FollowPlayer(directionToPlayer);
                
                if (random.Next(0, 1500) == 1000)
                {
                    aiState = AiState.RandomJump;
                }

                if (cachedTransform.position.y < 0.3f)
                {
                    aiState = AiState.IsFallingDown;
                }
                break;
            }
            case AiState.IsFallingDown:
            {
                JumpUp();
                aiState = AiState.FollowingPlayer;
                break;
            }
            case AiState.RandomJump:
            {
                RandomJump();
                aiState = AiState.FollowingPlayer;
                break;
            }
        }

        t++;
    }

    private Vector3 GetDirectionToPlayer()
    {
        var vectorBetweenCrabAndPlayer = (Player.position + dy) - cachedTransform.position;

        var directionToPlayer = vectorBetweenCrabAndPlayer.normalized;

        var distance = vectorBetweenCrabAndPlayer.magnitude;
        if (distance < distanceLimit)
        {
            directionToPlayer = -1 * directionToPlayer;
        }

        return directionToPlayer;
    }

    private void FollowPlayer(Vector3 directionToPlayer)
    {
        if (t >= period)
        {
            rb.AddForce(directionToPlayer * forceValue);
            t = 0;
        }
    }

    private void JumpUp()
    {
        rb.AddForce(Vector3.up * 30f);
    }

    private void RandomJump()
    {
        var x = random.Next(-10, 10);
        var y = random.Next(-10, 10);
        var dir = (new Vector3(x, y, 0f)).normalized;
        rb.AddForce(dir * 100f);
    }

    enum AiState
    {
        Respawned,
        FollowingPlayer,
        RandomJump,
        IsFallingDown
    }
}
