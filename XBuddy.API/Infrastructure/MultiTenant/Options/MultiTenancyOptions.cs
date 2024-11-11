namespace XBuddy.API.Infrastructure.MultiTenant.Options;

public class MultiTenancyOptions
{
    internal bool InternalUseCookieResolver { get; private set; }
    internal bool InternalUseHeaderResolver { get; private set; }
    internal bool InternalUseQueryResolver { get; private set; }
    internal bool InternalUseRouteResolver { get; private set; }

    public MultiTenancyOptions UseCookieResolver()
    {
        InternalUseCookieResolver = true;
        return this;
    }

    public MultiTenancyOptions UseQueryResolver()
    {
        InternalUseQueryResolver = true;
        return this;
    }

    public MultiTenancyOptions UseHeaderResolver()
    {
        InternalUseHeaderResolver = true;
        return this;
    }

    public MultiTenancyOptions UseRouteResolver()
    {
        InternalUseRouteResolver = true;
        return this;
    }

    public bool AtLeastOneActive => InternalUseCookieResolver
                                   | InternalUseHeaderResolver
                                   | InternalUseQueryResolver
                                   | InternalUseRouteResolver;
}