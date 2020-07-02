using UnityEngine;
using UniRx.Toolkit;

namespace HxCx {
    public class SampleObjectPooling : ObjectPool<SampleObject> {

        SampleObject _sampleObject;
        Transform _parent;
       
        public SampleObjectPooling(SampleObject sampleObject, Transform parent)
        {
            _sampleObject = sampleObject;
            _parent = parent;
        }

        protected override SampleObject CreateInstance()
        {
            var instance = GameObject.Instantiate(_sampleObject);

            instance.transform.SetParent(_parent);


            return instance;
        }
    }
}
