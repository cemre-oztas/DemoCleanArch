using Abp.Application.Services;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace CleanArch.Infrastructure.Services.Configurations;

public class ApplicationService : IApplicationService
{
    public List<MenuEntity> GetAuthorizeDefinitionEndpoints(Type type)
    {
        Assembly assembly = Assembly.GetAssembly(type);
        var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));

        List<MenuEntity> menus = new();
        if (controllers != null)
            foreach (var controller in controllers)
            {
                    {
                    if (attributes != null)
                        {
                        MenuEntity menu = null;

                            var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;
                            if (!menus.Any(m => m.Name == authorizeDefinitionAttribute.Menu))
                            {
                                menu = new() { Name = authorizeDefinitionAttribute.Menu };
                                menus.Add(menu);
                            }
                            else
                                menu = menus.FirstOrDefault(m => m.Name == authorizeDefinitionAttribute.Menu);

                            Application.DTOs.Configuration.Action _action = new()
                            {
                                ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType),
                                Definition = authorizeDefinitionAttribute.Definition
                            };

                            _action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Definition.Replace(" ", "")}";

                            menu.Actions.Add(_action);
                        }
                    }
            }

        return menus;
    }
}
