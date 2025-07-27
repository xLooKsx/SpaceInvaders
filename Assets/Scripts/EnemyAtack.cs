
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{

    public GameObject Bulletprefab;
    public GameObject GameManager;
    public float shootSpawnDistance;

    private float shootCooldown;
    private int chanceToShoot;
    private bool isAllowedToShoot;
    private float timeSinceLastShoot;

    void Start()
    {
        isAllowedToShoot = false;
        shootCooldown = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllowedToShoot)
        {
            CreateBullet();
            isAllowedToShoot = false;
            timeSinceLastShoot = 0;
        }
        CheckIfCanShoot();

    }

    private void CreateBullet()
    {
        Vector2 bulletPosition = new Vector2(this.transform.position.x, shootSpawnDistance);
        GameObject bullet = GameObject.Instantiate(Bulletprefab, bulletPosition, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetIsDownToTop(false);
        bullet.GetComponent<Bullet>().SetOriginIsPlayer(false);
        bullet.GetComponent<Bullet>().SetGameManagerScript(GameManager.GetComponent<GameManager>());
    }

    private void CheckIfCanShoot()
    {
        if (timeSinceLastShoot >= shootCooldown && !isAllowedToShoot)
        {
            chanceToShoot = Random.Range(0, 1000);
            isAllowedToShoot = chanceToShoot == 0;
        }
        else
        {
            timeSinceLastShoot += Time.deltaTime;
        }
    }
}
