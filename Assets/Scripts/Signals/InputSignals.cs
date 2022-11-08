using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction onInputReleased = delegate {  };
        public UnityAction onInputTaken = delegate {  };
        public UnityAction onDrawLine = delegate {  };
        
    }
}