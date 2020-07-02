using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;

namespace HxCx {
    public class SampleObject : MonoBehaviour {

        [SerializeField]
        float _lifeTime = 1.0f;

        public void Start()
        {
            this.UpdateAsObservable().Subscribe(_ => {
                transform.RotateAround(Vector3.zero, Vector3.up, 30 * Time.deltaTime);
            }).AddTo(this);
        }

        public IObservable<Unit> Spawn(Vector3 pos)
        {
            transform.position = pos;
            
            return Observable.Timer(TimeSpan.FromSeconds(_lifeTime))
                .ForEachAsync(_ => Debug.Log("Destroy"));
        }
    }
}
