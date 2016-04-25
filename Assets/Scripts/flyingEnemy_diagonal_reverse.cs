using UnityEngine;
using System.Collections;

public class flyingEnemy_diagonal_reverse : MonoBehaviour
{
    public static float enemy_flySpeed;
    private Transform thisTransform;
    private float moveDirX;
    private float moveDirY;
    private Vector3 movementnew;
	private Vector3 enemyPos;

    void Awake()
    {
        thisTransform = transform;
    }

    void Start()
    {
        moveDirX = -1.9f;
        moveDirY = 1;
        enemy_flySpeed = 0.5f;
		enemyPos = thisTransform.position;
    }

    void Update()
    {
        movementnew = new Vector3(moveDirX, moveDirY, 0f) * Time.deltaTime * enemy_flySpeed;
        thisTransform.Translate(movementnew.x, movementnew.y, 0f);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "player")
        {
            Player.alive = false;
        }
		if (xa.levelNumber == 3) {
			if (other.gameObject.name == "SuperMan") {
				gameObject.SetActive (false);
				Invoke ("activateEnemy", 5);
			}
		}

        if (other.gameObject.CompareTag("Diagonal_Collider"))
        {
            moveDirX *= -1;
            moveDirY *= -1;
        }
    }

	void activateEnemy()
	{
		this.transform.position = new Vector3(enemyPos.x, enemyPos.y, enemyPos.z);
		gameObject.SetActive (true);
	}

}
