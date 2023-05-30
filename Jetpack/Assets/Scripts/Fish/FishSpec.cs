using UnityEngine;

namespace Fish
{
    public class FishSpec
    {
        private readonly FishType _type;
        private readonly Vector2 _location;

        public FishSpec(FishType type, Vector2 location)
        {
            this._type = type;
            this._location = location;
        }

        public FishType getFishType()
        {
            return this._type;
        }

        public Vector2 getLocation()
        {
            return this._location;
        }

    }

}
