using Unity.Entities;
public struct Spawner : IComponentData
{
    public Entity prefab;

    public int erows;
    public int ecols;
}
