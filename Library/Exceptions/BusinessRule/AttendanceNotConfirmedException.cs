namespace Library.Exceptions.BusinessRule;

public class AttendanceNotConfirmedException : BusinessRuleException
{
    public AttendanceNotConfirmedException()
        : base("The user has not confirmed attendance") { }
}
