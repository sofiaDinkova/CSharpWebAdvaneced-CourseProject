namespace Blasco.Web.Infrastructure.Extentions
{
    using System.Security.Claims;

    using static Common.GeneralApplicationConstants;

    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin (this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }

        public static bool IsCustomer (this ClaimsPrincipal user)
        {
            return user.IsInRole(CustomerRoleName);
        }

        public static bool IsCreator (this ClaimsPrincipal user)
        {
            return user.IsInRole(CreatorRoleName);
        }
    }
}
