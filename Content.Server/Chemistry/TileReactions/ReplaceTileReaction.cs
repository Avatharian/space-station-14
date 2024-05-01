using Content.Server.Maps;
using Content.Shared.Chemistry.Reaction;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.FixedPoint;
using Content.Shared.Maps;
using JetBrains.Annotations;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Chemistry.TileReactions;

[UsedImplicitly]
[DataDefinition]
public sealed partial class ReplaceTileReaction: ITileReaction
{

    [DataField(required: true)]
    public ProtoId<ContentTileDefinition> Floor { get; set; } = default!;

    [DataField]
    public FixedPoint2 Usage = FixedPoint2.New(5);

    public FixedPoint2 TileReact(TileRef tile, ReagentPrototype reagent, FixedPoint2 reactVolume)
    {
        TileSystem tilesys = IoCManager.Resolve<IEntityManager>().System<TileSystem>();
        ITileDefinitionManager tiledef = IoCManager.Resolve<ITileDefinitionManager>();
        var replacementTile = (ContentTileDefinition) tiledef[Floor];
        if (reactVolume < Usage) // TODO: Make sure that reagent effect can't turn a tile into the same exact kind of tile to avoid undesired effect stacking
        {
            return FixedPoint2.Zero;
        }
        tilesys.ReplaceTile(tile, replacementTile);
        return Usage;
    }
}
