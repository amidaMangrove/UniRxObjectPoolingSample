using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

namespace HxCx {
    public class GameController : MonoBehaviour {

        [SerializeField]
        SampleObject _poolObject;

        [SerializeField]
        Transform _parent;

        [SerializeField]
        Button _createButton;

        SampleObjectPooling _sampleObjectPooling;

        Vector3 _spawnPositon;

        void Start()
        {
            _sampleObjectPooling = new SampleObjectPooling(_poolObject, _parent);

            this.OnDestroyAsObservable().Subscribe(_ => _sampleObjectPooling.Dispose());
            _createButton.OnClickAsObservable().Subscribe(_ =>
            {
                var sampleObject = _sampleObjectPooling.Rent();
                _spawnPositon.x = Random.Range(-5f, 5f);
                _spawnPositon.y = Random.Range(-5f, 5f);
                _spawnPositon.z = Random.Range(-5f, 5f);

                sampleObject.Spawn(_spawnPositon).Subscribe(__ =>
                {
                    _sampleObjectPooling.Return(sampleObject);
                });
            }).AddTo(this);
        }
    }
}
