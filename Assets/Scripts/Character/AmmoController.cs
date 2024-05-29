using UnityEngine;

public class AmmoController : MonoBehaviour
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

        _stateHolder.ammoCount.SetValue(_stateHolder.ammoCount.Value - 1);
    }

    public void OnRechargeCompleted()
    {
        _stateHolder.ammoCount.SetValue(StateHolder.MAX_AMMO);
        _stateHolder.onRechargeCompleted?.Invoke();
    }
}
