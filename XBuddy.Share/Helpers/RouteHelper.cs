using System.Text;

namespace XBuddy.Share.Helpers;

public static class RouteHelper
{
    public static string AdjustTenantRoute(this string route)
    {
        var totalLenght = Constants.Constants.MultiTenantConstants.TenantId.Length + route.Length + 2;
        var sbRoute = new StringBuilder(totalLenght);
        sbRoute.Append('/');
        sbRoute.AppendFormat("{{{0}}}", Constants.Constants.MultiTenantConstants.TenantId);

        if (!route.StartsWith('/'))
        {
            sbRoute.Append('/');
        }

        sbRoute.Append(route);

        return sbRoute.ToString();
    }
}