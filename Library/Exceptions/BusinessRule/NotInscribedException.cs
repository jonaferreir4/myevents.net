namespace Library.Exceptions.BusinessRule;
    public class NotInscribedException(long userId, long eventId) :
    BusinessRuleException($"User {userId} is not inscribed in the event {eventId}")
{ }