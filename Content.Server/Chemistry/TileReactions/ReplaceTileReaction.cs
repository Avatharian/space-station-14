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
public sealed partial class ReplaceTileReaction
{

    [DataField(required: true)]
    public ProtoId<ContentTileDefinition> Floor { get; set; } = default!;

    public FixedPoint2 TileReact(TileRef tile, ReagentPrototype reagent, FixedPoint2 reactVolume)
    {
        TileSystem tilesys = IoCManager.Resolve<IEntityManager>().System<TileSystem>();
        ITileDefinitionManager tiledef = IoCManager.Resolve<ITileDefinitionManager>();
        var replacementTile = (ContentTileDefinition) tiledef[Floor];
        tilesys.ReplaceTile(tile, replacementTile);
        return reactVolume;
    }
}
