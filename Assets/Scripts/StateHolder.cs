
using UnityEngine;
using UnityObservables;

public class StateHolder : MonoBehaviour
{
    
    [System.Serializable]
    public class ObservableState: Observable<State> {}

    public ObservableState movementState = new ObservableState() {  };

    public Observable<bool> shot = new Observable<bool> { Value = false };

    public int direction = 1;
}
