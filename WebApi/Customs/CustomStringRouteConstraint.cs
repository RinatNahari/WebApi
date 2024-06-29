namespace WebApi.Customs
{
    public class CustomStringRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, 
                          RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var routeValue) && routeValue is string)
                return true;
            return false;
        }
    }
}