using System;
using System.Threading.Tasks;
using GraphQL.Execution;
using GraphQL.Language.AST;

namespace GraphQL.Demo.DocumentExecuter
{
    /// <summary>
    /// Add support for executing GraphQL subscriptions, which is disabled by default
    /// </summary>
    public class DocumentExecuterWithSubscriptions : GraphQL.DocumentExecuter
    {
        /// <summary>
        /// Includes the SubscriptionExecutionStrategy when executing documents
        /// </summary>
        protected override IExecutionStrategy SelectExecutionStrategy(ExecutionContext context)
        {
            return context.Operation.OperationType switch
            {
                OperationType.Subscription => SubscriptionExecutionStrategy.Instance,
                _ => base.SelectExecutionStrategy(context)
            };
        }
    }
}
