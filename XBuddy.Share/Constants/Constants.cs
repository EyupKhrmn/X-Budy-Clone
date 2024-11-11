namespace XBuddy.Share.Constants;

public abstract class Constants
{
    public class CacheKeys
    {
        public const string UserFeed = "user_feed";
    }
    
    public abstract class MultiTenantConstants
    {
        public const string TenantId = "tenantId";
    }
    
    public class CosmosConstants
    {
        public const string CacheDbName = "cache_db";
        public const string FeedCacheContainerName = "feed_cache";
        public const string UserSettings = "user_settings"; 
    }
    
    public class ServiceBusConstants
    {
        public const string PostViewQueueName = "post-view";
    }
    
    public class RouteConstants
    {
        public const string PostViewApi = "PostViewed";
    }
}