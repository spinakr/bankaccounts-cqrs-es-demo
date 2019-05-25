using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BankAccounts.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccounts.Utils
{
    public static class HandlerRegistration
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            List<Type> handlerTypes = typeof(AccountsOverviewQueryHandler).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(y => IsHandlerInterface(y)))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (Type type in handlerTypes)
            {
                Type interfaceType = type.GetInterfaces().Single(y => IsHandlerInterface(y));
                services.AddTransient(interfaceType, type);
            }
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;

            Type typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
        }
    }
}