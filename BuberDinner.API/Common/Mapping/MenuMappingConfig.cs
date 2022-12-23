using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.MenuAggregate;
using Contracts.Authentication;
using Contracts.Menu;
using Mapster;
using MenuSection = BuberDinner.Domain.Menu.Entities.MenuSection;

namespace BuberDinner.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value))
            .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : (double?) null);
        
        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

    }
}