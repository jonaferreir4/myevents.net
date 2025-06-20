
namespace Library.Exceptions;

public class BusinessRuleException(string message) :
    Exception(message){ }

public class SpeakerNotAssignedException : BusinessRuleException
{
    public SpeakerNotAssignedException()
        : base("The activity has no speaker assigned") { }
}

public class AttendanceNotConfirmedException : BusinessRuleException
{
    public AttendanceNotConfirmedException()
        : base("The user has not confirmed attendance") { }
}

public class NotInscribedException(long userId, long eventId) :
    BusinessRuleException($"User {userId} is not inscribed in the event {eventId}")
{ }
