
namespace Library.Exceptions.BusinessRule;
    public class SpeakerNotAssignedException: BusinessRuleException
    {
         public SpeakerNotAssignedException()
        : base("The activity has no speaker assigned") { }
    }
