using GraphQL.Execution;
using GraphQL.Language.AST;

namespace GraphQl.Demo.DocumentExecuter
{
    /// <summary>
    /// Add support for executing GraphQL subscriptions, which is disabled by default
    /// </summary>
    public class DocumentExecuterWithSubscriptions : GraphQL.DocumentExecuter
    {
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
