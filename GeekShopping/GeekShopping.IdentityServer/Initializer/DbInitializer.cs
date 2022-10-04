using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySqlContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySqlContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _role = role ?? throw new ArgumentNullException(nameof(role));
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null)
                return;

            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            var admin = new ApplicationUser()
            {
                UserName = "lucas-admin",
                Email = "lucas-admin@gmail.com",
                EmailConfirmed = true, //only development
                PhoneNumber = "+55 (12) 12345-6789",
                PhoneNumberConfirmed = true,
                Firstname = "Lucas",
                Lastname = "Admin"
            };

            _user.CreateAsync(admin, "Admin123@").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClains = _user.AddClaimsAsync(admin, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{admin.Firstname} {admin.Lastname}"),
                new Claim(JwtClaimTypes.GivenName, admin.Firstname),
                new Claim(JwtClaimTypes.FamilyName, admin.Lastname),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            var client = new ApplicationUser()
            {
                UserName = "lucas-client",
                Email = "lucas-client@gmail.com",
                EmailConfirmed = true, //only development
                PhoneNumber = "+55 (12) 12345-6789",
                PhoneNumberConfirmed = true,
                Firstname = "Lucas",
                Lastname = "Client"
            };

            _user.CreateAsync(client, "Client123@").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientClains = _user.AddClaimsAsync(client, new Claim[] {
                new Claim(JwtClaimTypes.Name, $"{client.Firstname} {client.Lastname}"),
                new Claim(JwtClaimTypes.GivenName, client.Firstname),
                new Claim(JwtClaimTypes.FamilyName, client.Lastname),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;
        }
    }
}
