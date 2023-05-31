using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fish
{
    public class FishPatterns
    {
        public class FishPattern
        {
            private readonly int _fishCount;
            private readonly Vector3 _locationOffset;

            public FishPattern(int fishCount, float xDifference, float yDifference)
            {
                this._fishCount = fishCount;
                this._locationOffset = new Vector3(xDifference, yDifference, 0);
            }

            public int GetFishCount()
            {
                return this._fishCount;
            }

            public Vector3 GetLocationOffset()
            {
                return this._locationOffset;
            }
        }

        private readonly List<FishPattern> _fishPatterns;

        public FishPatterns()
        {
            this._fishPatterns = new List<FishPattern>();
            this._fishPatterns.Add(new FishPattern(5, 1, 0));
        }

        public List<FishPattern> GetPatterns()
        {
            return this._fishPatterns;
        }
    }
}
