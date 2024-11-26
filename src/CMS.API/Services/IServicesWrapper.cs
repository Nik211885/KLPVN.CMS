namespace CMS.API.Services;

public interface IServicesWrapper
{
  AuAction.IServices AuAction  { get; }
  AuClass.IServices AuClass { get; }
  Content.IServices Content { get; }
  FeedBack.IServices FeedBack { get; }
  InformationOrganization.IServices InformationOrganization { get; }
  Permission.IServices Permission { get; }
  Role.IServices Role { get; }
  sample.IServices Sample { get; }
  Subject.IServices Subject { get; }
  User.IServices User { get; }
}
