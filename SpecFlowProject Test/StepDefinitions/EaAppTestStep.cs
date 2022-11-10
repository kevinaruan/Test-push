namespace SpecFlowProject_Test.StepDefinitions
{
    [Binding]
    public sealed class EaAppTestStep
    {
        private readonly ScenarioContext _scenarioContext;

        public EaAppTestStep(ScenarioContext scenarioContext)
        {
            _scenarioContext= scenarioContext;
        }

        
    }
}