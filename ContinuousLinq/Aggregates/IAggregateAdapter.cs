using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContinuousLinq.Aggregates
{
    public interface IAggregateAdapter
    {
        void Pause();
        void Resume();
        bool IsPaused { get; }
    }
}
