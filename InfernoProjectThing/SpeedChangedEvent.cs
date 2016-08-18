using System;

namespace InfernoProjectThing
{
    public class SpeedChangedEvent : EventArgs
    {
        public double speed;

        public SpeedChangedEvent(double speed)
        {
            this.speed = speed;
        }
    }
}