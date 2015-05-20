using System.Activities;
using System.Activities.Expressions;
using Microsoft.Activities;

namespace DynamicValueEval
{
    /// <summary>
    ///     Activity used to evaluate a path on a given instance of a DynamicValue
    /// </summary>
    public class EvaluateDynamicValuePath : Activity<DynamicValue>
    {
        public EvaluateDynamicValuePath()
        {
            Implementation = () => new GetDynamicValueProperty<DynamicValue>
            {
                Source       = new ArgumentValue<DynamicValue>("Input"),
                PropertyName = new ArgumentValue<string>("Path"),
                Result       = new ArgumentReference<DynamicValue>("Result")
            };
        }

        [RequiredArgument]
        public InArgument<DynamicValue> Input { get; set; }

        [RequiredArgument]
        public InArgument<string> Path { get; set; }
    }
}