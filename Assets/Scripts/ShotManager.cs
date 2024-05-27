using UnityEngine;

public class ShotManager : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float bulletSpeed;

    private StateHolder _stateHolder;

    private void Awake()
    {
        _stateHolder = GetComponent<StateHolder>();
    }

    public void Shoot()
    {
        var obj = Instantiate(bullet, shotPoint.position, Quaternion.identity);
        var rigidbody = obj.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(bulletSpeed * _stateHolder.direction, shotPoint.position.y);
    }
}
