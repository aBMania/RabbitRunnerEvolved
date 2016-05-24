using Application.Model.Terrain.TerrainSegments;

namespace Application.Model.Terrain.TerrainGenerator
{
    public interface ITerrainGenerator
    {
        TerrainSegment GenerateNextTerrainSegment();
    }
}