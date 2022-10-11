namespace Code.Game.Other
{
    public readonly struct CubeSpawnData
    {
        public readonly float SpawnTime;
        public readonly float Speed;
        public readonly float Distance;

        public CubeSpawnData(float spawnTime, float speed, float distance)
        {
            SpawnTime = spawnTime;
            Speed = speed;
            Distance = distance;
        }
    }
}
