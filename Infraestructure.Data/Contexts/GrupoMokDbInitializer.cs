using Domain.Entity.V1;
using System.Collections.Generic;

namespace Infraestructure.Data.Contexts
{


    public static class GrupoMokDbInitializer
    {
        public static void Initialize(ProdContext context)
        {
            //CreatePermissions(context);
            //CreateRoles(context);
            //CreateCompania(context);
            //CreateMenu(context);
        }
   

        private static void CreateRoles(ProdContext context)
        {
            // Create the permissions
            var roles = new List<Role>
            {
                new Role{NameRole ="Invitado",Description="invitado", State = 1 },
                new Role{NameRole ="Administrador",Description="Administrador", State = 1 }
            };
            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }
            context.SaveChanges();
        }
        private static List<Menu> CreateMenu(ProdContext context)
        {
            // Seed the MenuItems
            var menuItems = new List<Menu>
            {
                new Menu
                {
                    
                    Name ="Configuracion General",
                    ParentId = null,
                    Icon = "wrench",
                    Url = null
                },
                new Menu
                {

                    Name = "Seguridad",
                    ParentId = 1,
                    Icon = "user",
                    Url = ""
                },
                new Menu
                {

                    Name = "Usuarios",
                    ParentId = 2,
                    Icon = "lock",
                    Url = "/Seguridad/Usuario"
                },
                new Menu
                {

                    Name = "Roles",
                    ParentId = 2,
                    Icon = "list",
                    Url = "/Seguridad/Roles"
                }
            };

            foreach (var menuItem in menuItems)
            {
                context.Menus.Add(menuItem);
            }
            context.SaveChanges();
            return menuItems;
        }
        private static void CreateCompania(ProdContext context)
        {
            // Create the permissions
            var compania = new Company { CompanyNumber = "99999999999", CompanyName = "Colambo Net", ContactName = "Ruben Maldonado", ContactEmail = "soporte@colambonet.com", ContactPhone = "923184442" };

            context.Companys.Add(compania);

            context.SaveChanges();
        }
        private static void CreatePermissions(ProdContext context)
        {
            // Create the permissions
            var permissions = new List<Permission>
            {
                new Permission {Name = "Crear"},
                new Permission {Name = "Visualizar"},
                new Permission {Name = "Actualizar"},
                new Permission {Name = "Eliminar"},
                new Permission {Name = "Publicar"},
                new Permission {Name = "Subir"}
            };
            foreach (var permission in permissions)
            {
                context.Permissions.Add(permission);
            }
            context.SaveChanges();
        }
        private static void CreateUsers(ProdContext context) {
        
        }
    }
}
