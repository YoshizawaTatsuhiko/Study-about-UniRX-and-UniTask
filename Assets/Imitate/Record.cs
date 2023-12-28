using UnityEngine;

namespace Imitate
{
    public struct Record
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public Record(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}
