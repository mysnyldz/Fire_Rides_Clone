using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace UnityTemplateProjects.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onPlay = delegate {  };
        public UnityAction onReset = delegate {  };
        public UnityAction onSetCameraTarget = delegate {  };
    }
}